using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Bomb;
using FreeEscape.Audio;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombLauncher;
        private GameObject equippedBomb;
        private SpriteRenderer heldBombSpriteRenderer;
        private Rigidbody2D rb;
        private AudioPlayerManager audioPlayerManager;
        private BombsIndicator bombsIndicator;
        private float launchVelocity;
        private float cooldown;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        [Header("[0]sticky(infinate), [1]fuse, [2]proximity")]
        [SerializeField] int[] bombAmmo = { 0, 5 };
        private int bombTypeEquipped; //0 = fuse bomb, 1= sticky bomb, 2=proximity bomb.
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            bombsIndicator = FindObjectOfType<BombsIndicator>();
            bombsIndicator.ShowAmmo(1, bombAmmo[1]);
        }

        private void Update()
        {
            if (countdownCurrent > 0)
            {
                countdownCurrent -= Time.deltaTime;
                if (countdownCurrent <= 0)
                {
                    BombReady();
                }
            }    
        }
        public void LaunchBombAction()
        {
            if ((!canLaunchBomb) || (!UseAmmo())) { return; }

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

        public void EquipBomb(GameObject _bombPrefab, int bombIndex)
        {
            bombTypeEquipped = bombIndex;
            equippedBomb = _bombPrefab;
            BombProperties bomb = equippedBomb.GetComponent<BombProperties>();
            launchVelocity = bomb.launchVelocity;
            cooldown = bomb.cooldown;
            heldBombSpriteRenderer.sprite = bomb.spriteRenderer.sprite;
            heldBombSpriteRenderer.color = bomb.spriteRenderer.color;
        }
        private bool UseAmmo()
        {
            if ((bombTypeEquipped != 0) && (bombAmmo[bombTypeEquipped] > 0))
            {
                bombAmmo[bombTypeEquipped]--;
                bombsIndicator.ShowAmmo(bombTypeEquipped, bombAmmo[bombTypeEquipped]);
                return true;
            }
            else if (bombTypeEquipped == 0)
            {
                return true;
            }
            return false;
        }


    }
}
