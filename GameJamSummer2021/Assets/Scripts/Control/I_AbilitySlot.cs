using System;
using System.Collections;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public interface I_AbilitySlot
    {
        GameObject AbilityPrefab { get; }
        int Ammo { get; set; }
        float Cooldown { set; }
        bool IsOffCooldown { get; }
        AbilityIcon AbilityIcon { get; set; }
        void UseAmmo();
        bool OutOfAmmo();
        void UpdateAmmo();
        event EventHandler AbilityOffCooldown;
        IEnumerator BeginCooldown();
    }
}
