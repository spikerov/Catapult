using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCannonball : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving == true)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }

    public void MoveCannonbal()
    {
        isMoving = true;
    }
}
