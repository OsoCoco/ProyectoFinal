using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameManager))]

public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;
        gameManager.gameplay = (GamePlay)EditorGUILayout.EnumPopup("GamePlay",gameManager.gameplay);
        switch (gameManager.gameplay)
        {
            case GamePlay.Touch:
                gameManager.touchPrefab = (GameObject)EditorGUILayout.ObjectField("TouchPrefab", gameManager.touchPrefab, typeof(GameObject), true);
                gameManager.nObjetos = EditorGUILayout.IntField("Numero de objetos a crear", gameManager.nObjetos);
                if(GUILayout.Button("Generar Objetos Touch") )
                {
                    gameManager.GenerateTouch();
                }
                break;
            case GamePlay.DragAndDrop:
                gameManager.ddPrefab = (GameObject)EditorGUILayout.ObjectField("Drag&DropPrefab", gameManager.ddPrefab, typeof(GameObject), true);
                gameManager.nObjetos = EditorGUILayout.IntField("N de Objetos", gameManager.nObjetos);
                if (GUILayout.Button("Generar Objetos Drag & Drop"))
                {
                    gameManager.GenerateDD();
                }
                break;
            default:
                break;
        }
    }
}
