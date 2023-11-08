using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 6f;
    Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    
    public AudioManager audioManager;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))        
        {            
            GameOver();
            Debug.Log("Spike");
        }
        else if (other.CompareTag("Finish"))
        {
            Win();
        }
        else if (other.CompareTag("Coin"))
        {
            Debug.Log("coin");
            audioManager.PlayCoin();
            Destroy(other.gameObject);            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
            Debug.Log("Enemy");
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        audioManager.PlayGameOver();
    }
    
    private void Win()
    {
        Debug.Log("Win");
        audioManager.PlayWin();
    }


}
