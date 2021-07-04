using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreeEscape.UI
{
    public class GameplayMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GameObject clearAllScoreUI;
        [SerializeField] private GameObject outOfTimeScoreUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && (!clearAllScoreUI.activeSelf && !outOfTimeScoreUI.activeSelf))
            {
                if (GameIsPaused)
                {
                    Resume();
                } else
                {
                    Pause();
                }
            }    
        }
    
        private void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void ResumeButton()
        {
            Resume();
        }

        private void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void ClearAllDebrisScoreScreen()
        {
            clearAllScoreUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void OutOfTimeScoreScreen()
        {
            outOfTimeScoreUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
