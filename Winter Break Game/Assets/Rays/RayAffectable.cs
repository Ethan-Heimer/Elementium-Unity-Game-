using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public abstract class RayAffectable : MonoBehaviour
{
    [SerializeField] Element[] personalElementTypes;

    [Header("UI")]
    [SerializeField] bool UseUI; 
    [SerializeField] Vector2 uiOffset;
    [SerializeField] Vector2 iconSize = new Vector2(1,1); 

    public void Awake()
    {
        if(UseUI) SetUpUi();
    }

    private void SetUpUi()
    {
        GridLayoutGroup ui = UiManager.GetNewCanvasWithGrid(transform, uiOffset, iconSize, Vector2.one);

        foreach (Element o in personalElementTypes)
        {
            Image image = UiManager.GetImage(o.Icon);
            image.transform.SetParent(ui.transform);
        }
    }

    public abstract void OnHit(Vector2 intercention); 

    public void CheckForHit(Element[] rayAffectableElements, Vector2 intersect)
    {
        HashSet<Element> elementSet = new HashSet<Element>(personalElementTypes);
        HashSet<Element> rayAffectable = new HashSet<Element>(rayAffectableElements);

        if (elementSet.Overlaps(rayAffectable))
        {
            OnHit(intersect);
        }
    }
}
