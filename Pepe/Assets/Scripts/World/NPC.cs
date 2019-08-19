using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction
{
    public string[] conditions;

    public string[] lines;
    public GameObject[] objects;
    private int currentLine;

    private const string negativeChar = "!";
    
    public override void OnInteraction()
    {
        bool play = true;

        foreach (string condition in conditions)
        {
            if(condition.StartsWith(negativeChar) && Game.instance.keys.HasKey(condition.Substring(1)))
            {
                play = false;
                break;
            }
            else if (!Game.instance.keys.HasKey(condition))
            {
                play = false;
                break;
            }
        }

        if(play)
        {
            PlayLine();
        }

    }

    private void PlayLine()
    {
        if (currentLine < lines.Length)
        {
            if (lines[currentLine].StartsWith("*"))
            {
                string operation = lines[currentLine].Substring(1).Split(' ')[0];
                string objectIndex = lines[currentLine].Split(' ')[1];


                EnableObject(operation == "enable", int.Parse(objectIndex));
                currentLine++;
                OnInteraction();
            }
            else if (lines[currentLine].StartsWith("["))
            {
                Game.instance.keys.AddOrRemoveKeyFromLine(lines[currentLine]);
                currentLine++;
                OnInteraction();
            }
            else
            {
                Game.instance.refs.GetTextbox().PlayText(lines[currentLine]);
                currentLine++;
            }
        }
        else
        {
            Game.instance.refs.GetTextbox().Hide();
            currentLine = 0;
        }
    }

    private void EnableObject(bool enable, int objectIndex)
    {
        objects[objectIndex].SetActive(enable);
    }
}
