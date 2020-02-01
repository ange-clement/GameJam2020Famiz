using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    private Vector3 initPos;

    private bool followCursor = false;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followCursor)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            transform.position = wantedPos;
        }
    }

    private void OnMouseDown()
    {
        if (!followCursor)
        {
            followCursor = true;
        }
        else
        {
            followCursor = false;
        }
    }
}
