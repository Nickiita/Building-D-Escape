using System.Collections;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;

    private Vector2 movementInput;
    private Animator animator;
    private BoxCollider2D boxCollider;

    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {

        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (movementInput != Vector2.zero)
        {
            Move();
        }

        animator.SetBool("isMoving", movementInput != Vector2.zero);
        animator.SetFloat("MoveX", movementInput.x);
        animator.SetFloat("MoveY", movementInput.y);
    }

    private void Move()
    {
        Vector3 targetPos = transform.position + (Vector3)movementInput * moveSpeed * Time.deltaTime;

        if (IsWalkable(targetPos))
        {
            transform.position = targetPos;
        }
        else
        {
            Vector3 checkPosX = new Vector3(targetPos.x, transform.position.y, transform.position.z);
            Vector3 checkPosY = new Vector3(transform.position.x, targetPos.y, transform.position.z);

            if (IsWalkable(checkPosX))
            {
                transform.position = checkPosX;
            }
            else if (IsWalkable(checkPosY))
            {
                transform.position = checkPosY;
            }
        }
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        Vector2 size = boxCollider.size;
        Vector2 offset = boxCollider.offset;
        Vector2 center = (Vector2)targetPos + offset;

        Collider2D hit = Physics2D.OverlapBox(center, size, 0f, solidObjectsLayer);
        return hit == null;
    }

}
