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
        [SerializeField] private PlayerAnimator playerAnimator;
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
                playerAnimator.InputUp(true);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                mover.Accelerate(false);
                playerAnimator.InputUp(false);
            }
        }
        private void LeftKey()
        {
            if (Input.GetKey(KeyCode.A))
            {
                rotateLeft = true;
                playerAnimator.InputLeft(true);
            }
            else
            {
                rotateLeft = false;
                playerAnimator.InputLeft(false);
            }
        }
        private void RightKey()
        {
            if (Input.GetKey(KeyCode.D))
            {
                rotateRight = true;
                playerAnimator.InputRight(true);
            }
            else
            {
                rotateRight = false;
                playerAnimator.InputRight(false);
            }
        }
        private void SendRotation()
        {
            if (rotateLeft && !rotateRight)
            {
                mover.Rotate(1);
            }
            else if (rotateRight && !rotateLeft)
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
