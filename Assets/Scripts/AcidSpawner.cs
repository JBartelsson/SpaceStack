using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject particlePrefab;
    [SerializeField] float particleSpawnWaitLow = 2.5f;

    [SerializeField] float particleSpawnWait = 5f;
    void Start()
    {
        Invoke(nameof(SpawnParticle), 1f);
    }

    private void SpawnParticle()
    {
        float maxScale = .7f;
        float rng = Random.Range(-maxScale, maxScale);
        float rng2 = Random.Range(-maxScale, maxScale);

        Vector3 pos = transform.position + new Vector3(transform.localScale.x * rng, transform.localScale.y * .5f, transform.localScale.z * rng);
        particlePrefab.transform.position = pos;
        particlePrefab.GetComponent<ParticleSystem>().Play();
        Invoke(nameof(SpawnParticle), Random.Range(particleSpawnWaitLow, particleSpawnWait));
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
