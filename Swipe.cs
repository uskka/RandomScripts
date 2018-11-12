
using UnityEngine;
using System.Collections;

public class Swipe : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public float speed;
    private Rigidbody2D rb2d;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 endPosition = Vector3.zero;

    void Update()
    {
        Vector2 movementLeft = new Vector2(-0.5f, 0.0f);
        Vector2 movementRight = new Vector2(0.5f, 0.0f);
        Vector2 movementUp = new Vector2(0.0f, 0.5f);
        Vector2 movementDown = new Vector2(0.0f, -0.5f);
        if (Input.GetMouseButtonDown(0))    // swipe begins
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))    // swipe ends
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //MoveDirection
        //anim.SetInteger("MoveDirection", 1); L-R
        //anim.SetInteger("MoveDirection", 2); R-L
        //anim.SetInteger("MoveDirection", 3); U-D
        //anim.SetInteger("MoveDirection", 4); D-U

        Debug.Log(rb2d.velocity.magnitude);
        
        if (rb2d.velocity.magnitude > 8)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);

            if (rb2d.velocity.magnitude == 0)
            {

                if (startPosition != endPosition && startPosition != Vector3.zero && endPosition != Vector3.zero)
                {
                    float deltaX = endPosition.x - startPosition.x;
                    float deltaY = endPosition.y - startPosition.y;

                    if (deltaX > 0.0f && deltaY > 0.0f) // ++
                    {
                        if (deltaX > deltaY)  //Right
                        {
                            rb2d.AddForce(movementRight * speed);
                            anim.SetInteger("MoveDirection", 1);

                        }
                        else   // up
                        {
                            rb2d.AddForce(movementUp * speed);
                            anim.SetInteger("MoveDirection", 4);
                        }


                    }

                    else if (deltaX < 0.0f && deltaY < 0.0f) //--
                    {

                        if (deltaX > deltaY)  //Down
                        {
                            rb2d.AddForce(movementDown * speed);
                            anim.SetInteger("MoveDirection", 3);

                        }
                        else   // Left
                        {
                            rb2d.AddForce(movementLeft * speed);
                            anim.SetInteger("MoveDirection", 2);
                        }






                    }

                    else if (deltaX < 0.0f && deltaY > 0.0f) //-+
                    {

                        if (-deltaX < deltaY)  //UP
                        {
                            rb2d.AddForce(movementUp * speed);
                            anim.SetInteger("MoveDirection", 4);

                        }
                        else   // Left
                        {
                            rb2d.AddForce(movementLeft * speed);
                            anim.SetInteger("MoveDirection", 2);
                        }
                    }

                    else if (deltaX > 0.0f && deltaY < 0.0f) //-+
                    {

                        if (deltaX < -deltaY)  //Down
                        {
                            rb2d.AddForce(movementDown * speed);
                            anim.SetInteger("MoveDirection", 3);

                        }
                        else   // Right
                        {
                            rb2d.AddForce(movementRight * speed);
                            anim.SetInteger("MoveDirection", 1);
                        }
                    }


                    startPosition = endPosition = Vector3.zero;
                }
            }
        }
    }
}