using UnityEngine;
using UnityEngine.SceneManagement; // N'oubliez pas d'inclure cette ligne

public class LoadSceneManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}