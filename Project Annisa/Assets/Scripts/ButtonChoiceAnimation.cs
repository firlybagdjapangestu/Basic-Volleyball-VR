using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

public class ButtonChoiceAnimation : BaseButtonVR
{
    private Renderer _myRenderer;
    [SerializeField] private string nameMove;
    [SerializeField] private string descriptionMove;
    [SerializeField] private TextMeshPro displayText;
    [SerializeField] private TextMeshPro displayText2;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private Material InactiveMaterial;
    [SerializeField] private Material GazedAtMaterial;
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private TimelineAsset timelineAsset;
    [SerializeField] AudioClip audioClip;


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
        base.OnClickTrigger();
        print("Clicked on ");
        ChangeDisplayText();
        PlayAudio();
        PlayTimeline();
        OnPointerExit();
    }

    private void PlayTimeline() // jalanin animasi
    {
        if (playableDirector != null && timelineAsset != null)
        {
            playableDirector.playableAsset = timelineAsset;
            playableDirector.Play();
        }
    }

    private void PlayAudio() // jalanin audio
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    private void ChangeDisplayText() // ubah text di atas kepala player
    {
        if (displayText != null)
        {
            displayText.text = nameMove;
            displayText2.text = nameMove;
            descriptionText.text = descriptionMove;
        }
    }
}
