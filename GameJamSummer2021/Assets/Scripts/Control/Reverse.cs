using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Movement;

namespace FreeEscape.Control
{
    public class Reverse : MonoBehaviour
    {
        float minAngleToNotRotate = 1f;
        float minSpeedToStop = 1f;
        private Mover mover;
        [SerializeField] private MaxSpeed maxSpeed;
        private void Start()
        {
            mover = GetComponent<Mover>();
            maxSpeed = GetComponent<MaxSpeed>();
        }
        public void ReverseFunction()

        {
            if (maxSpeed.GetSpeed() > 0)
            {
                Vector2 rbVelocity = maxSpeed.GetRBVelocity();
                Debug.Log("rb velocity " + rbVelocity.ToString());
                float angleOfTravel = Mathf.Atan2(rbVelocity.y, rbVelocity.x);
                angleOfTravel = Mathf.Rad2Deg * angleOfTravel;

                angleOfTravel = angleOfTravel - 270f;
                angleOfTravel = MakeIn360(angleOfTravel);

                //transform.eulerAngles = new Vector3(0, 0, angleOfTravel);
                float shipAngle = transform.eulerAngles.z;
                shipAngle = MakeIn360(shipAngle);
                RotateFunction(shipAngle, angleOfTravel);
            }
        }

        private void RotateFunction(float shipAngle, float angleOfTravel)
        {
            float angleDiff = angleOfTravel - shipAngle;
            angleDiff = MakeIn360(angleDiff);
            Debug.Log("angle of travel " + angleOfTravel.ToString() + " ship angle " + shipAngle.ToString() + " angeldiff "+ angleDiff.ToString());
            //Debug.Log("angle diff " + angleDiff.ToString());
            if ((angleDiff > minAngleToNotRotate && angleDiff <= 180))
            {
                mover.Rotate(1);
            }
            if ((angleDiff > 180 && angleDiff < 360 - minAngleToNotRotate))
            {
                mover.Rotate(-1);
            }
            bool isRotated = CheckIfRotated(angleOfTravel, angleDiff);
            if (isRotated)
            {
                ThrustInReverse();
            }
            else
            {
                mover.Accelerate(false);
            }
        }

        private bool CheckIfRotated(float angleOfTravel, float angleDiff)
        {
            if (angleDiff < minAngleToNotRotate || angleDiff > 360 - minAngleToNotRotate)
            {//make ship face in reverse
                transform.eulerAngles = new Vector3(0, 0, angleOfTravel);
                return true;
            }
            return false;
        }
        private void ThrustInReverse()
        {
            float speed = maxSpeed.GetSpeed();
            if (speed >= minSpeedToStop)
            {
                mover.Accelerate(true);
            }
            else
            {
                mover.Accelerate(false);
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }


        private static float MakeIn360(float _angle)
        {
            //Debug.Log("before " + _angle.ToString());
            while (_angle > 360f)
            {
                _angle -= 360f;
            }
            while (_angle < 0f)
            {
                _angle += 360f;
            }
            //Debug.Log("after " + _angle.ToString());

            return _angle;
        }
    }
}