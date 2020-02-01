using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaiseSoundManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
