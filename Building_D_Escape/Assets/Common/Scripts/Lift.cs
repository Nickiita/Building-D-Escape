using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Имя сцены, которую нужно загрузить

    private void OnTriggerEnter2D(Collider2D other)
    {
        LoadScene();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}