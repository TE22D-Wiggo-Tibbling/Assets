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

    bool mayJump = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movementX = new Vector2(moveX, 0);


        transform.Translate(movementX * speed * Time.deltaTime);

        if (Input.GetAxisRaw("Jump") > 0 && mayJump == true)
        {
            mayJump = false;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            Vector2 jump = Vector2.up * jumpforce;
            rb.AddForce(jump);
        }

        // if (Input.GetAxisRaw("Jump") == 0)
        // {
        //     mayJump = true;
        // }
    }


   void OnCollisionEnter2D(Collision2D other) {
        mayJump=true;
    }
}
