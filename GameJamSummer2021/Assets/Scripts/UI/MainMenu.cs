using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FreeEscape.Options;

namespace FreeEscape.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPage;
        [SerializeField] private GameObject optionsPage;
        [SerializeField] private GameObject aboutPage;
        [SerializeField] private GameObject controlsPage;
        private AudioSource musicAudioSource;
        private AudioSource titleThemeAudioSource;
        private void Start()
        {
            GameObject persistentGO = GameObject.FindWithTag("PersistentGO");
            musicAudioSource = persistentGO.GetComponent<AudioSource>();
            musicAudioSource.Stop();
            titleThemeAudioSource = GetComponent<AudioSource>();
            titleThemeAudioSource.volume = PlayerPrefsController.GetMasteMusicVolume();
        }
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            musicAudioSource.Play();
        }

        public void TravelToOptionsPage()
        {
            HideAll();
            optionsPage.SetActive(true);
        }

        public void TravelToMainMenuPage()
        {
            HideAll();
            mainMenuPage.SetActive(true);
        }
        public void TravelToControlsPage()
        {
            HideAll();
            controlsPage.SetActive(true);
        }
        public void TravelToAboutPage()
        {
            HideAll();
            aboutPage.SetActive(true);
        }

        private void HideAll()
        {
            mainMenuPage.SetActive(false);
            controlsPage.SetActive(false);
            optionsPage.SetActive(false);
            aboutPage.SetActive(false);
        }

    }
}
