using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeableLiquid : MonoBehaviour, IIceRayInteractable
{
    [SerializeField] GameObject LiquidSolidForm; 
    public void OnHit(Vector2 intercect)
    {
        Collider2D hit = Physics2D.OverlapCircle(intercect, .40f); 

        if(hit.gameObject.name != LiquidSolidForm.name)
        {
            GameObject obj = Instantiate(LiquidSolidForm);
            obj.transform.position = intercect;
            obj.name = LiquidSolidForm.name; 
        }

        Debug.Log(hit.gameObject.name == LiquidSolidForm.name);
    }
}
