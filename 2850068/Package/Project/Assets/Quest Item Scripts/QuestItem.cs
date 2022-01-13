using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public GameObject questIemCounterGO; // The Counter gameobject
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Has Entered the pickup zone");
            
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Player Has pressed E");
                // Quest Item 1 Count 
                if (gameObject.tag == "questItem1")
                {
                    Debug.Log("Player Has Taken the item [1]");
                    questIemCounterGO.GetComponent<QuestItemsCounter>().QI1C();
                    Destroy(this.gameObject);
                }
                // Quest Item 2 Count 
                if (gameObject.tag == "questItem2")
                {
                    Debug.Log("Player Has Taken the item [2]");
                    questIemCounterGO.GetComponent<QuestItemsCounter>().QI2C();
                    Destroy(this.gameObject);
                }
                // Quest Item 3 Count 
                if (gameObject.tag == "questItem3")
                {
                    Debug.Log("Player Has Taken the item [3]");
                    questIemCounterGO.GetComponent<QuestItemsCounter>().QI3C();
                    Destroy(this.gameObject);
                }
                // Quest Item 4 Count 
                if (gameObject.tag == "questItem4")
                {
                    Debug.Log("Player Has Taken the item [4]");
                    questIemCounterGO.GetComponent<QuestItemsCounter>().QI4C();
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
}
