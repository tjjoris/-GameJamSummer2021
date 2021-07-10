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
            TallyScore(false);
            timerActive = _state;
        }

        private void PlayerClearedAllDebris (object sender, EventArgs e)
        {
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
                //BonusScore();
            }
            scoreString = scoreString + "   Time Remaining: " + CalculateTimeRemainingScore().ToString() + "\n";
            tMProScore.text = scoreString;

            //probably calls a scoreManager script to do it's thing. Likely pushes currentTimeRemaining to it.
        }

        private int CalculateTimeRemainingScore()            
        {
            float floatTimeScore = (levelTotalTime - currentTimeRemaining) * timeRemainingToScoreMult;
            return Mathf.FloorToInt(floatTimeScore);
        }
    }
}
