using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmeManager : MonoBehaviour
{
    public GameObject squareEnigme;
    public GameObject triangleEnigme;
    public string nextScene;

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
            SceneManager.LoadScene(nextScene);
        }
        status++;
    }
}
