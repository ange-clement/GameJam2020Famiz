using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameManager gameManager;

    private bool canMount = false;
    private Vector2 wantedPos;
    private float mountForce = 320f;
    private Vector3 moutOffset = new Vector3(0, 3);

    private bool canFix = false;
    private int idFix;

    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (canFix)
            {
                canFix = false;
                if (idFix == 1)
                {
                    gameManager.FixSequence1();
                }
            }
            else if(canMount)
            {
                canMount = false;
                Vector2 dir = (wantedPos - new Vector2(transform.position.x, transform.position.y));
                dir.Normalize();
                playerRb.AddForce(dir * mountForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mountable"))
        {
            canMount = true;
            wantedPos = collision.transform.position + moutOffset;
        }
        else if (collision.CompareTag("Fixable"))
        {
            canFix = true;
            idFix = collision.GetComponent<FixManager>().idFix;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mountable"))
        {
            canMount = false;
        }
        else if (collision.CompareTag("Fixable"))
        {
            canFix = false;
        }
    }
}
