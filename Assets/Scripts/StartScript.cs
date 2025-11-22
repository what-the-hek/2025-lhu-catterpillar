using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartScript : MonoBehaviour
{
	public string playScene = "";
	public Button playButton;
	public Button exitButton;


	void Start()
	{
		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(TaskOnClickPlay);

		Button exitBtn = exitButton.GetComponent<Button>();
		exitBtn.onClick.AddListener(TaskOnClickExit);
	}

	void TaskOnClickPlay()
	{
		SceneManager.LoadScene(playScene);
	}

	void TaskOnClickExit()
	{
		Application.Quit();
		Debug.Log("CLOSE GAME");
	}
}