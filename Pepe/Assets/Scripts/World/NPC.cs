﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction
{
    public string[] lines;
    public GameObject[] objects;
    private int currentLine;
    
    public override void OnInteraction()
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
            else if(lines[currentLine].StartsWith("["))
            {
                // TODO: add or remove object from inventory
                Debug.Log(lines[currentLine]);
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
