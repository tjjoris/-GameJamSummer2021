using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class LoseCanvas : MonoBehaviour
    {
        private Canvas canvas;
        // Start is called before the first frame update
        void Start()
        {
            canvas = GetComponent<Canvas>();
            canvas.gameObject.SetActive(false);
        }

        public void ShowLoseCanvas()
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
