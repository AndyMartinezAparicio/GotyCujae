using System;
using UnityEngine;

[Serializable]
public class DialogueCharacter
{
    public string characterName;
    public Sprite icon;
}

[Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[Serializable]
public class Dialogue
{
    public DialogueLine[] lines;
}