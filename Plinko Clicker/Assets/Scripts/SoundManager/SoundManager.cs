using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    [Header("----------Music----------")]
    [SerializeField] private AudioClip[] musics;
    [SerializeField] private AudioSource musicSource;
    [Header("----------SFX----------")]
    public AudioClip buy;
    public AudioClip money;
    [SerializeField] private AudioSource sfxSource;

    private void OnEnable() => instance = this;

    public static SoundManager Instance(){
        if(instance==null) instance = new GameObject().AddComponent<SoundManager>();
        return instance;
    }

    private void Awake() => PlayRandomMusic();

    private void Update(){
        if(!musicSource.isPlaying) PlayRandomMusic();
    }

    private void PlayRandomMusic() => musicSource.PlayOneShot(musics[Random.Range(0, musics.Length)]);

    public void PlaySFX(AudioClip clip) => sfxSource.PlayOneShot(clip);
    
}
