using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Bomb;
using FreeEscape.Audio;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour, I_AbilityLauncher
    {
        [SerializeField] private GameObject bombLauncher;
        [SerializeField] private Transform frontLaunchPos;
        [SerializeField] private Transform backLaunchPos;
        private GameObject equippedBomb;
        private BombProperties bombProperties;
        private SpriteRenderer heldBombSpriteRenderer;
        private Rigidbody2D rb;
        private AudioPlayerManager audioPlayerManager;
        private I_AbilityManager _abilityManager;
        public I_AbilityManager AbilityManager { set { _abilityManager = value; } }
        private float launchVelocity;
        private float cooldown;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        private bool launcherEnabled = true;
        private int abilitySlotEquipped;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
            // audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
        }
        // private void Start()
        // {
        //     for (int i=1; i<bombAmmo.Length; i++)
        //     {
        //         abilityIconManager.ShowAmmo(i, bombAmmo[i]);
        //     }
        // }

        private void Update()
        {
            if (countdownCurrent > 0)
            {
                countdownCurrent -= Time.deltaTime;
                if (countdownCurrent <= 0  && launcherEnabled)
                {
                    BombReady();
                }
            }    
        }
        public void ActivateAbility()
        {
            if (_abilityManager == null)
                { Debug.LogWarning("LaunchBomb does not have AbilityManager."); return; }

            if ((!canLaunchBomb) || OutOfAmmo())
                { Debug.Log("Cannot activate ability right now."); return; }
            
            _abilityManager.UseAmmo(abilitySlotEquipped);
            GenerateBomb();
            BeginCooldown();
        }

        private void GenerateBomb()
        {
            GameObject bomb = Instantiate(equippedBomb, bombLauncher.transform.position, transform.rotation);
            Vector2 shipVelocity = rb.velocity;
            Vector2 reverseV2 = new Vector2(0, launchVelocity);
            bomb.GetComponent<Rigidbody2D>().AddRelativeForce(reverseV2);
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;
            //audioPlayerManager.PlayFireBomb();

        }

        private void BeginCooldown()
        {
            canLaunchBomb = false;
            heldBombSpriteRenderer.enabled = false;
            countdownCurrent = cooldown;
        }

        private void BombReady()
        {
            canLaunchBomb = true;
            heldBombSpriteRenderer.enabled = true;
        }

        public void LauncherEnabled(bool _state)
        {
            heldBombSpriteRenderer.enabled = _state;
            launcherEnabled = _state;
        }

        public void EquipAbility(I_AbilitySlot _abilitySlot, int _slotIndex)
        {
            //todo   use AbilityManager
            abilitySlotEquipped = _slotIndex;
            equippedBomb = _abilitySlot.AbilityPrefab;
            bombProperties = equippedBomb.GetComponent<BombProperties>();
            launchVelocity = bombProperties.launchVelocity;
            
            if (bombProperties.FrontLaunch)
            {
                bombLauncher.transform.position = frontLaunchPos.position;
            }
            else
            {
                bombLauncher.transform.position = backLaunchPos.position;
            }
            
            cooldown = bombProperties.cooldown;
            heldBombSpriteRenderer.sprite = bombProperties.spriteRenderer.sprite;
            heldBombSpriteRenderer.color = bombProperties.spriteRenderer.color;
        }

        private bool OutOfAmmo()
        {
            bool outOfAmmo = _abilityManager.OutOfAmmo(abilitySlotEquipped);
            return outOfAmmo;
        }
    }
}
