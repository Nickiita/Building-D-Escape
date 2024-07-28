using UnityEngine;
using UnityEngine.UI;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ персонажа
    public float interactDistance = 5f; // Расстояние, на котором можно взаимодействовать с объектом
    public Image[] uiSlots; // Массив UI Image для слотов
    private bool canInteract = false;
    private static int currentSlotIndex = 0; // Текущий индекс слота для отображения предмета

    void Start()
    {
        // Отключаем все слоты по умолчанию
        foreach (Image slot in uiSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        canInteract = distance < interactDistance; // Проверка на расстояние для взаимодействия
    }

    void OnMouseDown()
    {
        if (canInteract && currentSlotIndex < uiSlots.Length)
        {
            gameObject.SetActive(false); // Отключаем объект

            if (uiSlots[currentSlotIndex] != null)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    uiSlots[currentSlotIndex].sprite = spriteRenderer.sprite; // Устанавливаем спрайт
                    uiSlots[currentSlotIndex].gameObject.SetActive(true); // Включаем UI Image
                    currentSlotIndex++; // Переходим к следующему слоту
                }
            }
        }
    }
}
