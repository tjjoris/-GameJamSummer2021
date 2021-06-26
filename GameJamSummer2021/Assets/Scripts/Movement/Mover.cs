using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private Vector2 velocity;
        void Start()
        {

        }


        void Update()
        {

        }
        public void Rotate(float rotateAngle)
        {
            gameObject.transform.Rotate(0, 0, rotateAngle);
        }
    }
}
