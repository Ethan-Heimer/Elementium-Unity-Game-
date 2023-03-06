using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class ElemiteManager : MonoBehaviour
{
    [SerializeField] EventSystem rayEventSystem;
    [SerializeField] GameObject elemiteBase;
    [SerializeField] int DelayMultiplyer; 

    ElementRayData[] rays = new ElementRayData[0];
    [SerializeField] List<Elemite> elemites = new List<Elemite>();

    Elemite selectedMite;

    void Awake()
    {
        rayEventSystem.SubscribeToEvent("On Ray Init", InitElemites);
        rayEventSystem.SubscribeToEvent("On Ray Changed", OnSelected);
        rayEventSystem.SubscribeToEvent("On Ray List Changed", UpdateElemites);
    }

    private void OnDisable()
    {
        rayEventSystem.UnsubscribeToEvent("On Ray Init", InitElemites);
        rayEventSystem.UnsubscribeToEvent("On Ray Changed", OnSelected);
        rayEventSystem.UnsubscribeToEvent("On Ray List Changed", UpdateElemites);
    }

    public void InitElemites(EventData data)
    {
        UpdateElemites(data);
        SelectElemite(0);
    }

    public void UpdateElemites(EventData data)
    {
        ElementRayData[] newRays = (ElementRayData[])data.GetData("Selectable Rays"); 

        foreach (ElementRayData o in newRays)
        {
            if (!rays.Contains(o))
            {
                GameObject obj = Instantiate(elemiteBase);
                obj.GetComponent<SpriteRenderer>().color = o.Color.Evaluate(.5f); 

                Elemite elemite = obj.GetComponent<Elemite>();
                elemite.Init(Character.GetPlayer(), (elemites.Count+1) * DelayMultiplyer); 

                elemites.Add(elemite);
            }
        }

        rays = newRays;
    }

    void OnSelected(EventData data) => SelectElemite((int)data.GetData("Id Selected"));

    void SelectElemite(int id)
    {
        if (selectedMite is not null) selectedMite.Select(false);
        selectedMite = elemites[id];
        selectedMite.Select(true);
    }

    public static void CreateElemiteObject(RayCollectable elemite, ElementRayData rayData, Vector3 position)
    {
        var obj = Instantiate(elemite.gameObject);
        obj.transform.position = position;
        obj.GetComponent<RayCollectable>().rayData = rayData; 
    }
}
