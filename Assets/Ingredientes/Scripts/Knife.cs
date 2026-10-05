using System;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Dictionary<Ingredient, Vector3> touchPos;
    
    private void Start()
    {
        touchPos = new Dictionary<Ingredient, Vector3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            touchPos.Add(ingredient, other.ClosestPoint(transform.position));
        else if (other.TryGetComponent<Bomb>(out Bomb bomb))
            bomb.CutBomb();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Ingredient>(out Ingredient ingredient))
            Cut(other.ClosestPoint(transform.position), ingredient );
    }

    private void Cut(Vector3 untouchPos, Ingredient ingredient)
    {
        Vector3 cutDirection = (untouchPos - touchPos[ingredient]).normalized;
        
        Vector3 cutNormal = Vector3.Cross(cutDirection, transform.forward).normalized;

        if (cutNormal.sqrMagnitude < 0.001f)
        {
            Debug.Log("No se ha podido calcular el plano de corte");
            return;
        }

        ingredient.CutIngredient(touchPos[ingredient], cutNormal);

        touchPos.Remove(ingredient);
    }
}
