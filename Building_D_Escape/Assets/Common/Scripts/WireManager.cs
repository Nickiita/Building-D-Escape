using UnityEngine;

public class WireManager : MonoBehaviour
{
    public Wire[] wires;  // массив всех проводов

    void Update()
    {
        CheckAllWiresConnected();
    }

    void CheckAllWiresConnected()
    {
        foreach (Wire wire in wires)
        {
            if (!wire.LightOn.activeSelf)
            {
                return;  // если хоть один провод не соединен, выходим из функции
            }
        }

        // если все провода соединены
        SceneSwitcher.ReturnToPreviousScene();
    }
}
