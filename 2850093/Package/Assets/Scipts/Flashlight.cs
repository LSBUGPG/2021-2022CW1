using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject Flashlightlight;


    private bool flashLightActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //Sets flashlight to the off state at the start
        Flashlightlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //below translates to if F key is pressed it will set the 'Spotlight' object in the scene to active = true. When F is pressed again it will be set back to the false active state.
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightActive == false)
            {
                Flashlightlight.gameObject.SetActive(true);
                flashLightActive = true;
            }
            else
            {
                Flashlightlight.gameObject.SetActive(false);
                flashLightActive = false;

            }
        }
    }
}
