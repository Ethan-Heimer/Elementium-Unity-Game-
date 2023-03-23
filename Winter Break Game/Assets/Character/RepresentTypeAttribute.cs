using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RepresentTypeAttribute : Attribute
{
    public Type type;
    public RepresentTypeAttribute(Type _type)
    {
        type = _type;
    }
}
