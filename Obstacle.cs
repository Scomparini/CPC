using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public float speed;
    public float limitY;
    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y <= limitY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _audioManager.PlayDestruction();
            SceneManager.LoadScene("MenuScene");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            _audioManager.PlayScore();

            // encontra o ScoreManager e atualiza o score
            Object.FindAnyObjectByType<ScoreManager>().IncreaseScore();
        }
    }
}
