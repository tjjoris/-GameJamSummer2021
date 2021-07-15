using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Control;

namespace FreeEscape.UI
{
    public class AbilityIconManager : MonoBehaviour
    {
        int numberOfbombtypes;
        [SerializeField] private GameObject abilityIconPrefab;
        [SerializeField] private AbilityManager abilityManager;
        private List<AbilityIcon> abilityIcons = new List<AbilityIcon>();
        private Dictionary<int, I_AbilitySlot> abilitySlotDictionary;


        public void GenerateIcon(I_AbilitySlot _abilitySlot)
        {
            GameObject iconObj = Instantiate(abilityIconPrefab, this.transform);
            AbilityIcon abilityIcon = iconObj.GetComponent<AbilityIcon>();
            if (abilityIcon == null)
                {Debug.LogWarning("Could not obtain AbilityIcon script"); return;}

            GameObject abilityPrefab = _abilitySlot.AbilityPrefab;
            if (abilityPrefab == null)
            { Debug.LogWarning("AbilityIconManager could not obtain Ability Prefab"); return; }

            I_AbilityProperties abilityProperties = abilityPrefab.GetComponent<I_AbilityProperties>();
            if (abilityProperties == null)
            { Debug.LogWarning("AbilityIconManager could not locate Ability Properties."); return; }

            _abilitySlot.AbilityIcon = abilityIcon;
            
            abilityIcons.Add(abilityIcon);
            abilityIcon.SetupAbilityIcon(abilityProperties, _abilitySlot.Ammo);

            Debug.Log($"Generated Icon for {_abilitySlot.AbilityPrefab.name}.");
        }

        public void DisarmAll()
        {
            foreach (AbilityIcon icon in abilityIcons)
            {
                icon.BombUnarmed();
            }
        }

        public void ShowAmmo(int _abilityIndex, int _newAmmo)
        {
            if (abilityIcons[_abilityIndex] == null)
                { return; }
            
            abilityIcons[_abilityIndex].ShowAmmo(_newAmmo);
            
        }

    }
}
