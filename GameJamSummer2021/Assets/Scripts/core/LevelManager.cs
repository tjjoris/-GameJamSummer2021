using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using FreeEscape.UI;
using FreeEscape.Control;
using FreeEscape.Display;

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
        private float timeRemainingToScoreMult = 2f;

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
            int[] score = scoreTracker.GetScorePerTask();
            string scoreString = "Score: \n";
            scoreString = scoreString + "   Debris Destoryed: " + score[0].ToString() + "\n";
            if (levelCleared)
            {
                BonusScore(out scoreString, scoreString);
            }
            tMProScore.text = scoreString;

            //probably calls a scoreManager script to do it's thing. Likely pushes currentTimeRemaining to it.
        }

        private void BonusScore(out string _scoreString, string origionalScoreString)
        {//i cant remember how to use out properly so im doing it the way i can make work
            float floatTimeScore = (levelTotalTime - currentTimeRemaining) * timeRemainingToScoreMult;
             string timeScore = Mathf.FloorToInt(floatTimeScore).ToString();
            _scoreString = origionalScoreString + "   Area Cleared! \n   Bonus Score: \n";
            _scoreString = _scoreString + timeScore;
        }
    

        private int CalculateTimeRemainingScore()            
        {
            float floatTimeScore = (levelTotalTime - currentTimeRemaining) * timeRemainingToScoreMult;
            return Mathf.FloorToInt(floatTimeScore);
        }
    }
}
