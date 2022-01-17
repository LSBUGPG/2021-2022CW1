using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue[] dialogue;
    bool playerInRange;
    bool DialougeOpen;



 
    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if (collision.gameObject.tag==("Player"))
        {

            playerInRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerInRange && !DialougeOpen)
        {
            DialougeOpen = true;
            
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        if (!playerInRange)
        {
            DialougeOpen = false;
        }

    }



}