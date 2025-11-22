using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public float[] spawnXPositions;
    public float[] spawnYPositions;
    public GameObject[] prefabs;
    // void Start()
    // {
        
    // }

    // void Update()
    // {
        
    // }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        Debug.Log("MUNCH!!!");
        // loop back to coroutine to create new prefab
    }
}
