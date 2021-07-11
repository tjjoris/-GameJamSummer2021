using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.UI
{
    //[CreateAssetMenu(fileName = "New Dialogue", menuName = "NewDialogue")]
    [System.Serializable]

    public class Dialogue //: ScriptableObject
    {
        [TextArea(3, 10)]
        public string[] dialogueString;
    }
}
