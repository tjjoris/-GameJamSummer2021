using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace FreeEscape.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeRemainingText;
        [SerializeField] private float levelTotalTime;
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        [SerializeField] private GameObject scoreScreenCanvas;
        private bool timerActive = false;
        void Start()
        {
            debrisTracker.TallyDebris();
            debrisTracker.AllDebrisCleared += PlayerClearedAllDebris;
            currentTimeRemaining = levelTotalTime;
            timerActive = true;
            
        }

        private void Update()
        {
            if (timerActive)
            {
                currentTimeRemaining -= Time.deltaTime;
                TimeSpan ts = TimeSpan.FromSeconds(currentTimeRemaining);
                String result = ts.ToString("m\\:ss\\.fff");
                timeRemainingText.text = "Fleet Arrival In: " + result;

                if (currentTimeRemaining <= 0)
                {
                    PlayerRanOutOfTime();
                }
            }
        }

        private void PlayerClearedAllDebris (object sender, EventArgs e)
        {
            debrisTracker.LevelCleared();
            timerActive = false;

            Debug.Log("game end");
            scoreScreenCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        private void PlayerRanOutOfTime()
        {
            
        }
    }
}
