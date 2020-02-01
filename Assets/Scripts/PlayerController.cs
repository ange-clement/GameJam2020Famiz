using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public float force = 2000f;

    private Rigidbody2D playerRb;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GetComponent<Interact>().gameManager;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.isFixing)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (Mathf.Abs(playerRb.velocity.x) < speed)
            {
                playerRb.AddForce(Vector2.right * horizontalInput * force, ForceMode2D.Force);
            }

            if (horizontalInput == 0 && Mathf.Abs(playerRb.velocity.y) < 0.1f)
            {
                playerRb.drag = 10f;
            }
            else
            {
                playerRb.drag = 0f;
            }
        }
    }
}
