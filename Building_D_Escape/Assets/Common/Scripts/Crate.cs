using UnityEngine;

public class Crate : MonoBehaviour
{
    public Transform player;
    public float interactDistance = 8f;
    private bool canInteract = false;

    void OnMouseDown()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        canInteract = distance < interactDistance;

        if (DisappearOnApproach.canBreakCrates && canInteract)
        {
            Destroy(gameObject); // Удаляем ящик из сцены
        }
    }
}