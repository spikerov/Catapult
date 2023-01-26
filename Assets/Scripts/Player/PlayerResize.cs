using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResize : MonoBehaviour
{
    [SerializeField] private float _startCannonballSize = 4;
    [SerializeField] private float _minimumCannonballSize = 0.4f;

    public static Action OnGameOver;

    private float _currentCannonballSize;
    private float _cannonballPositionY;
    private bool _isLose = false;

    public float CurrentCannonballSize => _currentCannonballSize;

    private void Start()
    {
        _currentCannonballSize = _startCannonballSize;
    }

    public void ResizePlayerBall()
    {
        if (_isLose == false)
        {
            _currentCannonballSize -= Time.deltaTime;
            _cannonballPositionY = _currentCannonballSize / 2;
            transform.localScale = new Vector3(_currentCannonballSize, _currentCannonballSize, _currentCannonballSize);
            transform.position = new Vector3(0, _cannonballPositionY, 0);

            if (_currentCannonballSize <= _minimumCannonballSize)
            {
                _isLose = true;
                OnGameOver?.Invoke();
            }
        }
    }
}
