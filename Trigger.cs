using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioManager audioManager;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            audioManager.PlayScore();
            scoreManager.IncreaseScore();
        }
    }
}
