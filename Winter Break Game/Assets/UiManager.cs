using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks; 
public static class UiManager
{
    public static void HighlightElement(GameObject element)
    {
        scaleUI(element, .1f, 1.1f);
        colorUI(element, .1f, new Color(1, 1, 1));
    }

    public static void UnhighlightElement(GameObject element)
    {
        scaleUI(element, .1f, .9f);
        colorUI(element, .1f, new Color(.5f, .5f, .5f));
    }
    public static async void scaleUI(GameObject selectUI, float speed, float scaleTo)
    {
        Vector3 startingScale = selectUI.transform.localScale;
        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            if (selectUI is not null)
            {
                selectUI.transform.localScale = Vector3.Lerp(startingScale, Vector3.one * scaleTo, percentComplete);
            }

            await Task.Yield();
        }
    }
    public static async void colorUI(GameObject selectUI, float speed, Color color)
    {
        Image image = selectUI.GetComponent<Image>();
        Color startingColor = image.color;

        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            if (selectUI is not null)
            {
                image.color = Color.Lerp(startingColor, color, percentComplete);
            }

            await Task.Yield();
        }
    }

    static Queue<PopupUiData> popupData = new Queue<PopupUiData>();

    static bool isDisplayingData = false;
    public static void UiPopup(Sprite image, string header, string text)
    {
        PopupUiData data = new PopupUiData();
        data.image = image;
        data.header = header; 
        data.text = text; 

        popupData.Enqueue(data);

        InvokePopups();
    }

    static async void InvokePopups()
    {
        if (isDisplayingData) return;

        isDisplayingData = true;

        while(popupData.Count > 0)
        {
            await ShowPopup(popupData.Dequeue());
        }

        isDisplayingData = false;
    }

    static async Task ShowPopup(PopupUiData data)
    {
        await PopupUI.Instance.Pop(data, .25f, 3); 
    }

    
}

[System.Serializable]
public struct PopupUiData
{
    public Sprite image;
    public string header; 
    public string text; 
}
