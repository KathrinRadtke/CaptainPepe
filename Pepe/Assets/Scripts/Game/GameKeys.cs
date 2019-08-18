using System.Collections.Generic;
using UnityEngine;

public class GameKeys : MonoBehaviour
{
    [SerializeField] private string[] initialKeys = new string[0];
    private List<string> currentKeys = new List<string>();

    public void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        currentKeys.Clear();
        // add all initial keys
        for (int i = 0; i < initialKeys.Length; i++)
        {
            currentKeys.Add(initialKeys[i]);
        }
    }

    /// <summary>
    /// Check if Game keys have the given key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool HasKey(string key)
    {
        return currentKeys.Contains(key);
    }
    
    /// <summary>
    /// check if Game Keys contain the given keys.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public bool HasKeys(string[] keys)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (currentKeys.Contains(keys[i]))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Remove a key
    /// </summary>
    /// <param name="key"></param>
    public void RemoveKey(string key)
    {
        if (currentKeys.Contains(key))
        {
            currentKeys.Remove(key);
        }
    }

    /// <summary>
    /// Add a key.
    /// </summary>
    /// <param name="key"></param>
    public void AddKey(string key)
    {
        if (!currentKeys.Contains(key))
        {
            currentKeys.Add(key);
        }   
    }
}
