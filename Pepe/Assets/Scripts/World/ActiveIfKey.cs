using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIfKey : MonoBehaviour
{
    public string key;

    // Start is called before the first frame update
    void Start()
    {
        if (Game.instance.keys.HasKey(key))
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
