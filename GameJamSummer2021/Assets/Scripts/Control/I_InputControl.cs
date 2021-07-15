using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public interface I_InputControl
    {

        I_AbilityManager AbilityManager { set; }
        void PlayerControlsLocked(bool state);
    }
}
