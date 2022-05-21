using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;

    [SerializeField] bool isGrounded = false;

    Rigidbody2D RB;

    
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}
