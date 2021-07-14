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
            if (cutsceneManager != null) {Debug.Log("LevelProperties contains cutsceneManager");}
            SetupPlayerObject();
        }
        private void SetupPlayerObject()
        {
            player = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            playerInput = player.GetComponent<I_InputControl>();
            if (playerInput == null)
            {
                Debug.Log("Could not find PlayerInput.");
                return;
            }

            abilityManager = player.GetComponent<I_AbilityManager>();
            abilityManager.HookupPlayerAbilities(player.GetComponent<I_AbilityLauncher>(), abilityIconManager);
            AudioPlayerManager audioPlayerManager = player.GetComponent<AudioPlayerManager>();

            cutsceneManager.SetupPlayer(player, playerInput, audioPlayerManager);
        }
    }
}
