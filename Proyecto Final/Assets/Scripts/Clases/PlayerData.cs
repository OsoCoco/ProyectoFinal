using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class PlayerData : MonoBehaviour
{
    public string playerName;
    public int lives;
    public float health;
    Vector3 position;

    private void Start()
    {
        position = transform.position;
       Debug.Log(SaveToString());
    }
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
   
    byte[] Serialization()
    {
        var size = sizeof(int) + sizeof(float) * 4;

        byte[] myBytearray = new byte[size];

        byte[] livesArray = BitConverter.GetBytes(lives);

        for (int i = 0; i < sizeof(int); i++)
        {
            myBytearray[i] = livesArray[i];
        }

        byte[] healthArray = BitConverter.GetBytes(health);

        for (int i = 0; i < sizeof(float); i++)
        {
            myBytearray[sizeof(int) + i] = livesArray[i];
        }

        return myBytearray;
    }
}
