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

    private float _timer = 0;
    private float _timerEndValue = 1;
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
            }
            else
            {
                _actionAlarm.ChangeAlarmStatus();
            }
        }

        _actionDoor.OpenDoor();
    }

    private void Update()
    {
        if (_isStarted == true)
        {
            _timer = _timer + Time.deltaTime;
        }

        if (_timer >= _timerEndValue)
        {
            _isStarted = false;
            _actionRogue.ChangeSpeed();
            _actionAlarm.ChangeAlarmStatus();
            _timer = 0;
        }
    }
}
