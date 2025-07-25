using UnityEngine;
using UnityEngine.Audio;

public class AudioMasterToggler : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private AudioMixer _audioMixer;

    private bool _isPlaying = true;

    public void ToggleMusic()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            _audioMixer.SetFloat(_masterGroup.name, 0);
        else
            _audioMixer.SetFloat(_masterGroup.name, -80);
    }
}
