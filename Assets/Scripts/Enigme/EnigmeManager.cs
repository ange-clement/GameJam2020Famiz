using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnigmeManager : MonoBehaviour
{
    public GameObject[] enigmes;
    public string nextScene;

    public AudioSource VFXSource;
    public AudioClip[] feedBackClips;

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
        }


        if (status < enigmes.Length-1)
        {
            enigmes[status + 1].SetActive(true);
        }
        else
        {
            End();
        }

        VFXSource.PlayOneShot(feedBackClips[status]);
        status++;
    }

    void End()
    {
        SceneManager.LoadScene(nextScene);
    }
}
