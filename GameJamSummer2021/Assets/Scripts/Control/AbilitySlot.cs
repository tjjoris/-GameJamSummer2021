using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    [System.Serializable]
    public class AbilitySlot : I_AbilitySlot
    {
        [SerializeField] private GameObject abilityPrefab;
        public GameObject AbilityPrefab { get { return abilityPrefab; } }
        private AbilityIcon _abilityIcon;
        public AbilityIcon AbilityIcon { get{ return _abilityIcon; } set{ _abilityIcon = value; } }
        
        [SerializeField] private int ammo;
        public int Ammo { get { return ammo; } set { ammo = value; } }
        private float _cooldown;
        public float Cooldown { set { _cooldown = value; } }
        private bool isOffCooldown = true;
        public bool IsOffCooldown { get { return isOffCooldown; } }
        public event EventHandler AbilityOffCooldown;

        public IEnumerator BeginCooldown()
        {
            isOffCooldown = false;
            yield return new WaitForSeconds(_cooldown);

            isOffCooldown = true;
            AbilityOffCooldown?.Invoke(this, EventArgs.Empty);
        }


        public void UseAmmo()
        {
            if (ammo > 0)
            ammo --;
            UpdateAmmo();
        }

        public bool OutOfAmmo()
        {
            if (ammo > 0 || ammo == -1)
            {
                return false;
            }
            
            return true;
        }
        public void UpdateAmmo()
        {
            _abilityIcon.ShowAmmo(ammo);
        }
    }
}
