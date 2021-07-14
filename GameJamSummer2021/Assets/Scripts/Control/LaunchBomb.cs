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
        private AbilityIconManager abilityIconManager;
        private float launchVelocity;
        private float cooldown;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        private bool launcherEnabled = true;
        [Header("[0]Ability 1, [1]Ability 2, [2]Ability 3")]
        [SerializeField] int[] bombAmmo = { -1, 5 , 5};
        private int bombTypeEquipped;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            abilityIconManager = FindObjectOfType<AbilityIconManager>();
        }
        private void Start()
        {
            for (int i=1; i<bombAmmo.Length; i++)
            {
                abilityIconManager.ShowAmmo(i, bombAmmo[i]);
            }
        }

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
            if ((!canLaunchBomb) || (!HasAmmo())) { return; }
            
            UseAmmo();
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
            audioPlayerManager.PlayFireBomb();

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

        public void EquipAbility(GameObject _bombPrefab, int bombIndex)
        {
            bombTypeEquipped = bombIndex;
            equippedBomb = _bombPrefab;
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


        private bool HasAmmo()
        {
            if (bombAmmo[bombTypeEquipped] > 0 || bombAmmo[bombTypeEquipped] == -1)
            { return true; }
            return false;
        }
        private void UseAmmo()
        {
            if (bombAmmo[bombTypeEquipped] > 0 )
            {
                bombAmmo[bombTypeEquipped]--;
                abilityIconManager.ShowAmmo(bombTypeEquipped, bombAmmo[bombTypeEquipped]);
            }
        }


    }
}
