using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FreeEscape.UI
{
    public class AbilityIcon : MonoBehaviour
    {
        [SerializeField] Sprite bombArmed;
        [SerializeField] Sprite bombUnarmed;
        [SerializeField] TextMeshProUGUI tMPro;
        [SerializeField] private Image image;

        public void SetupAbilityIcon(I_AbilityProperties _AbilityProperties, int _ammo)
        {
            bombArmed = _AbilityProperties.IconArmed;
            bombUnarmed = _AbilityProperties.IconDisarmed;
            image.sprite = bombUnarmed;
            tMPro.text = "" + _ammo;
        }
        public void BombActive()
        {
            image.sprite = bombArmed;
        }
        public void BombUnarmed()
        {
            image.sprite = bombUnarmed;
        }
        public void ShowAmmo(int newAmmo)
        {
            tMPro.text = newAmmo.ToString();
        }
    }
}
