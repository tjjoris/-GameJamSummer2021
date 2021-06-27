using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class PlayerCollidesWithEdge : MonoBehaviour
    {
        [SerializeField] private RestartCanvas restartCanvas;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("game end");
                restartCanvas.ShowGameEndCanvas();
                Time.timeScale = 0f;
            }
        }
    }
}
