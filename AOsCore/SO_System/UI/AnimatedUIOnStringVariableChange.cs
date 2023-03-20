using System;
using System.Collections;
using AOsCore.SO_System.DataVariables;
//using DG.Tweening;
using UnityEngine;

namespace AOsCore.UI
{
    public class AnimatedUIOnStringVariableChange : MonoBehaviour
    {
        [SerializeField] private StringVar variable;
        
        [Header("Animation values")]
        [SerializeField] private bool usePositionAnimation;
        [SerializeField] private bool useScaleAnimation;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector3 endPosition;
        [SerializeField] private Vector3 endScale;
        //[SerializeField] private Ease positionEase;
        //[SerializeField] private Ease scaleEase;
        [SerializeField] private float positionAnimTime;
        [SerializeField] private float scaleAnimTime;
        
        [Header("After animation state")]
        [SerializeField] private bool resetAfterAnimation;
        [SerializeField] private float resetAfterTime;
        
       
        private Vector3 _initialPosition, _initialScale;
        private AudioSource _audioSource;
        
        private void Start()
        {
            _initialPosition = rectTransform.localPosition;
            _initialScale = rectTransform.localScale;
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            variable.SubscribeToValueChanged(Animate);
        }

        private void OnDisable()
        {
            variable.UnsubscribeFromValueChanged(Animate);
        }

        //[EasyButtons.Button]
        public void Animate()
        {
            if (usePositionAnimation)
            {
                AnimatePosition();
            }

            if (useScaleAnimation)
            {
                AnimateScale();
            }

            if (resetAfterAnimation)
            {
                StartCoroutine(ResetAfterAnimation());
            }

            if (_audioSource != null)
            {
                _audioSource.Play();
            }
        }

        private void AnimatePosition()
        {
            Debug.Log($"{nameof(AnimatedUIOnStringVariableChange)} AnimatePosition() initialPosition: {_initialPosition} endPosition: {endPosition}");
            //rectTransform.DOLocalMove(endPosition, positionAnimTime).SetEase(positionEase);
        }

        private void AnimateScale()
        {
            //rectTransform.DOScale(endScale, scaleAnimTime).SetEase(scaleEase);
        }

        private IEnumerator ResetAfterAnimation()
        {
            var waitTime = positionAnimTime > scaleAnimTime ? positionAnimTime : scaleAnimTime;
            yield return new WaitForSeconds(waitTime + resetAfterTime);
            rectTransform.localPosition = _initialPosition;
            rectTransform.localScale = _initialScale;
        }

    }
}
