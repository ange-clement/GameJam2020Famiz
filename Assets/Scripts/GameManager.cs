using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isFixing = false;
    public GameObject[] FixGraphicObjects1;

    private int idImage = 0;
    private bool haveToPress = false;
    private float startTimeDown;
    private float interCommandDelay = 1f;
    private float holdOnDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixing)
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
        Debug.Log("début");
        isFixing = true;
        FixGraphicObjects1[0].SetActive(true);
        idImage = 1;
        StartCoroutine(ShowCurrentImage());
    }

    IEnumerator ShowCurrentImage()
    {
        yield return new WaitForSeconds(interCommandDelay);
        Debug.Log("next");
        haveToPress = true;
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
    }
}
