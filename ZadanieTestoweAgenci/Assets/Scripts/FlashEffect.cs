using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] Material flashMaterial;
    private Material defaultMaterial;
    private MeshRenderer meshRenderer;
    private Coroutine flashRoutine;
    [SerializeField] float duration;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        meshRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        meshRenderer.material = defaultMaterial;

    }
}
