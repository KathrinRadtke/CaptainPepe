﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interaction
{
    public string[] conditions;

    public string[] lines;
    public GameObject[] objects;
    private int currentLine;

    private const string negativeChar = "!";
    private const string funfare = "FUN";
    private const string pickup = "PICKUP";

    public override void OnInteraction()
    {
        bool play = true;

        foreach (string condition in conditions)
        {
            if (condition.StartsWith(negativeChar) && !Game.instance.keys.HasKey(condition.Substring(1)))
            {                

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
            else if (lines[currentLine].StartsWith("w_"))
            {
                WrestlingMatch wrestlingMatch = GetComponent<WrestlingMatch>();
                string line = "";
                if(wrestlingMatch)
                    line = wrestlingMatch.OnLine(lines[currentLine]);

                if(!string.IsNullOrEmpty(line))
                    Game.instance.refs.GetTextbox().PlayText(line);

                currentLine++;
            }
            else if (lines[currentLine] == funfare)
            {
                Game.instance.gameAudio.PlayFunfare();
                currentLine++;
                OnInteraction();
            }
            else if (lines[currentLine] == pickup)
            {
                Game.instance.gameAudio.PlayPickupSound();
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
