using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FreeEscape.UI;

namespace FreeEscape.Options
{
    public class MusicSliderScript : MonoBehaviour
    {
        private Slider slider;
        private AudioSource musicAudioSource;
        private AudioSource titleThemeAudioSource;
        // Start is called before the first frame update
        void Start()
        {
            MainMenu mainMenu = FindObjectOfType<MainMenu>();
            if (mainMenu != null)
            {
                titleThemeAudioSource = mainMenu.GetComponent<AudioSource>();
            }
            slider = GetComponent<Slider>();
            //slider.value = PlayerPrefsController.
            GameObject persistentGO = GameObject.FindWithTag("PersistentGO");
            //Debug.Log(persistentGO.name);
            if (persistentGO != null)
            {
                musicAudioSource = persistentGO.GetComponent<AudioSource>();
            }
            
                float startVolume = PlayerPrefsController.GetMasteMusicVolume();
                if (PlayerPrefsController.GetFirstTimeMusic())
                {
                Debug.Log("set music to default");
                    startVolume = 0.3f;
                ValueChangeCheck(startVolume);

                }
                slider.value = startVolume;
            if (musicAudioSource != null)
            {
                
                SetMusicVolume(startVolume);
            }
            slider.onValueChanged.AddListener(delegate { ValueChangeCheck(slider.value); });
        }

        public void ValueChangeCheck(float volume)
        {
            PlayerPrefsController.SetMasterMusicVolume(volume);
            SetMusicVolume(volume);
        }
        private void SetMusicVolume(float volume)
        {
            musicAudioSource.volume = volume;
            if (titleThemeAudioSource != null)
            {
                titleThemeAudioSource.volume = volume;
            }
        }
    }
}
