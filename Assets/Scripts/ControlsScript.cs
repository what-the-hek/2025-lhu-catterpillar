using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControlsScript : MonoBehaviour
{
	public string playScene = "";
    public Button startButton;

	void Start()
	{
		Button startBtn = startButton.GetComponent<Button>();
		startBtn.onClick.AddListener(TaskOnClickStart);
	}
    void TaskOnClickStart()
	{
		SceneManager.LoadScene(playScene);
	}
}