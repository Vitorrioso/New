        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

        public class DragAndDrop1 : MonoBehaviour
        {

            bool moveAllowed;
            Collider2D col;

            public GameObject selectionEffect;

            // Update is called once per frame
            void Update()
            {
                if(Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    if (touch.phase ==TouchPhase.Began)
                    {
                        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                        if (col == touchedCollider)
                        {
                            Instantiate(selectionEffect, transform.position, Quaternion.identity);

                            moveAllowed = true;
                        }

                    }

                    if (touch.phase == TouchPhase.Moved)
                    {
                        if (moveAllowed)
                        {
                            transform.position = new Vector2(touchPosition.x, touchPosition.y);
                        }

                    }


                    if (touch.phase == TouchPhase.Ended)
                    {
                        moveAllowed = false;

                    }

                }
            }
        }