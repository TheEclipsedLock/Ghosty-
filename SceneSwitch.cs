using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //Special thanks to https://www.youtube.com/watch?v=9lPCv9kkbSI
    //Jimmy Vegas for a tutorial on switching scenes
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
