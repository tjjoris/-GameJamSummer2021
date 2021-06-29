using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;
using FreeEscape.Core;

namespace FreeEscape.Damage
{
    public class PlayerHealth : MonoBehaviour
    {
        private HPBar hPBar;
        private float hPCurrent = 100f;
        private float hPMax = 100f;
        [SerializeField] private LoseCanvas loseCanvas;
        // Start is called before the first frame update
        void Start()
        {
            hPBar = FindObjectOfType<HPBar>();
            hPBar.UpdateHPSlider(hPCurrent / hPMax);
            //loseCanvas = FindObjectOfType<LoseCanvas>();
        }
        public void TakeDamage(float amount)
        {
            hPCurrent -= amount;
            hPBar.UpdateHPSlider(hPCurrent / hPMax);
            CheckIfDead();
        }
       private void CheckIfDead()
        {
            if (hPCurrent <= 0f)
            {
                loseCanvas.ShowLoseCanvas();
                Time.timeScale = 0f;
            }
        }
    }
}
