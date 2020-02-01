using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private float force = 2000f;

    public AudioSource walkSource;
    public AudioClip[] walkSounds;
    public AudioSource foleySource;
    public AudioClip[] foleySounds;
    public Animator animator;
    private bool playWalkSound = false;
    private float playTime = .5f;
    private float playTimer = 0f;

    public ParticleSystem walkParticle;

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

            if (horizontalInput == 0 && Mathf.Abs(playerRb.velocity.y) < 0.01f)
            {
                playerRb.drag = 10f;
            }
            else
            {
                playerRb.drag = 0f;
            }

            if (Mathf.Abs(playerRb.velocity.x)<0.01f || Mathf.Abs(playerRb.velocity.y)>0.01f)
            {
                if (playWalkSound)
                {
                    playWalkSound = false;
                    walkSource.Stop();
                }
                if (walkParticle.isPlaying)
                {
                    walkParticle.Stop();
                }
                if (animator.GetBool("mooving_b")) {
                    animator.SetBool("mooving_b", false);
                    Debug.Log(playerRb.velocity.x);
                }

            }
            else if (Mathf.Abs(playerRb.velocity.x) > 0.01f)
            {
                playWalkSound = true;
                if (!walkParticle.isPlaying)
                {
                    walkParticle.Play();
                }
                if (!animator.GetBool("mooving_b"))
                {
                    animator.SetBool("mooving_b", true);
                    Debug.Log(playerRb.velocity.x);
                }
            }
        }
        else
        {
            if (walkSource.isPlaying)
            {
                walkSource.Stop();
                playWalkSound = false;
            }
            if (walkParticle.isPlaying)
            {
                walkParticle.Stop();
            }
        }

        if (playWalkSound && !walkSource.isPlaying && playTimer + playTime < Time.time)
        {
            playTimer = Time.time;

            int randomWalkClipId = Random.Range(0, walkSounds.Length);
            walkSource.clip = walkSounds[randomWalkClipId];
            int randomFoleyClipId = Random.Range(0, foleySounds.Length);
            foleySource.clip = foleySounds[randomFoleyClipId];

            PlayWalk();
        }
    }

    void PlayWalk()
    {
        walkSource.Play();
        foleySource.Play();
    }
}
