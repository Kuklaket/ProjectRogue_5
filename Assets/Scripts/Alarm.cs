using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sos;

    private float _volumeMinimum = 0.3f;
    private float _volumeMaximum = 0.9f;
    private bool _isOn = false;

    public void ChangeAlarmStatus()
    {
        _isOn = !_isOn;

        Coroutine coroutineForSound;

        if (_isOn == true)
        {
            _sos.volume = _volumeMinimum;
            _sos.Play();
            _animator.SetBool(HashAnimationsNames.IsHackAsHash, true);

            coroutineForSound = StartCoroutine(ChangeVolume(_volumeMaximum));
        }
        else
        {
            coroutineForSound = StartCoroutine(ChangeVolume(_volumeMinimum));
        }
    }

    private IEnumerator ChangeVolume(float targetingVolume)
    {
        float changeVolumeCount = 0.3f;

        while (_sos.volume != targetingVolume)
        {
            _sos.volume = Mathf.MoveTowards(_sos.volume, targetingVolume, changeVolumeCount * Time.deltaTime);

            yield return null;
        }

        if (_isOn == false)
        {
            _animator.SetBool(HashAnimationsNames.IsHackAsHash, false);
            _sos.Stop();
        }
    }
}
