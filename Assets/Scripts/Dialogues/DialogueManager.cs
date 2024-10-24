using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    [SerializeField] float typingSpeed;

    public GameObject sprite1;
    public GameObject sprite2;

    //public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    void Start()
    {
        sentences= new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sprite1.SetActive(true);
        sprite2.SetActive(false);

        animator.SetBool("IsOpen", true);

        //nameText.text = dialogue.name;  

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) 
        { 
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
    
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public void ChangeSprite1()
    {
        if(sprite1.activeInHierarchy == true)
        {
            sprite1.SetActive(false);
        }
        else
        {
            sprite1.SetActive(true);    
        }
    }

    public void ChangeSprite2()
    {
        if (sprite2.activeInHierarchy == true)
        {
            sprite2.SetActive(false);
        }
        else
        {
            sprite2.SetActive(true);
        }
    }

}
