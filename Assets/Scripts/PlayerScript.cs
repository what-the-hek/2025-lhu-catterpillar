using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D caterpillar;
    public float moveSpeed = 7f;
    private float currentMoveSpeed;
    private bool isPaused = false;
    public int bodyLength = 0;
    private Vector2 direction = Vector2.up;
    public GameObject[] bodyPrefabs;
    private List<Transform> bodySegments = new List<Transform>();
    private List<Vector2> positionHistory = new List<Vector2>();
    public string startScene = "";
	public Button pauseButton;
	public Button exitButton;
    public TextMeshProUGUI score;
    public GameObject gameWinBlob;
    public GameObject gameOverBlob;

    void Start()
    {
        caterpillar = GetComponent<Rigidbody2D>();
        caterpillar.bodyType = RigidbodyType2D.Kinematic;

        Button pauseBtn = pauseButton.GetComponent<Button>();
		pauseBtn.onClick.AddListener(TogglePause);

		Button exitBtn = exitButton.GetComponent<Button>();
		exitBtn.onClick.AddListener(TaskOnClickExit);
    }

    void Update()
    {
        score.text = $"{bodyLength} / 15";

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TogglePause();
        }

        if (isPaused) return;

        caterpillar.MovePosition(caterpillar.position + direction * moveSpeed * Time.fixedDeltaTime);

        positionHistory.Insert(0, caterpillar.position);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (direction != Vector2.right)
                direction = Vector2.left;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            if (direction != Vector2.left)
                direction = Vector2.right;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            if (direction != Vector2.down)
                direction = Vector2.up;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            if (direction != Vector2.up)
                direction = Vector2.down;

        // move the body segments with the head
        for (int i = 0; i < bodySegments.Count; i++)
        {
            int index = (i + 1) * 60; //tweak spacing between segments
            if (index < positionHistory.Count)
            {
                bodySegments[i].position = positionHistory[index];
            }
        }
        // if(positionHistory.Count > 1000)
        //     positionHistory.RemoveAt(positionHistory.Count -1);

        CheckBorderBounds();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (bodyLength < 15)
        {
            if (other.CompareTag("Food"))
            {
                bodyLength += 1;
                Debug.Log("body length: " + bodyLength);
                moveSpeed += 0.3f;
                currentMoveSpeed = moveSpeed += 0.3f;
                Debug.Log("movement speed: " + moveSpeed);
                AddBodySegment();
            }
        }
        else if (bodyLength >= 15)
        {
            Debug.Log("YOU WIN");
            moveSpeed = 0f;
            gameWinBlob.SetActive(true);
        }
            
        // TODO it's constantly in contact with it's body so this constantly fires - fix later
        // if (other.CompareTag("Body"))
        // {
        //     Debug.Log("YOU LOSE");
        // }
    }

    void AddBodySegment()
    {
        int prefabIndex = Random.Range(0, bodyPrefabs.Length);

        Vector2 spawnPos = bodySegments.Count == 0
            ? caterpillar.position - direction * 0.5f
            : bodySegments[bodySegments.Count - 1].position;

        GameObject newSegment = Instantiate(bodyPrefabs[prefabIndex], spawnPos, Quaternion.identity);
        bodySegments.Add(newSegment.transform);

        SpriteRenderer sr = newSegment.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingOrder = -bodySegments.Count;
        }
    }

    void CheckBorderBounds()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(caterpillar.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Debug.Log("GAME OVER");
            gameOverBlob.SetActive(true);
            enabled = false;
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
    }

    void TaskOnClickExit()
	{
		SceneManager.LoadScene(startScene);
	}
}
