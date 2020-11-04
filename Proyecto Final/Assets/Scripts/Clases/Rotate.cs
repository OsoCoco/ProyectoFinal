using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0.0f,100.00f)]
    public float speed;
  // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 0 + speed * Time.deltaTime);
    }
}
