using UnityEngine;
using UnityEngine.UI;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player; // ������ �� ��������� ���������
    public float disappearDistance = 5f; // ����������, �� ������� ������ ��������
    public Image uiImage; // ������ �� UI Image ��� ����������� �������

    void Start()
    {
        if (uiImage != null)
        {
            uiImage.gameObject.SetActive(false); // ��������� UI Image �� ���������
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < disappearDistance)
        {
            gameObject.SetActive(false); // ��������� ������

            if (uiImage != null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    uiImage.sprite = spriteRenderer.sprite; // ������������� ������
                    uiImage.gameObject.SetActive(true); // �������� UI Image
                }
            }
        }
    }
}
