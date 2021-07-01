using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Movement;
using FreeEscape.Display;

namespace FreeEscape.Control
{
    public class PlayerInput : MonoBehaviour
    {
        private Mover mover;
        private LaunchBomb launchBomb;
        private Reverse reverse;
        private bool rotateRight;
        private bool rotateLeft;
        private bool reverseBool;

        void Start()
        {
            mover = GetComponent<Mover>();
            launchBomb = GetComponent<LaunchBomb>();
            reverse = GetComponent<Reverse>();
        }


        void Update()
        {
            ForwardKey();
            LeftKey();
            RightKey();
            ReverseKey();
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
        private void ReverseKey()
        {
            if (Input.GetKey(KeyCode.S))
            {
                reverseBool = true;
                reverse.ReverseFunction();
            }
            else
            {
                reverseBool = false;
            }
        }
        private void SendRotation()
        {
            if (rotateLeft && rotateRight || !rotateLeft && !rotateRight)
            {
                mover.Rotate(0);
            }
            else if (rotateLeft)
            {
                mover.Rotate(1);
            }
            else if (rotateRight)
            {
                mover.Rotate(-1);
            }
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
