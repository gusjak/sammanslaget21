using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    Animator animator;


    private void Awake()
    {
        DialogueSystem.OnM_Started += DialogueSystem_OnM_Started;
    }

    private void DialogueSystem_OnM_Started()
    {
        animator.SetTrigger("NextAnimation");
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnDestroy()
    {
        DialogueSystem.OnM_Started -= DialogueSystem_OnM_Started;

    }
}
