using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape
{
    public class AudioPlayerManager : MonoBehaviour
    {
        //[SerializeField] AudioSource bombFire;
        //[SerializeField] AudioSource bonk;
        //[SerializeField] AudioSource bonk2;
        //[SerializeField] AudioSource bonk3;
        //[SerializeField] AudioSource explosion2;
        //[SerializeField] AudioSource explosion2a;
        //[SerializeField] AudioSource explosion3;
        //[SerializeField] AudioSource explosion3a;
        //[SerializeField] AudioSource thruster1;
        //[SerializeField] AudioSource thruster2;
        //[SerializeField] AudioSource winTheme;
        [SerializeField] AudioClip bombFireAC;
        [SerializeField] AudioClip[] bonkArrayAC;
        //[SerializeField] AudioClip bonk2AC;
        //[SerializeField] AudioClip bonk3AC;
        [SerializeField] AudioClip explosion2AC;
        [SerializeField] AudioClip explosion2aAC;
        [SerializeField] AudioClip explosion3AC;
        [SerializeField] AudioClip explosion3aAC;
        [SerializeField] AudioClip thruster1AC;
        [SerializeField] AudioClip thruster2AC;
        [SerializeField] AudioClip winThemeAC;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayBombFire()
        {
            AudioSource.PlayClipAtPoint(bombFireAC, Camera.main.transform.position);
        }
        public void PlayBonkAC(int intensity)
        {
            {
                AudioSource.PlayClipAtPoint(bonkArrayAC[intensity], Camera.main.transform.position);
                Debug.Log("playing bonk");
            }
        }
    }
}
