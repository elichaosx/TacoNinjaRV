using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public static ParticlesManager Instance { get; private set; }

    [SerializeField]
    private Transform cameraTransform;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayParticle(GameObject particlePrefab, Vector3 ingredientPos)
    {
        if (particlePrefab == null)
        {
            Debug.LogWarning("Particle prefab is null.");
            return;
        }

        Quaternion rotation = Quaternion.LookRotation(cameraTransform.position);

        GameObject particleInstance = Instantiate(particlePrefab, ingredientPos, rotation);
        ParticleSystem particleSystem = particleInstance.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
            Destroy(particleInstance, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
        }
        else
        {
            Debug.LogWarning("No ParticleSystem component found on the instantiated prefab.");
            Destroy(particleInstance);
        }
    }
}
