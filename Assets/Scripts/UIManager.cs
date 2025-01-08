using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public ActionsCaller actionsCaller;
    public TextMeshProUGUI torchesLitText; 

    private void Start()
    {
        UpdateTorchesLitText();
        ActionManager.OnTorchLit += UpdateTorchesLitText; 
    }

    private void OnDestroy()
    {
        ActionManager.OnTorchLit -= UpdateTorchesLitText; 
    }

    // update the text to show how many torches are lit
    private void UpdateTorchesLitText()
    {
        int torchesLit = actionsCaller.GetTorchesLit();
        //Debug.Log($"Updating UI: Torches Lit = {torchesLit}");
        torchesLitText.text = $"Torches Lit: {torchesLit}";

        if (torchesLit == 3)
        {
            torchesLitText.text = "Antitode ready, you Win!";
        }
    }
}
