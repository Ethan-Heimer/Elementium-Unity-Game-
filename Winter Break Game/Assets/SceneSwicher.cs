using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Threading.Tasks; 

public static class SceneSwicher
{
    public static event Action OnSceneEntered;
    public static AsyncEventHandler OnSceneExited;
    public static event Action OnSceneChanged; 

    public static async void SwitchScene(int id)
    {
        await OnSceneExited?.Invoke();
        SceneManager.LoadScene(id);
        OnSceneChanged?.Invoke();
        OnSceneEntered?.Invoke();
    }    
}

public delegate Task AsyncEventHandler();
