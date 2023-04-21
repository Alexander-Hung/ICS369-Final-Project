using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from https://youtu.be/_nRzoTzeyxU

[System.Serializable]
public class Dialogue
{
    public string title;
    public string[] names;
    public string[] lines;
}

[System.Serializable]
public class DialogueList
{
    public Dialogue[] dialogue;
}
