using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCollider : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowGameOver();
            Destroy(other.gameObject);
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
}
