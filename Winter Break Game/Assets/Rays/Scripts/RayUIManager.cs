using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayUIManager : MonoBehaviour
{
    [SerializeField] EventSystem rayEventSystem;
    [SerializeField] GameObject rayUIElement;
    [SerializeField] Transform uiParent;

    GameObject[] uiElements;
    GameObject selectedElement;

    void Awake()
    {
        rayEventSystem.SubscribeToEvent("On Ray Init", InitUI);
        rayEventSystem.SubscribeToEvent("On Ray Changed", OnSelected);
    }

    private void OnDisable()
    {
        rayEventSystem.UnsubscribeToEvent("On Ray Init", InitUI);
        rayEventSystem.UnsubscribeToEvent("On Ray Changed", OnSelected);
    }

    public void InitUI(EventData data)
    {
        CreateUI(data);
        SelectUI(0);
    }

    void CreateUI(EventData data)
    {
        ElementRayData[] selectableRays = (ElementRayData[])data.GetData("Selectable Rays");
        uiElements = new GameObject[selectableRays.Length];

        for (int i = 0; i < selectableRays.Length; i++)
        {
            GameObject obj = Instantiate(rayUIElement);
            obj.transform.SetParent(uiParent);

            obj.GetComponent<Image>().sprite = selectableRays[i].icon;

            DeselectElement(obj);

            uiElements[i] = obj;
        }
    }

    void OnSelected(EventData data) => SelectUI((int)data.GetData("Id Selected"));

    void SelectUI(int id)
    {
        if (selectedElement is not null) DeselectElement(selectedElement);
        selectedElement = uiElements[id];
        SelectElement(selectedElement); 
    }

    void SelectElement(GameObject element)
    {
        StartCoroutine(scaleUI(element, .1f, 1.1f));
        StartCoroutine(colorUI(element, .1f, new Color(1, 1, 1)));
    }
    void DeselectElement(GameObject element)
    {
        StartCoroutine(scaleUI(element, .1f, .9f));
        StartCoroutine(colorUI(element, .1f, new Color(.5f, .5f, .5f)));
    }
    IEnumerator scaleUI(GameObject selectUI, float speed, float scaleTo)
    {
        Vector3 startingScale = selectUI.transform.localScale;
        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            selectUI.transform.localScale = Vector3.Lerp(startingScale, Vector3.one * scaleTo, percentComplete);
            yield return new YieldInstruction();
        }
    }
    IEnumerator colorUI(GameObject selectUI, float speed, Color color)
    {
        Image image = selectUI.GetComponent<Image>();
        Color startingColor = image.color;

        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            image.color = Color.Lerp(startingColor, color, percentComplete);
            yield return new YieldInstruction();
        }
    }
}

