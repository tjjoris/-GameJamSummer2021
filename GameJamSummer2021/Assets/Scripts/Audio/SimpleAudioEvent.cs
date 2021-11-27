using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEditor;
namespace FreeEscape
{
    [CreateAssetMenu(menuName = "Audio Events/Simple")]
    public class SimpleAudioEvent : AudioEvent
    {
        private AudioSource _previewer; 
        public void OnEnable()
        {
            _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();

        }

        public void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }

        [SerializeField] private AudioClip[] clips;

        [PropertySpace(20)]
        [MinMaxSlider(0,1, true)]
        public Vector2 _volume = new Vector2(0.4f, 0.6f);
        
        [MinMaxSlider(0,2, true)]
        public Vector2 _pitch = new Vector2(0.9f, 1.1f);

        [PropertySpace(20)]
        [Button(ButtonSizes.Gigantic)]
        private void SampleAudioEvent()
        {
            Play(_previewer);
        }

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0) return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(_volume.x, _volume.y);
            source.pitch = Random.Range(_pitch.x, _pitch.y);
            source.Play();
        }
    }
}
