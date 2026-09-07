using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private GameObject halfIngredient;

    [Header("Cut face")]
    [SerializeField]
    private Vector3 halfCutNormal = Vector3.forward;

    [Header("Separation")]
    [SerializeField]
    private float separationDistance = 0.05f;

    [SerializeField]
    private float separationForce = 1.5f;

    public void CutIngredient(Vector3 cutPoint, Vector3 cutNormal)
    {
        if (cutNormal.sqrMagnitude < 0.001f)
            return;

        cutNormal.Normalize();
        
        Vector3 originalNormal = transform.TransformDirection(halfCutNormal).normalized;
        
        Quaternion rotation =
            Quaternion.FromToRotation(
                originalNormal,
                cutNormal
            ) * transform.rotation;
        
        Vector3 separationDirection = cutNormal;
        

        GameObject leftHalf = Instantiate(
            halfIngredient,
            transform.position + separationDirection * separationDistance,
            rotation
        );

        GameObject rightHalf = Instantiate(
            halfIngredient,
            transform.position - separationDirection * separationDistance,
            rotation
        );
        
        rightHalf.transform.Rotate(
            180f,
            0f,
            0f,
            Space.Self
        );


        Rigidbody leftRb =
            leftHalf.GetComponent<Rigidbody>();

        Rigidbody rightRb =
            rightHalf.GetComponent<Rigidbody>();

        if (leftRb != null)
        {
            leftRb.AddForce(
                separationDirection * separationForce,
                ForceMode.Impulse
            );
        }

        if (rightRb != null)
        {
            rightRb.AddForce(
                -separationDirection * separationForce,
                ForceMode.Impulse
            );
        }
        
        Destroy(gameObject);
    }
}