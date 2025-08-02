using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script controla o comportamento de uma bomba no Unity.
public class BombScript : MonoBehaviour
{
    // Tempo em segundos antes da bomba explodir.
    public float explosionDelay = 5f; // Time before the bomb explodes
    public GameObject explosionPrefab; // Prefab for explosion effect (optional)

    void Start()
    {
        // Inicia a corrotina que aguarda o tempo de delay antes de explodir.
        StartCoroutine(explosionCoroutine());
    }

    // Corrotina responsável por aguardar o tempo de delay e então explodir a bomba.
    private IEnumerator explosionCoroutine()
    {
        // Espera pelo tempo definido em explosionDelay antes de continuar.
        yield return new WaitForSeconds(explosionDelay);
        // Após o tempo de espera, chama o método Explode.
        Explode();
    }

    // Método que executa a explosão da bomba.
    private void Explode()
    {
        // Create Explosion Effect
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);


        // Aqui você pode adicionar lógica para destruir plataformas próximas.


        // Destroi o objeto da bomba, removendo-o da cena.
        Destroy(gameObject);
    }
}