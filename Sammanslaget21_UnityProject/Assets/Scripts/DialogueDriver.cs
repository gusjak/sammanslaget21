using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDriver : MonoBehaviour
{



    public Dialogue[] dialogue;

    void Start()
    {
        DialogueSystem.instance.StartDialogue(dialogue[0]);
            
    }


}
