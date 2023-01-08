using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayTest : MonoBehaviour, IFireRayInteractable
{
    public void OnHit(Vector2 intercention)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
