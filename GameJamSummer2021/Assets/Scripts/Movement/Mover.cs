using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private bool accelBool; //true if acccelerating forward
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField]private float accelAmount = 10f;
        [SerializeField] private float rotateAmount = 90f;
        private float forwardSpeed;
        private Vector2 velocity;
        private float maxSpeed = 5;
        private Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Accelerate(bool accelBool)
        {
            this.accelBool = accelBool;
        }
        public void Rotate(float _rotateDir)
        {
            gameObject.transform.Rotate(0, 0, rotateAmount * _rotateDir * Time.deltaTime);
            UpdateAnimatorRotation(_rotateDir);
        }
        private void UpdateAnimatorRotation(float _rotateDir)
        {
            if (_rotateDir == 0)
            {
                playerAnimator.InputLeft(false);
                playerAnimator.InputRight(false);
            }
            else if (_rotateDir > 0)
            {
                playerAnimator.InputLeft(true);
            }
            else if (_rotateDir < 0)
            {
                playerAnimator.InputRight(true);
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
