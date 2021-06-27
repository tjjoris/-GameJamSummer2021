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
        private float rotateAmount = 3.5f;
        private float accelerateAmount = 6f;

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
        }

        private void ForwardKey()
        {
            if (Input.GetKey(KeyCode.W))
            {
                mover.Accelerate(accelerateAmount);
            }
        }
        private void LeftKey()
        {
            if (Input.GetKey(KeyCode.A))
            {
                mover.Rotate(rotateAmount);
            }
        }
        private void RightKey()
        {
            if (Input.GetKey(KeyCode.D))
            {
                mover.Rotate(-rotateAmount);
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
