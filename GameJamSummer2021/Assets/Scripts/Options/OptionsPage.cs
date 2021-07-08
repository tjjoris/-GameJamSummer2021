//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//namespace FreeEscape.Options
//{
//    public class OptionsPage : MonoBehaviour
//    {
//        // Start is called before the first frame update
//        void Start()
//        {
//            //VolumeSliderScript volumeSlierScript = FindObjectOfType<VolumeSliderScript>();
//            //Slider volumeSlider = volumeSlierScript.GetComponent<Slider>();
            

//            //float startVolume = PlayerPrefsController.GetMasterVolume();
//            //if (PlayerPrefsController.GetFirstTime())
//            //{
//            //    Debug.Log("set sfx volume to default");
//            //    startVolume = 1f;
//            //    PlayerPrefsController.SetMasterVolume(startVolume);
//            //}
//            ////volumeSlider.value = startVolume;
//            ////volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(volumeSlider.value); });

//            StartMusicSlider();

//            gameObject.SetActive(false);
//        }
//        private void StartMusicSlider()
//        {
//            MusicSliderScript musicSliderScript = FindObjectOfType<MusicSliderScript>();
//            Slider musicSlider = GetComponent<Slider>();
//            GameObject persistentGO = GameObject.FindWithTag("PersistentGO");
//            AudioSource musicAudioSource = null;
//            if (persistentGO != null)
//            {
//                musicAudioSource = persistentGO.GetComponent<AudioSource>();
//            }

//            float startVolume = PlayerPrefsController.GetMasteMusicVolume();
//            if (PlayerPrefsController.GetFirstTimeMusic())
//            {
//                Debug.Log("set music to default");
//                startVolume = 1f;

//                //musicSliderScript.ValueChangeCheck(startVolume);

//            }
//            musicAudioSource.volume = startVolume;
//            //if (musicSlider != null)
//            //{
//            //    musicSlider.value = startVolume;
//            //    if (musicAudioSource != null)
//            //    {
//            //        musicAudioSource.volume = startVolume;
//            //    }
//            //}
//            //musicSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(slider.value); });
//        }
//    }
//}
