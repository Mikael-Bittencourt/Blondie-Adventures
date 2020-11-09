using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

public float speed;
public float jumpForce;
private float moveInput;

private Rigidbody2D rb;

private bool facingRight = true;

private bool isGrounded;
public Transform groundCheck;
public float checkRadius;
public LayerMask whatIsGrounded;

private int extraJumps;
public int extraJumpsValue;

public Animator transition;
private Animator animator;

    public float transitionTime = 1f;

    public ParticleSystem dust;


void Start()
{
    extraJumps = extraJumpsValue;
    rb = GetComponent<Rigidbody2D>();
     FindObjectOfType<AudioManager>().Play("Menu");
}

void FixedUpdate()
{

    isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);
     
      moveInput = Input.GetAxis("Horizontal");
     rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
     if(facingRight == false && moveInput > 0)
     {
        Flip();
     }else if(facingRight == true && moveInput < 0)
     {
         Flip();
     }
}

void Update()
{

    if(isGrounded == true)
    {
       extraJumps = extraJumpsValue;
    }
    
    if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
    {
        CreateDust();
       rb.velocity = Vector2.up * jumpForce;
       extraJumps--;
    }else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
    {
        rb.velocity = Vector2.up * jumpForce;
    }

}

void Flip()
{
    CreateDust();
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;
}

public void OnTriggerEnter2D (Collider2D other)
   {
     if(other.CompareTag("End"))
     {
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
         LoadNextLevel();
     }

     if(other.CompareTag("Death"))
     {
        Destroy(gameObject);
     }

    if(other.CompareTag("Death 2"))
     {
        Destroy(gameObject);
     }

     if(other.CompareTag("Coin"))
     {
        ScoreText.scoreValue += 10;
        
        FindObjectOfType<AudioManager>().Play("coin");

         Destroy(other.gameObject);
     }

     if(other.CompareTag("Torch"))
     {
        Destroy(gameObject);
     }  
     
     if(other.CompareTag("Ghost"))
     {
        Destroy(gameObject);
     }

     if(other.CompareTag("CampFire"))
     {
        transform.position = new Vector3 (10,57,0);
     }

    }

   public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
       transition.SetTrigger("Start");

       yield return new WaitForSeconds(transitionTime);

       SceneManager.LoadScene(levelIndex);

    }

    void CreateDust()
    {
        dust.Play();
    }

}
