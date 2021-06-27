using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public class Debris : MonoBehaviour
    {

        public void HitByBomb()
        {
            Destroy(gameObject, 1f);
        }
    }
}
