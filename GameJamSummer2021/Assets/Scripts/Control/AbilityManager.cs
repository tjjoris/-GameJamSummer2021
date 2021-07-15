using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;
using FreeEscape.Bomb;

namespace FreeEscape.Control
{
    public class AbilityManager : MonoBehaviour, I_AbilityManager
    {
        [SerializeField] private List<AbilitySlot> abilitySlots;
        private I_AbilityLauncher abilityLauncher;
        private AbilityIconManager abilityIconManager;
        private Dictionary<int, I_AbilitySlot> abilitySlotDictionary;
        

        public void HookupPlayerAbilities(I_AbilityLauncher _launcher, AbilityIconManager _iconManager)
        {
            Debug.Log("Hooking up player abilities");
            abilityIconManager = _iconManager;
            abilityLauncher = _launcher;

            GenerateAbilities();
            EquipAbility(0);
        }

        private void GenerateAbilities()
        {
            abilitySlotDictionary = new Dictionary<int, I_AbilitySlot>();
            int i = 0;

            foreach (I_AbilitySlot abilitySlot in abilitySlots)
            {
                if (abilitySlot == null)
                    { Debug.Log("GenerateAbility slot was null."); return; }

                abilityIconManager.GenerateIcons(abilitySlot);

                Debug.Log($"added {abilitySlot.AbilityPrefab.name} in slot {i}.");

                abilitySlotDictionary.Add(i, abilitySlot);

                i++;
            }
        }

        public void EquipAbility(int _slotIndex)
        {
            Debug.Log("selected: " + abilitySlotDictionary[_slotIndex].AbilityPrefab.name);

            if (abilitySlotDictionary[_slotIndex] == null)
            { Debug.Log("No Ability in slot " + _slotIndex); return; }

            // GameObject abilityPrefab = abilitySlotDictionary[_slotIndex].AbilityPrefab;
            abilityLauncher.EquipAbility(abilitySlotDictionary[_slotIndex], _slotIndex);
            abilityIconManager.DisarmAll();
            abilitySlotDictionary[_slotIndex].AbilityIcon.BombActive();
        }

        public bool OutOfAmmo(int _abilityIndex)
        {
            I_AbilitySlot activeAbility = abilitySlotDictionary[_abilityIndex];
            if (activeAbility.Ammo > 0 || activeAbility.Ammo == -1)
            { return false; }
            return true;
        }

        public void UseAmmo(int _slotIndex)
        {
            I_AbilitySlot ability = abilitySlotDictionary[_slotIndex];
            if (ability.Ammo == -1)
                { return; }
            
            ability.Ammo --;

            ability.UpdateAmmo();
        }
    }
}
