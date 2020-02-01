using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool isFixing = false;
    public Camera camera;
    public GameObject FixGraphicObject1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixSequence1()
    {
        isFixing = true;
        FixGraphicObject1.SetActive(true);
        StartCoroutine(EndFixSequence());
    }

    IEnumerator EndFixSequence()
    {
        yield return new WaitForSeconds(1);
        FixGraphicObject1.SetActive(false);
        isFixing = false;
    }
}
