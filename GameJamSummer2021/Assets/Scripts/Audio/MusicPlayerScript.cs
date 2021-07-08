using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Options;

namespace FreeEscape.Audio
{
    public class MusicPlayerScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            AudioSource musicSource = GetComponent<AudioSource>();
            if (PlayerPrefsController.GetFirstTimeMusic())
            {
                musicSource.volume = 1f;
                PlayerPrefsController.SetMasterMusicVolume(1f);
            }
            else
            {
                musicSource.volume = PlayerPrefsController.GetMasteMusicVolume();
            }
        }

    }
}
