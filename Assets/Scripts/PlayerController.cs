﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float force = 2000f;

    public AudioSource walkSource;
    public AudioClip[] walkSounds;
    private bool playWalkSound = false;
    private float playTime = .5f;
    private float playTimer = 0f;

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

            if (Mathf.Abs(playerRb.velocity.x)<0.1f || Mathf.Abs(playerRb.velocity.y)>0.1f)
            {
                if (playWalkSound)
                {
                    playWalkSound = false;
                    walkSource.Stop();
                }
            }
            else if (Mathf.Abs(playerRb.velocity.x) > 0.1f)
            {
                playWalkSound = true;
            }
        }
        else
        {
            if (walkSource.isPlaying)
            {
                walkSource.Stop();
                playWalkSound = false;
            }
        }

        if (playWalkSound && !walkSource.isPlaying && playTimer + playTime < Time.time)
        {
            playTimer = Time.time;

            int randomClipId = Random.Range(0, walkSounds.Length);
            walkSource.clip = walkSounds[randomClipId];

            walkSource.Play();
        }
    }
}
