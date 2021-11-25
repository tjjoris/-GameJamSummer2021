using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FreeEscape
{
    [CreateAssetMenu(menuName = "Audio Events/Simple")]
    public class SimpleAudioEvent : AudioEvent
    {
        [SerializeField] private AudioClip[] clips;
        [SerializeField] private RangedFloat _volume;
        //[Range(0,2)]
        [SerializeField] private RangedFloat _pitch;

        public override void Play(AudioSource source)
        {
            if (clips.Length == 0) return;

            source.clip = clips[Random.Range(0, clips.Length)];
            source.volume = Random.Range(_volume.Min, _volume.Max);
            source.pitch = Random.Range(_pitch.Min, _pitch.Max);
            source.Play();
        }
    }
}
