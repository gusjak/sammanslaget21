using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDialogueManager : MonoBehaviour
{

    public List<Monologue> dialogues;
    private int currentDialogue;

    void Start()
    {
        DialogueSystem.instance.StartDialogue(dialogues);
    }

    private void Update()
    {


    }



}
