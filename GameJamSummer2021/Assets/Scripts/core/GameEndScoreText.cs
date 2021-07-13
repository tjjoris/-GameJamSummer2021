using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace FreeEscape.Core
{
    public class GameEndScoreText : MonoBehaviour
    {
        private ScoreTracker scoreTracker;
        private TMPro.TextMeshProUGUI tMProScore;
        private int numberOfScenesBeforeLevel1 = 1;
        private int numberOfScenesAfterMaxLevel = 1;
        void Start()
        {
            tMProScore = GetComponent<TMPro.TextMeshProUGUI>();
            string scoreText = "Score: \n";

            scoreTracker = FindObjectOfType<ScoreTracker>();
            if (scoreTracker == null)
            {
                Debug.Log("GameEndScoreText could not find ScoreTracker Object");
                scoreText = "GameEndScoreText could not find ScoreTracker Object";
                tMProScore.text = scoreText;
                return;
            }
            
            int levelCount = 1;
            int scoreTotal = 0;
            for (int i=numberOfScenesBeforeLevel1; i< SceneManager.sceneCountInBuildSettings -
                numberOfScenesAfterMaxLevel; i++)
            {
                scoreText = scoreText + "Level " + levelCount.ToString() + ": " +
                    scoreTracker.GetScoreOfLevel(i) + "\n";
                scoreTotal += scoreTracker.GetScoreOfLevel(i);
                levelCount++;
            }
            scoreText = scoreText + "Total: " + scoreTotal.ToString();
            //scoreText = scoreText + "Level 1: " + ScoreTracker.

            tMProScore.text = scoreText;
        }
    }
}
