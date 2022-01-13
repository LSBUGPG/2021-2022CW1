using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemsCounter : MonoBehaviour
{
    
    //Current count of collected quest items
    private int questItem1Count = 0;
    private int questItem2Count = 0;
    private int questItem3Count = 0;
    private int questItem4Count = 0;

    // Desired amount of quest items to collect
    public int totalQuestItem1Count = 0;
    public int totalQuestItem2Count = 0;
    public int totalQuestItem3Count = 0;
    public int totalQuestItem4Count = 0;

    //All Items Collect amount
    public int allItemsCollectedCount;

    public Image QI1;
    public Image QI2;
    public Image QI3;
    public Image QI4;
    public GameObject greenTick;

    void Start()
    {
        totalQuestItem1Count = GameObject.FindGameObjectsWithTag("questItem1").Length; // Gets the total of game objects with a tag 
        totalQuestItem2Count = GameObject.FindGameObjectsWithTag("questItem2").Length;
        totalQuestItem3Count = GameObject.FindGameObjectsWithTag("questItem3").Length;
        totalQuestItem4Count = GameObject.FindGameObjectsWithTag("questItem4").Length; 
        allItemsCollectedCount = totalQuestItem1Count + totalQuestItem2Count + totalQuestItem3Count + totalQuestItem4Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (questItem1Count == totalQuestItem1Count) // If you collect all of one type
        {
            Debug.Log("You have collected all Quest Item 1's");
            QI1.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        }

        if (questItem2Count == totalQuestItem2Count)
        {
            Debug.Log("You have collected all Quest Item 2's");
            QI2.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        }
        if(questItem3Count == totalQuestItem3Count)
        {
            Debug.Log("You have collected all Quest Item 3's");
            QI3.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        }
        if(questItem4Count == totalQuestItem4Count)
        {
            Debug.Log("You have collected all Quest Item 4's");
            QI4.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        }

        if (questItem1Count + questItem2Count + questItem3Count + questItem4Count == allItemsCollectedCount)
        {
            Debug.Log("All items of each type has been collected");
            greenTick.SetActive(true);
        }
    }

    public void QI1C()
    {
        questItem1Count += 1;
    }

    public void QI2C()
    {
        questItem2Count += 1;
    }

    public void QI3C()
    {
        questItem3Count += 1;
    }

    public void QI4C()
    {
        questItem4Count += 1;
    }
}
