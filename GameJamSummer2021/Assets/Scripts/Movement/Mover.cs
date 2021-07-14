using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Audio;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private bool accelBool; //true if acccelerating forward
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField]private float accelAmount;
        [SerializeField] private float rotateAmount;
        private Rigidbody2D rb;
        private AudioPlayerManager _audioPlayerManager;
        

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Accelerate(bool accelBool)
        {
            this.accelBool = accelBool;
            if (accelBool)
            {
                AudioPlayerManager.StartMainThrustersAudio();
            }
            else
            {
                AudioPlayerManager.StopMainThrustersAudio();
            }
        }

        private AudioPlayerManager AudioPlayerManager
        {
            get
            {
                if (_audioPlayerManager == null)
                { _audioPlayerManager = GetComponent<AudioPlayerManager>();}
                return _audioPlayerManager;
            }
        }

        public void Rotate(float _rotateDir)
        {
            //Debug.Log("rotate " + _rotateDir);
            gameObject.transform.Rotate(0, 0, rotateAmount * _rotateDir * Time.deltaTime);
            UpdateAnimatorRotation(_rotateDir);
        }
        private void UpdateAnimatorRotation(float _rotateDir)
        {
            if (_rotateDir == 0)
            {
                playerAnimator.InputLeft(false);
                playerAnimator.InputRight(false);
                AudioPlayerManager.StopRotatingThrustersAudio();
            }
            else if (_rotateDir > 0)
            {
                playerAnimator.InputLeft(true);
                AudioPlayerManager.StartRotatingThrustersAudio();
            }
            else if (_rotateDir < 0)
            {
                playerAnimator.InputRight(true);
                AudioPlayerManager.StartRotatingThrustersAudio();
            }
        }

        private void FixedUpdate()
        {
            if (accelBool)
            {
                Vector2 forwardV2 = new Vector2(0, accelAmount);
                rb.AddRelativeForce(forwardV2);
                playerAnimator.InputUp(true);
            }
            else
            {
                playerAnimator.InputUp(false);
            }
        }

    }
}
