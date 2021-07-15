using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public interface I_AbilityManager
    {
        void EquipAbility(int _abilitySlot);
        void HookupPlayerAbilities(I_AbilityLauncher _launchBomb, AbilityIconManager _abilityIconManager);
        bool OutOfAmmo(int slot);
        void UseAmmo(int slot);
        
    }
}
