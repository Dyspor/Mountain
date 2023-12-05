using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Bewegung
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Animation "Walk"
        bool isWalking = Mathf.Abs(horizontalInput) > 0.1f;
        animator.SetBool("Walk", isWalking);

        // Sprung
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("Jump", !isGrounded);
        }

        
       

        // Blast
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Hier kannst du den Code für die "Blast"-Funktion einfügen
            // Zum Beispiel eine Animation abspielen oder spezielle Logik auslösen
            animator.SetTrigger("Blast");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Grounded Check
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
