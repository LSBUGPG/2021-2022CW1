using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MinimapCamera;

    AudioListener Camera1AudioLis;
    AudioListener Camera2AudioLis;

    void Start()
    {
        //Get Camera Listeners
        Camera1AudioLis = MainCamera.GetComponent<AudioListener>();
        Camera2AudioLis = MinimapCamera.GetComponent<AudioListener>();

        //Camera Position Set
        CameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }

    public void CameraPositionM()
    {
        CameraChangeCounter();
    }

    void SwitchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CameraChangeCounter();
        }
    }

     void CameraChangeCounter()
     {
        int CameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        CameraPositionCounter++;
        CameraPositionChange(CameraPositionCounter);
     }

      void CameraPositionChange(int CamPosition)
      {
        if (CamPosition > 1)
        {
            CamPosition = 0;
        }

        PlayerPrefs.SetInt("CameraPosition", CamPosition);

        //Set Camera 1
        if (CamPosition == 0)
        {
            MainCamera.SetActive(true);
            Camera1AudioLis.enabled = true;

            Camera2AudioLis.enabled = false;
            MinimapCamera.SetActive(false);
        }

        //Set Camera 2
        if (CamPosition == 1)
        {
            MainCamera.SetActive(false);
            Camera1AudioLis.enabled = false;

            Camera2AudioLis.enabled = true;
            MinimapCamera.SetActive(true);
        }

        
        
      }

}
