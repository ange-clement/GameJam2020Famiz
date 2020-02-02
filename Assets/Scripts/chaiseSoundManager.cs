using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaiseSoundManager : MonoBehaviour
{
    public GameObject spaceObject;

    public AudioSource vfxSource;
    public AudioClip landClip;

    private Rigidbody2D rb;
    private AudioSource source;

    private float indicatorZone = 3.5f;
    bool imShow = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Arret ou reprise du son quand on est immobile ou en mouvement
        if (rb.velocity.magnitude > 0.1f)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else if (rb.velocity.magnitude < 0.1f)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
        }

        if (transform.position.x > indicatorZone)
        {
            if (!imShow)
            {
                imShow = true;
                spaceObject.SetActive(true);
            }
        }
        else if (imShow)
        {
            imShow = false;
            spaceObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.transform.position.y > transform.position.y)
        {
            vfxSource.PlayOneShot(landClip);
        }
    }
}
