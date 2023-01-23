using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private BallCreator _cannonballCreator;

    private void Update()
    {
        GetTouchInput();
    }

    private void GetTouchInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // создаем и увеличиваем м€чь.
        }
    }
}
