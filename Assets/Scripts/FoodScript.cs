using UnityEngine;
using System.Collections;


public class FoodScript : MonoBehaviour
{
    public int xIndex;
    public int yIndex;
    void Respawn()
    {
        int xIndex = Random.Range(-8, 8);
        int yIndex = Random.Range(-4, 3);
        Vector2 spawnPosition = new Vector2(xIndex, yIndex);
        transform.position = spawnPosition;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MUNCH!!!");
        Respawn();
    }
}
