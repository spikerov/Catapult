using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballExplosion : MonoBehaviour
{
    [SerializeField] private float _ratioRadiusExplosion = 7f;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private CannonballMover _cannonballMover;
    [SerializeField] private ParticleSystem _explossionEffect;

    [HideInInspector] public List<GameObject> ListDestroyLets = new List<GameObject>();

    public void SetExplosionRadius()
    {
        _sphereCollider.radius = gameObject.transform.localScale.x * _ratioRadiusExplosion;
        _explossionEffect.transform.localScale = new Vector3(_sphereCollider.radius, _sphereCollider.radius, _sphereCollider.radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Let")
        {
            ChangeExplossionList(other.gameObject);
        }
    }

    private void ChangeExplossionList(GameObject let)
    {
        ListDestroyLets.Add(let);
    }
}
