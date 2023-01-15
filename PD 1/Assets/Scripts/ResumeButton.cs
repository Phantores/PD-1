using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public GameObject pauseui;

    public void resumegame()
    {
        pauseui.SetActive(false);
        Time.timeScale = 1;
    }
}
