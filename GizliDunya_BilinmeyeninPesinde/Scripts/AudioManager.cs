using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    [Header("Music Clips")]
    public AudioClip amazonJungleMusic;
    public AudioClip underwaterMusic;
    public AudioClip egyptianMusic;
    public AudioClip mayaMusic;
    public AudioClip himalayanMusic;
    public AudioClip desertMusic;
    public AudioClip englishMusic;
    public AudioClip pacificMusic;
    public AudioClip antarcticMusic;
    public AudioClip mysteriousMusic;
    
    [Header("Sound Effects")]
    public AudioClip puzzleSolvedSFX;
    public AudioClip wrongAnswerSFX;
    public AudioClip doorOpenSFX;
    public AudioClip playerHurtSFX;
    public AudioClip levelCompleteSFX;
    
    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 0.7f;
    [Range(0f, 1f)] public float sfxVolume = 1f;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        if (musicSource == null || sfxSource == null)
        {
            // Create audio sources if they don't exist
            AudioSource[] sources = GetComponents<AudioSource>();
            if (sources.Length == 0)
            {
                musicSource = gameObject.AddComponent<AudioSource>();
                sfxSource = gameObject.AddComponent<AudioSource>();
                sfxSource.playOnAwake = false;
            }
            else if (sources.Length == 1)
            {
                musicSource = sources[0];
                sfxSource = gameObject.AddComponent<AudioSource>();
                sfxSource.playOnAwake = false;
            }
            else
            {
                musicSource = sources[0];
                sfxSource = sources[1];
                sfxSource.playOnAwake = false;
            }
        }
        
        SetVolume();
    }
    
    public void SetVolume()
    {
        if (musicSource != null)
            musicSource.volume = musicVolume;
        if (sfxSource != null)
            sfxSource.volume = sfxVolume;
    }
    
    public void PlayMusicForLevel(int levelIndex)
    {
        AudioClip musicClip = null;
        
        switch (levelIndex)
        {
            case 1: // Amazon Jungle
                musicClip = amazonJungleMusic;
                break;
            case 2: // Atlantis
                musicClip = underwaterMusic;
                break;
            case 3: // Egypt
                musicClip = egyptianMusic;
                break;
            case 4: // Maya
                musicClip = mayaMusic;
                break;
            case 5: // Himalayas
                musicClip = himalayanMusic;
                break;
            case 6: // Nazca
                musicClip = desertMusic;
                break;
            case 7: // Stonehenge
                musicClip = englishMusic;
                break;
            case 8: // Easter Island
                musicClip = pacificMusic;
                break;
            case 9: // Antarctica
                musicClip = antarcticMusic;
                break;
            case 10: // Bermuda Triangle
                musicClip = mysteriousMusic;
                break;
            default:
                musicClip = amazonJungleMusic; // Default music
                break;
        }
        
        if (musicClip != null && musicSource != null)
        {
            if (musicSource.clip != musicClip)
            {
                musicSource.clip = musicClip;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }
    
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
    
    public void PlayPuzzleSolvedSFX()
    {
        if (puzzleSolvedSFX != null)
            PlaySFX(puzzleSolvedSFX);
    }
    
    public void PlayWrongAnswerSFX()
    {
        if (wrongAnswerSFX != null)
            PlaySFX(wrongAnswerSFX);
    }
    
    public void PlayDoorOpenSFX()
    {
        if (doorOpenSFX != null)
            PlaySFX(doorOpenSFX);
    }
    
    public void PlayPlayerHurtSFX()
    {
        if (playerHurtSFX != null)
            PlaySFX(playerHurtSFX);
    }
    
    public void PlayLevelCompleteSFX()
    {
        if (levelCompleteSFX != null)
            PlaySFX(levelCompleteSFX);
    }
    
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }
    
    public void PauseMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Pause();
        }
    }
    
    public void ResumeMusic()
    {
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.UnPause();
        }
    }
}