using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    public Text text;
    public Image image;
    
    public void PlayText(string line)
    {
        Game.instance.refs.GetPlayer().GetComponent<PlayerMovement>().enabled = false;
        
        image.enabled = true;
        text.enabled = true;
        text.text = line;
    }

    public void Hide()
    {
         Game.instance.refs.GetPlayer().GetComponent<PlayerMovement>().enabled = true;
                
         image.enabled = false;
         text.enabled = false;
    }
}
