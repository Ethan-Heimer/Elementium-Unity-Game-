using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class ElemiteManager : MonoBehaviour
{
    [SerializeField] GameObject elemiteBase;
    [SerializeField] int DelayMultiplyer; 

    ElementRayData[] rays = new ElementRayData[0];
    [SerializeField] List<Elemite> elemites = new List<Elemite>();

    Elemite selectedMite;

    void Start()
    {
        ElementRaySelectionManager.OnElementRaySelected += SelectElemite;
        ElementRayCollectionsManager.OnUsableRayListChanged += UpdateElemites;

        InitElemites();
    }

    private void OnDisable()
    {
        ElementRaySelectionManager.OnElementRaySelected += SelectElemite;
        ElementRayCollectionsManager.OnUsableRayListChanged += UpdateElemites;
    }

    public void InitElemites()
    {
        UpdateElemites();
        SelectElemite(ElementRayCollectionsManager.SelectableElementRays[0]);
    }

    public void UpdateElemites()
    {
        foreach (ElementRayData o in ElementRayCollectionsManager.SelectableElementRays)
        {
            if (!rays.Contains(o))
            {
                GameObject obj = Instantiate(elemiteBase);
                obj.GetComponent<SpriteRenderer>().color = o.Color.Evaluate(.5f); 

                Elemite elemite = obj.GetComponent<Elemite>();
                elemite.Init(Character.GetPlayer(), (elemites.Count+1) * DelayMultiplyer, o); 

                elemites.Add(elemite);
            }
        }

        rays = ElementRayCollectionsManager.SelectableElementRays;
    }


    void SelectElemite(ElementRayData data)
    {
        if (selectedMite is not null) selectedMite.Select(false);
        selectedMite = elemites.First(x => x.representedRay == data); 
        selectedMite.Select(true);
    }
}
