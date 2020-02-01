﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmeManager : MonoBehaviour
{
    public GameObject squareEnigme;
    public GameObject triangleEnigme;

    private int status = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void next()
    {
        if (status == 0)
        {
            squareEnigme.GetComponentInChildren<DragableObject>().isDragable = false;
            triangleEnigme.SetActive(true);
        }
        else if (status == 1)
        {
            triangleEnigme.GetComponentInChildren<DragableObject>().isDragable = false;
            Debug.Log("FIN ENIGME"); //TODO
        }
        status++;
    }
}
