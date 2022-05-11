using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerController : MonoBehaviour
{
    public static MusicManagerController musicManagerController;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        if (musicManagerController == null)        
            musicManagerController = this;        

        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(musicManagerController);
    }

    public void ChangeMusicState()
    {
        if (_audioSource.volume == 1)
            _audioSource.volume = 0;

        else if (_audioSource.volume == 0)
            _audioSource.volume = 1;

    }
}
