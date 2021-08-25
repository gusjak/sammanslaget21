using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneDialogueManager : MonoBehaviour
{

    public List<Monologue> dialogues;
    public string nextScene;

    void Start()
    {
        DialogueSystem.OnFinish += DialogueSystem_OnFinish;
        DialogueSystem.instance.StartDialogue(dialogues);
    }

    private void DialogueSystem_OnFinish()
    {
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

    private void OnDestroy()
    {
        DialogueSystem.OnFinish -= DialogueSystem_OnFinish;

    }



}
