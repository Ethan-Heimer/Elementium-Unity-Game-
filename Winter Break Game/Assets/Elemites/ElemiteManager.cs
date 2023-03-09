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

    void Awake()
    {
        ElementRayManager.OnElementRayInit += InitElemites;
        ElementRayManager.OnElementRaySelected += OnSelected;
        ElementRayManager.OnUsableRayListChanged+= UpdateElemites;
    }

    private void OnDisable()
    {
        ElementRayManager.OnElementRayInit -= InitElemites;
        ElementRayManager.OnElementRaySelected -= OnSelected;
        ElementRayManager.OnUsableRayListChanged -= UpdateElemites;
    }

    public void InitElemites(ElementRayData[] data)
    {
        UpdateElemites(data);
        SelectElemite(rays[0]);
    }

    public void UpdateElemites(ElementRayData[] data)
    {
        foreach (ElementRayData o in data)
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

        rays = data;
    }

    void OnSelected(ElementRayData rayData) => SelectElemite(rayData);

    void SelectElemite(ElementRayData data)
    {
        if (selectedMite is not null) selectedMite.Select(false);
        selectedMite = elemites.First(x => x.representedRay == data); 
        selectedMite.Select(true);
    }

    public static void CreateElemiteObject(RayCollectable elemite, ElementRayData rayData, Vector3 position)
    {
        var obj = Instantiate(elemite.gameObject);
        obj.transform.position = position;
        obj.GetComponent<RayCollectable>().rayData = rayData; 
    }
}
