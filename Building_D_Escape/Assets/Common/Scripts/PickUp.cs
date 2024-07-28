using UnityEngine;
using UnityEngine.UI;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ персонажа
    public float disappearDistance = 5f; // Расстояние, на котором объект исчезает
    public Image uiImage; // Ссылка на UI Image для отображения спрайта

    void Start()
    {
        if (uiImage != null)
        {
            uiImage.gameObject.SetActive(false); // Отключаем UI Image по умолчанию
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < disappearDistance)
        {
            gameObject.SetActive(false); // Отключаем объект

            if (uiImage != null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    uiImage.sprite = spriteRenderer.sprite; // Устанавливаем спрайт
                    uiImage.gameObject.SetActive(true); // Включаем UI Image
                }
            }
        }
    }
}
