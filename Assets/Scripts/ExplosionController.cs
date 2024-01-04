using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private Transform explosionObject;
    [SerializeField] private float explosionDelay;
    
    private List<Explosion> _explosionsList = new();
    
    private void Start()
    {
        GetExplosionComponents();
        StartCoroutine(ExplosionCor(explosionDelay));
    }

    private IEnumerator ExplosionCor(float delay)
    {
        yield return new WaitForSeconds(1f);
        
        WaitForSeconds waiter = new WaitForSeconds(delay);
        
        foreach (var explosion in _explosionsList)
        {
            float power = Random.Range(50f, 550f);
            float upwardModifier = Random.Range(0.00025f, 0.0008f);
            
            explosion.Blow(power, upwardModifier);

            yield return waiter;
        }
        
    }

    private void GetExplosionComponents()
    {
        foreach (Transform child in explosionObject)
        {
            _explosionsList.Add(child.GetComponent<Explosion>());
        }
    }
    
}
