using System.Collections;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float moveSpeed;
    public bool isMoving;

    private Vector2 movementInput;
    private Animator animator;

    public LayerMask solidObjectsLayer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        transform.position = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        // Debug.Log("X: " + movementInput.x);
        // Debug.Log("Y: " + movementInput.y);
        if (movementInput != Vector2.zero)
        {

            Vector2 targetPos = (Vector2)transform.position + movementInput * moveSpeed * Time.deltaTime;
            // animator.SetBool("isMoving", true);
            // animator.SetFloat("MoveX", movementInput.x);
            // animator.SetFloat("MoveY", movementInput.y);

            // transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);


                    // collision
            Debug.Log(IsWalkable(targetPos));
            if (IsWalkable(targetPos)) {
                

            animator.SetBool("isMoving", true);
            animator.SetFloat("MoveX", movementInput.x);
            animator.SetFloat("MoveY", movementInput.y);

            transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);

            }
            
        }else {
            animator.SetBool("isMoving", false);
        }
          

    }

    private bool IsWalkable(Vector3 targetPos) {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null ) {
            return false;

        }else {
            return true;
        }
    }
}