using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHideObject : BaseButtonVR
{
    public GameObject objectToHide; // Referensi ke objek yang ingin disembunyikan  
    public GameObject objectToShow;


    protected override void Start()
    {
        base.Start();
    }

    protected override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    protected override void OnPointerExit()
    {
        base.OnPointerExit();
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

    private void HideObject() // Menyembunyikan objek
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

    private void ShowObject() // Menampilkan objek
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
