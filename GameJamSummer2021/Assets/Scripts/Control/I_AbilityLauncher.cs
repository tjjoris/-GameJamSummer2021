using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public interface I_AbilityLauncher
    {
        void ActivateAbility();
        void LauncherEnabled(bool state);
        void EquipAbility(GameObject abilityPrefab, int slot);
    }
}
