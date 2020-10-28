using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    Transform targetPosition;
    Vector2 initialPosition;
    float deltaX, deltaY;
    public  bool locked = false;
    #endregion
    // Start is called before the first frame update
    #region UNITYFUNCTIONS
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    #endregion

    #region FUNCTIONS
    void Move() //Función que engloba el Drag and Drop
    {
        if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began: 
                    if(GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;

                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x-deltaX,touchPos.y -deltaY);
                    break;
                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - targetPosition.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - targetPosition.position.y) <= 0.5f)
                    {
                        transform.position = targetPosition.position;
                        locked = true;
                    }
                    else
                    {
                        transform.position = initialPosition;
                    }
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}
