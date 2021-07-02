using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FreeEscape
{
    public class SceneLoader : MonoBehaviour
    {

        public void restartLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
            Time.timeScale = 1f;
        }
    }
}
