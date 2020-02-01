using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    public string playSceneName;
    public float fadeOutTime = 2f;
    private float alphaSpeed = .8f;
    public TextMeshProUGUI[] texts;
    public Image[] images;

    public AudioSource VfxSource;
    public AudioClip playSound;

    private bool isFading = false;
    private float alpha = 1f;


    private void Update()
    {
        if (isFading)
        {
            foreach (TextMeshProUGUI text in texts)
            {
                text.alpha = alpha;
            }
            foreach (Image image in images)
            {
                image.color = new Color(image.material.color.r, image.material.color.g, image.material.color.b, alpha);
            }
            alpha -= alphaSpeed * Time.deltaTime;
        }
    }

    public void Jouer()
    {
        isFading = true;
        VfxSource.PlayOneShot(playSound);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadScene(playSceneName);
    }
}
