using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour, ICharacterInputHandler
{
    public float GetHorizontalInput() => Input.GetAxisRaw("Horizontal");
    public float GetVerticalInput() => Input.GetAxisRaw("Vertical");
    public bool GetJumpInput() => Input.GetButtonDown("Jump");
}
