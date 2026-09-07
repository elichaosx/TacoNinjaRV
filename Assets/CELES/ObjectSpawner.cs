using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Creación de Spawn")]
    public GameObject tacoPrefab;
    public float spawnInterval = 2f;

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
        if (tacoPrefab == null) return;
        GameObject spawnedTaco = Instantiate(tacoPrefab, transform.position, transform.rotation);

        Rigidbody rb = spawnedTaco.GetComponent<Rigidbody>();
        if (rb != null )
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
