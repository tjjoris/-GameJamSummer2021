using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public interface I_AbilityLauncher
    {
        void ActivateAbility();
        void LauncherEnabled(bool state);
        void EquipAbility(I_AbilitySlot _abilitySlot, int _slotIndex);
        I_AbilityManager AbilityManager { set; }
    }
}
