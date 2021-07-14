using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using FreeEscape.UI;
using FreeEscape.Control;
using FreeEscape.Display;
using UnityEngine.SceneManagement;
using FreeEscape.Audio;

namespace FreeEscape.Core
{
    [RequireComponent(typeof(CutsceneManager), typeof(LevelProperties))]
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private float levelTotalTime;
        [SerializeField] private TMPro.TextMeshProUGUI tMProScore;
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        private CutsceneManager cutsceneManager;
        private LevelProperties levelProperties;
        private ScoreTracker scoreTracker;
        private AudioPlayerManager audioPlayerManager;
        private bool timerActive = false;
        private float timeRemainingToScoreMult = 200f;
        private int[] scoreThisLevelByTask;
        private int scoreThisLevel;
        private int numberOfTasks;
        private int thisLevel;
        private int bonusScoreForClear = 5000;

        private void Awake()
        {
            cutsceneManager = this.GetComponent<CutsceneManager>();
            cutsceneManager.SetupCutsceneManager(this, debrisTracker, levelTotalTime);
            levelProperties = this.GetComponent<LevelProperties>();
            levelProperties.LevelSetup(cutsceneManager);
        }

        private void Start()
        {
            GetScoreTracker();            
            debrisTracker.TallyDebris();
            debrisTracker.AllDebrisCleared += PlayerClearedAllDebris;
            currentTimeRemaining = levelTotalTime;
            thisLevel = SceneManager.GetActiveScene().buildIndex;
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            if (audioPlayerManager) {Debug.Log("found audioPlayerManager");}
        }

        private void GetScoreTracker()
        {
            scoreTracker = FindObjectOfType<ScoreTracker>();
            if (scoreTracker == null)
            {
                Debug.Log("Could not find ScoreTracker.");
                return;
            }
            numberOfTasks = scoreTracker.GetNumberOfTasks();
            scoreThisLevelByTask = new int[numberOfTasks];
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
                    PlayerRanOutOfTime();
                }
            }
        }

        public void LevelTimerActive(bool _state)
        {
            timerActive = _state;
        }
        public void SetTimerActive(bool _state)
        {
            timerActive = _state;
        }

        private void PlayerClearedAllDebris(object sender, EventArgs e)
        {
            TallyScore(true);
            StartCoroutine(cutsceneManager.ClearAllDebrisCoroutine());
        }

        private void PlayerRanOutOfTime()
        {
            timerActive = false;
            cutsceneManager.UpdateTimerText(0f);
            TallyScore(false);
            StartCoroutine(cutsceneManager.PlayerRanOutOfTime());
        }

        public void PlayerDestroyed()
        {
            TallyScore(false);
            StartCoroutine(cutsceneManager.PlayerDestroyedCoroutine());
        }

        private void TallyScore(bool levelCleared)
        {
            if (scoreTracker == null) { GetScoreTracker(); } //this failsafe should not exist. Currently implemented due to a race condition.
            
            scoreThisLevel = 0;
            scoreThisLevelByTask = scoreTracker.GetScorePerTask();
            string scoreString = "Score: \n";
            scoreString = scoreString + "   Debris Destroyed: " + scoreThisLevelByTask[0].ToString() + "\n";
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
        }

        private void BonusScore(out string _scoreString, string origionalScoreString)
        {//i cant remember how to use out properly so im doing it the way i can make work
            float floatTimeScore = (currentTimeRemaining) * timeRemainingToScoreMult;
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
