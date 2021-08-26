using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueSystem : MonoBehaviour
{

    public static DialogueSystem instance;

    public delegate void DialogueFinished();
    public static event DialogueFinished OnD_Finish;

    public delegate void MonologueStarted();
    public static event MonologueStarted OnM_Started;

    //Add queue variable
    private Queue<string> sentences;
    private Queue<Monologue> dialogues;

    public TextMeshProUGUI speechBox;
    public TextMeshProUGUI nameBox;

    private Coroutine textScroll;
    public float letterWaitTime;

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

        sentences = new Queue<string>();
        dialogues = new Queue<Monologue>();

        sentences.Enqueue("if you read this something went wrong");

        DontDestroyOnLoad(gameObject);

    }

    public void StartDialogue(List<Monologue> newDialogues)
    {

        print("Starting New Dialogue");
        

        dialogues.Clear();

        if (newDialogues.Count == 0)
        {
            Debug.LogWarning("No dialogues in newDialogues");
            return;
        }

        foreach (Monologue dialogue in newDialogues)
        {
            dialogues.Enqueue(dialogue);

        }

        //DisplayNextSentence();

        StartMonologue(dialogues.Dequeue());
    }

    public void StartMonologue(Monologue monologue)
    {
        print("Starting New Monologue");

        if (monologue.animTrigger)
        {
            OnM_Started();
        }
        
        sentences.Clear();

        if (monologue.sentences.Length == 0)
        {
            Debug.LogWarning("No sentences in Monologue");
            return;
        }

        nameBox.text = monologue.name;

        foreach (string sentence in monologue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }

    //This is mainly triggered by ContinueButton in the dialogue system prefab
    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            if (dialogues.Count == 0)
            {
                print("All Dialogues done");
                OnD_Finish();
                return;
            }

            StartMonologue(dialogues.Dequeue());
            return;
        }

        //speechBox.text = sentences.Dequeue();
        string sentence = sentences.Dequeue();

        if(textScroll != null)
        {
            StopCoroutine(textScroll);
        }

        textScroll = StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        speechBox.text = "";

        foreach (char letter in sentence)
        {
            speechBox.text += letter;
            yield return new WaitForSeconds(letterWaitTime);
        }

    }


}
