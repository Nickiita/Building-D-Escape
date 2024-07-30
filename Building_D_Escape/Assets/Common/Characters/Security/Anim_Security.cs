using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Anim_Security : MonoBehaviour
{
    private Animator animator;
    private Vector3 lastPosition; // Последняя известная позиция NPC
    private int horizontalDirection = 0; // Направление движения по горизонтали: -1 для влево, 1 для вправо, 0 для отсутствия движения
    private int verticalDirection = 0; // Направление движения по вертикали: -1 для вниз, 1 для вверх, 0 для отсутствия движения
    private Vector2 movementInput;


    void Start()
    {
                StartCoroutine(CheckEvery200ms());

    }
IEnumerator CheckEvery200ms()
    {
        while (true)
        {

            // Здесь ваш код, который должен выполняться каждые 0.2 секунды
            Debug.Log("Это сообщение выводится каждые 1 секунды");

            yield return new WaitForSeconds(1f);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        float mov_x = transform.position.x -   lastPosition.x;
        float mov_y  = transform.position.y -  lastPosition.y;
        horizontalDirection = 0;
        verticalDirection = 0;
         if (Math.Abs(mov_x) >= Math.Abs(mov_y))
        {
            if (mov_x > 0) {
                horizontalDirection = 1;
            }else if(mov_x < 0) {
                horizontalDirection = -1;
            }else {
                horizontalDirection = 0;
            }
        }else {
            if (mov_y > 0) {
                verticalDirection = 1;
            }else if(mov_y < 0) {
                verticalDirection = -1;
            }else {
                verticalDirection = 0;
            }
        }

        // if (transform.position.x > lastPosition.x)
        // {
        //     horizontalDirection = 1;
        // }
        // else if (transform.position.x < lastPosition.x)
        // {
        //     horizontalDirection = -1;
        // }
        // else
        // {
        //     horizontalDirection = 0;
        // }

        // if (transform.position.y > lastPosition.y)
        // {
        //     verticalDirection = 1;
        // }
        // else if (transform.position.y < lastPosition.y)
        // {
        //     verticalDirection = -1;
        // }
        // else
        // {
        //     verticalDirection = 0;
        // }


        // if (Math.Abs(transform.position.y) > Math.Abs(transform.position.x))
        // {
        //     horizontalDirection = 0; 
        // }else {
        //     verticalDirection = 0;

        // }



        lastPosition = transform.position;

        movementInput.x = horizontalDirection;
        movementInput.y = verticalDirection;

        animator.SetBool("IsMoving", movementInput != Vector2.zero);

        
        animator.SetFloat("MoveX", movementInput.x);
        animator.SetFloat("MoveY", movementInput.y);
    }

}
