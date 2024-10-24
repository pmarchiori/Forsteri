using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circleCollider;

    public GameObject Collected;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Collected.SetActive(true);
            sr.enabled = false;
            circleCollider.enabled = false;


            Destroy(gameObject, 0.33f);
        }
    }
}
