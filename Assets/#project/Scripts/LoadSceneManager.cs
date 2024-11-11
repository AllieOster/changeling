using UnityEngine;
using UnityEngine.SceneManagement; 

public static class LoadSceneManager 
{
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}