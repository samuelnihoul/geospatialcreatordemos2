using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 1f;

    private float timer;

    void Update()
    {
        // Increment timer
        timer += Time.deltaTime;

        // Check if it's time to spawn
        if (timer >= spawnInterval)
        {
            // Reset timer
            timer = 0f;

            // Spawn prefab
            SpawnPrefab();
        }
    }

    void SpawnPrefab()
    {
        // Check if the prefab and spawn point are assigned
        if (prefabToSpawn != null && transform != null)
        {
            // Instantiate the prefab at the spawn point's position and rotation
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Prefab or spawn point is not assigned");
        }
    }
}
