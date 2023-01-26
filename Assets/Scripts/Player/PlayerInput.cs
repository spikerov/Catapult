using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CannonballCreator _cannonballCreator;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            _cannonballCreator.CreateCannonball();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _cannonballCreator.PushCannonball();
        }
    }
}
