using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnTouch : MonoBehaviour
{
    public float speed;
    public float smoothingSpeed;

    private Vector3 startPos;
    private Vector3 previousPos;
    private Vector3 currentPos;
    private Vector3 offsetPos;
    private Vector3 newPos;
    private float offset;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.localEulerAngles;
        timer = 2f;
        DragAndDrop.isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DragAndDrop.isDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                currentPos = Input.mousePosition;
                if (currentPos.x != previousPos.x)
                {
                    offset = currentPos.x - previousPos.x;
                    newPos = transform.localEulerAngles;
                    newPos.y += (Mathf.Clamp(offset, -10f, 10f) * speed) % 360f;
                    timer = 0f;
                }

                previousPos = currentPos;
            }
            timer += Time.deltaTime * smoothingSpeed;

            if (newPos.y < 359.9f)
                transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, newPos, timer);
            else
                transform.localEulerAngles = newPos;
        }
    }
}
