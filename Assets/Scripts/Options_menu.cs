using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options_menu : MonoBehaviour
{
  
  public AudioMixer audioMixer;

  public void setVolume (float volume)
   {
     audioMixer.SetFloat("volume", volume);
   }

   public void SetFullscreen (bool isFullscreen)
   {
       Screen.fullScreen = isFullscreen;
   }

}
