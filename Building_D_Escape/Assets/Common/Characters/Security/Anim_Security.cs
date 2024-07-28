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
        lastPosition = transform.position;
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (transform.position.x > lastPosition.x)
        {
            horizontalDirection = 1;
        }
        else if (transform.position.x < lastPosition.x)
        {
            horizontalDirection = -1;
        }
        else
        {
            horizontalDirection = 0;
        }

        if (transform.position.y > lastPosition.y)
        {
            verticalDirection = 1;
        }
        else if (transform.position.y < lastPosition.y)
        {
            verticalDirection = -1;
        }
        else
        {
            verticalDirection = 0;
        }


        if (Math.Abs(transform.position.y) > Math.Abs(transform.position.x))
        {
            horizontalDirection = 0; 
        }else {
            verticalDirection = 0;

        }

        lastPosition = transform.position;

        movementInput.x = horizontalDirection;
        movementInput.y = verticalDirection;

        animator.SetBool("IsMoving", movementInput != Vector2.zero);

        animator.SetFloat("MoveX", movementInput.x);
        animator.SetFloat("MoveY", movementInput.y);
    }

}
