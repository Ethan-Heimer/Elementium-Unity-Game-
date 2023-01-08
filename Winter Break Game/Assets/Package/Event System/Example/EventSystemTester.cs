using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class EventSystemTester : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;

    private void Start()
    {
        eventSystem.SubscribeToEvent("Test", UseEventData);

        eventSystem.WhileEventFlagged("Test Flag", WhileFlagged);
    }

    private void OnDestroy()
    {
        eventSystem.UnsubscribeToEvent("Test", UseEventData);

        eventSystem.RemoveWhileEventFlagged("Test Flag", WhileFlagged);
    }

   

    [ContextMenu("Invoke Event")]
    public void InvokeEvent()
    {
        int a = 10;
        eventSystem.InvokeEvent("Test", new EventData(new EventInfo("Test Val", a)));
    }
    void UseEventData(EventData data)
    {
        Debug.Log(data.GetData("Test Val"));
    }

    [ContextMenu("Flag Event")]
    public void FlagEvent()
    {
        int b = 12;
        eventSystem.FlagEvent("Test Flag", new EventData(new EventInfo("Test Val", b)));
    }

    [ContextMenu("Unflag Event")]
    public void UnflagEvent()
    {
        eventSystem.UnflagEvent("Test Flag");
    }

    public void WhileFlagged(EventData data)
    {
        Debug.Log(data.GetData("Test Val"));
    }
}
