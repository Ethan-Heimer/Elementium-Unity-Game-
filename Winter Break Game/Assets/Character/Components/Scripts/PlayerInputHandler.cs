using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Input Handler", menuName = "Character Components/Input Handlers/Player Input Handler")]
public class PlayerInputHandler : CharacterInputHandler
{
    public override float GetHorizontalInput(Character character) => Input.GetAxisRaw("Horizontal");
    public override float GetVerticalInput(Character character) => Input.GetAxisRaw("Vertical");
    public override bool GetJumpInput(Character character) => Input.GetButtonDown("Jump");
    public override bool GetActionInput(Character character) =>  Input.GetButton("Fire1") || (Input.GetAxisRaw("Fire1") > 0 && (Input.GetAxis("AimY") != 0 || Input.GetAxis("AimX") != 0));
    public override bool GetClimbInput(Character character) => Input.GetAxisRaw("Vertical") > 0; 
}
