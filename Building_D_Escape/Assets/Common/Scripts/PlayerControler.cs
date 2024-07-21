using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
<<<<<<< HEAD
    private bool isMoving;
=======

>>>>>>> e6bd1343efee0cdb75132ef3ae9946c222f3d132
    private Vector2 movementInput;
    private Animator animator;

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

        Debug.Log("X: " + movementInput.x);
        Debug.Log("Y: " + movementInput.y);

        if (movementInput != Vector2.zero)
        {
<<<<<<< HEAD
            isMoving = true;
=======
>>>>>>> e6bd1343efee0cdb75132ef3ae9946c222f3d132
            animator.SetFloat("MoveX", movementInput.x);
            animator.SetFloat("MoveY", movementInput.y);

            Vector2 targetPosition = (Vector2)transform.position + movementInput * moveSpeed * Time.deltaTime;
            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
<<<<<<< HEAD
            isMoving = false;
=======
>>>>>>> e6bd1343efee0cdb75132ef3ae9946c222f3d132
        }
    }
    // animator.SetBool("isMoving", isMoving)
}