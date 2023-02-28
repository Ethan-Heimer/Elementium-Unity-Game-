using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PlayerInputHandler : CharacterClass, ICharacterInputHandler
{
    public float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float GetVerticalInput() => Input.GetAxisRaw("Vertical");
    public bool GetJumpInput() => Input.GetButtonDown("Jump");
    public bool GetActionInput() =>  Input.GetButton("Fire1") || (Input.GetAxisRaw("Fire1") > 0 && (Input.GetAxis("AimY") != 0 || Input.GetAxis("AimX") != 0));
}
