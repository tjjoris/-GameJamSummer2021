using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public class Debris : MonoBehaviour
    {
        [SerializeField] private bool resistantDebris;
        //public bool GetResistantDebris()
        //{
        //    return resistantDebris;
        //}
        public void HitByBomb(bool bigExplosion)
        {
            if ((bigExplosion && resistantDebris) || (!bigExplosion && !resistantDebris))
            Destroy(gameObject);
        }
    }
}
