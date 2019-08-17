using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ColorPalette", fileName = "ColorPalette", order = 0)]
public class ColorPalette : ScriptableObject
{
    public List<Color> colors;
}
