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
        [SerializeField] AudioSource thruster1;
        [SerializeField] AudioSource thruster2;
        //[SerializeField] AudioSource winTheme;
        [SerializeField] AudioClip bombFireAC;
        [SerializeField] AudioClip[] bonkArrayAC;
        //[SerializeField] AudioClip bonk2AC;
        //[SerializeField] AudioClip bonk3AC;
        //[SerializeField] AudioClip explosion2AC;
        //[SerializeField] AudioClip explosion2aAC;
        //[SerializeField] AudioClip explosion3AC;
        //[SerializeField] AudioClip explosion3aAC;
        [SerializeField] AudioClip[] explosionArrayAC;
        [SerializeField] AudioClip thruster1AC;
        [SerializeField] AudioClip thruster2AC;
        [SerializeField] AudioClip winThemeAC;
        //private AudioSource audioSource;
        private Coroutine forwardThrustCR;
        private Coroutine rotarteThrustCR;
        private bool forwardThrustPlaying;
        private bool rotateThrustBool;
        private GameObject forwardThrustAudio;
        private AudioSource rotateThrustAudio;

        private void Start()
        {
            //audioSource = GetComponent<AudioSource>();
        }

        public void PlayBombFire()
        {
            AudioSource.PlayClipAtPoint(bombFireAC, Camera.main.transform.position);
        }
        public void PlayBonkAC(int intensity)
        {
            {
                AudioSource.PlayClipAtPoint(bonkArrayAC[intensity], Camera.main.transform.position, 0.2f);
                Debug.Log("playing bonk");
            }
        }
        public void PlayExplosion(int index)
        {
            int whichExplosionToPlay = ChooseWhichExplosionToPlay(index);
            Debug.Log("play explosion " + whichExplosionToPlay.ToString());
            AudioSource.PlayClipAtPoint(explosionArrayAC[whichExplosionToPlay], Camera.main.transform.position, 0.4f);
        }
        private int ChooseWhichExplosionToPlay(int index)
        {
            if (index == 0)
            {
                return Random.Range(0, 2);
            }
            else if (index == 1)
            {
                return Random.Range(2, 4);
            }
            return 0;
        }
        public void StartForwardThrustAudio()
        {
            if (!forwardThrustPlaying)
            {
                forwardThrustPlaying = true;
                thruster1.Play();
                Debug.Log("play forward thruster start");
            }
        }
        public void StopForwardThrustAudio()
        {
            if (forwardThrustPlaying)
            {
                forwardThrustPlaying = false;
                thruster1.Stop();
                Debug.Log("playe forward thruster stop");
            }
        }
        //public void StartForwardThrustAudio()
        //{
        //    forwardThrustBool = true;
        //    if (forwardThrustCR == null)
        //    {
        //        forwardThrustCR = StartCoroutine(ForwardThrustAudio());
        //    }
        //}
        //IEnumerator ForwardThrustAudio()
        //{
        //    if (forwardThrustBool)
        //            {
        //                forwardThrustAudio = PlayClipAt(thruster1AC, Camera.main.transform.position);
        //                yield return new WaitForSecondsRealtime(1.5f);
        //                StartCoroutine(ForwardThrustAudio());
        //    }
        //}
        //stop foward thrust aduio
        //public void StopForwardThrustAudio()
        //{
        //    forwardThrustBool = false;
        //    Destroy(forwardThrustAudio);
        //    if (forwardThrustCR != null)
        //    {
        //        StopCoroutine(forwardThrustCR);
        //    }

        //}

        private GameObject PlayClipAt(AudioClip clip, Vector3 pos)
        {
            GameObject tempGO = new GameObject();
            AudioSource aSource = tempGO.AddComponent<AudioSource>();
            aSource.clip = clip;
            aSource.Play();
            Destroy(tempGO, clip.length);
            return tempGO;
        }
    }

}

