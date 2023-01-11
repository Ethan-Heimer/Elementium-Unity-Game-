using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
public class Cloneable : ICloneable 
{
   public virtual object Clone()
    {
        return this.MemberwiseClone(); 
    }
}
