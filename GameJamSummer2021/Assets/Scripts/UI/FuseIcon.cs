using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeEscape.UI
{
    public class FuseIcon : MonoBehaviour, I_ChangeBombActive
    {
        [SerializeField] Sprite fuseArmed;
        [SerializeField] Sprite fuseUnarmed;
        private Sprite fuseIcon;

        private void Start()
        {
            fuseIcon = GetComponent<Image>().sprite;
        }
        public void BombActive()
        {
            fuseIcon = fuseArmed;
        }
        public void BombUnarmed()
        {
            fuseIcon = fuseUnarmed;
        }
    }
}
