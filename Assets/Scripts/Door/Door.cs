using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _doorMoveSpeed = 10f;
    [SerializeField] private float _openDoorPositionX = -3f;
    [SerializeField] private float _closeDoorPositionX = 0.0f;

    private bool _doorOpened = false;
    private bool _doorClosed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _doorOpened = true;
        }
    }

    private void Update()
    {
        if (_doorOpened == true)
        {
            OpenDoor();
        }

        if (_doorClosed == true)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_openDoorPositionX, transform.position.y, transform.position.z), _doorMoveSpeed * Time.deltaTime);

        if (transform.position.x == _openDoorPositionX)
        {
            _doorOpened = false;
            _doorClosed = true;
        }
    }

    private void CloseDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_closeDoorPositionX, transform.position.y, transform.position.z), _doorMoveSpeed * Time.deltaTime);

        if (transform.position.x == _closeDoorPositionX)
        {
            _doorClosed = false;
        }
    }
}
