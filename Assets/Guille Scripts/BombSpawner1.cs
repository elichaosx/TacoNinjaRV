using UnityEngine;

public class BombSpawner1 : MonoBehaviour
{
    public GameObject bomb;

    void Start()
    {
        Invoke("CreateBomb", Random.Range(6f, 10f));
    }

    void CreateBomb()
    {
        Instantiate(bomb, transform.position, Quaternion.identity);

        Invoke("CreateBomb", Random.Range(6f, 10f)); //Esperar unos 6 o 10 segundos entre cada lanzamiento de bomba 
    }


}

