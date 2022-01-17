# Semester1Tutorials
Starting WK3/05.10.21


## Tutorial One - Point and Click Mechanics

## 1

Make a 2D Project
Make a Script called 'PlayerController'
Create a 3D Object in the Hierarchy (A cube) - and attach the PlayerController Script to it. 

## 2
Open the Platercontroller Script
Remove the start function lines of code. 
Create a new Private variable.
 ``private Vector2 target;``
 
 In ``Update()``, write
 ``Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);``
 
 Add Debug (
        ``Debug.Log(mousePos);``)
        To test if the function is working properly. This function being carried out should Recognise the mouse position, and display in the Unity console.
        Once you have tested this has worked you can remove ``Update()`` from the code.  

## 3
From here, we need to check if the player clicks for the object to move, and if they do, the coordinates of where they click will also need to be found. 

Create an if statement (In unity, type ``IF`` and press TAB twice in order to generate an if statement structure.)

``if (Input.GetMouseButtonDown(0))
        {       
            target = new Vector2(mousePos.x, transform.position.y);
        }``
        This will ensure that players can move anywhere on the x-axis, while keeping them in the same y-axis position when they click anywhere on the screen.
        Now, to move the player, we need to add to the ``Update()`` Function, the player positioning, and their movement speed once a click has been initiated. 
        
       ` `transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5f);``
      
       
## 4
        
Now you can save your script and click play within the Unity scene. By clicking anywhere on the screen the cube should now follow and stop at the x-axis position.
        This is a simple point and click movement (2d) system in Unity. 
        
       
       
       
## Tutorial Two - Scroll

## 1 

Create an EmptyGameObject in the canvas, name is 'Content'. Re-size it to fit the space you want to scroll within. Drag all text objects you have created for scrolling on this object, to make them children objects of 'Content'.

## 2

In the Inspector of the 'Content' object, select 'Add component' and search 'Vertical Layout Group'. Select it and give borders and spacing to your text that you see fit. Additionally, add the 'Content size fitter' component to 'Content' too, and set Vertical fir to preferred size. 

## 3

Make the 'Content' GameObject a child object of a new Empty Game Object, 'ScrollArea'. To 'ScrollArea', add the 'ScrollRect' component, and untick the 'Horizontal' button, and adjust the Scroll Sensitivity as you see fit. To avoid UI overlap when scrolling, also apply the 'RectMask' component to ScrollArea' to block titles etc out of the scrolling text.

## 4

Initiate play and either use the middle mouse/trackpad to scroll normally and see the text scroll with it, or click and drag where you want to scroll. 
       This is how to create scrolling text in Unity. 
       
## Tutorial Three - Pause Menu

## 1 

In your project, create a canvas, and initiate 2D mode in the scene view. (Top left of viewport). Right-click on the Canvas, and create a panel in the UI menu, and change the panel colour to a slightly transparent black background. Change the source image of the panel to 'None', and rename the panel to PauseMenuUI

Create a button, and resize using the Rect Tool (T). Disable the image in the inspector. Select and size text as desired, name 'Resume', change colour, add shadow and place how you want it. Turn on Image, and reduce opacity, also alter highlight and selected colour at different opacities, and change 'Navigation' to none, for better player input and feedback.

Duplicate the buttons and change the text and names for 'Menu' and 'Exit'
This is the UI Setup.

## 2 

Disable the pause menu panel in Unity.
Add a new C# Script in the canvas and open. Delete the start method and write:
`` public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;``
    
    In Update write:
    ``  void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();   
            }
        }
    }``
    
    Also write a use for each method, such as Resume, Load Menu etc. 
    
    ``  public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;


    }

   void Pause()
    {

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
           Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }``



## 4

Add functionality to these buttons. Add the GameObject (Pause Menu Panel) into the script on the canvas. On each button, under OnClick press (+),  and select PauseMenu, and then the relevant function ((Resume, Edit, Menu), test these.

## 5 

In order to ensure that these LoadMenu and Quit functions work, add ``using UnityEngine.SceneManagement;`` to the top of the script, and all relevant scripts are in the Game Build Settings, under the correct names as referred to in the script. 
Make sure to test all of these. 
 This is how to create a pause menu in Unity.
 
 
 ## Tutorial Four - Dialogue System

## 1

Set Up a canvas with panel and 2 text elements in the unity project. (Can be in a 2D or 3D project). To do this, right click in the hierarchy, UI-> Canvas, Panel and Text.Resize and colour the panel as desired (Ideally lower 3rd screen). Name the text objects 'Name' and 'Dialogue'. Also make a 'Continue' button for this panel.
Also make a button (UI -> Button), and name it 'Start dialogue', resize and recolour as desired.

## 2 

Create 3 scripts. Name them 'DialogueManager', 'Dialogue' and 'DialogueTrigger'
In Dialogue:
At the top of the script, write:
[System.Serializable]

Also, do not derive from monobehaviour.

Below the class name, write:

	public string name;

	[TextArea(3, 10)]
	public string[] sentences;

In DialogueTrigger 

Below the class name write

public Dialogue dialogue;

       	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

In DialogueManager

At the top of the script, add 
using UnityEngine.UI;

Then, below the Class name, add 

        public Text nameText;
	public Text dialogueText;
	private Queue<string> sentences;
	
	In start, write:
	void Start () 
	{
		sentences = new Queue<string>();
	}
	and then
	
		public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}
	
	Under this, make a new methods, public void DisplayNextSentence ()
	
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		
	}
	
	void EndDialogue()
	{
		
	}


##3

Create an empty game object and apply the dialogue manager to it. Drag in the name and dialogue text objects. 
Now apply the dialogue trigger to the button and make an on click event (TriggerDialogue()) to begin the dialogue, and type in the dialogue and name. 
For the continue button, apply the Dialogue Manager,Onclickevent of the button, and add DisplayNextSentence() to the, and add an OnClick event , 

##4
For additional effects (Eg typing effect) or animation in the DialogueManager script, write:


for Typing effect, below DisplayNextSentence(), write in:
	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
and add

                StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence)); 
in the above function. 



For animation, go to Window -> Animation. Select the Panel (with the text as child objects, and create a new animation clip. For the open clip, press the record button in the animator. 
Select the Y position of the panel and copy it, move the Y-Axis of the panel slightly and re-paste the coordinate. 
Create a new close animation of the same panel. Press record again, select the panel, press shift and move the panel below the canvas. 

Now open the animator (Window -> Animator, where the two animators should be. Set the close animation as the default state (Right click -> Default state). Now create a transition from the closed state to the open and then the opened to the closed. 
Go to the parameter tab and press the + icon. Create a new bool parameter called IsOpen. Click on the transitions between Open and Closed, apply the peraniter (true for closed, false for open)and ensure to turn off exit time for both. 
In the dialogueManager script, add a reference to the Animator: public Animator animator;

And then write within public void StartDialogue (Dialogue dialogue):

        animator.SetBool("IsOpen", true);

Then create, 
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

Be sure to add the animator to the dialogue manager and test.

##5

From here, you are able to attach the DialogueTrigger script to an object (Eg 2D sprite)and fill out dialogue
Some additions made could be allowing audio clips in your system, or having them set within a trigger, or with a key (EG C to start, V to continue). If using these/a 3D project, make sure to alter scripts to make them work in eg (Eg for colliders) and apply non-2D rigidbody and collider to the trigger object. 


That is how to make a Dialogue System in Unity.

