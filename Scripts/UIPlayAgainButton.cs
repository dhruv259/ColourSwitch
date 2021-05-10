using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPlayAgainButton : MonoBehaviour
{
    public void playAgain()
    {
        SceneManager.LoadScene("Scene1");
    }
}
