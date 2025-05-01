using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHideObject : BaseButtonVR
{
    public GameObject objectToHide; // Referensi ke objek yang ingin disembunyikan  
    public GameObject objectToShow;

    private Renderer _myRenderer;
    [SerializeField] private Material InactiveMaterial;
    [SerializeField] private Material GazedAtMaterial;

    protected override void Start()
    {
        base.Start();
        _myRenderer = GetComponent<Renderer>();
    }

    protected override void OnPointerEnter()
    {
        SetMaterial(true);
        base.OnPointerEnter();
    }

    protected override void OnPointerExit()
    {
        SetMaterial(false);
        base.OnPointerExit();
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    protected override void OnClickTrigger()
    {
        // Pastikan OnPointerExit selesai sebelum HideObject dipanggil  
        StartCoroutine(HandleClick());
    }

    private IEnumerator HandleClick()
    {
        OnPointerExit();
        yield return null; // Tunggu satu frame agar OnPointerExit selesai  
        HideObject();
        ShowObject();
    }

    private void HideObject()
    {
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // Menyembunyikan objek  
        }
        else
        {
            Debug.LogWarning("Object to hide is not assigned.");
        }
    }

    private void ShowObject()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true); // Menampilkan objek  
        }
        else
        {
            Debug.LogWarning("Object to show is not assigned.");
        }
    }
}
