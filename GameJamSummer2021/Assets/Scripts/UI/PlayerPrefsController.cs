using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.UI
{
    public class PlayerPrefsController : MonoBehaviour
    {
        const string MASTER_VOLUME_KEY = "master volume";
        const string MASTER_MUSIC_VOLUME_KEY = "master music volume";
        const float MIN_VOLUME = 0f;
        const float MAX_VOLUME = 1f;
        const string FIRST_TIME_KEY = "first time";
        const string FIRST_TIME_MUSIC_KEY = "first time music";
        // Start is called before the first frame update
        void Start()
        {
            //PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, 0.7f);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public static void SetMasterVolume(float volume)
        {
            if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            {
                //Debug.Log("master volume set to " + volume.ToString());
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            }
        }
        public static float GetMasterVolume()
        {
            //Debug.Log("get master volume " + PlayerPrefs.GetFloat(MASTER_VOLUME_KEY).ToString());
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
            
        }
        public static void SetMasterMusicVolume(float volume)
        {
            if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            {
                PlayerPrefs.SetFloat(MASTER_MUSIC_VOLUME_KEY, volume);
            }
        }
        public static float GetMasteMusicVolume()
        {
            return PlayerPrefs.GetFloat(MASTER_MUSIC_VOLUME_KEY);
        }
        public static bool GetFirstTime()
        {
            int isFirstTime = PlayerPrefs.GetInt(FIRST_TIME_KEY);
                if (isFirstTime == 0)
            {
                Debug.Log("first time");
                PlayerPrefs.SetInt(FIRST_TIME_KEY, 1);
                return true;
            }
            return false;
        }
        public static bool GetFirstTimeMusic()
        {
            int isFirstTime = PlayerPrefs.GetInt(FIRST_TIME_MUSIC_KEY);
            if (isFirstTime == 0)
            {
                Debug.Log("first time music");
                PlayerPrefs.SetInt(FIRST_TIME_MUSIC_KEY, 1);
                return true;
            }
            return false;
        }

    }
}
