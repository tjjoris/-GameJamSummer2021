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
        private float targetProgress = 0f;
        private bool activateShaderProgression = false;
        [SerializeField] private AnimationCurve progressCurve;

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

        public void ApplyShaderEffect(float _timeToComplete, float _percentage)
        {
            if (spriteRenderer == null)
                { spriteRenderer = this.GetComponent<SpriteRenderer>(); }

            targetProgress = _percentage;
            activateShaderProgression = true;
            timeToComplete = _timeToComplete;

            if (_timeToComplete == 0)
            {
                spriteRenderer.material.SetFloat("_ProgressAmount", progressCurve.Evaluate(1));
            }
        }

        private void TickShader()
        {
            TrackShaderProgress();

            if (spriteRenderer.material)
            {
                spriteRenderer.material.SetFloat("_ProgressAmount", progressCurve.Evaluate(progress));
            }
        }

        private void TrackShaderProgress()
        {
            if (targetProgress == 0 && progress > targetProgress)
            {
                progress -= Time.deltaTime / timeToComplete;
                return;
            }

            if (progress >= targetProgress)
            {
                activateShaderProgression = false;
                progress = targetProgress;
                return;
            }

            progress += Time.deltaTime / timeToComplete;
        }
    }
}
