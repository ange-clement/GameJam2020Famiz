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
        enigmes[status].GetComponentInChildren<DragableObject>().isDragable = false;
        if (status < enigmes.Length-1)
        {
            enigmes[status + 1].SetActive(true);
        }
        else
        {
            Debug.Log("FIN");
        }

        VFXSource.PlayOneShot(feedBackClips[status]);

        status++;
    }

    void End()
    {
        SceneManager.LoadScene(nextScene);
    }
}
