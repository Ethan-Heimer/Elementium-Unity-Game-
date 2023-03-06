using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; 

public class FireTwinAction : CharacterClass, ICharacterActionHandler
{
    public Projectile fireBall;

    Transform playerTransform; 
    public void Start()
    {
        playerTransform = Character.GetPlayer().transform;
    }

    public async void OnAction()
    {
        Vector2 dir = playerTransform.position - character.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x)*Mathf.Rad2Deg;
       
        ShootFireball(angle);
        await Task.Delay(500);
        ShootFireball(angle);
        await Task.Delay(500);
        ShootFireball(angle);
    }

    void ShootFireball(float angle)
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
