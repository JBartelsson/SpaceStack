using UnityEngine;

public class WaterScroll : MonoBehaviour
{
    [SerializeField] private float scrollVector = .5f;
    float offset = 0f;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float timeOffset = scrollVector * Time.deltaTime;
        offset += timeOffset;
        rend.material.SetFloat("_Offset", offset);
    }
}
