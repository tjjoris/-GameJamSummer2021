using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    [System.Serializable]
    public class AbilitySlot : I_AbilitySlot
    {
        [SerializeField] private GameObject abilityPrefab;
        public GameObject AbilityPrefab { get { return abilityPrefab; } }
        [SerializeField] private int ammo;
        public int Ammo { get { return ammo; } set { ammo = value; } }
    }
}
