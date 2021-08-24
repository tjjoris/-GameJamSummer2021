using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Math
{
    [CreateAssetMenu(fileName = "New PID Controller", menuName = "PID Controller")]
    [System.Serializable]
    public class PID_Controller : ScriptableObject
    {
        /*Proportional Integral Dirivitive controller.
        Feed in the difference between current value and smoothedTarget value, adjust the gains below and the returned value should provide
        a self adjusting curve that slopes towards it's smoothedTarget, with the ability to oversteer or dampen.
        */
        [SerializeField] private float Kp = 1; //Proportional Spring: The speed or natural frequency
        [SerializeField] private float Ki = 0;
        [SerializeField] private float Kd = 0.1f; //Dirivitive Damper: 0 no dampening, 0.693 overshoot but no rubberband, 1+ no overshoot
        [SerializeField] float currentValue = 0;
        [SerializeField] float currentVelocity = 0;
        [SerializeField] private float k_p;
        [SerializeField] private float k_d;
        [SerializeField] private float threshold;
        [SerializeField] private float smoothStepStrength;

        private void OnEnable()
        {
            currentValue = 0f;
            currentVelocity = 0f;
        }

        public float GetOutput(float _target, float _strength, float _dt)
        {            
            k_p = Kp * Kp;
            k_d = 2 * Kd * Kp;
            float errorValue = _target - currentValue * _strength;
            if (errorValue > -threshold && errorValue < threshold)
            {
                currentVelocity = 0f;
                errorValue = 0f;
            }

            float acceleration = (k_p * (errorValue)) - (k_d * currentVelocity);
            //acceleration *= _strength;

            currentVelocity += acceleration * _dt;
            currentValue += currentVelocity * _dt;
            return currentValue;

        }
    }
}
