using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DisableLogicWhenHidden : MonoBehaviour
{
    Component[] components; 
    public void Awake()
    {
        Component[] _components = GetComponents(typeof(MonoBehaviour));
        components = _components.Where(x => x != this).ToArray();
    }


    private void OnBecameInvisible()
    {
        EnableComponents(false);
       
    }

    
    private void OnBecameVisible()
    {
        EnableComponents(true);
       
    }

    private void EnableComponents(bool enable)
    {
      
        foreach (MonoBehaviour o in components)
        {
            o.enabled = enable;
        }
    }

}
