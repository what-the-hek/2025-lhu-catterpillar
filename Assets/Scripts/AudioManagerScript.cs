using UnityEngine;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;
    public AudioSource bgMusic;
    public Button muteButton;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Button muteBtn = muteButton.GetComponent<Button>();
        muteBtn.onClick.AddListener(ToggleMute);
    }

    public void ToggleMute()
    {
        bgMusic.mute = !bgMusic.mute;
    }
}
