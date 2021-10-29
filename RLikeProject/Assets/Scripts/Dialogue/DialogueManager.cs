using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	private bool isInteractiveDM = false;

	public Animator animator;

	private Queue<string> sentences;

	public GameObject interactivePanel;
	public GameObject continuePanel;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void StartDialogue (bool isInteractive, string name, string[] eventStrings)
	{
		continuePanel.SetActive(true);

		isInteractiveDM = isInteractive;

		animator.SetBool("IsOpen", true);

		nameText.text = "" + name;

		foreach (string sentence in eventStrings)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
        if (isInteractiveDM)
        {	
			if (sentences.Count == 1)
			{
				interactivePanel.SetActive(true);
				continuePanel.SetActive(false);
			}	
		}
		if (sentences.Count == 0)
		{
			interactivePanel.SetActive(false);
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
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}
