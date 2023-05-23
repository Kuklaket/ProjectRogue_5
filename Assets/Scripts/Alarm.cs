using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _sos;
    private float _volumeMinimum = 0.4f;
    private float _volumeMaximum = 1f;
    private float _additionalVolume = 0.1f;
    private bool _isOn = false;

    public void ChangeAlarmStatus()
    {
        _isOn = !_isOn;

        if (_isOn == true)
        {
            _sos.volume = _volumeMinimum;
            _sos.Play();
            _animator.SetBool("IsHack", true);
        }
    }

    private void Update()
    {
        if (_isOn == true)
        {            
            _sos.volume = Mathf.MoveTowards(_sos.volume, _volumeMaximum, _additionalVolume * Time.deltaTime);
        }
        else
        {
            _sos.volume = Mathf.MoveTowards(_sos.volume, _volumeMinimum, _additionalVolume * Time.deltaTime);
        }

        if (_sos.volume <= _volumeMinimum)
        {
            _animator.SetBool("IsHack", false);
            _sos.Stop();
        }
    }
}
