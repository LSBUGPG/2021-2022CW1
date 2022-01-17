using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void btn_changes_scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
