using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject Light;
    public bool isOn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn == true)
            {
                Light.SetActive(true);
            }

            if (isOn == false)
            {
                Light.SetActive(false);
            }
            isOn = !isOn;
        }
    }
}
