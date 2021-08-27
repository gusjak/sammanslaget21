using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    // Start is called before the first frame update
    public bool FadeIn;

    void Start()
    {
        if (SoundManager.instance == null)
        {
            return;
        }

        if (FadeIn)
        {
            SoundManager.instance.StartFadeIn();

        }
        else
        {
            FadeOut();
        }
    }

    public void FadeOut()
    {
        SoundManager.instance.StartFadeOut();
    }


}
