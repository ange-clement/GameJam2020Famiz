using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isFixing = false; // Stop the player
    public GameObject[] FixGraphicObjects1; //Sequence of images
    public string enigmeScene1; //Scene to load at the end

    private int idImage = 0; //track the progress
    private float startTimeDown; //The time at the player began to press the key
    private float interCommandDelay = 1f; //delay time between keys
    private float holdOnDelay = 1f; //delay to hold on the kay
    private float pickupTime = 2f; //delay between the time the player press the interract button and the first picture

    private bool isInQTS = false; //if the player have to presse the key

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInQTS)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                startTimeDown = Time.time;
                Debug.Log("start F : "+startTimeDown);
            }
            else if (Input.GetKeyUp(KeyCode.F))
            {
                Debug.Log("Cut F");
                startTimeDown = 0f;
            }

            if (startTimeDown != 0f && startTimeDown + holdOnDelay < Time.time)
            {
                Debug.Log("End F");
                startTimeDown = 0f;

                FixGraphicObjects1[idImage].SetActive(false);
                idImage++;
                FixGraphicObjects1[0].SetActive(false);
                FixGraphicObjects1[idImage].SetActive(true);

                EndFixSequence();
            }
        }
    }

    public void FixSequence1()
    {
        isFixing = true;
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(pickupTime);
        SceneManager.LoadScene(enigmeScene1);
    }

    IEnumerator BeginFix1()
    {
        yield return new WaitForSeconds(pickupTime);
        Debug.Log("début");
        FixGraphicObjects1[0].SetActive(true);
        idImage = 1;
        StartCoroutine(ShowCurrentImage());
    }

    IEnumerator ShowCurrentImage()
    {
        yield return new WaitForSeconds(interCommandDelay);
        isInQTS = true;
        Debug.Log("next");
        FixGraphicObjects1[idImage].SetActive(true);
    }

    void EndFixSequence()
    {
        Debug.Log("fin");
        foreach (GameObject fixImage in FixGraphicObjects1)
        {
            fixImage.SetActive(false);
        }
        isFixing = false;
        isInQTS = false;
        SceneManager.LoadScene(enigmeScene1);
    }
}
