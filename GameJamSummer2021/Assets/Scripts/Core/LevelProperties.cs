using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Control;
using FreeEscape.UI;
using FreeEscape.Audio;

namespace FreeEscape.Core
{
    public class LevelProperties : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private I_AbilityManager abilityManager;
        [SerializeField] private AbilityIconManager abilityIconManager;
        [SerializeField] private Transform playerSpawnPoint;
        private GameObject player;
        private I_InputControl playerInput;
        private CutsceneManager cutsceneManager;

        public void LevelSetup(CutsceneManager _cutsceneManager)
        {
            cutsceneManager = _cutsceneManager;
            if (cutsceneManager == null)
                {Debug.Log("LevelProperties did not get passed CutsceneManager"); return;}
            SetupPlayerObject();
        }
        private void SetupPlayerObject()
        {
            player = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            playerInput = player.GetComponent<I_InputControl>();
            if (playerInput == null)
                { Debug.Log("LevelProperties could not find PlayerInput."); return; }
            
            abilityManager = GetComponent<I_AbilityManager>();
            if (abilityManager == null)
                { Debug.Log("LevelProperties could not find AbilityManager."); return; }

            I_AbilityLauncher abilityLauncher = player.GetComponent<LaunchBomb>();
            if (abilityLauncher == null)
                {Debug.LogWarning("LevelProperties could not get AbilityLauncher from player."); return; }

            abilityManager.HookupPlayerAbilities(player.GetComponent<I_AbilityLauncher>(), abilityIconManager);
            playerInput.AbilityManager = abilityManager;

            I_AbilityLauncher playerLauncher = player.GetComponent<I_AbilityLauncher>();
            if (playerLauncher == null)
                { Debug.LogWarning("LevelProperties cannot find AbilityLauncher on Player."); return; }
            playerLauncher.AbilityManager = abilityManager;

            AudioPlayerManager audioPlayerManager = player.GetComponent<AudioPlayerManager>();

            cutsceneManager.SetupPlayer(player, playerInput, audioPlayerManager);
        }
    }
}
