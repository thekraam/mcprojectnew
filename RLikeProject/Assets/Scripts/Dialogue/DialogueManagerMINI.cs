using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerMINI : MonoBehaviour
{

	// interlocutore e testo
	public Text nameText;
	public Text dialogueText;

	// booleane varie
	private bool isInteractiveDM = false;
	private int responseToInteractiveDialogue = 0;
	private int DialogueIsResetting = 0;
	int endingdialogue = 0;

	// animazione apertura e chiusura
	public Animator animator;

	// suoni interazione
	public AudioClip[] OpenAndCloseSounds;
	public AudioClip[] FlippingPagesSounds;

	// frasi da accodare
	private Queue<string> sentences;

	// pannello interattivo con si e no e oannello con tasto continua
	public GameObject interactivePanel;
	public GameObject continuePanel;

	void Start()
	{
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

	public void StartDialogue(bool isInteractive, string name, string[] eventStrings)
	{
		StartCoroutine(WaitForPreviousDialogue(isInteractive, name, eventStrings));
	}

	private IEnumerator WaitForPreviousDialogue(bool isInteractive, string name, string[] eventStrings)
    {
		yield return new WaitUntil(() => FindObjectOfType<Events>().attendingMainEvent == false);

		endingdialogue = 0;
		responseToInteractiveDialogue = 0;
		if (DialogueIsResetting == 1)
			DialogueIsResetting = 0;
		continuePanel.SetActive(true);

		isInteractiveDM = isInteractive;

		FindObjectOfType<AudioManager>().RandomSoundEffect(OpenAndCloseSounds);
		animator.SetBool("IsOpen", true);

		nameText.text = "" + name;

		foreach (string sentence in eventStrings)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		FindObjectOfType<AudioManager>().RandomSoundEffect(FlippingPagesSounds);
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

	IEnumerator TypeSentence(string sentence)
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
		FindObjectOfType<AudioManager>().RandomSoundEffect(OpenAndCloseSounds);
		FindObjectOfType<Game>().dialogueInterfaceBlocker.SetActive(false);
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
