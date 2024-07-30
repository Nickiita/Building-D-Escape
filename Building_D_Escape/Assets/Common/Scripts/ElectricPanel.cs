using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string WireScene;
    public static string PreviousScene { get; private set; }

    void Start()
    {
        PreviousScene = SceneManager.GetActiveScene().name;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(WireScene);
    }

    public static void ReturnToPreviousScene()
    {
        if (!string.IsNullOrEmpty(PreviousScene))
        {
            SceneManager.LoadScene(PreviousScene);
        }
    }
}
