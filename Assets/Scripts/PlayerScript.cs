using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D caterpillar;
    public float moveSpeed = 5f;
    private Vector2 direction = Vector2.up;

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
}
