using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Transform _targetPosition;

    public static Action PlayerInTarget;

    private float _targetPozitionY;
    private bool _wayFree = false;

    private void OnEnable()
    {
        FreeWayChecker.WayFree += IsWayFree;
    }

    private void OnDisable()
    {
        FreeWayChecker.WayFree -= IsWayFree;

    }

    private void FixedUpdate()
    {
        if (_wayFree == true && transform.position != _targetPosition.position)
        {
            MovePlayerToHit();
        }

        if (transform.position.z >= _targetPosition.position.z)
        {
            print("Win");
            PlayerInTarget?.Invoke();
        }
    }

    private void MovePlayerToHit()
    {
        _targetPozitionY = transform.localScale.y / 2;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_targetPosition.position.x, _targetPozitionY, _targetPosition.position.z), _speed * Time.deltaTime);
    }

    private void IsWayFree()
    {
        _wayFree = true;
    }
}
