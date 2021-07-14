using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FreeEscape.UI
{
    public class AbilityIcon : MonoBehaviour
    {
        Sprite bombArmed;
        Sprite bombUnarmed;
        TextMeshProUGUI tMPro;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            tMPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }

        public void SetupAbilityIcon(I_AbilityProperties _AbilityProperties)
        {
            bombArmed = _AbilityProperties.IconArmed;
            bombUnarmed = _AbilityProperties.IconDisarmed;
        }
        public void BombActive()
        {
            _image.sprite = bombArmed;
        }
        public void BombUnarmed()
        {
            _image.sprite = bombUnarmed;
        }
        public void ShowAmmo(int newAmmo)
        {
            tMPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
            tMPro.text = newAmmo.ToString();
        }
    }
}
