using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTest : MonoBehaviour
{
    public PopupUiData[] data;

    public void Start()
    {
        foreach(PopupUiData o in data)
        {
            UiManager.UiPopup(o.image, o.header, o.text); 
        }
    }
}
