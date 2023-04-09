using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enviorment Status Holder", menuName = "Character Components/Enviorment Status Holder/Basic Enviorment Status Holder")]
public class CharacterEnviormentStatusProviders : CharacterEnviormentStatusHolder
{
    [SerializeField] CharacterEnviormentStatusProvider[] characterEnviormentStatusProviders;

    public override CharacterEnviormentStatusProvider[] GetStatusComponents() => characterEnviormentStatusProviders;
}
