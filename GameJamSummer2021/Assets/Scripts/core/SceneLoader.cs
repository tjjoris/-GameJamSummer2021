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
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
    }
}
