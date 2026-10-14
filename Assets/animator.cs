using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 5f; // <-- added

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Animator Controller: " + animator.runtimeAnimatorController.name);
        rb = GetComponent<Rigidbody2D>();
        animator.SetFloat("Speed", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(
            horizontal * moveSpeed,
            rb.velocity.y
        );

        animator.SetFloat("Speed", Mathf.Abs(horizontal)); // <-- fixed typo

        Debug.Log("Horizontal: " + horizontal + " | Speed: " + animator.GetFloat("Speed"));

        if (Input.GetKeyDown(KeyCode.M) && isGrounded)
        {
            rb.velocity = new Vector2(
                rb.velocity.x,
                jumpForce
            );

            isGrounded = false;
        }
    }
}