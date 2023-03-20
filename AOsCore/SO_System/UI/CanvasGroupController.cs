using System;
using System.Collections;
using System.Collections.Generic;
//using DG.Tweening;
//using DG.Tweening.Core;
//using DG.Tweening.Plugins.Options;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    [SerializeField] private bool activeOnStart;
    [SerializeField] private bool deactivateGameObjectAfterHide;
    
    private CanvasGroup _group;
    //private TweenerCore<float, float, FloatOptions> currentTween; 

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
        //Debug.Log($"Enabling canvas controller : {name}");
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
        _group.interactable = true;
        _group.blocksRaycasts = true;
        //currentTween = _group.DOFade(1, fadeTime);
        
        Debug.Log("InteractionButtonInfo  - Canvas group controller - Activate");
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
        _group.interactable = false;
        _group.blocksRaycasts = false;
        //currentTween = _group.DOFade(0, fadeTime);

        if (deactivateGameObjectAfterHide)
        {
            Invoke(nameof(Deactivate), fadeTime);
        }
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Disable();
    }

    private void Activate()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    
}