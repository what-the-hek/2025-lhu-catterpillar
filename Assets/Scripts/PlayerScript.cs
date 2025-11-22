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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction = Vector2.left;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction = Vector2.right;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction = Vector2.up;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction = Vector2.down;
    }
}
