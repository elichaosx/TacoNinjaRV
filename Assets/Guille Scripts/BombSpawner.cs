using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public float fuerza = 10f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * fuerza, ForceMode.Impulse);
    }

}
