using System;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Dictionary<GameObject, Vector3> touchPos;
    
    private void Start()
    {
        touchPos = new Dictionary<GameObject, Vector3>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingredient"))
            touchPos.Add(other.gameObject, other.ClosestPoint(transform.position));
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ingredient"))
            Cut(other.ClosestPoint(transform.position), other.gameObject );
    }

    private void Cut(Vector3 untouchPos, GameObject Ingredient)
    {
        Vector3 cutDirection = (untouchPos - touchPos[Ingredient]).normalized;
<<<<<<< HEAD

        Vector3 bladeDir = transform.forward;

        Vector3 cutNormal = Vector3.Cross(cutDirection, bladeDir).normalized;
=======
        
        Vector3 cutNormal = Vector3.Cross(cutDirection, transform.forward).normalized;
>>>>>>> origin/main

        if (cutNormal.sqrMagnitude < 0.001f)
        {
            Debug.Log("No se ha podido calcular el plano de corte");
            return;
        }

        Ingredient.GetComponent<Ingredient>()?.CutIngredient(touchPos[Ingredient], cutNormal);

        touchPos.Remove(Ingredient);
    }
}
