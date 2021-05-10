using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuitGameButton : MonoBehaviour
{
    public void quitGame()
	{
		Application.Quit();
	}
}