using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _rogue;
    [SerializeField] private GameObject _alarm;
    [SerializeField] private GameObject _door;
    [SerializeField] private Rogue _actionRogue;
    [SerializeField] private Alarm _actionAlarm;
    [SerializeField] private Door _actionDoor;

    private float _timer = 0f;
    private float _timerEndValue = 1f;
    private bool _isStarted = false;
    private bool _is—ommingIn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            if (_is—ommingIn == true)
            {
                _isStarted = true;
                _actionRogue.ChangeSpeed();
                _is—ommingIn = !_is—ommingIn;
                StartCoroutine(StartTimer());
            }
            else
            {
                _actionAlarm.ChangeAlarmStatus();
            }
        }
    }

    private IEnumerator StartTimer()
    {
        if (_isStarted == true)
        {
            while (_timer < _timerEndValue)
            {
                _timer = _timer + Time.deltaTime;

                yield return null;
            }

            _isStarted = false;
            _timer = 0;
            _actionRogue.ChangeSpeed();
            _actionAlarm.ChangeAlarmStatus();
            _actionDoor.OpenDoor();
        }
    }
}
