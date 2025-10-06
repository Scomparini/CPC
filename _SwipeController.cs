using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _endPosition = touch.position;
                EvaluateSwipe();
            }
        }
    }

    private void EvaluateSwipe()
    {
        Vector2 swipeDirection = _endPosition - _startPosition;
        float horizontalDirection = Mathf.Abs(swipeDirection.x);
        float verticalDirection = Mathf.Abs(swipeDirection.y);

        if (horizontalDirection > verticalDirection)
        {
            if (swipeDirection.x > 0)
                _spriteRenderer.color = Color.yellow;
            else
                _spriteRenderer.color = Color.red;
        }
        else
        {
            if (swipeDirection.y > 0)
                _spriteRenderer.color = Color.green;
            else
                _spriteRenderer.color = Color.blue;
        }
    }
}
