using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Display
{
    public class ProgressShader : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private float timeToComplete;
        private float progress = 0.01f;
        private bool activateShaderProgression = false;

        private void Start()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }
        private void Update()
        {
             if (activateShaderProgression == true)
             {
                 TickShader();
             }
        }

        public void ApplyShaderEffect(float _timeToComplete)
        {
            activateShaderProgression = true;
            timeToComplete = _timeToComplete;
        }

        private void TickShader()
        {
            progress += Time.deltaTime / timeToComplete;
            if (spriteRenderer.material)
            {
                spriteRenderer.material.SetFloat("_ProgressAmount", progress);
            }
        }
    }
}
