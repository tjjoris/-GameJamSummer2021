using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public interface I_AbilitySlot
    {
        GameObject AbilityPrefab { get; }
        int Ammo { get; set; }
    }
}
