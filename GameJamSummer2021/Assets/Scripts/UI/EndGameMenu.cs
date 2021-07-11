using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FreeEscape.UI
{
    public class EndGameMenu : MonoBehaviour
    {
 
        public void CompleteButton()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
