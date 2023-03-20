using System;
using System.Collections;
using AOsCore.SO_System.DataVariables;
using TMPro;
using UnityEngine;

namespace AOsCore.UI
{
    public class AnimatedTextMeshOnStringVariableChange : MonoBehaviour
    {
        [SerializeField] private StringVar stringVariable;
        [SerializeField] private float betweenLettersWaitTime = 0.05f;

        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            stringVariable.SubscribeToValueChanged(Animate);
        }

        private void OnDisable()
        {
            Debug.Log("AnimatedTextOnStringVariableChange - OnDisable");
            stringVariable.UnsubscribeFromValueChanged(Animate);
        }

        private void Animate()
        {
            Debug.Log("Animate FUCK are we here???");
            var text = stringVariable.Value;
            //StopAllCoroutines();
            _textMesh.SetText("");
            StartCoroutine(AnimationCoro(text));
        }

        private IEnumerator AnimationCoro(string value)
        {
            Debug.Log("Coro FUCK are we here???");
            var chars = value.ToCharArray();
            //_textMesh.SetText("");
            
            foreach (var t in chars)
            {
                //Debug.Log($"{gameObject.name} : adding letter to task text: {t}");
                _textMesh.text += t;
                yield return new WaitForSecondsRealtime(betweenLettersWaitTime);
            }
        }
    }
}
