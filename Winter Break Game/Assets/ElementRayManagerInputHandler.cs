using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayManagerInputHandler : IElementRayManagerInputProvider
{
    public int GetInput()
    {
        if (Input.GetButtonDown("SelectLeft"))
        {
            return -1; 
        }
        else if (Input.GetButtonDown("SelectRight"))
        {
            return 1;
        }

        return 0; 
    }
}
