using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IElementRayInteractable
{
    public void OnHit(Vector2 intercection);
}

public interface IFireRayInteractable : IElementRayInteractable { }
public interface IWaterRayInteractable : IElementRayInteractable { }
public interface IIceRayInteractable : IElementRayInteractable { }
