using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FreeEscape.Core
{
    public class DebrisEvent : MonoBehaviour
    {
        public event EventHandler DebrisDestroyedEvent;

        public void AlertEventWatchers()
        {
		    DebrisDestroyedEvent?.Invoke(this, EventArgs.Empty);
        } 
    }
}
