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
        //[SerializeField] private Transform cameraStartPosition;
        //[SerializeField] private Animator cameraMotion;
        [SerializeField] private GameObject dialogueUI;
        private LevelManager levelManager;
        private LevelProperties levelProperties;
        private ProgressShader progressShader;
        private DebrisTracker debrisTracker;
        private float levelTotalTime;
        private GameObject player;        
        private I_InputControl playerInput;
        private AudioPlayerManager audioPlayerManager;
        [SerializeField] private float playerTeleportTime;
        [SerializeField] private GameplayMenu gameplayMenu;
        [SerializeField] private TextMeshProUGUI timeRemainingText;
        [SerializeField] private TextMeshProUGUI announcementText;
        [SerializeField] private GameObject hpBar;
        [SerializeField] private GameObject abilityIcons;

        public void SetupPlayer(GameObject _player, I_InputControl _InputControl, AudioPlayerManager _audioPlayerManager)
        {
            player = _player;
            if (player == null) {Debug.LogWarning("CutsceneManager did not obtain Player Object");}
            playerInput = _InputControl;
            audioPlayerManager = _audioPlayerManager;
            
            playerInput.PlayerControlsLocked(true);
            progressShader = player.GetComponentInChildren<ProgressShader>();
            if (progressShader == null)
            {
                Debug.Log("Could not find ProgressShader");
                return;
            }
            player.SetActive(false);
            progressShader.ApplyShaderEffect(0f, 0f);

            InitializeScene();
        }

        public void SetupCutsceneManager(LevelManager _levelManager, DebrisTracker _debrisTracker, float _timeToComplete)
        {
            levelManager = _levelManager;
            debrisTracker = _debrisTracker;
            
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            if (mainCamera == null)
            {
                Debug.Log("Could not find Main Camera.");
                return;
            }
        }
        

        public void UpdateTimerText(float _currentTimeRemaining)
        {
            TimeSpan ts = TimeSpan.FromSeconds(_currentTimeRemaining);
                String result = ts.ToString("m\\:ss\\.fff");
                timeRemainingText.text = "Fleet Arrival In: " + result;
        }

        private void InitializeScene()
        {
            mainCamera.GetComponent<FollowCamera>().LockCameraToPlayer(player);

            levelProperties = this.GetComponent<LevelProperties>();

            debrisTracker.HideText();
            timeRemainingText.text = "";
            announcementText.text = "";
            dialogueUI.SetActive(false);
            hpBar.SetActive(false);
            abilityIcons.SetActive(false);

            StartCoroutine(IntroDialogue());
        }

        IEnumerator IntroDialogue()
        {
            yield return new WaitForSeconds(0.62f);

            dialogueUI.SetActive(true);
            dialogueUI.GetComponent<DialogueTrigger>().StartDialogue();
        }

        public IEnumerator BeginLevelSequence()
        {
            Debug.Log("called intro sequence.");
            //level loads
            yield return new WaitForSeconds(0.5f);
         
            //camera zoomed out with view of debris
            //zooms in toward debris
            
            debrisTracker.ShowText();
            yield return new WaitForSeconds(0.5f);
            
            //Pans camera to where ship appears
            
            TimeSpan ts = TimeSpan.FromSeconds(levelTotalTime);
            String result = ts.ToString("m\\:ss\\.fff");
            timeRemainingText.text = "Fleet Arrival In: " + result;
            yield return new WaitForSeconds(0.5f);

            if (audioPlayerManager == null) 
            {
                Debug.Log("CutsceneManager does not have AudioPlayerManager.");
                yield break;
            }
            player.SetActive(true);
            audioPlayerManager.PlayeWarpIn();
            progressShader.ApplyShaderEffect(playerTeleportTime, 1.1f);
            yield return new WaitForSeconds(playerTeleportTime);

            levelManager.SetTimerActive(true);

            playerInput.PlayerControlsLocked(false);
            hpBar.SetActive(true);
            abilityIcons.SetActive(true);
            dialogueUI.SetActive(false);
        }

        private void PlayerTeleportOut()
        {
            audioPlayerManager.PlayeWarpOut();
            player.GetComponent<I_AbilityLauncher>().Teleporting = true;
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
    }
}
