using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape
{
    public class BumpIntoObstacle : MonoBehaviour
    {
        private AudioPlayerManager audioPlayerManager;
        private void Start()
        {
            audioPlayerManager = GetComponent<AudioPlayerManager>();
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(10f);
                audioPlayerManager.PlayBonkAC(0);
            }
        }
    }
}
