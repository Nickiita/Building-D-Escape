using UnityEngine;

public class Crate : MonoBehaviour
{
    void OnMouseDown()
    {
        if (DisappearOnApproach.canBreakCrates)
        {
            Destroy(gameObject); // Удаляем ящик из сцены
        }
    }
}