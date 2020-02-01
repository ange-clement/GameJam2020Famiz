using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public AudioSource sourceAudio;
    public AudioClip[] clips;

    private bool collided = false;

    private void Update()
    {
        if (collided && !sourceAudio.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !sourceAudio.isPlaying) {
            collided = true;

            int randomIndex = Random.Range(0, clips.Length);
            sourceAudio.PlayOneShot(clips[randomIndex]);
        }
    }
}
