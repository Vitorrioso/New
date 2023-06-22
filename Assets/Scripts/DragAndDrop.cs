using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;
    Vector2 initialPosition;

    public GameObject selectionEffect;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            HandleInput(touch.phase, touchPosition);
        }
        else
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            HandleInputMouse(mousePosition);
        }
    }

    void HandleInput(TouchPhase phase, Vector2 inputPosition)
    {
        switch (phase)
        {
            case TouchPhase.Began:
                Collider2D touchedCollider = Physics2D.OverlapPoint(inputPosition);
                if (col == touchedCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    moveAllowed = true;
                    initialPosition = transform.position;
                }
                break;
            case TouchPhase.Moved:
                if (moveAllowed)
                {
                    transform.position = new Vector2(inputPosition.x, inputPosition.y);
                }
                break;
            case TouchPhase.Ended:
                moveAllowed = false;
                break;
        }
    }

    void HandleInputMouse(Vector2 inputPosition)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D clickedCollider = Physics2D.OverlapPoint(inputPosition);
            if (col == clickedCollider)
            {
                Instantiate(selectionEffect, transform.position, Quaternion.identity);
                moveAllowed = true;
                initialPosition = transform.position;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (moveAllowed)
            {
                transform.position = new Vector2(inputPosition.x, inputPosition.y);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveAllowed = false;
        }
    }
}
