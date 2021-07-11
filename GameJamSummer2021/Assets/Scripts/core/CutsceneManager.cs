using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Control;
using FreeEscape.UI;
using TMPro;
using FreeEscape.Audio;

namespace FreeEscape.Core
{
    public class CutsceneManager : MonoBehaviour
    {
        private Camera mainCamera;
        private LevelManager levelManager;
        private GameObject player;
        private PlayerInput playerInput;
        private ProgressShader progressShader;
        private DebrisTracker debrisTracker;
        private float levelTotalTime;
        private AudioPlayerManager audioPlayerManager;
        [SerializeField] private float playerTeleportTime;
        [SerializeField] private GameplayMenu gameplayMenu;
        [SerializeField] private TextMeshProUGUI timeRemainingText;
        [SerializeField] private TextMeshProUGUI announcementText;
        [SerializeField] private GameObject hpBar;
        

        private void Start()
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            if (mainCamera == null)
            { Debug.Log("Could not find Main Camera.");}
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            SetupPlayerObject();
            StartCoroutine(BeginLevelSequence());
        }

        public void SetupCutsceneManager(LevelManager _levelManager, DebrisTracker _debrisTracker, float _timeToComplete)
        {
            levelManager = _levelManager;
            debrisTracker = _debrisTracker;
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
            playerInput.PlayerControlsLocked(true);
            progressShader = player.GetComponentInChildren<ProgressShader>();
            if (progressShader == null)
            {
                Debug.Log("Could not find ProgressShader");
                return;
            }
            progressShader.ApplyShaderEffect(0f, 0f);
            player.SetActive(false);
        }

        public void UpdateTimerText(float _currentTimeRemaining)
        {
            TimeSpan ts = TimeSpan.FromSeconds(_currentTimeRemaining);
                String result = ts.ToString("m\\:ss\\.fff");
                timeRemainingText.text = "Fleet Arrival In: " + result;
        }


        IEnumerator BeginLevelSequence()
        {
            debrisTracker.HideText();
            timeRemainingText.text = "";
            announcementText.text = "";
            hpBar.SetActive(false);
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

            audioPlayerManager.PlayeWarpIn();
            player.SetActive(true);
            progressShader.ApplyShaderEffect(playerTeleportTime, 1.1f);
            yield return new WaitForSeconds(playerTeleportTime);

            levelManager.SetTimerActive(true);

            playerInput.PlayerControlsLocked(false);
            hpBar.SetActive(true);
        }

        private void PlayerTeleportOut()
        {
            audioPlayerManager.PlayeWarpOut();
            progressShader.ApplyShaderEffect(playerTeleportTime, 0f);
            playerInput.PlayerControlsLocked(true);
        }

        public IEnumerator ClearAllDebrisCoroutine()
        {
            debrisTracker.LevelCleared();
            levelManager.LevelTimerActive(false);
            announcementText.text = "MISSION ACCOMPLISHED";
            yield return new WaitForSeconds(0.62f);

            PlayerTeleportOut();
            yield return new WaitForSeconds(1.38f);

            gameplayMenu.ClearAllDebrisScoreScreen();
            audioPlayerManager.PlayLevelWinTheme();
        }

        public IEnumerator PlayerRanOutOfTime()
        {
            // timerActive = false;
            announcementText.text = "FLEET ARRIVAL IMMINENT!";
            yield return new WaitForSeconds(0.62f);
            
            PlayerTeleportOut();
            yield return new WaitForSeconds(1.38f);

            gameplayMenu.OutOfTimeScoreScreen();
            audioPlayerManager.PlayLoseTheme();
        }

        public IEnumerator PlayerDestroyedCoroutine()
        {
            announcementText.text = "CRITICAL DAMAGE: ABORTING MISSION";
            PlayerTeleportOut();
            yield return new WaitForSeconds(1.38f);

            gameplayMenu.PlayerDestroyedScoreScreen();
            audioPlayerManager.PlayLoseTheme();
        }



        ////////////////////////


        //Level Ends
        //Score collected
        //Timer Paused
        ////Player controls locked
        //Player teleports out
        //Fleet comes screaming through
        //Fleet colliders hit debris/bombs
        //
    }
}
