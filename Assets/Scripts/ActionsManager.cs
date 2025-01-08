using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public static ActionsManager Instance; 
    
    public event Action OnTorchLit; 
    private int torchesLit = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TorchLit()
    {
        torchesLit++;
        Debug.Log($"Torch Lit: {torchesLit}");
        OnTorchLit?.Invoke(); 
    }

    public int GetTorchesLit()
    {
        return torchesLit;
    }
}
