using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Core
{
    public class RestartCanvas : MonoBehaviour
    {
        [SerializeField] private Canvas gameEndCanvas;
        // Start is called before the first frame update
        void Start()
        {
            gameEndCanvas.gameObject.SetActive(false);
        }

        
    }
}
