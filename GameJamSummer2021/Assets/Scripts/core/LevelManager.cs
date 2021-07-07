using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using FreeEscape.UI;
using FreeEscape.Control;

namespace FreeEscape.Core
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeRemainingText;
        [SerializeField] private float levelTotalTime;
        private float currentTimeRemaining;
        [SerializeField] private DebrisTracker debrisTracker;
        [SerializeField] private GameplayMenu gameplayMenu;
        [SerializeField] private Camera mainCamera;
        private GameObject player;
        private PlayerInput playerInput;

        private bool timerActive = false;
        void Start()
        {
            player = GameObject.Find("Player");
            playerInput = player.GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.Log("Could not find Player.");
                return;
            }
            playerInput.PlayerControlsLocked();
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

        IEnumerator BeginLevelSequence()
        {
            debrisTracker.HideText();
            timeRemainingText.text = "";
            player.SetActive(false);
            //level loads
            //camera zoomed out with view of debris
            //zooms in toward debris
            
            //Debris counter appears
            yield return new WaitForSeconds(0.5f);
            debrisTracker.ShowText();
            
            //Pans camera to where ship appears
            
            //Time Remaining text appears (paused)
            yield return new WaitForSeconds(0.5f);
            TimeSpan ts = TimeSpan.FromSeconds(levelTotalTime);
            String result = ts.ToString("m\\:ss\\.fff");
            timeRemainingText.text = "Fleet Arrival In: " + result;

            //Ship teleports in & teleportation animation plays
            yield return new WaitForSeconds(0.5f);
            player.SetActive(true);


            //Timer Unpauses
            yield return new WaitForSeconds(0.5f);
            timerActive = true;
            //player controls unlocked.
            playerInput.PlayerControlsUnlocked();
        }


        private void PlayerClearedAllDebris (object sender, EventArgs e)
        {
            StartCoroutine(ClearAllDebrisCoroutine());            
        }
        IEnumerator ClearAllDebrisCoroutine()
        {
            debrisTracker.LevelCleared();
            timerActive = false;
            yield return new WaitForSeconds(1);
            gameplayMenu.ClearAllDebrisScoreScreen();
        }

        IEnumerator PlayerRanOutOfTime()
        {
            timerActive = false;
            timeRemainingText.text = "FLEET ARRIVAL IMMINENT!";
            playerInput.PlayerControlsLocked();
            //teleport out
            yield return new WaitForSeconds(1);
            gameplayMenu.OutOfTimeScoreScreen();
        }

        public void PlayerDestroyed()
        {
            StartCoroutine(PlayerDestroyedCoroutine());
        }

        IEnumerator PlayerDestroyedCoroutine()
        {
            yield return new WaitForSeconds(1);
            gameplayMenu.PlayerDestroyedScoreScreen();
        }
    }
}
