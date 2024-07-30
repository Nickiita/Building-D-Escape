using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class NPCCatch : MonoBehaviour
{
    public GameObject playerObject;


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        float player_x = playerObject.transform.position.x;
        float player_y = playerObject.transform.position.y;
        float npc_x = transform.position.x;
        float npc_y = transform.position.y;

        if (Math.Abs(player_x - npc_x) < 0.25 && Math.Abs(player_y - npc_y) < 1)
        {
            ReloadScene();
        }
    }

}