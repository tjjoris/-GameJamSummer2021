using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FreeEscape.Core;

namespace FreeEscape.UI
{
    public class DialogueManager : MonoBehaviour
    {
        public Queue<string> sentences;
        [SerializeField] private CutsceneManager cutsceneManager;
        [SerializeField] private TextMeshProUGUI dialogueBox;
        private Animator animator;
        private bool dialogueCompleted = false;
        void Awake()
        {
            sentences = new Queue<string>();
            animator = this.GetComponent<Animator>();
            animator.SetBool("DialogueActive", false);
        }

        public void StartDialogue (Dialogue _dialogue)
        {
            animator.SetBool("DialogueActive", true);
            sentences.Clear();

            foreach (string _sentence in _dialogue.dialogueString)
            {
                sentences.Enqueue(_sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            dialogueBox.text = sentence;
        }

        private void EndDialogue()
        {
            if (dialogueCompleted == true)
            {
                return;
            }

            animator.SetBool("DialogueActive", false);
            dialogueCompleted = true;
            StartCoroutine(cutsceneManager.BeginLevelSequence());
        }
    }
}
