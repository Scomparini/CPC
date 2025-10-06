using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2[] lanes;
    public int speed;
    private int _currentLane = 1;

    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        // verifica se há toque na tela
        if (Input.touchCount > 0)
        {
            // guarda a referência de toque
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                _endPosition = touch.position;
                float swipeDistance = _endPosition.x - _startPosition.x;

                if (swipeDistance > 50 && _currentLane < 2)
                {
                    _currentLane++;
                    audioManager.PlaySwipe();
                }
                else if (swipeDistance < -50 && _currentLane > 0)
                {
                    _currentLane--;
                    audioManager.PlaySwipe();
                }
            }
        }

        // itera de forma fluida os valores de posição para a posição alvo
        transform.position = Vector2.Lerp(transform.position, lanes[_currentLane], Time.deltaTime * speed);
    }
}
