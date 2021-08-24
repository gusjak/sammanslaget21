using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem instance;

    //Add queue variable
    private Queue<string> sentences;

    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI NameBox;
    


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        print("Starting New Dialogue");

        sentences.Clear();
        if (dialogue.sentences.Length == 0)
        {
            Debug.LogWarning("No sentences in Dialogue");
            return;
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            print("Dialogue Ended");
            TextBox.text = "";
            return;
        }

        TextBox.text = sentences.Dequeue();


    }
}
