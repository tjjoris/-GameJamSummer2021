using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Audio
{
    public class AudioPlayerManager : MonoBehaviour
    {
        [SerializeField] private AudioClip bombFire;
        [SerializeField] private AudioClip[] explosions;
        [SerializeField] private AudioClip[] bonk;
        [SerializeField] private AudioClip winTheme;
        [SerializeField] private AudioSource thruster1;
        [SerializeField] private AudioSource thruster2;
        private bool isAccelerating;
        private bool isRotating;
    public void PlayFireBomb(){
        AudioSource.PlayClipAtPoint(bombFire, Camera.main.transform.position);
        }
        public void PlayBonk(float intensity)
        {
            int randIndex = Random.Range(0,3);
            AudioSource.PlayClipAtPoint(bonk[randIndex], Camera.main.transform.position, intensity);
        }
        public void PlayExplosion()
        {
            int randIndex = Random.Range(0,4);
            AudioSource.PlayClipAtPoint(explosions[randIndex], Camera.main.transform.position);
        }
        public void StartMainThrustersAudio()
        {
            if (!isAccelerating)
            {
                isAccelerating = true;
                thruster1.Play();
            }
        }
        public void StopMainThrustersAudio()
        {
            if (isAccelerating)
            {
                isAccelerating = false;
                thruster1.Stop();
            }
        }
        public void StartRotatingThrustersAudio()
        {
            if (!isRotating)
            {
                isRotating = true;
                thruster2.Play();
            }
        }
        public void StopRotatingThrustersAudio()
        {
            if (isRotating)
            {
                isRotating = false;
                thruster2.Stop();
            }
        }
    }

    }
