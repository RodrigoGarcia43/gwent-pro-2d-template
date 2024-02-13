using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject selectedObject;
    public bool isSelected;
    private Camera mainCamera;
    public Vector3 upPosition = new Vector3(0, 5, 0);
    public float speed = 10.0f; // Speed of the movement

    void Start()
    {
        mainCamera = Camera.main; // Cache the main camera
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Creada Línea Majá

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the ray hits this object
                if (!isSelected && hit.transform.gameObject == gameObject)
                {
                    isSelected = true;
                    selectedObject = gameObject; // Select this object

                    // Try to get the Rigidbody component on the hit object
                    // If the object has a Rigidbody, disable its gravity
                    if (gameObject.TryGetComponent<Rigidbody>(out var rb))
                    {
                        rb.useGravity = false;
                    }

                    float step = speed * Time.deltaTime; // Calculate the step size

                    // Move our position a step closer to the target.
                    transform.position = Vector3.MoveTowards(transform.position, mainCamera.transform.position, step);


                }
                else if (isSelected && hit.transform.gameObject == gameObject)
                {
                    isSelected = false;
                    selectedObject = gameObject; // Select this object

                    // Try to get the Rigidbody component on the hit object
                    // If the object has a Rigidbody, disable its gravity
                    if (gameObject.TryGetComponent<Rigidbody>(out var rb))
                    {
                        rb.useGravity = true;
                    }
                }
            }
        }
    }
}
