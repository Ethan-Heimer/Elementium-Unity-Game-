using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRayRanderer : MonoBehaviour, IElementRayRenderer
{
    LineRenderer renderer;

    //ParticleSystem startParticles;
    [SerializeField] ParticleSystem endParticles;
  
    [Header("Width Wave Animation")]
    [SerializeField] float waveSpeed;
    [SerializeField] float waveItensity;
    [SerializeField] float waveBaseWidth;

    [Header("Ray Glow Wave")]
    [SerializeField] float baseGlow;
    [SerializeField] float glowWaveIntensity;

    [Header("Shoot Warming")]
    [SerializeField] float warmingSpeed;
    [SerializeField] float decaySpeed; 
    [SerializeField] AnimationCurve warmCurve;

    Material rayMaterial;
    Color baseMaterialColor; 

    float _step;
    float step
    {
        get
        {
            return _step; 
        }

        set
        {
            _step = Mathf.Clamp01(value); 
        }
    }

    Camera mainCam;
   
    private void Awake()
    {
        renderer = GetComponent<LineRenderer>();
        renderer.positionCount = 2;

        mainCam = Camera.main;
        rayMaterial = renderer.materials[0];
        baseMaterialColor = rayMaterial.GetColor("_Glow"); 
    }

    public void RenderRay(ElementRayData data, float distance, Vector2 angle)
    {
        SetRayDementions(distance, angle);
        SetRayColorData(data);
        PlayParticles(true);
        GrowWarmingStep();
    }
    public void DisableRay(float distance, Vector2 angle)
    {
        DecayWarmingStep();
        SetRayDementions(distance, angle); 
        PlayParticles(false);
    }

    private void SetRayColorData(ElementRayData data)
    {
        float glow = GetRayGlowValue();
        SetGlowIntencity(glow);
        SetRayColor(data.Color);
    }
    private void SetRayDementions(float distance, Vector2 angle)
    {
        Vector2 endPos = GetEndPosition(distance, angle);
        SetRayLength(endPos);

        float width = GetWidth();
        SetRayWidth(width);
    }

    private float GetWidth() => (waveBaseWidth + Mathf.Sin(Time.realtimeSinceStartup * waveSpeed) * waveItensity) * warmCurve.Evaluate(step);
    private Vector2 GetEndPosition(float distance, Vector2 angle)
    {
        Vector3 _distance = angle.normalized * distance * warmCurve.Evaluate(step);
        return transform.position + _distance;
    }
    private void GrowWarmingStep() => step += warmingSpeed * Time.deltaTime;
    private void DecayWarmingStep() => step -= decaySpeed * Time.deltaTime;
    private void SetRayLength(Vector2 endPos)
    {
        renderer.SetPosition(0, transform.position);
        renderer.SetPosition(1, endPos);

        endParticles.gameObject.transform.position = endPos;
        endParticles.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(endPos.y, endPos.x)));
    }
    private void SetRayWidth(float width) => renderer.SetWidth(width/2, width);
    private void SetRayColor(Gradient color) => renderer.colorGradient = color;
    private void PlayParticles(bool play)
    {
        if (endParticles.isPlaying == play) return; 

        if (play) endParticles.Play();
        else endParticles.Stop(); 
    }
    private void SetGlowIntencity(float value)
    {
        Color newColor = new Color(baseMaterialColor.r + value, baseMaterialColor.g + value, baseMaterialColor.b + value);
        rayMaterial.SetColor("_Glow", newColor);
    }
    private float GetRayGlowValue() => baseGlow + Mathf.Sin(Time.realtimeSinceStartup * waveSpeed) * glowWaveIntensity; 
}
