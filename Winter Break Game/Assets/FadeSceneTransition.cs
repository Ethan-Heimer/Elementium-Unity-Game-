using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class FadeSceneTransition : SceneTransition
{
    [SerializeField] Image fade;
    [SerializeField] float fadeSpeed;

    public override async Task Appear()
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        while(percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / fadeSpeed;

            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, percentComplete);
            await Task.Yield();
        }
    }

    public override async void Disappear()
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / fadeSpeed;

            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 1-percentComplete);
            await Task.Yield();
        }
    }
}
