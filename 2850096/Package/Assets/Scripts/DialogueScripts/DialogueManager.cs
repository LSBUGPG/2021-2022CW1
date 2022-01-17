using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;

	public Animator animator;

	private Queue<string> sentences;
	private Queue<AudioClip> Clips;
	private int dialogueIndex = 0;
	private Dialogue[] theDialogue;
	private AudioSource Sound;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
		Clips = new Queue<AudioClip>();
		Sound = GetComponent<AudioSource>();
	}

	public void StartDialogue(Dialogue[] dialogue)
	{
		theDialogue = dialogue;
		animator.SetBool("IsOpen", true);

		SetupSentences();
	}

	private void SetupSentences()
	{
		nameText.text = theDialogue[dialogueIndex].name;

		

		foreach (string sentence in theDialogue[dialogueIndex].sentences)
		{
			sentences.Enqueue(sentence);
		}
		foreach (AudioClip Clip in theDialogue[dialogueIndex].Audio)
		{
			Clips.Enqueue(Clip);
		}

		DisplayNextSentence();

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.V))
			DisplayNextSentence();

	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			dialogueIndex += 1;
			
			if (dialogueIndex < theDialogue.Length)
			{
				SetupSentences();
				return;
			}
			else
			{
				EndDialogue();
				return;
			}
		}

		string sentence = sentences.Dequeue();
		AudioClip clip = Clips.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		Sound.clip = clip;
		Sound.Play();

		
	}

	IEnumerator TypeSentence(string sentence)
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
		dialogueIndex = 0;
		animator.SetBool("IsOpen", false);
	}

}