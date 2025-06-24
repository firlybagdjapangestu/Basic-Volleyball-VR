using System.Collections;
using UnityEngine;

public class BaseButtonVR : MonoBehaviour
{
    public AudioSource audioSource;    
    [SerializeField] private float gazeDuration = 2.0f;

    private Coroutine gazeCoroutine;

    protected static AnimationClip selectedAnimation; // Menyimpan animasi yang dipilih
    protected static Animator sharedAnimator; // Animator yang dipakai oleh semua button
    protected static AudioClip selectedAudioClip; // Menyimpan audio yang dipilih
    protected static string nameMove;

    protected virtual void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnClickTrigger();
                }
            }
        }
    }

    protected virtual void OnPointerEnter()
    {

    }

    protected virtual void OnPointerExit()
    {

    }


    protected virtual void OnClickTrigger()
    {
        // Fungsi ini akan di-override oleh button spesifik
    }

    
}
