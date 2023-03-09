using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System; 

[CreateAssetMenu]
public class CameraEffectManager : ScriptableObject
{
    [SerializeField] CameraShakeManager CameraShake;

    Camera _cam = null;
    Camera mainCamera
    {
        get
        {
            if (_cam == null) _cam = Camera.main;

            return _cam; 
        }
    }

    public void ExecuteShake(string name) => CameraShake.InvokeShake(name, mainCamera);
    public void FlagShake(string name) => CameraShake.FlagEffect(name, mainCamera);
    public void UnflagShake(string name) => CameraShake.UnflagEffect(name, mainCamera);

}

[System.Serializable]
public abstract class CameraEffect
{
    public string name;
    public abstract Task ExecuteEffect(Camera camera);
    public abstract void OnFlag(Camera camera);
    public abstract void OnUnflag(Camera camera);
}

[System.Serializable]
public class CameraShakeManager
{
    [SerializeField] List<CameraShake> cameraShakes = new List<CameraShake>();

    bool isShakeFlagged = false;
    string flaggedName;

    bool flaggedPaused = false; 

    public async void InvokeShake(string name, Camera mainCamera)
    {
        try
        {
          
            string shakeFlaggedName = flaggedName;

            if (isShakeFlagged)
            {
                UnflagEffect(shakeFlaggedName, mainCamera);
                flaggedPaused = true; 
            }

            await cameraShakes.Find(x => x.name == name).ExecuteEffect(mainCamera);

            if (flaggedPaused) 
            {
                FlagEffect(shakeFlaggedName, mainCamera);
                flaggedPaused = false; 
            }
            
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist");
        }
    }

    public void FlagEffect(string name, Camera mainCamera)
    {
        try
        {
            if(!isShakeFlagged)
            {
                CameraShake shake = cameraShakes.Find(x => x.name == name);
                shake.OnFlag(mainCamera);
                isShakeFlagged = true;
                flaggedName = name;
            }
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist");
        }
    }

    public void UnflagEffect(string name, Camera mainCamera)
    {
        try
        {
            cameraShakes.Find(x => x.name == name).OnUnflag(mainCamera);
            isShakeFlagged = false;
            flaggedName = "";

            if (flaggedPaused) flaggedPaused = false;
        }
        catch (NullReferenceException)
        {
            Debug.Log("Shake Effect Does Not Exist");
        }
    }
}

[System.Serializable]
public class CameraShake : CameraEffect
{
    public float ShakeTime; 
    public float ShakeIntensity;
    public float ShakeSpeed;

    public async override Task ExecuteEffect(Camera camera)
    {
        await ShakeCam(camera);
        ReturnToOrigin(camera, .1f); 
    }

    public override void OnFlag(Camera camera)
    {
        StartShake(camera); 
    }

    public override void OnUnflag(Camera camera)
    {
        StopShake(); 
    }

    public async Task ShakeCam(Camera cam)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        while(percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / ShakeTime;

            float shakeBy = GetShakeBy(Time.time);
         
            ApplyShake(cam, shakeBy);

            await Task.Yield();
        }
    }

    bool shake = false;
    public async void StartShake(Camera cam)
    {
        shake = true;

        while (shake)
        {
            await ShakeCam(cam);
        }

        ReturnToOrigin(cam, .1f);
    }

    public void StopShake() => shake = false; 

    float GetShakeBy(float x) => Mathf.Sin(x * ShakeSpeed) * ShakeIntensity;
    void ApplyShake(Camera cam, float offset)
    { 
        if(cam is not null)
        cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, offset, cam.transform.localPosition.z); 
    }

    async void ReturnToOrigin(Camera cam, float speed)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        Vector2 startPos = cam.transform.localPosition; 

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            cam.transform.localPosition = Vector2.Lerp(startPos, Vector2.zero, percentComplete);

            await Task.Yield();
        }
    }
}
