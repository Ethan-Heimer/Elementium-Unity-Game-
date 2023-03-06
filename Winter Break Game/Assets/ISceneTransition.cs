using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public abstract class SceneTransition : MonoBehaviour
{
    public void Start()
    {
        SceneSwicher.OnSceneExited += async() => await Appear();
        Disappear();
    }

    public abstract Task Appear();
    public abstract void Disappear();
}
