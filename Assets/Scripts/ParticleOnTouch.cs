using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class ParticleOnTouch : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    particleSystem.Play();
                }
            }
        }
    }
}
