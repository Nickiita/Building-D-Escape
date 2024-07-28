using UnityEngine;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public GameObject menu;

    private void Start()
    {
        loadingScreen.SetActive(true);
        menuScreen.SetActive(false);
        menu.SetActive(false);

        StartCoroutine(ShowLoadingScreen());
    }

    private IEnumerator ShowLoadingScreen()
    {
        loadingScreen.SetActive(true);
        menuScreen.SetActive(false);
        menu.SetActive(false);

        // 5 sec
        yield return new WaitForSeconds(5);

        loadingScreen.SetActive(false);
        menuScreen.SetActive(true);
        menu.SetActive(true);
    }
}
