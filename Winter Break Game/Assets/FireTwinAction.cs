using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

[CreateAssetMenu(fileName = "New Action Handler", menuName = "Character Components/Action Handlers/Twin Action Handler")]
public class FireTwinAction : CharacterActionHandler
{
    public Projectile fireBall;
    public override async void OnAction(Character character)
    {
        Vector2 dir = Character.GetPlayer().transform.position - character.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
       
        ShootFireball(character, angle);
        await Task.Delay(500);
        ShootFireball(character, angle);
        await Task.Delay(500);
        ShootFireball(character, angle);
    }

    void ShootFireball(Character character, float angle)
    {
        GameObject obj = GameObject.Instantiate(fireBall.gameObject);
        try
        {
            obj.GetComponent<Projectile>().Init(angle, 20, character.gameObject);
            obj.transform.position = character.transform.position;
        }
        catch
        {
            GameObject.DestroyImmediate(obj);
        }
    }


}
