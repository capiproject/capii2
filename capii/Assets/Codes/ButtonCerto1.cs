using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes1 : MonoBehaviour
{
    public void GoToNextAct()
    {
        SceneManager.LoadScene("Numeros1");
    }
}