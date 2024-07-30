using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class NPCCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("NPC столкнулся с игроком!");
            OnPlayerCollision();
        }
    }

    void OnPlayerCollision()
    {
        Debug.Log("Вызвана функция OnPlayerCollision");
    }
}