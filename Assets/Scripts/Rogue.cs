using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rogue : MonoBehaviour
{
    private float _speed = 2f;

    public void ChangeDirection()
    {
        int directionRightForY = 0;

        if (transform.rotation.y == directionRightForY)
        {
            transform.Rotate(0, 180, 0);
            _speed = 6f;
        }
    }

    public void ChangeSpeed()
    {
        float _walkSpeed = 2f;

        if (_speed != 0) 
        {
            _speed = 0;
        }
        else
        {
            _speed = _walkSpeed;
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}
