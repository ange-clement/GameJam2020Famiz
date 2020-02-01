using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float length = 20f;
    public float angle = -360f;
    [HideInInspector] public bool isDragable = true;
    public float helperTime = 3f;
    public GameObject helper;

    private Rigidbody2D objectRb;
    private EnigmeManager enigmeManager;
    private BoxCollider2D collider;
    private Vector2 originalSize;

    private bool followCursor = false;
    private float initProgress = 0f;
    private float progress = 0f;
    // Start is called before the first frame update
    void Start()
    {
        enigmeManager = GameObject.Find("EnigmeManager").GetComponent<EnigmeManager>();
        objectRb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        originalSize = collider.size;

        StartCoroutine(ShowHelper());
    }

    IEnumerator ShowHelper()
    {
        yield return new WaitForSeconds(helperTime);
        helper.SetActive(true);
    }

    void DisableHelpers()
    {
        helper.SetActive(false);
        StartCoroutine(ShowHelper());
    }

    // Update is called once per frame
    void Update()
    {
        if (followCursor)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 plannedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

            progress = initProgress + plannedPos.x / length;
            transform.rotation = Quaternion.Euler(0, 0, progress * angle);

            if (Mathf.Abs(progress) >= 1f)
            {
                followCursor = false;
                initProgress = progress;
                collider.size = originalSize;
                transform.rotation = Quaternion.Euler(0, 0, angle);

                helper.SetActive(false);

                enigmeManager.next();
            }
        }
    }

    private void OnMouseDown()
    {
        if (!followCursor && isDragable)
        {
            followCursor = true;
            collider.size = new Vector2(100, 100);

            DisableHelpers();
        }
        else
        {
            followCursor = false;
            initProgress = progress;
            collider.size = originalSize;
        }
    }
}
