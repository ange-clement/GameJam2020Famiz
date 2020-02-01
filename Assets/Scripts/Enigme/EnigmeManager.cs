﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmeManager : MonoBehaviour
{
    public GameObject[] enigmes;
    public string nextScene;

    public AudioSource VFXSource;
    public AudioClip[] successClips;
    public AudioClip[] failClips;

    public int idEnigme = 0;

    private int status = 0;

    public void next()
    {
        DragableObject dragableObject = enigmes[status].GetComponentInChildren<DragableObject>();
        if (dragableObject != null)
        {
            dragableObject.isDragable = false;
        }
        else
        {
            SpinObject spinObject = enigmes[status].GetComponentInChildren<SpinObject>();
            if (spinObject != null)
            {
                spinObject.isDragable = false;
            }
            else
            {
                PorteEnigme enigmeObject = enigmes[status].GetComponentInChildren<PorteEnigme>();
                if (enigmeObject != null)
                {
                    enigmeObject.isDragable = false;
                }
            }
        }


        if (status < enigmes.Length-1)
        {
            enigmes[status + 1].SetActive(true);
            if (idEnigme == 1 && status == 1)
            {
                enigmes[0].SetActive(false);
            }
        }
        else
        {
            End();
        }

        VFXSource.PlayOneShot(successClips[status]);
        status++;
    }

    public void fail()
    {
        int randomIdFail = Random.Range(0, failClips.Length);
        VFXSource.PlayOneShot(failClips[randomIdFail]);
    }

    void End()
    {
        SceneManager.LoadScene(nextScene);
    }
}