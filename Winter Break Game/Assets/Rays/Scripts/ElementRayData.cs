using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ElementRayData : ScriptableObject
{
    public Gradient Color;
    public Sprite icon; 

    public List<string> InterfacesToInvoke = new List<string>();

    #region context menu stuff
    [ContextMenu(nameof(AddFireInteractablilty))] void AddFireInteractablilty() => InterfacesToInvoke.Add(nameof(IFireRayInteractable));
    [ContextMenu(nameof(AddIceInteractablilty))]  void AddIceInteractablilty() => InterfacesToInvoke.Add(nameof(IIceRayInteractable));
    [ContextMenu(nameof(AddWaterInteractablilty))] void AddWaterInteractablilty() => InterfacesToInvoke.Add(nameof(IWaterRayInteractable));
    #endregion
}
