using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;
using FreeEscape.Options;

namespace FreeEscape.Audio
{
    public class AudioPlayerManager : MonoBehaviour
    {
        [SerializeField] private AudioClip bombFire;
        [SerializeField] private AudioClip[] explosions;
        [SerializeField] private AudioClip[] bonk;
        [SerializeField] private AudioClip[] uiClips;
        [SerializeField] private AudioClip winTheme;
        [SerializeField] private AudioClip warpIn;
        [SerializeField] private AudioClip warpOut;
        [SerializeField] private AudioSource thruster1;
        [SerializeField] private AudioSource thruster2;

        private bool isAccelerating;
        private bool isRotating;
        private float volume;
        private void Start()
        {
            volume = PlayerPrefsController.GetMasterVolume();
            thruster1.volume = volume;
            thruster2.volume = volume;
        }
        public void PlayeWarpIn()
        {
            AudioSource.PlayClipAtPoint(warpIn, Camera.main.transform.position, volume);
        }
        public void PlayeWarpOut()
        {
            AudioSource.PlayClipAtPoint(warpOut, Camera.main.transform.position, volume);
        }
        public void PlayFireBomb(){
        AudioSource.PlayClipAtPoint(bombFire, Camera.main.transform.position, volume);
        }
        public void PlayBonk(float intensity)
        {
            int randIndex = Random.Range(0,3);
            AudioSource.PlayClipAtPoint(bonk[randIndex], Camera.main.transform.position, intensity * volume);
        }
        public void PlayExplosion()
        {
            int randIndex = Random.Range(0,4);
            AudioSource.PlayClipAtPoint(explosions[randIndex], Camera.main.transform.position, volume);
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
