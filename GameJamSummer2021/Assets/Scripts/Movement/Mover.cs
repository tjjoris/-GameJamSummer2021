using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Audio;
using FreeEscape.Math;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private bool accelBool; //true if acccelerating forward
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] PID_Controller pID_Controller;
        [SerializeField] SmoothStep smoothStepper;
        [SerializeField]private float accelAmount;
        [SerializeField] private float rotateAmount;
        [SerializeField] private float currentRotationDifference;
        private Rigidbody2D rb;
        private AudioPlayerManager _audioPlayerManager;
        

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            currentRotationDifference = 0f;
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

        private float GetRotationValue(float _rotateDir)
        {
            float dt = Time.deltaTime;
            float target = rotateAmount * _rotateDir;
            float rotationStrength = smoothStepper.EaseIn(_rotateDir, Time.deltaTime);
            float currentError = (target - currentRotationDifference);
            float value = pID_Controller.GetOutput(currentError, rotationStrength, dt);
            currentRotationDifference = value;

            return value;
        }

        public void Rotate(float _rotateDir)
        {
            //Debug.Log("rotate " + _rotateDir);
            //gameObject.transform.Rotate(0, 0, rotateAmount * _rotateDir * Time.deltaTime);
            float rotationValue = GetRotationValue(_rotateDir);
            //Debug.Log("rotation value: " + rotationValue);
            gameObject.transform.Rotate(0, 0, rotationValue * Time.deltaTime);
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
