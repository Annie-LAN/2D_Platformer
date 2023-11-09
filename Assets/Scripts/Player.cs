using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f;
    Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    public float lowerBound = -17f;
    
    public AudioManager audioManager;
    public UI ui;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // move the player
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        
        // flip the player's sprite based on the direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // jump
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.75f, 0.06f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // game over if drop below the screen
        if (transform.position.y < lowerBound)
        {
            audioManager.PlayGameOver();
            ui.GameOver(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))        
        {
            audioManager.PlayGameOver();
            ui.GameOver(false);
        }
        else if (other.CompareTag("Finish"))
        {
            audioManager.PlayWin();
            ui.GameOver(true);
        }
        else if (other.CompareTag("Coin"))
        {
            audioManager.PlayCoin();
            Destroy(other.gameObject);            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            audioManager.PlayGameOver();
            ui.GameOver(false);
        }
    }   

}
