using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonballCreator : MonoBehaviour
{
    [SerializeField] private PlayerResize _playerResize;
    [SerializeField] private GameObject _cannonballPrefab;
    [SerializeField] private FreeWayChecker _freeWayChecker;

    private GameObject _cannonball;
    private float _spawnedSizeCannonball = 0.0f;
    private float _positionY;
    private bool _push = false;

    public void CreateCannonball()
    {
        if (_cannonball == null)
        {
            _cannonball = Instantiate(_cannonballPrefab);
            _push = false;
            _positionY = 0.0f;
            _spawnedSizeCannonball = 0.0f;
        }

        if (_push == false)
        {
            ChangeCannonball();
        }
    }
    public void PushCannonball()
    {
        _push = true;
        _freeWayChecker.IsCannonballMoving();
        _cannonball.GetComponent<CannonballMover>().MoveCannonbal();

    }

    private void ChangeCannonball()
    {
        _spawnedSizeCannonball += Time.deltaTime;
        _positionY = _spawnedSizeCannonball / 2;
        _cannonball.transform.localScale = new Vector3(_spawnedSizeCannonball, _spawnedSizeCannonball, _spawnedSizeCannonball);
        _cannonball.transform.position = new Vector3(transform.position.x, _positionY, 6);
        _playerResize.ResizePlayerBall();
    }
}
