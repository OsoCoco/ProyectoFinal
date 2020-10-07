using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenus : MonoBehaviour
{
    public void OnAction(GameObject act)
    {
        if (act.activeSelf)
            act.SetActive(false);
        else
            act.SetActive(true);
    }
}
