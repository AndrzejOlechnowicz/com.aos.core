using System;
using System.Collections;
using UnityEngine;

namespace AOsCore.SO_System.Binders.TMProBinders
{
    public class AnimatedFloatTextBinder : FloatTextBinder
    {
        public float animationTime = 1f;

        private float animProgress;

        private float val, prevVal, nextVal;

        private void Start()
        {
            prevVal = data.Value;
        }

        protected override void Refresh()
        {
            StartCoroutine(AnimationCoro());
        }

        private IEnumerator AnimationCoro()
        {
            animProgress = 0f;
            nextVal = data.Value;
            while (animProgress <= 1)
            {
                animProgress += Time.deltaTime * 1f / animationTime;
                
                val = prevVal + (nextVal - prevVal) * Mathf.Clamp01(animProgress);

                if (Time.frameCount % 3 == 0)
                {
                    _text.SetText(val.ToString("n2"));
                }

                yield return null;
            } 
            prevVal = data.Value;
        }
    }
}
