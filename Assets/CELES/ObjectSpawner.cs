using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Lista de Ingredientes (Prefabs)")]
    public List<GameObject> ingredientPrefabs;

    [Header("Puntos de Spawn (Tus 3 posiciones)")]
    public List<Transform> spawnPoints;

    [Header("Configuración de Tiempo")]
    public float minSpawnInterval = 1.5f;

    public float maxSpawnInterval = 3f;

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
            float randomWait = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomWait);

            SpawnAndLaunch();
        }
    }

    void SpawnAndLaunch()
    {
        if (ingredientPrefabs == null || ingredientPrefabs.Count == 0) return;
        if (spawnPoints == null || spawnPoints.Count == 0) return;
        
        GameObject randomPrefab = ingredientPrefabs[Random.Range(0, ingredientPrefabs.Count)];
        
        Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Count)];
        
        GameObject spawnedIngredient = Instantiate(randomPrefab, randomSpawn.position, randomSpawn.rotation);
        
        Rigidbody rb = spawnedIngredient.GetComponent<Rigidbody>();
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
