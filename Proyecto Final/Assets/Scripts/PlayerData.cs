using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public string playerName = "Player";
    public int lives = 5;
    public float health = 10;

    private void Start()
    {
       Debug.Log(SaveToString());
    }
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    public Stream GetStream()
    {
        return null;
    }
}
