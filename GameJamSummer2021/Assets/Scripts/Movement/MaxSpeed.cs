using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Movement
{

    public class MaxSpeed : MonoBehaviour
    {
        private Vector2 rbVelocity;
        private float speed;
        private float maxSpeed = 10f;
        void Update()
        {
            rbVelocity = GetComponent<Rigidbody2D>().velocity;
            //Debug.Log("rb velocity source " + rbVelocity.ToString());
            speed = rbVelocity.magnitude;
        }
        public float GetSpeed()
        {
            return speed;
        }
        public Vector2 GetRBVelocity()
        {
            Debug.Log("rb velocity return " + rbVelocity.ToString());
            return rbVelocity;
        }
    }
}
