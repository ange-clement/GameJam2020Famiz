using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float angle = 180f;
    [HideInInspector] public bool isDragable = true;

    private Rigidbody2D objectRb;
    private EnigmeManager enigmeManager;

    private bool followCursor = false;
    // Start is called before the first frame update
    void Start()
    {
        enigmeManager = GameObject.Find("EnigmeManager").GetComponent<EnigmeManager>();
        objectRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followCursor)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

            transform.LookAt(wantedPos, Vector3.forward);

            if (transform.rotation.eulerAngles.z > angle)
            {
                //enigmeManager.next();
            }
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
            }
        }
    }
}
