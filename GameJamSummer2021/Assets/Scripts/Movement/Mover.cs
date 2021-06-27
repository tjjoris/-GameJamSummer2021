using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private float forwardSpeed;
        private Vector2 velocity;
        private float maxSpeed = 5;
        private Rigidbody2D rigidbody2D;
        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }


        void Update()
        {

        }
        public void Accelerate(float accelAmount)
        {
            forwardSpeed += accelAmount;
            Vector2 forwardV2 = new Vector2(0, accelAmount);
            rigidbody2D.AddRelativeForce(forwardV2);
        }
        public void Rotate(float rotateAngle)
        {
            gameObject.transform.Rotate(0, 0, rotateAngle * Time.deltaTime);
        }
    }
}
