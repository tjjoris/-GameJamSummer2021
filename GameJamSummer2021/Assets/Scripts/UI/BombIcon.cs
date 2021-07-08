using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FreeEscape.UI
{
    public class BombIcon : MonoBehaviour
    {
        [SerializeField] Sprite bombArmed;
        [SerializeField] Sprite bombUnarmed;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }
        public void BombActive()
        {
            _image.sprite = bombArmed;
        }
        public void BombUnarmed()
        {
            _image.sprite = bombUnarmed;
        }
    }
}
