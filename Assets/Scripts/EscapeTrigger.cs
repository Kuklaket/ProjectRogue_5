using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _rogue;
    [SerializeField] private GameObject _alex;
    [SerializeField] private Rogue _actionRogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _alex.SetActive(true);
            _actionRogue.ChangeDirection();
        }
    }
}
