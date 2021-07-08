using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeEscape.Options
{
    public class MusicSliderScript : MonoBehaviour
    {
        private Slider slider;
        private AudioSource musicAudioSource;
        // Start is called before the first frame update
        void Start()
        {
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
                    startVolume = 1f;
                ValueChangeCheck(startVolume);

                }
                slider.value = startVolume;
            if (musicAudioSource != null)
            {
                musicAudioSource.volume = startVolume;
            }
            slider.onValueChanged.AddListener(delegate { ValueChangeCheck(slider.value); });
        }

        public void ValueChangeCheck(float volume)
        {
            PlayerPrefsController.SetMasterMusicVolume(volume);
            musicAudioSource.volume = volume;
        }
    }
}
