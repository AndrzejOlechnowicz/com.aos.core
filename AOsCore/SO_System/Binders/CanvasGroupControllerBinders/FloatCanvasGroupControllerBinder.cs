using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCanvasGroupControllerBinder : CanvasGroupControllerBinder<float>
{
    [SerializeField] private float shownCanvasValue;
    [SerializeField] private float hidedCanvasValue;
    
    
    protected override void Refresh()
    {
        //Debug.Log($"Refreshing.... data.Value: {data.Value}");
        if (data.Value > shownCanvasValue)
        {
            //Debug.Log($"Refreshing.... data.Value: {data.Value} canvas should be ENABLED");
            if(_controller != null)
            {
                _controller.Enable();
            }
            
        }
        else if (data.Value <= hidedCanvasValue)
        {
            //Debug.Log($"Refreshing.... data.Value: {data.Value} canvas should be DISABLED");
            if (_controller != null)
            {
                _controller.Disable();
            }
            else
            {
                Debug.LogError("Refreshing error, there is no canvas group controller");
            }
        }
        
    }

    protected override void OnDisable()
    {
        //Debug.Log("Disabled");
    }
}
