using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawlies : MonoBehaviour
{
    private void OnEnable()
    {
        ActionManager.OnTorchLit += HideSpider;
    }

    private void OnDisable()
    {
        ActionManager.OnTorchLit -= HideSpider;
    }

    // when the light hits the spider it disappears (later make it run?)
    private void HideSpider()
    {
        //Debug.Log($"{gameObject.name}: spider hides!");
        gameObject.SetActive(false);
    }
}
