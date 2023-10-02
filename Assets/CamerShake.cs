using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CamerShake : MonoBehaviour
{

    //private CinemachineVirtualCamera cinemachineVirtualCamera;
    //private float shakeIntensity = 1f;
    //private float shakeTime = 0.2f;

    //private float timer;
    //private CinemachineBasicMultiChannelPerlin _cbmcp;

    //private void Avake()
    //{

    //}

    //private void Start()
    //{
    //    cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    //    StopShake();
    //}

    //public void ShakeCamera()
    //{
    //    Debug.Log("Shake Baby Shake");
    //    CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    //    _cbmcp.m_AmplitudeGain = shakeIntensity;

    //    timer = shakeTime;

    //}

    //public void StopShake()
    //{
    //    CinemachineBasicMultiChannelPerlin _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    //    _cbmcp.m_AmplitudeGain = 0f;
    //    timer = 0f;
    //}

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.PageUp))
    //    {
    //        ShakeCamera();
    //    }

    //    if (Input.GetKey(KeyCode.PageDown))
    //    {
    //        StopShake();
    //    }

    //    if (timer > 0)
    //    {
    //        timer -= Time.deltaTime;

    //        if (timer <= 0)
    //        {
    //            StopShake();
    //        }
    //    }
    //}

    private void Update()
    {
        if (Input.GetKey(KeyCode.PageUp))
        {
            
        }
    }

    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
