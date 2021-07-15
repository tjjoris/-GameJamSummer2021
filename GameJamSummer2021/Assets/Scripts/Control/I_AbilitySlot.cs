using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public interface I_AbilitySlot
    {
        GameObject AbilityPrefab { get; }
        int Ammo { get; set; }
        bool IsOnCooldown { get; }
        AbilityIcon AbilityIcon { get; set; }
        void UpdateAmmo();
        
        IEnumerator ActivateCooldown();
    }
}
