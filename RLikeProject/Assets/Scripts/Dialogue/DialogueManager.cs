using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	int endingdialogue = 0;

	private bool isInteractiveDM = false;
	private int responseToInteractiveDialogue = 0;
	private int DialogueIsResetting = 0;

	public Animator animator;

	private Queue<string> sentences;

	public GameObject interactivePanel;
	public GameObject continuePanel;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
	}

	public void PositiveResponseToInteractiveDialogue()
    {
		this.responseToInteractiveDialogue = 1;
	}
	public void NegativeResponseToInteractiveDialogue()
	{
		this.responseToInteractiveDialogue = 0;
	}

	public int getResponse()
    {
		DialogueIsResetting = 1;
		return this.responseToInteractiveDialogue;
    }

	public void StartDialogue (bool isInteractive, string name, string[] eventStrings)
	{
		endingdialogue = 0;
		responseToInteractiveDialogue = 0;
        if (DialogueIsResetting == 1)
			DialogueIsResetting = 0;
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
        if (isInteractiveDM && sentences.Count == 1)
		{
			interactivePanel.SetActive(true);
			continuePanel.SetActive(false);	
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
			yield return new WaitForSeconds(0.02f);
		}
	}

	public void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		endingdialogue = 1;
	}

	public int[] InvokedChecker()
    {
		int[] container = new int[2]; // array di appoggio

		container[0] = 0;
		container[1] = 0;

		if (endingdialogue == 1) // controllo sul fatto che il dialogue sia completato
        {
			container[0] = this.responseToInteractiveDialogue; // effettiva risposta giocatore
			container[1] = 1; // checkResponse
        }
		return container; // ritorna l'array di appoggio a prescindere
	}

}
