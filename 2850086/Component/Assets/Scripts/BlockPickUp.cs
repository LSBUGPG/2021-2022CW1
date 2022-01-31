using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPickUp : MonoBehaviour
{
    public Transform blockPickUp;

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = blockPickUp.position;
        this.transform.parent = GameObject.Find("PickupLocation").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
