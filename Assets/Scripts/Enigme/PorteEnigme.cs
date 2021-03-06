﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteEnigme : MonoBehaviour
{
    public Collider2D targetCollider;
    [HideInInspector] public bool isDragable = true;
    public float helperTime = 3f;
    public GameObject[] helpers;
    public bool inverted = false;

    public AudioSource vfxSource;
    public AudioClip openClip;
    public AudioClip closeClip;

    private Vector3 initPos;
    private Rigidbody2D objectRb;
    private EnigmeManager enigmeManager;

    private bool followCursor = false;
    // Start is called before the first frame update
    void Start()
    {
        enigmeManager = GameObject.Find("EnigmeManager").GetComponent<EnigmeManager>();
        initPos = transform.position;
        objectRb = GetComponent<Rigidbody2D>();

        StartCoroutine(ShowHelper());
    }

    // Update is called once per frame
    void Update()
    {
        if (followCursor)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));

            bool canMoveDoor = false;
            if (!inverted)
            {
                canMoveDoor = (wantedPos.x > targetCollider.transform.position.x && wantedPos.x < initPos.x);
            }
            else
            {
                canMoveDoor = (wantedPos.x < targetCollider.transform.position.x && wantedPos.x > initPos.x);
            }
            if (canMoveDoor)
            {
                transform.position = new Vector3(wantedPos.x, initPos.y, initPos.y);
            }
        }
    }

    IEnumerator ShowHelper()
    {
        yield return new WaitForSeconds(helperTime);
        if (isDragable)
        {
            if (followCursor)
            {
                helpers[0].SetActive(false);
                helpers[1].SetActive(true);
            }
            else
            {
                helpers[0].SetActive(true);
                helpers[1].SetActive(false);
            }
        }
    }

    void DisableHelpers()
    {
        helpers[0].SetActive(false);
        helpers[1].SetActive(false);
        StartCoroutine(ShowHelper());
    }

    private void OnMouseDown()
    {
        if (isDragable)
        {
            if (!followCursor)
            {
                followCursor = true;

                vfxSource.PlayOneShot(openClip);

                DisableHelpers();
            }
            else
            {
                followCursor = false;
                vfxSource.PlayOneShot(closeClip);

                if (objectRb.IsTouching(targetCollider))
                {
                    helpers[0].SetActive(false);
                    helpers[1].SetActive(false);

                    enigmeManager.next();
                }
                else
                {
                    DisableHelpers();
                }
            }
        }
    }
}
