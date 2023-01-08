using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    IOnCharacterUpdate[] characterUpdates;
    IOnCharacterFixedUpdate[] characterFixedUpdates;
    IOnCharacterStart[] characterStarts;

    public void Awake()
    {
        characterStarts = GetComponents<IOnCharacterStart>();
        characterUpdates = GetComponents<IOnCharacterUpdate>();
        characterFixedUpdates = GetComponents<IOnCharacterFixedUpdate>();
    }

    public void Start()
    {
        foreach(IOnCharacterStart o in characterStarts)
        {
            o.OnCharacterStart();
        }
    }

    public void Update()
    {
        foreach (IOnCharacterUpdate o in characterUpdates)
        {
            o.OnCharacterUpdate();
        }
    }

    public void FixedUpdate()
    {
        foreach (IOnCharacterFixedUpdate o in characterFixedUpdates)
        {
            o.OnCharacterFixedUpdate();
        }
    }
}
