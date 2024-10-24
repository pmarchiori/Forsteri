using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{
    [SerializeField] GameObject cmCamera;
    [SerializeField] GameObject gameOver;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            cmCamera.SetActive(false);
        }
    }
}
