using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsCaller : MonoBehaviour
{
    private int torchesLit = 0;

    public void TorchLit()
    {
        torchesLit++;
        //Debug.Log($"Torch Lit: {torchesLit}");
        ActionManager.OnTorchLit?.Invoke();
    }

    public int GetTorchesLit()
    {
        return torchesLit;
    }
}
