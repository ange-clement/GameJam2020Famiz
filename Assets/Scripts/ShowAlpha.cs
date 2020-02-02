using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAlpha : MonoBehaviour
{
    public MoveCredit moveCredit;
    public float speed = 0.1f;

    private SpriteRenderer titleText;
    private float currentAlpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
        titleText = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCredit.isFinished)
        {
            if (currentAlpha < 1f)
            {
                currentAlpha += speed * Time.deltaTime;
                titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, currentAlpha);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
