using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int movementSpeed = 10;
    public int jumpForce = 4;

    private bool is2D = false;

    private Rigidbody2D rb;
    private SpriteRenderer shadow;

    private Vector2 movementVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shadow = transform.Find("Shadow").gameObject.GetComponent<SpriteRenderer>();
        shadow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.F)) { is2D = !is2D; shadow.enabled = is2D; };

        if (is2D)
        {
            rb.gravityScale = 0;

            movementVector = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);

        } else
        {
            rb.gravityScale = 1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(1, jumpForce * 50));
            }

            movementVector = new Vector2(horizontal * movementSpeed, rb.linearVelocity.y);
        }
        
        

        

    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementVector;
    }
}
