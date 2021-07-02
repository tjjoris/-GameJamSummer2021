using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public class Abilities : MonoBehaviour
    {
        [SerializeField] private GameObject fuseBomb;
        [SerializeField] private GameObject stickyBomb;
        private LaunchBomb launchBomb;
        
        void Start()
        {
            launchBomb = this.GetComponent<LaunchBomb>();
            launchBomb.EquipBomb(fuseBomb);
        }

        public void EquipPrevAbility()
        {
            launchBomb.EquipBomb(fuseBomb);
        }

        public void EquipNextAbility()
        {
            launchBomb.EquipBomb(stickyBomb);
        }
    }
}
