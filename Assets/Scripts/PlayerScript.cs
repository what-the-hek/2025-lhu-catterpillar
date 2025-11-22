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
    private List<Vector2> positionHistory = new List<Vector2>();

    void Start()
    {
        caterpillar = GetComponent<Rigidbody2D>();
        caterpillar.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
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
