using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> stones;
    void Start()
    {
        foreach (var stone in stones)
        {
            stone.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
