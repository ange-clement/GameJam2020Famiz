using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    public Collider2D targetCollider;
    [HideInInspector] public bool isDragable = true;

    private Vector3 initPos;
    private Rigidbody2D objectRb;
    private EnigmeManager enigmeManager;

    private bool followCursor = false;
    // Start is called before the first frame update
    void Start()
    {
        enigmeManager = GameObject.Find("EnigmeManager").GetComponent<EnigmeManager>();
        initPos = transform.position;
        objectRb = GetComponent<Rigidbody2D>();
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
        if (isDragable)
        {
            if (!followCursor)
            {
                followCursor = true;
            }
            else
            {
                followCursor = false;

                if (objectRb.IsTouching(targetCollider))
                {
                    enigmeManager.next();
                }
            }
        }
    }
}
