using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 10f;
    private Vector3 touchPosition;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float xpos;
        float xposition;
        
       

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            xposition = touchPosition.x;
            if (xposition < 5 && xposition > -5)
            {
                direction = (touchPosition - transform.position);
                rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;
            }

            

            if (touch.phase == TouchPhase.Ended)
                rb.velocity = Vector2.zero;
        }

        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            xpos = mousePosition.x;

            if (xpos < 5 && xpos > -5)
            {

                direction = (mousePosition - transform.position);
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

            }
            Debug.Log("Move");
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

