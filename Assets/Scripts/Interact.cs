using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource VFXSource;
    public AudioClip pickUpSound;

    private bool canMount = false;
    private Vector2 wantedPos;
    private float mountForce = 350f;
    private Vector3 moutOffset = new Vector3(0, 3.5f);

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
                    playerRb.velocity = Vector2.zero;

                    VFXSource.PlayOneShot(pickUpSound);

                    gameManager.FixSequence1();
                }
            }
            else if(canMount)
            {
                canMount = false;

                playerRb.velocity = Vector2.zero;

                Vector2 dir = (wantedPos - new Vector2(transform.position.x, transform.position.y));
                dir.Normalize();

                float posOffset = .2f;
                if (transform.position.x < wantedPos.x)
                {
                    transform.Translate(Vector3.right * -posOffset);
                }
                else
                {
                    transform.Translate(Vector3.right * posOffset);
                }

                playerRb.AddForce(dir * mountForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Mountable"))
        {
            canMount = true;
            wantedPos = collision.transform.position + moutOffset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fixable"))
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
