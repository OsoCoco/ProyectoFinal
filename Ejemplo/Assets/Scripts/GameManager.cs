using System.Collections;
using System.Collections.Generic;
using UnityEngine;


   public enum GamePlay
{
    Touch,
    DragAndDrop
}
public class GameManager : MonoBehaviour
{
   public GamePlay gameplay;
   public GameObject ddPrefab;
   public GameObject touchPrefab;
   public int nObjetos;

    public void GenerateDD()
    {
        for (int i = 0; i < nObjetos; i++)
            Instantiate(ddPrefab);
    }

    public void GenerateTouch()
    {
        for (int i = 0; i < nObjetos; i++)
            Instantiate(touchPrefab);
    }

}
