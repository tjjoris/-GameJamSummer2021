using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.UI;

namespace FreeEscape.Control
{
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private GameObject fuseBomb;
        [SerializeField] private GameObject stickyBomb;
        [SerializeField] private GameObject proximityBomb;
        private LaunchBomb launchBomb;
        private BombsIndicator bombsIndicator;
        
        
        private void Start()
        {
            bombsIndicator = FindObjectOfType<BombsIndicator>();
            launchBomb = this.GetComponent<LaunchBomb>();
            launchBomb.EquipBomb(fuseBomb, 0);
        }

        public void EquipPrevAbility()
        {
            launchBomb.EquipBomb(fuseBomb, 0);
            bombsIndicator.SetBombActive(0);
        }

        public void EquipNextAbility()
        {
            launchBomb.EquipBomb(stickyBomb, 1);
            bombsIndicator.SetBombActive(1);
        }
        public void EquipProximityBomb()
        {
            //launchBomb.EquipBomb();
            launchBomb.EquipBomb(proximityBomb, 2);
            bombsIndicator.SetBombActive(2);
        }
    }
}
