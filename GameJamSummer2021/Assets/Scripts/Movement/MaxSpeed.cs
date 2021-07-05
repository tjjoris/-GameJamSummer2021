using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Movement
{

    public class MaxSpeed : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector2 rbVelocity;
        private float speed;
        private float maxSpeed = 10f;
        private float radiansOfVelocity;
        void Update()
        {
            rb = GetComponent<Rigidbody2D>();
            rbVelocity = rb.velocity;
            //Debug.Log("rb velocity source " + rbVelocity.ToString());
            speed = rbVelocity.magnitude;
            radiansOfVelocity = Mathf.Atan2(rbVelocity.y, rbVelocity.x);
            //angleOfVelocity = angleOfVelocity * Mathf.Rad2Deg;
            if (speed > maxSpeed)
            {
                float xSpeed = Mathf.Cos(radiansOfVelocity) * maxSpeed;
                float ySpeed = Mathf.Sin(radiansOfVelocity) * maxSpeed;
                rb.velocity = new Vector2(xSpeed, ySpeed);
            }
        }
        public float GetSpeed()
        {
            return speed;
        }
        public float GetMaxSpeed()
        {
            return maxSpeed;
        }
        public Vector2 GetRBVelocity()
        {
            Debug.Log("rb velocity return " + rbVelocity.ToString());
            return rbVelocity;
        }
    }
}
