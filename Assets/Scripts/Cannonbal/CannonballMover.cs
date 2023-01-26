using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballMover : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _timeDelayAddLetsList = 0.1f;
    [SerializeField] private float _deathLinePositionZ = 50f;
    [SerializeField] private CannonballExplosion _cannonballExplosion;
    [SerializeField] private ExplosiveDamage _explosiveDamage;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _explossionEffect;

    public static Action<List<GameObject>> ExplosionCannonball;

    public bool IsMoving { get; set; } = false;

    private bool _activeExplosion = false;

    private void Update()
    {
        if (IsMoving == true)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        if (_activeExplosion == true && IsMoving == true)
        {
            _cannonballExplosion.SetExplosionRadius();
            StopCannonbal();
            _cannonballExplosion.gameObject.SetActive(true);
            _meshRenderer.enabled = false;
            _explossionEffect.Play();
            StartCoroutine(DestroyCannonball());
        }

        if (transform.position.z >= _deathLinePositionZ)
        {
            print("Ã»ÃŒ - ”Õ»◊“Œ∆»“‹ ﬂƒ–Œ");
            IsMoving = false;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Let>())
        {
            collision.rigidbody.isKinematic = true;
            ActiveExplosion();
        }
    }

    public void MoveCannonbal()
    {
        IsMoving = true;
    }

    private void StopCannonbal()
    {
        IsMoving = false;
    }
    
    private void ActiveExplosion()
    {
        _activeExplosion = true;
    }

    private IEnumerator DestroyCannonball()
    {
        yield return new WaitForSeconds(_timeDelayAddLetsList);
        ExplosionCannonball?.Invoke(_cannonballExplosion.ListDestroyLets);
        Destroy(gameObject);
    }
}
