using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particlePrefab;

    private void Awake()
    {
       var life = GetComponent<Life>(); ;
        life.onDeath.AddListener(OnDeath);
    }

    void OnDeath()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
