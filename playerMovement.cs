using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 3;

    [SerializeField]
    float jumpforce = 100;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    float groundRadius = 0.1f;

    [SerializeField]
    LayerMask groundLayer;

    bool mayJump = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("hej");

        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movementX = new Vector2(moveX, 0);


        transform.Translate(movementX * speed * Time.deltaTime);

        // bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        Vector3 size = MakeGroundcheckSize();
        bool isGrounded = Physics2D.OverlapBox(groundCheck.position, size, 0,groundLayer);


        if (Input.GetAxisRaw("Jump") > 0 && mayJump == true && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 jump = Vector2.up * jumpforce;

            rb.AddForce(jump);

            mayJump = false;
        }


        if (Input.GetAxisRaw("Jump") == 0)
        {
            mayJump = true;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 size = MakeGroundcheckSize();
        Gizmos.DrawWireCube(groundCheck.position, size);

    }

    private Vector3 MakeGroundcheckSize() => new Vector3(1.5f, groundRadius);

}
