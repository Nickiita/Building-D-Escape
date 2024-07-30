using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string WireScene;
    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(WireScene);
    }

    public void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
