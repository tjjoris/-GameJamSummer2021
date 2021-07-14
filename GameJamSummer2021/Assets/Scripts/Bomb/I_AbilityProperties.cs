using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape
{
    public interface I_AbilityProperties
    {
        float launchVelocity { get; }
        float cooldown { get; }
        SpriteRenderer spriteRenderer { get; }
        Animator animator { get; }
        AudioClip launchAudioClip { get; }
        bool FrontLaunch { get; }
        Sprite IconArmed { get; }
        Sprite IconDisarmed { get; }
        
        bool IsOnCoolDown();
    }
}
