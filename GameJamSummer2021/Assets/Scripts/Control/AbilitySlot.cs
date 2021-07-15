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
        [SerializeField] private AbilityIcon _abilityIcon;
        public AbilityIcon AbilityIcon { get{ return _abilityIcon; } set{ _abilityIcon = value; } }
        
        [SerializeField] private int ammo;
        public int Ammo { get { return ammo; } set { ammo = value; } }
        [SerializeField] private float _cooldown;
        private bool isOnCooldown = false;
        public bool IsOnCooldown { get { return isOnCooldown; } }

        public IEnumerator ActivateCooldown()
        {
            isOnCooldown = true;
            yield return new WaitForSeconds(_cooldown);

            isOnCooldown = false;
        }

        public void UpdateAmmo()
        {
            _abilityIcon.ShowAmmo(ammo);
        }
    }
}
