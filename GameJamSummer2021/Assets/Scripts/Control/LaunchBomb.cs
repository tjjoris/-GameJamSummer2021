using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Bomb;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombLauncher;
        private GameObject equippedBomb;
        private SpriteRenderer heldBombSpriteRenderer;
        private Rigidbody2D rb;
        private float launchVelocity;
        private AudioSource playerAudioSource;
        private AudioPlayerManager audioPlayerManger;
        private float cooldown;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerAudioSource = this.GetComponent<AudioSource>();
            heldBombSpriteRenderer = bombLauncher.GetComponent<SpriteRenderer>();
            audioPlayerManger = GetComponent<AudioPlayerManager>();
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
            //playerAudioSource.Play();
            audioPlayerManger.PlayBombFire();

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
            //playerAudioSource.clip = bomb.launchAudioClip;
        }
    }
}
