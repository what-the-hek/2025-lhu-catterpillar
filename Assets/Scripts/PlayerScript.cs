using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D caterpillar;
    public float moveSpeed = 5f;
    public int bodyLength = 1;
    private Vector2 direction = Vector2.up;

    public GameObject bodyPrefabs;
    private List<Transform> bodySegments = new List<Transform>();

    void Start()
    {
        caterpillar = GetComponent<Rigidbody2D>();
        caterpillar.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        caterpillar.MovePosition(caterpillar.position + direction * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector2.left;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector2.right;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector2.up;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector2.down;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bodyLength += 1;
        Debug.Log("body length: " + bodyLength);
        moveSpeed += 0.5f;
        Debug.Log("movement speed: " + moveSpeed);
        AddBodySegment();
    }

    void AddBodySegment()
    {
        Vector2 spawnPos = caterpillar.position;
        GameObject newSegment = Instantiate(bodyPrefabs, spawnPos, Quaternion.identity);
        bodySegments.Add(newSegment.transform);
    }
}
