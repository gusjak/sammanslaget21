using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Monologue
{
    public string name;

    public bool animTrigger;
    [TextArea(3,10)]
    public string[] sentences;


}
