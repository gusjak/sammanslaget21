using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject thingToToggle;

    public void ToggleThing()
    {

        thingToToggle.SetActive(!thingToToggle.activeInHierarchy);
    }
}
