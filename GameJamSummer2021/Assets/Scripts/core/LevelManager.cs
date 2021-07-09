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
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        private CutsceneManager cutsceneManager;
        private bool timerActive = false;

        private void Awake()
        {
            cutsceneManager = this.GetComponent<CutsceneManager>();
            cutsceneManager.SetupCutsceneManager(this, debrisTracker, levelTotalTime);
        }
        private void Start()
        {
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
            TallyScore();
            timerActive = _state;
        }

        private void PlayerClearedAllDebris (object sender, EventArgs e)
        {
            TallyScore();
            StartCoroutine(cutsceneManager.ClearAllDebrisCoroutine());            
        }

        public void PlayerDestroyed()
        {
            TallyScore();
            StartCoroutine(cutsceneManager.PlayerDestroyedCoroutine());
        }

        private void TallyScore()
        {
            //probably calls a scoreManager script to do it's thing. Likely pushes currentTimeRemaining to it.
        }
    }
}
