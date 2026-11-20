using System;
using UnityEngine;

public class IngredientTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ingredient>())
        {
            GameManager.instance.LoseLife();
            Destroy(other.gameObject);
        }
    }
}
