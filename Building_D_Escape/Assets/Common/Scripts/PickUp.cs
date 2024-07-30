using UnityEngine;
using UnityEngine.UI;

public class DisappearOnApproach : MonoBehaviour
{
    public Transform player;
    public float interactDistance = 5f;
    public Image[] uiSlots;
    private bool canInteract = false;
    private static int currentSlotIndex = 0;
    public string requiredItemForBreaking;
    public static bool canBreakCrates = false; 

    void Start()
    {
        foreach (Image slot in uiSlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            canInteract = distance < interactDistance; // Проверка на возможность взаимодействия
        }
    }

    void OnMouseDown()
    {
        if (canInteract && currentSlotIndex < uiSlots.Length)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            if (spriteRenderer != null)
                {
                    uiSlots[currentSlotIndex].sprite = spriteRenderer.sprite;
                    uiSlots[currentSlotIndex].gameObject.SetActive(true);

                    if (spriteRenderer.sprite.name == requiredItemForBreaking)
                    {
                        canBreakCrates = true; // Устанавливаем флаг для возможности ломать ящики
                    }

                    gameObject.SetActive(false); // Исчезновение предмета
                    currentSlotIndex++;
                }
        }
    }
}