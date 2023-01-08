using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System; 

[CreateAssetMenu]
public class CameraEffectManager : ScriptableObject
{
    [SerializeReference]
    public List<CameraEffect> effects = new List<CameraEffect>();

    Camera _cam = null;
    Camera mainCamera
    {
        get
        {
            if (_cam == null) _cam = Camera.main;

            return _cam; 
        }
    }

    public void ExecuteEffect(string name)
    {
        try 
        {
            effects.Find(x => x.name == name).ExecuteEffect(mainCamera);
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist"); 
        }
       
    }

    public void FlagEffect(string name)
    {
        try
        {
            effects.Find(x => x.name == name).OnFlag(mainCamera);
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist");
        }
    }

    public void UnflagEffect(string name)
    {
        try
        {
            effects.Find(x => x.name == name).OnUnflag(mainCamera);
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist");
        }
    }

    [ContextMenu("Add Shake")] void AddShake() => effects.Add(new CameraShake()); 
}

[System.Serializable]
public abstract class CameraEffect
{
     public string name; 
     public abstract void ExecuteEffect(Camera camera);
    public abstract void OnFlag(Camera camera);
    public abstract void OnUnflag(Camera camera);
}

[System.Serializable]
public class CameraShake : CameraEffect
{
    public float ShakeTime; 
    public float ShakeIntensity;
    public float ShakeSpeed;

    float lastShake = 0;
    public override void ExecuteEffect(Camera camera)
    {
        ShakeCam(camera); 
    }

    public override void OnFlag(Camera camera)
    {
        StartShake(camera); 
    }

    public override void OnUnflag(Camera camera)
    {
        StopShake(); 
    }

    public async void ShakeCam(Camera cam)
    {
        Debug.Log("Shake"); 

        float elapsedTime = 0;
        float percentComplete = 0;

        while(percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / ShakeTime;

            float shakeBy = GetShakeBy(Time.time);

            ApplyShake(cam, cam.transform.position.y-lastShake, shakeBy);

            lastShake = shakeBy; 

            await Task.Yield();
        }

        lastShake = 0; 
    }

    bool shake = false; 
    public async void StartShake(Camera cam)
    {
        Debug.Log("Shake");
        shake = true;

        while (shake)
        {
            float shakeBy = GetShakeBy(Time.time);
            ApplyShake(cam, cam.transform.position.y - lastShake, shakeBy);

            lastShake = shakeBy;
          
            await Task.Yield();
        }

        lastShake = 0;
    }

    public void StopShake() => shake = false; 

    float GetShakeBy(float x) => Mathf.Sin(x * ShakeSpeed) * ShakeIntensity; 
    void ApplyShake(Camera cam, float originalPos, float offset) => cam.transform.position = new Vector3(cam.transform.position.x, originalPos + offset, cam.transform.position.z);
}
