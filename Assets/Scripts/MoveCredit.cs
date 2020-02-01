using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCredit : MonoBehaviour
{
    public float speed = 100f;
    public float endHeight = 300f;
    [HideInInspector] public bool isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < endHeight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            isFinished = true;
        }
    }
}
