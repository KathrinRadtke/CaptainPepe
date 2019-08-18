using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    /// Add a key.
    /// </summary>
    /// <param name="key"></param>
    public void AddKey(string key)
    {
        if (!currentKeys.Contains(key))
        {
            currentKeys.Add(key);
#if UNITY_EDITOR
            Debug.Log("Key added: " + key + " ("+currentKeys.Count+" keys)");
#endif
        }
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
#if UNITY_EDITOR
        Debug.Log("Key removed: " + key + " ("+currentKeys.Count+" keys)");
#endif
    }

    /// <summary>
    /// Adds a key from a NPCs line.
    /// </summary>
    /// <param name="line"></param>
    public void AddOrRemoveKeyFromLine(string line)
    {
        #if UNITY_EDITOR
        if (!(line.StartsWith("[") && line.EndsWith("]")))
        {
            Debug.LogError("Error: Key is not formatted correctly! Add: [+mykey] - Remove: [-mykey]");
            return;
        }
        #endif
        line = line.Substring(1, line.Length - 2);
        if (line[0] == '+')
        {
            AddKey(line.Substring(1, line.Length-1));
        } else if (line[0] == '-')
        {
            RemoveKey(line.Substring(1, line.Length-1));
        } else
        {
            Debug.LogError("Error: Key is not formatted correctly! Add: [+mykey] - Remove: [-mykey]");
        }
    }
}
