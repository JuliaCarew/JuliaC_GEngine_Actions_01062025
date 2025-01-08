using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI torchesLitText; 

    private void Start()
    {
        UpdateTorchesLitText(); 
        ActionsManager.Instance.OnTorchLit += UpdateTorchesLitText; 
    }

    private void OnDestroy()
    {
        ActionsManager.Instance.OnTorchLit -= UpdateTorchesLitText; 
    }

    private void UpdateTorchesLitText()
    {
        int torchesLit = ActionsManager.Instance.GetTorchesLit();
        //Debug.Log($"Updating UI: Torches Lit = {torchesLit}");
        torchesLitText.text = $"Torches Lit: {torchesLit}";

        if (torchesLit == 3)
        {
            torchesLitText.text = "Antitode ready, you Win!";
        }
    }
}
