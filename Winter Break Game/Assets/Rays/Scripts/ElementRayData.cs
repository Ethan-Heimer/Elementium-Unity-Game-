using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ElementRayData : ScriptableObject
{
    public Gradient Color;
    public Sprite icon; 

    public List<Element> ElementSToInteractWith = new List<Element>();
}
