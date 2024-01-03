using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F;
    [SerializeField] private float power = 10.0F;
    
    private GameObject _fullObject;
    private Transform _cells;
    private Vector3 _explosionPos;

    private void Start()
    {
        InitVariables();
        StartCoroutine(ExplosionInSecCor(1f));
    }

    private IEnumerator ExplosionInSecCor(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        _fullObject.SetActive(false);
        
        foreach (Transform child in _cells)
        {
            var rb = child.AddComponent<Rigidbody>();
            
            child.gameObject.SetActive(true);
            child.AddComponent<BoxCollider>();
            rb.AddExplosionForce(power, _explosionPos, radius, 0.005f);
            rb.useGravity = true;
        }
    }

    private void InitVariables()
    {
        _explosionPos = transform.position;

        foreach (Transform child in this.transform)
        {
            if (child.name.Equals("FULL")) _fullObject = child.gameObject;
            if (child.name.Equals("CELLS")) _cells = child;
        }
    }
}
