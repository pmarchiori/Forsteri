using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneFade : MonoBehaviour
{
    [SerializeField] string levelName;
    
    [SerializeField] Image fade;
    [SerializeField] Animator anim;

    [SerializeField] GameObject fadeImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        fadeImage.SetActive(true);
        anim.SetBool("Fade", true);
        yield return new WaitUntil (()=>fade.color.a== 1);
        SceneManager.LoadScene(levelName);
    }
}
