using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeEscape.UI
{
    public class HPBar : MonoBehaviour
    {
        private Slider hPSlider;
        // Start is called before the first frame update
        void Start()
        {
            hPSlider = GetComponent<Slider>();
        }
        public void UpdateHPSlider(float hPFraction)
        {
            if (hPSlider == null) return;
            hPSlider.value = hPFraction;
        }
    }
}
