using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Bomb;
using FreeEscape.Audio;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombLauncher;
        private GameObject equippedBomb;
        private SpriteRenderer heldBombSpriteRenderer;
        private Rigidbody2D rb;
        private AudioPlayerManager audioPlayerManager;
        private float launchVelocity;
        private float cooldown;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
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
            if (!canLaunchBomb) { return; }

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

        public void EquipBomb(GameObject _bombPrefab)
        {
            equippedBomb = _bombPrefab;
            BombProperties bomb = equippedBomb.GetComponent<BombProperties>();
            launchVelocity = bomb.launchVelocity;
            cooldown = bomb.cooldown;
            heldBombSpriteRenderer.sprite = bomb.spriteRenderer.sprite;
            heldBombSpriteRenderer.color = bomb.spriteRenderer.color;
        }
    }
}
