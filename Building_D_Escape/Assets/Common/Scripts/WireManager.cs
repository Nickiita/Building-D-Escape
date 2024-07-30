using UnityEngine;

public class WireManager : MonoBehaviour
{
    public Wire[] wires;  // ������ ���� ��������

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
                return;  // ���� ���� ���� ������ �� ��������, ������� �� �������
            }
        }

        // ���� ��� ������� ���������
        SceneSwitcher.ReturnToPreviousScene();
    }
}
