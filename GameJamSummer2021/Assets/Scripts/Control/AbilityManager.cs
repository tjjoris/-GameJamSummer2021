using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;
using FreeEscape.Bomb;

namespace FreeEscape.Control
{
    public class AbilityManager : MonoBehaviour, I_AbilityManager
    {
        [SerializeField] private GameObject abilitySlot00;
        [SerializeField] private GameObject abilitySlot01;
        [SerializeField] private GameObject abilitySlot02;

        [SerializeField] private List<AbilitySlot> abilitySlots;
        private Dictionary<int, I_AbilityProperties> abilitySlotProperty;
        private I_AbilityLauncher abilityLauncher;
        private AbilityIconManager abilityIconManager;
        
        
        // private void Start()
        // {
        //     abilityIconManager = FindObjectOfType<AbilityIconManager>();
        //     abilityLauncher = this.GetComponent<LaunchBomb>();
        //     abilityLauncher.EquipBomb(abilitySlot00, 0);
        // }

        public void HookupPlayerAbilities(I_AbilityLauncher _launcher, AbilityIconManager _iconManager)
        {
            Debug.Log("Hooking up player abilities");
            abilityIconManager = _iconManager;
            abilityLauncher = _launcher;
            abilityLauncher.EquipAbility(abilitySlot00, 0);

            GenerateAbilities();


        }

        private void GenerateAbilities()
        {
            abilitySlotProperty = new Dictionary<int, I_AbilityProperties>();
            int i = 0;

            foreach (I_AbilitySlot ability in abilitySlots)
            {
                GameObject abilityPrefab = ability.AbilityPrefab;
                I_AbilityProperties abilityProperties = abilityPrefab.GetComponent<I_AbilityProperties>();

                abilityIconManager.GenerateIcons(abilityProperties);
                abilitySlotProperty.Add(i, abilityProperties);
                
                i ++;

                Debug.Log("added " + abilityPrefab.name);
            }
        }

        public void EquipAbility(int _abilitySlot)
        {
            GameObject abilityPrefab = abilitySlots[_abilitySlot].AbilityPrefab;
            abilityLauncher.EquipAbility(abilityPrefab, _abilitySlot);
            abilityIconManager.SetBombActive(_abilitySlot);
        }
    }
}
