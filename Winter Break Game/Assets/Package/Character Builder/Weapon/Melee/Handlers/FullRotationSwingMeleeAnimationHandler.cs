using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRotationSwingMeleeAnimationHandler : MonoBehaviour, IWeaponAnimationHandler
{
    [SerializeField] float animationSpeed;
    public void Play() => StartCoroutine(Animation(animationSpeed));
    public IEnumerator Animation(float speed)
    {

        float elapsedtime = 0;
        float percentComplete = 0;

        Quaternion startRotation = Quaternion.identity;

        while (percentComplete < 1)
        {
            elapsedtime += Time.deltaTime;
            percentComplete = elapsedtime / speed;

            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(new Vector3(0, 0, 180)), percentComplete);

            yield return new YieldInstruction();
        }

        transform.rotation = startRotation;
    }
}
