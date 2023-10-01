/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrail : MonoBehaviour
{

    public float activeTime = 2f;

    [Header("Mesh Related")]
    public float meshRefreshRate = 0.1f;

    private bool isTrailActive;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Enter) && !isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActivateTrail(activeTime));
        }
    }

    IEnumerator ActivateTrail (float time)
    {
        while(time > 0) {
            time -= meshRefreshRate;
            yield return new WaitForSeconds (meshRefreshRate);

        }

        isTrailActive = false;
    }
}
*/