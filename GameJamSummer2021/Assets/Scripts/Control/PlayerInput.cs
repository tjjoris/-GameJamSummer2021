using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Movement;

namespace FreeEscape.Control
{
    public class PlayerInput : MonoBehaviour
    {
        private Mover mover;
        private float rotateAmount = 1f;

        void Start()
        {
            mover = GetComponent<Mover>();
        }


        void Update()
        {
            ForwardKey();
            LeftKey();
            RightKey();
        }

        private void ForwardKey()
        {
            if (Input.GetKey(KeyCode.W))
            {

            }
        }
        private void LeftKey()
        {
            if (Input.GetKey(KeyCode.A))
            {
                mover.Rotate(-rotateAmount);
            }
        }
        private void RightKey()
        {
            if (Input.GetKey(KeyCode.D))
            {
                mover.Rotate(rotateAmount);
            }
        }
    }
}
