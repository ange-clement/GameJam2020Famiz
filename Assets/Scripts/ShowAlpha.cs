using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowAlpha : MonoBehaviour
{
    public MoveCredit moveCredit;
    public float speed = 0.1f;

    private TextMeshProUGUI titleText;
    private float currentAlpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
        titleText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCredit.isFinished)
        {
            if (currentAlpha < 1f)
            {
                currentAlpha += speed * Time.deltaTime;
                titleText.alpha = currentAlpha;
            }
        }
    }
}
