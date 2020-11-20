using System;
using System.Collections;
using UnityEngine; 

[System.Serializable]
class SaveData
    {
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
    }


 }

