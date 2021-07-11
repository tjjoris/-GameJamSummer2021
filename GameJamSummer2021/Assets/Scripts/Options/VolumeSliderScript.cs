using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeEscape.Options
{
    public class VolumeSliderScript : MonoBehaviour
    {
        private Slider slider;
        private AudioSource audioSource;
        private bool isPlayingSample;
        
        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponent<Slider>();
            audioSource = GetComponent<AudioSource>();
            
            float startVolume = PlayerPrefsController.GetMasterVolume();
            if (PlayerPrefsController.GetFirstTime())
            {
                Debug.Log("set sfx volume to default");
                startVolume = 0.2f;
                PlayerPrefsController.SetMasterVolume(startVolume);
            }
            slider.value = startVolume;
            audioSource.volume = startVolume;
            slider.onValueChanged.AddListener(delegate { ValueChangeCheck(slider.value); });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private void ValueChangeCheck(float value)
        {
            
            PlayerPrefsController.SetMasterVolume(value);
            audioSource.volume = value;
            StartCoroutine(PlaySample());
        }
        IEnumerator PlaySample()
        {
            if (!isPlayingSample)
            {
                isPlayingSample = true;
                audioSource.Play();
                yield return new WaitForSeconds(audioSource.clip.length);
                isPlayingSample = false;
            }
        }
    }
}
