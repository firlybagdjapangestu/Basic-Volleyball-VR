using System.Collections;
using UnityEngine;

public class BaseButtonVR : MonoBehaviour
{
    public enum TriggerType
    {
        Gaze,
        Input
    }

    [Header("Interaction Settings")]
    public TriggerType triggerType = TriggerType.Input;
    public AudioSource audioSource;
    [SerializeField] private float gazeDuration = 2.0f;

    private Coroutine gazeCoroutine;

    protected static AnimationClip selectedAnimation;
    protected static Animator sharedAnimator;
    protected static AudioClip selectedAudioClip;
    protected static string nameMove;

    protected virtual void Start()
    {
        // Kosong, bisa diisi oleh subclass
    }

    private void Update()
    {
        switch (triggerType)
        {
            case TriggerType.Input:
                HandleInputTrigger();
                break;
        }
    }

    private void HandleInputTrigger()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject == gameObject)
            {
                OnClickTrigger();
            }
        }
    }


    protected virtual void OnPointerEnter()
    {
        if (triggerType == TriggerType.Gaze)
        {
            gazeCoroutine = StartCoroutine(GazeTrigger());
        }
    }

    protected virtual void OnPointerExit()
    {
        if (triggerType == TriggerType.Gaze && gazeCoroutine != null)
        {
            StopCoroutine(gazeCoroutine);
        }
    }

    private IEnumerator GazeTrigger()
    {
        yield return new WaitForSeconds(gazeDuration);
        OnClickTrigger();
    }

    protected virtual void OnClickTrigger()
    {
        // Di-override oleh subclass
    }
}
