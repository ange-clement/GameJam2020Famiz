using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool canMount = false;
    private Vector2 wantedPos;
    private float mountForce = 310f;
    private Vector3 moutOffset = new Vector3(0, 3);

    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMount && Input.GetButtonDown("Interact"))
        {
            Vector2 dir = (wantedPos - new Vector2(transform.position.x, transform.position.y));
            dir.Normalize();
            playerRb.AddForce(dir * mountForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mountable"))
        {
            canMount = true;
            wantedPos = collision.transform.position + moutOffset;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mountable"))
        {
            canMount = false;
        }
    }
}
