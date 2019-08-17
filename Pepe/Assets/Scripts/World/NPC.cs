using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction
{
    public string[] lines;

    private int currentLine;
    
    public override void OnInteraction()
    {
        if (currentLine < lines.Length)
        {
            Game.instance.refs.GetTextbox().PlayText(lines[currentLine]);
            currentLine++;
        }
        else
        {
            Game.instance.refs.GetTextbox().Hide();
            currentLine = 0;
        }
    }
}
