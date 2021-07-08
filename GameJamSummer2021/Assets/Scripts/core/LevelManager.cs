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
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeRemainingText;
        [SerializeField] private TextMeshProUGUI announcementText;
        [SerializeField] private float levelTotalTime;
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        [SerializeField] private GameplayMenu gameplayMenu;
        [SerializeField] private Camera mainCamera;
        private GameObject player;
        private PlayerInput playerInput;
        private ProgressShader progressShader;

        private bool timerActive = false;
        void Start()
        {
            SetupPlayerObject();
            debrisTracker.TallyDebris();
            debrisTracker.AllDebrisCleared += PlayerClearedAllDebris;
            currentTimeRemaining = levelTotalTime;
            StartCoroutine(BeginLevelSequence());
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
                    StartCoroutine(PlayerRanOutOfTime());
                }
            }
        }

        private void SetupPlayerObject()
        {
            player = GameObject.Find("Player");
            playerInput = player.GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.Log("Could not find Player.");
                return;
            }
            playerInput.PlayerControlsLocked();
            progressShader = player.GetComponentInChildren<ProgressShader>();
            if (progressShader == null)
            {
                Debug.Log("Could not find ProgressShader");
                return;
            }
            progressShader.ApplyShaderEffect(0f, 0f);
            player.SetActive(false);
        }

        IEnumerator BeginLevelSequence()
        {
            debrisTracker.HideText();
            timeRemainingText.text = "";
            announcementText.text = "";
            yield return new WaitForSeconds(0.5f);
            
            //level loads
            //camera zoomed out with view of debris
            //zooms in toward debris
            
            debrisTracker.ShowText();
            yield return new WaitForSeconds(0.5f);
            
            //Pans camera to where ship appears
            
            TimeSpan ts = TimeSpan.FromSeconds(levelTotalTime);
            String result = ts.ToString("m\\:ss\\.fff");
            timeRemainingText.text = "Fleet Arrival In: " + result;
            yield return new WaitForSeconds(0.5f);

            player.SetActive(true);
            progressShader.ApplyShaderEffect(0.62f, 1.1f);
            yield return new WaitForSeconds(0.62f);

            timerActive = true;
            playerInput.PlayerControlsUnlocked();
        }


        private void PlayerClearedAllDebris (object sender, EventArgs e)
        {
            StartCoroutine(ClearAllDebrisCoroutine());            
        }
        IEnumerator ClearAllDebrisCoroutine()
        {
            debrisTracker.LevelCleared();
            announcementText.text = "MISSION ACCOMPLISHED!";
            timerActive = false;
            yield return new WaitForSeconds(0.62f);
            progressShader.ApplyShaderEffect(0.62f, 0f);
            yield return new WaitForSeconds(1.38f);

            gameplayMenu.ClearAllDebrisScoreScreen();
        }

        IEnumerator PlayerRanOutOfTime()
        {
            timerActive = false;
            announcementText.text = "FLEET ARRIVAL IMMINENT!";
            yield return new WaitForSeconds(0.62f);
            
            progressShader.ApplyShaderEffect(0.62f, 0f);
            yield return new WaitForSeconds(1.38f);
            

            gameplayMenu.OutOfTimeScoreScreen();
        }

        public void PlayerDestroyed()
        {
            StartCoroutine(PlayerDestroyedCoroutine());
        }

        IEnumerator PlayerDestroyedCoroutine()
        {
            announcementText.text = "CRITICAL DAMAGE: ABORTING MISSION";
            progressShader.ApplyShaderEffect(0.62f, 0f);
            yield return new WaitForSeconds(2.38f);
            gameplayMenu.PlayerDestroyedScoreScreen();
        }
    }
}
