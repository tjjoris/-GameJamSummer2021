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
            //if (PlayerPrefsController.GetFirstTimeMusic())
            if (true)
            {
                musicSource.volume = 0.3f;
                PlayerPrefsController.SetMasterMusicVolume(0.3f);
            }
            // else
            // {
            //     musicSource.volume = PlayerPrefsController.GetMasteMusicVolume();
            // }
        }

    }
}
