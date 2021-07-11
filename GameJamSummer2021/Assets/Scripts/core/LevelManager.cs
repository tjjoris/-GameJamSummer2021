using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using FreeEscape.UI;
using FreeEscape.Control;
using FreeEscape.Display;
using UnityEngine.SceneManagement;

namespace FreeEscape.Core
{
    [RequireComponent(typeof(CutsceneManager))]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float levelTotalTime;
        [SerializeField] private TMPro.TextMeshProUGUI tMProScore;
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        private CutsceneManager cutsceneManager;
        private ScoreTracker scoreTracker;
        private bool timerActive = false;
        private float timeRemainingToScoreMult = 400f;
        private int[] scoreThisLevelByTask;
        private int scoreThisLevel;
        private int numberOfTasks;
        private int thisLevel;
        private int bonusScoreForClear = 7000;

        private void Awake()
        {
            cutsceneManager = this.GetComponent<CutsceneManager>();
            cutsceneManager.SetupCutsceneManager(this, debrisTracker, levelTotalTime);
        }
        private void Start()
        {
            scoreTracker = FindObjectOfType<ScoreTracker>();
            debrisTracker.TallyDebris();
            debrisTracker.AllDebrisCleared += PlayerClearedAllDebris;
            currentTimeRemaining = levelTotalTime;
            numberOfTasks = scoreTracker.GetNumberOfTasks();
            scoreThisLevelByTask = new int[numberOfTasks];
            thisLevel = SceneManager.GetActiveScene().buildIndex;
            scoreTracker.ResetScorePerTask();
        }

        private void Update()
        {
            TickLevelTimer();
        }

        private void TickLevelTimer()
        {
            if (timerActive)
            {
                currentTimeRemaining -= Time.deltaTime;
                cutsceneManager.UpdateTimerText(currentTimeRemaining);


                if (currentTimeRemaining <= 0)
                {
                    timerActive = false;
                    cutsceneManager.UpdateTimerText(0f);
                    StartCoroutine(cutsceneManager.PlayerRanOutOfTime());
                }
            }
        }

        public void LevelTimerActive(bool _state)
        {
            //Debug.Log("time out" + _state.ToString());
            if (_state) { TallyScore(false); }
            timerActive = _state;
        }

        private void PlayerClearedAllDebris(object sender, EventArgs e)
        {
            //Debug.Log("this level has been cleared");
            TallyScore(true);
            StartCoroutine(cutsceneManager.ClearAllDebrisCoroutine());
        }

        public void PlayerDestroyed()
        {
            TallyScore(false);
            StartCoroutine(cutsceneManager.PlayerDestroyedCoroutine());
        }

        private void TallyScore(bool levelCleared)
        {
            scoreThisLevel = 0;
            scoreThisLevelByTask = scoreTracker.GetScorePerTask();
            string scoreString = "Score: \n";
            scoreString = scoreString + "   Debris Destoryed: " + scoreThisLevelByTask[0].ToString() + "\n";
            if (levelCleared)
            {
                BonusScore(out scoreString, scoreString);
            }
            scoreString = scoreString + "\n \nTotal: ";
            SumScore();
            scoreString = scoreString + scoreThisLevel + "\n \n";

            if (IsScoreHigherThanHighScore())
            {
                scoreTracker.SetHighScoreOfLevel(thisLevel, scoreThisLevel);
            }
            scoreString = scoreString + "High Score: " + scoreTracker.GetHighScoreOfLevel(thisLevel);
            tMProScore.text = scoreString;
            //probably calls a scoreManager script to do it's thing. Likely pushes currentTimeRemaining to it.
        }

        private void BonusScore(out string _scoreString, string origionalScoreString)
        {//i cant remember how to use out properly so im doing it the way i can make work
            float floatTimeScore = (levelTotalTime - currentTimeRemaining) * timeRemainingToScoreMult;
            _scoreString = origionalScoreString + "   Area Cleared! \n   Bonus Score: +"
                + bonusScoreForClear.ToString() + "\n";
            scoreThisLevelByTask[1] = bonusScoreForClear;//the bonus score for clearing
            scoreThisLevelByTask[2] = Mathf.FloorToInt(floatTimeScore);//the task of bonus time
            string timeScore = scoreThisLevelByTask[2].ToString();
            _scoreString = _scoreString + "   Time: " + timeScore;

        }
    

        private int CalculateTimeRemainingScore()            
        {
            float floatTimeScore = (levelTotalTime - currentTimeRemaining) * timeRemainingToScoreMult;
            return Mathf.FloorToInt(floatTimeScore);
        }
        private void SumScore()
        {
            for (int i=0; i<numberOfTasks; i++)
            {
                scoreThisLevel += scoreThisLevelByTask[i];
            }
            scoreTracker.SetScoreOfLevel(scoreThisLevel);
        }
        private bool IsScoreHigherThanHighScore()
        {
            if (scoreThisLevel > scoreTracker.GetHighScoreOfLevel(thisLevel))
            {
                return true;
            }
            return false;
        }
    }
}
