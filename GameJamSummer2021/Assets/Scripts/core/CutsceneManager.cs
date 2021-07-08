using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Control;

namespace FreeEscape.Core
{
//     public class CutsceneManager : MonoBehaviour
//     {
//         [SerializeField] private Camera mainCamera;
//         private GameObject player;
//         private PlayerInput playerInput;
//         private ProgressShader progressShader;
//         private DebrisTracker debrisTracker;
//         private float levelTotalTime;
        

//         private void Start()
//         {
//             SetupPlayerObject();
//             StartCoroutine(BeginLevelSequence());
//         }

//         public void SetupCutsceneManager(DebrisTracker _debrisTracker, float _timeToComplete)
//         {
//             debrisTracker = _debrisTracker;
//         }
//         private void SetupPlayerObject()
//         {
//             player = GameObject.Find("Player");
//             playerInput = player.GetComponent<PlayerInput>();
//             if (playerInput == null)
//             {
//                 Debug.Log("Could not find Player.");
//                 return;
//             }
//             playerInput.PlayerControlsLocked();
//             progressShader = player.GetComponentInChildren<ProgressShader>();
//             if (progressShader == null)
//             {
//                 Debug.Log("Could not find ProgressShader");
//                 return;
//             }
//             progressShader.ApplyShaderEffect(0f, 0f);
//             player.SetActive(false);
//         }


//         IEnumerator BeginLevelSequence()
//         {
//             yield return new WaitForSeconds(0.5f);
            
//             //level loads
//             //camera zoomed out with view of debris
//             //zooms in toward debris
            
//             //Debris counter appears
//             debrisTracker.ShowText();
//             yield return new WaitForSeconds(0.5f);
            
//             //Pans camera to where ship appears
            
//             //Time Remaining text appears (paused)
//             TimeSpan ts = TimeSpan.FromSeconds(levelTotalTime);
//             String result = ts.ToString("m\\:ss\\.fff");
//             timeRemainingText.text = "Fleet Arrival In: " + result;
//             yield return new WaitForSeconds(0.5f);

//             //Ship teleports in & teleportation animation plays
//             player.SetActive(true);
//             progressShader.ApplyShaderEffect(0.62f, 1.1f);
//             yield return new WaitForSeconds(0.62f);

//             //Timer Unpauses
//             timerActive = true;
//             //player controls unlocked.
//             playerInput.PlayerControlsUnlocked();
//         }

//         public IEnumerator ClearAllDebrisCoroutine()
//         {
//             debrisTracker.LevelCleared();
//             timerActive = false;
//             yield return new WaitForSeconds(0.62f);
//             progressShader.ApplyShaderEffect(0.62f, 0f);
//             yield return new WaitForSeconds(1.38f);

//             gameplayMenu.ClearAllDebrisScoreScreen();
//         }



//         ////////////////////////


//         //Level Ends
//         //Score collected
//         //Timer Paused
//         ////Player controls locked
//         //Player teleports out
//         //Fleet comes screaming through
//         //Fleet colliders hit debris/bombs
//         //
//     }
}
