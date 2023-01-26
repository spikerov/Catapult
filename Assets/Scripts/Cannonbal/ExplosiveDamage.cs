using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveDamage : MonoBehaviour
{

    [SerializeField] private MeshRenderer _meshRenderer;

    public static Action CannonballDestroed;

    private void OnEnable()
    {
        CannonballMover.ExplosionCannonball += DeleteLets;
    }

    private void OnDisable()
    {
        CannonballMover.ExplosionCannonball -= DeleteLets;
    }

    private void DeleteLets(List<GameObject> lets)
    {
        _meshRenderer.enabled = false;

        for (int i = 0; i < lets.Count; i++)
        {
            Destroy(lets[i]);
        }
        lets.Clear();

        CannonballDestroed?.Invoke();
        Destroy(gameObject);
    }
}
