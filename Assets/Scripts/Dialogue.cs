using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

[System.Serializable]
public class Dialogue 
{
    public string name;
    [TextArea(5,15)]
    public string[] sentences;
}
