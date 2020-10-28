using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    #region VARIABLES
    [SerializeField]
    Transform targetPosition;

    Vector2 touchPos;
    Vector2 startPos;

    bool locked = false;
    #endregion

    #region UNITYFUNCTIONS
    private void Start()
    {
        startPos = transform.position;
    }
    #endregion

    #region EVENTS
    public void OnDrag(PointerEventData eventData) //Evento donde de realiza el movimiento de drag
    {
        if(!locked)
        {
        touchPos = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = touchPos;
        }
      
    }
   /* public void OnBeginDrag(PointerEventData data)
    {
        
       // Debug.Log("Begin called.");
    }*/
    public void OnEndDrag(PointerEventData data) //Evento donde termina el drag y hace el check si esta cerca de su lugar 
    {
        if (Mathf.Abs(transform.position.x - targetPosition.position.x) <= 0.5f &&
                        Mathf.Abs(transform.position.y - targetPosition.position.y) <= 0.5f)
        {
            transform.position = targetPosition.position;
            locked = true;
        }
        else
        {
            transform.position = startPos;
        }
        Debug.Log("End.");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1f);
        }
    }


    #endregion
}
