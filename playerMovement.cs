using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovement : MonoBehaviour
{

    [SerializeField]
float speed =3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
  
        

         Vector2 movementX = new Vector2(moveX, 0);


                // if (Input.GetKeyDown("space"))

         transform.Translate(movementX * speed * Time.deltaTime);

         
    }
}
