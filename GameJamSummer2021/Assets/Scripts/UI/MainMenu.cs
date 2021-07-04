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
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void TravelToOptionsPage()
        {
            mainMenuPage.SetActive(false);
            optionsPage.SetActive(true);
        }

        public void TravelToMainMenuPage()
        {
            mainMenuPage.SetActive(true);
            optionsPage.SetActive(false);
        }
    }
}
