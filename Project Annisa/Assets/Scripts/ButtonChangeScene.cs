using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeScene : BaseButtonVR
{
    public string sceneName; // Nama scene yang ingin di-load
    [SerializeField] private Material InactiveMaterial;
    [SerializeField] private Material GazedAtMaterial;
    [SerializeField] private Renderer _myRenderer;


    private void Start()
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
        // Pastikan OnPointerExit selesai sebelum LoadScene dipanggil  
        StartCoroutine(HandleClick());
        Debug.Log("Clicked on " + gameObject.name); // Debug log untuk memastikan klik terdeteksi
    }
    private IEnumerator HandleClick()
    {
        OnPointerExit();
        yield return null; // Tunggu satu frame agar OnPointerExit selesai  
        LoadScene();
    }
    private void LoadScene() // Memuat scene baru
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is empty or null.");
        }
    }
}