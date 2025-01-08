using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblet : MonoBehaviour
{
    public Color glowColor = Color.green; 
    public float maxGlowIntensity = 2f; 
    private Renderer plantRenderer;
    private Material plantMaterial;

    private void OnEnable()
    {
        if (ActionsManager.Instance != null)
        {
            ActionsManager.Instance.OnTorchLit += UpdateGlow;
        }

        plantRenderer = GetComponent<Renderer>();
        if (plantRenderer != null)
        {
            plantMaterial = plantRenderer.material;
            plantMaterial.EnableKeyword("_EMISSION");
        }
    }

    private void OnDisable()
    {
        if (ActionsManager.Instance != null)
        {
            ActionsManager.Instance.OnTorchLit -= UpdateGlow;
        }
    }

    // for each torch lit, update the intensity of the material's emission until its 3 (100%)
    private void UpdateGlow()
    {
        if (plantMaterial == null) return;

        int torchesLit = ActionsManager.Instance.GetTorchesLit();

        float intensity = Mathf.Clamp01((float)torchesLit / 3) * maxGlowIntensity;

        Color emissionColor = glowColor * intensity;
        plantMaterial.SetColor("_EmissionColor", emissionColor);

        //Debug.Log($"{gameObject.name}: Glow updated with intensity {intensity} (Torches lit: {torchesLit})");
    }
}
