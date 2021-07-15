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
        private I_AbilityManager _abilityManager;
        public I_AbilityManager AbilityManager { set { _abilityManager = value; } }
        private I_AbilitySlot equippedAbility;
        private float launchVelocity;
        private bool canLaunchBomb = true;
        private bool _teleporting = false;
        public bool Teleporting { set { _teleporting = value; } }

        private int abilitySlotEquipped;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
        }

        public void ActivateAbility()
        {
            if (!canLaunchBomb || equippedAbility.OutOfAmmo())
            {
                CannotFire();
                return;
            }
            
            equippedAbility.UseAmmo();
            GenerateBomb();
            LauncherEnabled(false);
            StartCoroutine(equippedAbility.BeginCooldown());
        }
        
        private void CannotFire()
        {
            //TODO: improved feedback when player can't fire.
        }

        private void GenerateBomb()
        {
            GameObject bomb = Instantiate(equippedBomb, bombLauncher.transform.position, transform.rotation);
            Vector2 shipVelocity = rb.velocity;
            Vector2 reverseV2 = new Vector2(0, launchVelocity);
            bomb.GetComponent<Rigidbody2D>().AddRelativeForce(reverseV2);
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;

        }

        public void LauncherEnabled(bool _state)
        {
            if (_teleporting || equippedAbility.OutOfAmmo())
            {
                _state = false;
            }

            heldBombSpriteRenderer.enabled = _state;
            canLaunchBomb = _state;
        }

        public void EquipAbility(I_AbilitySlot _abilitySlot, int _slotIndex)
        {
            equippedAbility = _abilitySlot;
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
            
            heldBombSpriteRenderer.sprite = bombProperties.spriteRenderer.sprite;
            heldBombSpriteRenderer.color = bombProperties.spriteRenderer.color;

            LauncherEnabled(_abilitySlot.IsOffCooldown);
        }
    }
}
