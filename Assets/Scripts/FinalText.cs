using UnityEngine;

public class FinalText : MonoBehaviour
{
    public GameObject objectToSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (objectToSpawn != null)
            {
                objectToSpawn.SetActive(true);
            }
        }
    }
}
