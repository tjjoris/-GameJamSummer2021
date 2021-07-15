using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Audio;

namespace FreeEscape
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private static GameMaster GM;
        public static GameMaster Instance { get { return GM; } }
        [SerializeField] private GameObject soundManager;
        private AudioPlayerManager _audioPlayerManager;
        public int score;
        
        void Awake()
        {
            if(GM != null)
            GameObject.Destroy(GM);
            else
            GM = this;

            DontDestroyOnLoad(this);
        }
        
        public AudioPlayerManager AudioPlayerManager()
        {
            if (_audioPlayerManager == null)
            {
                _audioPlayerManager = soundManager.GetComponent<AudioPlayerManager>();
            } 
            return _audioPlayerManager;
        }
    }
}
