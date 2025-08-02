using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    public float Delay = 1f;
    void Start()
    {
        StartCoroutine(BeginSelfDestruction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator BeginSelfDestruction()
    {
        // Espera pelo tempo definido em Delay antes de continuar.
        yield return new WaitForSeconds(Delay);
        
        // Destroi o objeto atual, removendo-o da cena.
        Destroy(gameObject);
    }
}
