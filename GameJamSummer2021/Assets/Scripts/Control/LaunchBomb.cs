using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject fusePrefab;
        [SerializeField] private GameObject stickyPrefab;
        [SerializeField] private GameObject bombLauncher;
        private GameObject equippedBomb;
        private SpriteRenderer heldBombSprite;
        private Rigidbody2D rb;
        [SerializeField] private float reverseVelocity = 100f;
        [SerializeField] private float cooldown;
        [SerializeField] private AudioSource launchAudioClip;
        private float countdownCurrent;
        private bool canLaunchBomb = true;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            heldBombSprite = bombLauncher.GetComponent<SpriteRenderer>();
            equippedBomb = fusePrefab;
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
            Vector2 reverseV2 = new Vector2(0, -reverseVelocity);
            bomb.GetComponent<Rigidbody2D>().AddRelativeForce(reverseV2);
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;
            launchAudioClip.Play();

        }

        private void BeginCooldown()
        {
            canLaunchBomb = false;
            heldBombSprite.enabled = false;
            countdownCurrent = cooldown;
        }

        private void BombReady()
        {
            canLaunchBomb = true;
            heldBombSprite.enabled = true;
        }

        public void EquipFuseBomb()
        {
            equippedBomb = fusePrefab;
            heldBombSprite.color = new Color(255, 255, 255, 255);
        }

        public void EquipStickyBomb()
        {
            equippedBomb = stickyPrefab;
            heldBombSprite.color = Color.green;
        }
    }
}
