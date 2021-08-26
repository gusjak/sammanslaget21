using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneDialogueManager : MonoBehaviour
{

    public List<Monologue> dialogues;
    public string nextScene;

    public bool fadeOnFinish;

    void Start()
    {
        DialogueSystem.OnD_Finish += DialogueSystem_OnFinish;
        DialogueSystem.instance.StartDialogue(dialogues);
    }

    private void DialogueSystem_OnFinish()
    {

        if (fadeOnFinish)
        {
            if (ScreenFader.instance != null)
            {
                ScreenFader.instance.FadeToLevel(nextScene);
                return;
            }
        }

        SceneManager.LoadScene(nextScene);

    }

    private void Update()
    {

        if (nextScene == "")
        {
            return;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(nextScene);
        //}


    }

    public void DecideNewScene(string newScene)
    {
        SceneManager.LoadScene(newScene);

    }

    private void OnDestroy()
    {
        DialogueSystem.OnD_Finish -= DialogueSystem_OnFinish;

    }



}
