using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PlayerInputHandler : ICharacterInputHandler
{
    public float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float GetVerticalInput() => Input.GetAxisRaw("Vertical");
    public bool GetJumpInput() => Input.GetButtonDown("Jump");

    public virtual object Clone()
    {
        return this.MemberwiseClone();
    }

    public void Constructer(Character character) { } 
}
