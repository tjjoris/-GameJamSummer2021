using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Movement
{
    public class Mover : MonoBehaviour
    {
        private bool accelBool; //true if acccelerating forward
        [SerializeField]private float accelAmount = 10f;
        private float rotateAmount;
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
            if (rotateAmount != 0)
            {
                gameObject.transform.Rotate(0, 0, rotateAmount * Time.deltaTime);
            }
        }
        public void Accelerate(bool accelBool)
        {
            this.accelBool = accelBool;
        }
        public void Rotate(float rotateAmount)
        {
            this.rotateAmount = rotateAmount;
            
        }
        private void FixedUpdate()
        {
            if (accelBool)
            {
                Vector2 forwardV2 = new Vector2(0, accelAmount);
                rigidbody2D.AddRelativeForce(forwardV2);
            }
        }
    }
}
