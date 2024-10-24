using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingEnemies : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float moveTime;
    //[SerializeField] int respawn;

    [SerializeField] GameObject gameOver;

    private bool dirRight = true;
    private float timer;

    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime); //se verdadeiro, serra vai para direita
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime); //se falso, serra vai para esquerda
        }

        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowGameOver();
            Destroy(other.gameObject);
        }
    }

    //void LoadScene()
    //{
    //    SceneManager.LoadScene(respawn);
    //}

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
}

