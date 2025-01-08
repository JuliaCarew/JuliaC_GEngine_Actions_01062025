using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{
    public GameObject torchLight;
    private bool isLit = false;

    private void Start()
    {
        if (torchLight == null)
        {
            //Debug.LogError($"{gameObject.name}: torchLight component not assigned");
        }
        else if (torchLight != null)
        {
            //Debug.Log($"{gameObject.name}: torchLight is assigned to {torchLight.name}");
            torchLight.SetActive(false); 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log($"{gameObject.name}: Player entered torch trigger.");
            ActionManager.OnTorchLit?.Invoke();
        }
    }

    private void OnEnable()
    {
        //Debug.Log($"{gameObject.name} subscribing to OnTorchLit.");
        ActionManager.OnTorchLit += ActivateTorchLight; 

    }

    private void OnDisable()
    {
        ActionManager.OnTorchLit -= ActivateTorchLight; 
    }

    // enable light gameobject for each light triggered
    private void ActivateTorchLight()
    {
        if (isLit && torchLight != null)
        {
            //Debug.Log($"{gameObject.name} activating its torch light.");
            torchLight.SetActive(true);
        }
    }
}
