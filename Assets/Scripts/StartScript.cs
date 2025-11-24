using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartScript : MonoBehaviour
{
	public string controlsScene = "";
	public Button playButton;
	public Button exitButton;
	public Button muteButton;


	void Start()
	{
		Button playBtn = playButton.GetComponent<Button>();
		playBtn.onClick.AddListener(TaskOnClickPlay);

		Button exitBtn = exitButton.GetComponent<Button>();
		exitBtn.onClick.AddListener(TaskOnClickExit);

		Button muteBtn = muteButton.GetComponent<Button>();
		muteBtn.onClick.AddListener(TaskOnClickMute);

	}

	void TaskOnClickPlay()
	{
		SceneManager.LoadScene(controlsScene);
	}

	void TaskOnClickExit()
	{
		Application.Quit();
		// Debug.Log("CLOSE GAME");
	}

	void TaskOnClickMute()
	{
		AudioManagerScript.Instance.ToggleMute();
	}

}