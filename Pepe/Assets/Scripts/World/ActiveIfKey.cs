using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIfKey : MonoBehaviour
{
    public string key;
    public bool invert = false;

    // Start is called before the first frame update
    void Start()
    {
        if(invert)
        {
            if (Game.instance.keys.HasKey(key))
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }
        else
        {
            if (Game.instance.keys.HasKey(key))
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }        
    }
}
