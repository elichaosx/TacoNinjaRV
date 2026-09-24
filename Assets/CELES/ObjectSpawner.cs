using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Configuración General")]
    public GameObject tacoPrefab;
    public float spawnInterval = 2f;
    
    [Header("Spawn Aleatorio")]
    public List<Transform> spawnPoints;

    [Header("Fuerza Lanzamiento")]
    public float minForceX = -2f;
    public float maxForceX = 2f;
    public float minForceY = 8f;
    public float maxForceY = 12f;
    public float minForceZ = 4f;
    public float maxForceZ = 6f;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnAndLaunch();
        }
    }
    void SpawnAndLaunch()
    {
        if (tacoPrefab == null || spawnPoints == null || spawnPoints.Count == 0) return;
        
        Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];
        
        GameObject spawnedTaco = Instantiate(tacoPrefab, randomSpawn.position, randomSpawn.rotation);

        Rigidbody rb = spawnedTaco.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 launchForce = new Vector3(
                Random.Range(minForceX, maxForceX),
                Random.Range(minForceY, maxForceY),
                Random.Range(minForceZ, maxForceZ)
            );

            rb.AddForce(launchForce, ForceMode.Impulse);
        }
    }
}
