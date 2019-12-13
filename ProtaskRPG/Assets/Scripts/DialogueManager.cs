using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text DialogueBox;
    private Queue<string> sentences;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Helper.PlayAudio("DialogueOpen");

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence(dialogue.name);
    }

    public void DisplayNextSentence(string name = "")
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        DialogueBox.text = "";
        if (name != "")
        {
            DialogueBox.text += name + ": ";
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

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

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Helper.PlayAudio("DialogueClose");
    }
}
