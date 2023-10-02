using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] List<GameObject> rigidBodies;
    [SerializeField] private GameObject stoneWhole;
    [SerializeField] private AudioSource stoneSound;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.AddComponent<Rigidbody>();
            rigidBody.SetActive(false);
            stoneWhole.SetActive(true);
            GetComponent<BoxCollider>().enabled = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.SetActive(true);
        }
        stoneSound.Play();
        stoneWhole.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;

        Invoke(nameof(DestroyAll), 1.4f);
    }

    private void DestroyAll()
    {
        Destroy(gameObject);

    }
}
