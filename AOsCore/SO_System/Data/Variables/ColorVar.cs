using System.Collections;
using System.Collections.Generic;
using AOsCore.SO_System.DataVariables;
using UnityEngine;

[CreateAssetMenu(menuName="SO_SYSTEM/Data/ColorVariable")]
public class ColorVar : DataVariable<Color>
{
    public string GetHexValue()
    {
        return ColorUtility.ToHtmlStringRGBA(Value);
    }
}
