using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape
{
    [System.Serializable]
    public class RangedFloat
    {
        [Range(0f, 1f)]
        public float Min = 0;
        [Range(0f, 1f)]
        public float Max = 1;
        
    }
}
