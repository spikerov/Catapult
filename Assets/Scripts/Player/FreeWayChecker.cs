using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeWayChecker : MonoBehaviour
{
    [SerializeField] private float _lengthPath = 49f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PlayerResize _playerResize;
    [SerializeField] private LineRenderer _lineRenderer;

    public static Action WayFree;

    private bool _cannonballMoving = false;
    private bool isMoving = false;
    private RaycastHit _raycastHits;

    private void OnEnable()
    {
        ExplosiveDamage.CannonballDestroed += IsCannonballMoving;
    }

    private void OnDisable()
    {
        ExplosiveDamage.CannonballDestroed -= IsCannonballMoving;
    }

    private void FixedUpdate()
    {
        if (isMoving == false)
        {
            if (_cannonballMoving == false)
            {
                if (!_rigidbody.SweepTest(Vector3.forward, out _raycastHits, _lengthPath))
                {
                    WayFree?.Invoke();
                    isMoving = true;
                }
            }

            if (_lineRenderer.enabled == false)
            {
                _lineRenderer.enabled = true;
            }

            _lineRenderer.SetWidth(_playerResize.CurrentCannonballSize, _playerResize.CurrentCannonballSize);
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }

    public void IsCannonballMoving()
    {
        if (_cannonballMoving == true)
        {
            _cannonballMoving = false;
        }
        else
        {
            _cannonballMoving = true;
        }
    }
}
