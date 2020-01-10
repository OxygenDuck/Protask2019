using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueBox; //UI Text Object
    private Queue<string> sentences; //List of sentences

    public Animator animator; //Animater Object

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


    //Start dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        //Open the dialoguebox
        animator.SetBool("IsOpen", true);
        Helper.PlayAudio("DialogueOpen");

        //Set the next sentences
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        //Display first sentence
        DisplayNextSentence(dialogue.name);
    }

    //Display next sentence
    public void DisplayNextSentence(string name = "")
    {
        //See if there are no sentences left
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Show Sentence
        string sentence = sentences.Dequeue();
        DialogueBox.text = "";
        if (name != "")
        {
            DialogueBox.text += name + ": ";
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //Run each frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    //Display nect letter in a sentence
    IEnumerator TypeSentence (string sentence)
    {
        DialogueBox.text = "";
        foreach(char character in sentence.ToCharArray())
        {
            DialogueBox.text += character;
            Helper.PlayAudio("DialogueTalk");
            yield return null;
        }
    }

    //End the dialogue
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Helper.PlayAudio("DialogueClose");
    }
}
