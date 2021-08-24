using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Math
{
    [CreateAssetMenu(fileName = "New SmoothStepFunction", menuName = "SmoothStepFunction")]
    [System.Serializable]
    public class SmoothStep : ScriptableObject
    {
        [SerializeField] private float smoothStepStrength;
        [SerializeField] private float currentTargetValue;
        [SerializeField] private float threshold;
        [SerializeField] private float prevTarget = 0f;
        [SerializeField] private float easeInStrength;
        [SerializeField] private float currentProgress;
        [SerializeField] private float easeInComparator = 2f;

        private void OnEnable()
        {
            currentTargetValue = 0f;
        }

        public float EaseInPercent(float x)
        {
            return x*x*(easeInComparator - x);
        }

        private bool ChangeDir(float _target)
        {
            if (_target != prevTarget)
            {
                prevTarget = _target;
                return true;
            }
            return false;
        }

        public float EaseIn(float _target, float _dt)
        {
            if (ChangeDir(_target))
                { currentProgress = 0f; }

            currentProgress += (easeInStrength * _dt);

            if (currentProgress >= 1)
                { currentProgress = 1; }
            
            return EaseInPercent(currentProgress);
        }
    }
}
