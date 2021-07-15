using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;
using FreeEscape.Core;

namespace FreeEscape.Damage
{
    public class PlayerHealth : MonoBehaviour, I_ExplosionDamageReaction
    {
        private HPBar hPBar;
        private float hPCurrent = 100f;
        private float hPMax = 100f;
        private LevelManager levelManager;

        private void GetHPBar()
        {
            hPBar = FindObjectOfType<HPBar>();
            hPBar.UpdateHPSlider(hPCurrent / hPMax);
            levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
            if (levelManager == null) {Debug.Log("Player Health could not locate LevelManager.");}
        }
        public void TakeDamage(float amount)
        {
            if (hPBar == null) {GetHPBar();}
            hPCurrent -= amount;
            hPBar.UpdateHPSlider(hPCurrent / hPMax);
            CheckIfDead();
        }
       private void CheckIfDead()
        {
            if (hPCurrent <= 0f)
            {
                levelManager.PlayerDestroyed();
            }
        }

        public void HitByExplosion(BombExplosion _explosion)
        {
            TakeDamage(_explosion.Damage);
        }
        public void TriggerExplosionRange()
        {
            //TODO: explosion was close. Visual/audio effect?
        }
    }
}
