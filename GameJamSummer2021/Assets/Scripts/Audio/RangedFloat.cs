using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace FreeEscape
{
    [System.Serializable]
    public class RangedFloat
    {
        private Vector2 DynamicRange = new Vector2(0f,1f);
        public float Min {get {return DynamicMinMax.x;}}
        public float Max {get {return DynamicMinMax.y;}}

        [MinMaxSlider("DynamicRange", true)]
        public Vector2 DynamicMinMax = new Vector2(0.4f, 0.6f);
        
        public void SetMinMaxRange(float _min, float _max)
        {
            DynamicRange.x = _min;
            DynamicRange.y = _max;
        }
    }
}
