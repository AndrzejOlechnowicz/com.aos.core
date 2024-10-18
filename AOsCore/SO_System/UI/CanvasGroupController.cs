using System.Collections;
using UnityEngine;

namespace AOsCore.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupController : MonoBehaviour
    {
        [SerializeField] private bool activeOnStart;
        [SerializeField] private bool deactivateGameObjectAfterHide;

        protected CanvasGroup _group;


        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            if (!activeOnStart)
            {
                Disable();
            }
        }

        public void Disable()
        {
            if (_group == null)
                return;

            _group.interactable = false;
            _group.blocksRaycasts = false;
            _group.alpha = 0;

            if (deactivateGameObjectAfterHide)
            {
                Deactivate();
            }
        }

        public void Enable()
        {
            if (_group == null)
                return;

            _group.interactable = true;
            _group.blocksRaycasts = true;
            _group.alpha = 1;

            Activate();
        }

        /// <summary>
        /// Enables canvas group
        /// <param name="fadeTime">smooth enable time</param>>
        /// </summary>
        public void FadeOut(float fadeTime)
        {
            if (_group == null)
                return;

            _group.interactable = true;
            _group.blocksRaycasts = true;
            FadeOutAnimation(fadeTime);

            Activate();
        }

        /// <summary>
        /// Enables canvas group and hides it after set time
        /// </summary>
        public void FadeOutAndHideAfter(float time)
        {
            Enable();
            StopAllCoroutines();
            StartCoroutine(DisableAfterTime(time));
        }

        /// <summary>
        /// Disables canvas group
        /// <param name="fadeTime">smooth disable time</param>>
        /// </summary>
        public void FadeIn(float fadeTime = 1)
        {
            if (_group == null)
                return;

            _group.interactable = false;
            _group.blocksRaycasts = false;
            FadeInAnimation(fadeTime);

            if (deactivateGameObjectAfterHide)
            {
                StartCoroutine(DeactivationCoro(fadeTime));
            }
        }

        private IEnumerator DisableAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            Disable();
        }

        protected virtual void Activate()
        {
            if (!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }
        }

        protected virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        protected virtual void FadeInAnimation(float animationTime)
        {

        }

        protected virtual void FadeOutAnimation(float animationTime)
        {

        }

        protected virtual IEnumerator DeactivationCoro(float deactivateAfterSeconds)
        {
            yield return new WaitForSecondsRealtime(deactivateAfterSeconds);
            Deactivate();
        }
    }
}