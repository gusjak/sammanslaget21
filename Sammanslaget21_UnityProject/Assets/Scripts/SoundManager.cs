using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    AudioSource source;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {

    }

    public void StartFadeIn()
    {
        source.Play();
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        for (float i = 0f; i < 0.99f; i += 0.01f)
        {
            source.volume = i;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        for (float i = 1f; i > 0; i -= 0.01f)
        {
            source.volume = i;
            yield return null;
        }

        source.Stop();
    }



}
