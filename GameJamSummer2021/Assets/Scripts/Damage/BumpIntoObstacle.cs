using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;
using FreeEscape.Audio;
using FreeEscape.Movement;

namespace FreeEscape
{
    public class BumpIntoObstacle : MonoBehaviour
    {
        private MaxSpeed maxSpeed;
        private AudioPlayerManager audioPlayerManager;
        private float collisionDamageMax = 10f; //this is not the max damage, it is lessedned by the ratioOfMinSpeedForNoDamage 
        private float ratioOfMinSpeedForNoDamage = 0.3f;
        //private void Start()
        //{
        //    //audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
        //    //maxSpeed = FindObjectOfType<MaxSpeed>();
        //}
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                maxSpeed = collision.gameObject.GetComponent<MaxSpeed>();
                float maxSpeedFloat = maxSpeed.GetMaxSpeed();
                float speedFloat = maxSpeed.GetSpeed();
                float speedRatio = speedFloat / maxSpeedFloat;
                speedRatio = speedRatio - ratioOfMinSpeedForNoDamage;
                if (speedRatio <= 0f)
                {
                    speedRatio = 0f;
                }
                //Debug.Log("collision damage " + speedRatio * collisionDamageMax);
                playerHealth.TakeDamage(speedRatio * collisionDamageMax);
                audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
                audioPlayerManager.PlayBonk(speedRatio);
            }
        }
    }
}
