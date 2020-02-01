using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    public Collider2D targetCollider;
    [HideInInspector] public bool isDragable = true;
    public float helperTime = 3f;
    public GameObject[] helpers;

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

        StartCoroutine(ShowHelper());
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

    IEnumerator ShowHelper()
    {
        yield return new WaitForSeconds(helperTime);
        if (isDragable)
        {
            if (followCursor)
            {
                helpers[0].SetActive(false);
                helpers[1].SetActive(true);
            }
            else
            {
                helpers[0].SetActive(true);
                helpers[1].SetActive(false);
            }
        }
    }

    void DisableHelpers()
    {
        helpers[0].SetActive(false);
        helpers[1].SetActive(false);
        StartCoroutine(ShowHelper());
    }

    private void OnMouseDown()
    {
        if (isDragable)
        {
            if (!followCursor)
            {
                followCursor = true;

                DisableHelpers();
            }
            else
            {
                followCursor = false;

                if (objectRb.IsTouching(targetCollider))
                {
                    helpers[0].SetActive(false);
                    helpers[1].SetActive(false);
                    enigmeManager.next();
                }
                else
                {
                    DisableHelpers();
                }
            }
        }
    }
}
