using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Options;

namespace FreeEscape.Audio
{
    public class EndSceneMusic : MonoBehaviour
    {
        private AudioSource winTheme;
        private AudioSource musicAudioSource;
        private void Start()
        {
            
            winTheme = GetComponent<AudioSource>();
            winTheme.volume = PlayerPrefsController.GetMasteMusicVolume();
            GameObject persistentGO = GameObject.FindWithTag("PersistentGO");
            musicAudioSource = persistentGO.GetComponent<AudioSource>();
            musicAudioSource.Stop();
        }

    }
}
