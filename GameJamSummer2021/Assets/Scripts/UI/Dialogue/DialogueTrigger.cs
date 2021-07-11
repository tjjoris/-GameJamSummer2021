using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.UI
{
    [RequireComponent(typeof(DialogueManager))]
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private Dialogue dialogue;
        private DialogueManager dialogueManager;
        
        private void Awake()
        {
            dialogueManager = this.GetComponent<DialogueManager>();
        }

        public void StartDialogue()
        {
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
