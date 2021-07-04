using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreeEscape.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPage;
        [SerializeField] private GameObject optionsPage;
        [SerializeField] private GameObject aboutPage;
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void TravelToOptionsPage()
        {
            mainMenuPage.SetActive(false);
            optionsPage.SetActive(true);
            aboutPage.SetActive(false);
        }

        public void TravelToMainMenuPage()
        {
            mainMenuPage.SetActive(true);
            optionsPage.SetActive(false);
            aboutPage.SetActive(false);
        }

        public void TravelToAboutPage()
        {
            mainMenuPage.SetActive(false);
            optionsPage.SetActive(false);
            aboutPage.SetActive(true);
        }
    }
}
