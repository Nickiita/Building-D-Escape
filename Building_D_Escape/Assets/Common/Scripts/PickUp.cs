using UnityEngine;
using UnityEngine.UI;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player; // ������ �� ��������� ���������
    public float interactDistance = 5f; // ����������, �� ������� ����� ����������������� � ��������
    public Image[] uiSlots; // ������ UI Image ��� ������
    private bool canInteract = false;
    private static int currentSlotIndex = 0; // ������� ������ ����� ��� ����������� ��������

    void Start()
    {
        // ��������� ��� ����� �� ���������
        foreach (Image slot in uiSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        canInteract = distance < interactDistance; // �������� �� ���������� ��� ��������������
    }

    void OnMouseDown()
    {
        if (canInteract && currentSlotIndex < uiSlots.Length)
        {
            gameObject.SetActive(false); // ��������� ������

            if (uiSlots[currentSlotIndex] != null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    uiSlots[currentSlotIndex].sprite = spriteRenderer.sprite; // ������������� ������
                    uiSlots[currentSlotIndex].gameObject.SetActive(true); // �������� UI Image
                    currentSlotIndex++; // ��������� � ���������� �����
                }
            }
        }
    }
}
