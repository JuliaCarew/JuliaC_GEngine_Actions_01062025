using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torches : MonoBehaviour
{
    public GameObject torchLight;
    private bool isLit = false;

    private void Start()
    {
        // if (torchLight != null) // manually set active for debugging
        // {
        //     Debug.Log($"Manually activating light for {gameObject.name}.");
        //     torchLight.SetActive(true);
        // }

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

    // when the player's torch collider connects with the wall torches, invoke the onLit action
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLit) 
        {
            //Debug.Log($"{gameObject.name}: Player entered torch trigger.");
            isLit = true; 
            ActionsManager.Instance?.TorchLit(); 
        }
        else
        {
            //Debug.Log($"{gameObject.name}: Torch already lit or invalid collider.");
        }
    }

    private void OnEnable()
    {
        if (ActionsManager.Instance != null)
        {
            //Debug.Log($"{gameObject.name} subscribing to OnTorchLit.");
            ActionsManager.Instance.OnTorchLit += ActivateTorchLight; 
        }
        else{
            //Debug.LogError($"{gameObject.name}: ActionsManager.Instance is null!");
        }
    }

    private void OnDisable()
    {
        ActionsManager.Instance.OnTorchLit -= ActivateTorchLight; 
    }

    // enable light gameobject for each light triggered
    private void ActivateTorchLight()
    {
        if (isLit && torchLight != null)
        {
            //Debug.Log($"{gameObject.name} activating its torch light.");
            torchLight.SetActive(true);
        }
        else
        {
            //Debug.LogWarning($"{gameObject.name}: torch light activation failed. isLit = {isLit}, torchLight = {torchLight}");
        }
    }
}
