using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject Platform;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision is CharacterController)
        {
            Platform.transform.Rotate(90, 0, 0);
        }
        if (collision.gameObject.tag == "Weight")
        {
            Platform.transform.Rotate(90, 0, 0);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision is CharacterController)
        {
            Platform.transform.Rotate(-90, 0, 0);
        }
        if (collision.gameObject.tag == "Weight")
        {
            Platform.transform.Rotate(-90, 0, 0);
        }
    }
}