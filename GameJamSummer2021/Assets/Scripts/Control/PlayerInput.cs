using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Movement;

namespace FreeEscape.Control
{
    public class PlayerInput : MonoBehaviour
    {
        private Mover mover;
        private LaunchBomb launchBomb;
        [SerializeField] private float rotateAmount = 90f;
        private float accelerateAmount = 6f;
        private bool rotateRight;
        private bool rotateLeft;

        void Start()
        {
            mover = GetComponent<Mover>();
            launchBomb = GetComponent<LaunchBomb>();
        }


        void Update()
        {
            ForwardKey();
            LeftKey();
            RightKey();
            SpaceKey();
            SendRotation();
        }

        private void ForwardKey()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mover.Accelerate(true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                mover.Accelerate(false);
            }
        }
        private void LeftKey()
        {
            if (Input.GetKey(KeyCode.A))
            {
                rotateLeft = true;
            }
            else
            {
                rotateLeft = false;
            }
        }
        private void RightKey()
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotateRight = true;
            }
            else
            {
                rotateRight = false;
            }
        }
        private void SendRotation()
        {
            if ((rotateRight && rotateLeft) || (!rotateRight && !rotateLeft))
                {
                mover.Rotate(0);
            }
            else if (rotateLeft)
            {
                mover.Rotate(rotateAmount);
            }
            else if (rotateRight)
                mover.Rotate(-rotateAmount);
        }
        private void SpaceKey()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                launchBomb.LaunchBombAction();
            }
        }
    }
}
