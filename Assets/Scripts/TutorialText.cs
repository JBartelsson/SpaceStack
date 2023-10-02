using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TutorialText preDecessor;
    [SerializeField] float closeRange = 1.4f;

    public event EventHandler OnSuccess;
    void Start()
    {
        if (preDecessor != null)
        {
            gameObject.SetActive(false);

            preDecessor.OnSuccess += PreDecessor_OnSuccess;
        } else
        {
            gameObject.SetActive(true);
        }
    }

    private void PreDecessor_OnSuccess(object sender, EventArgs e)
    {
            gameObject.SetActive(true);
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
        float dist = Vector3.Distance(transform.position, PlayerSingleton.Instance.transform.position);
        if ( dist < closeRange)
        {
            OnSuccess?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
