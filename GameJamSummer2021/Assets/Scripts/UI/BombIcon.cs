using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FreeEscape.UI
{
    public class BombIcon : MonoBehaviour
    {
        [SerializeField] Sprite bombArmed;
        [SerializeField] Sprite bombUnarmed;
        [SerializeField] TMPro.TextMeshProUGUI tMPro;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
            tMPro = GetComponentInChildren<TMPro.TextMeshProUGUI>();
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
