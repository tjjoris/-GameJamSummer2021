using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject abilitySlot00;
        [SerializeField] private GameObject abilitySlot01;
        [SerializeField] private GameObject abilitySlot02;
        private LaunchBomb launchBomb;
        private BombsIndicator bombsIndicator;
        
        
        private void Start()
        {
            bombsIndicator = FindObjectOfType<BombsIndicator>();
            launchBomb = this.GetComponent<LaunchBomb>();
            launchBomb.EquipBomb(abilitySlot00, 0);
        }

        public void EquipAbility00()
        {
            launchBomb.EquipBomb(abilitySlot00, 0);
            bombsIndicator.SetBombActive(0);
        }

        public void EquipAbility01()
        {
            launchBomb.EquipBomb(abilitySlot01, 1);
            bombsIndicator.SetBombActive(1);
        }
        public void EquipAbility02()
        {
            launchBomb.EquipBomb(abilitySlot02, 2);
            bombsIndicator.SetBombActive(2);
        }
    }
}
