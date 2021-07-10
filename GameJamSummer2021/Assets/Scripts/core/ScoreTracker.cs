using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


namespace FreeEscape
{
    public class ScoreTracker : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI scoreTMPro;
        [Header("[0]=Debris Destroyed, [1]=time remaining, [2]=bombs remaining")]
        private int[] scorePerTask;
        private int[] scorePerLevel;
        private bool[] clearedLevel;
        private int levelCount;
        //private List<int> scorePerTask = new List<int>();
        //private List<int> scorePerLevel = new List<int>();
        private int numberOfnonLevelScenes = 1;
        private int highScore;
        private int numberOfTasks = 3;
        private float debrisHpToScoreMult = 10;

        private void Start()
        {
            levelCount = SceneManager.sceneCountInBuildSettings - numberOfnonLevelScenes;
            Debug.Log("level count " + levelCount.ToString());
            scorePerTask = new int[numberOfTasks];
            clearedLevel = new bool[levelCount];
            scorePerLevel = new int[levelCount];

        }
        public void ResetScorePerTask()
            {
                for (int i=0; i<scorePerTask.Length; i++)
            {
                scorePerTask[i] = 0;
            }
            }
        public void AddDebrisScore(float debrisScore)
        {
            float floatScore = debrisScore * debrisHpToScoreMult;
            int intScore = Mathf.FloorToInt(floatScore);
            scorePerTask[0] += intScore;
        }
        public int ScoreOfTask(int task)
        {
            return scorePerTask[task];
        }
        public void ResetScoreForEachLevel()
        {
            for (int i=0; i<levelCount; i++)
            {
                scorePerLevel[i] = 0;
                clearedLevel[i] = false;
            }
        }
        public void ClearedThisLevel(bool cleared)
        {
            clearedLevel[SceneManager.GetActiveScene().buildIndex] = cleared;
        }
        public void FinishedLevel()
        {
            for (int i = 0; i < numberOfTasks; i++)
            {
                scorePerLevel[SceneManager.GetActiveScene().buildIndex] += scorePerTask[i];
                }
        }
    }
}
