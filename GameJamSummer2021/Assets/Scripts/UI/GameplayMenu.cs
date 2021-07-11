using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace FreeEscape.UI
{
    public class GameplayMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        [SerializeField] private GameObject pauseMenuUI;
        [SerializeField] private GameObject scoreScreenUI;
        [SerializeField] private GameObject playerDestroyedScoreUI;
        [SerializeField] private GameObject outOfTimeScoreUI;
        [SerializeField] private GameObject clearAllScoreUI;
        [SerializeField] private TextMeshProUGUI scoreCardText;
        [SerializeField] private Button nextLevelButton;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !scoreScreenUI.activeSelf)
            {
                if (GameIsPaused)
                {
                    ClosePauseMenu();
                } else
                {
                    OpenPauseMenu();
                }
            }    
        }
    
        public void ClosePauseMenu()
        {
            pauseMenuUI.SetActive(false);
            ResumeTime();
        }

        public void OpenPauseMenu()
        {
            pauseMenuUI.SetActive(true);
            PauseTime();
        }

        private void PauseTime()
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        private void ResumeTime()
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void PlayerDestroyedScoreScreen()
        {
            scoreScreenUI.SetActive(true);
            playerDestroyedScoreUI.SetActive(true);
            outOfTimeScoreUI.SetActive(false);
            clearAllScoreUI.SetActive(false);
            nextLevelButton.interactable = true;

            PauseTime();
        }

        public void OutOfTimeScoreScreen()
        {
            scoreScreenUI.SetActive(true);
            playerDestroyedScoreUI.SetActive(false);
            outOfTimeScoreUI.SetActive(true);
            clearAllScoreUI.SetActive(false);
            nextLevelButton.interactable = true;
            
            PauseTime();
        }
        public void ClearAllDebrisScoreScreen()
        {
            scoreScreenUI.SetActive(true);
            playerDestroyedScoreUI.SetActive(false);
            outOfTimeScoreUI.SetActive(false);
            clearAllScoreUI.SetActive(true);
            nextLevelButton.interactable = true;
            
            PauseTime();
        }

        public void ExitToMainMenu()
        {
            ResumeTime();
            SceneManager.LoadScene("MainMenu");
        }

        public void RetryLevelButton()
        {
            ResumeTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NextLevelButton()
        {
            ResumeTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void WriteToScore(string _scoreText)
        {
            scoreCardText.text = _scoreText;
        }
    }
}
