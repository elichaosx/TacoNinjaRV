using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bombParticle;
    
    public void CutBomb()
    {
        GameManager.instance.LoseLife();
        Debug.Log("Bomba cortada");
        
        //Sound
        AudioManager.Instance.PlaySound(1);

        //Particles
        ParticlesManager.Instance.PlayParticle(bombParticle, transform.position);

        Destroy(gameObject);
    }

}
