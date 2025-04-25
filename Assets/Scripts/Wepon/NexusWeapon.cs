using System.Collections;
using UnityEngine;

public class NexusWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private float _projectileSpeed;

    [SerializeField]
    private float _projectileLifeTime;

    [SerializeField]
    private float _fireRate;

    [SerializeField]
    private int _projectileDamage;

    [SerializeField]
    private float _projectileCost;

    [SerializeField]
    private float _explosionRadius;

    [SerializeField]
    private float _explosionForce;

    private Player _player;

    private Animator _animator;

    private Coroutine _nexusShootCoroutine;

    private void OnEnable()
    {
        PlayerActions.OnPlayerShoot += Shoot;
    }

    private void OnDisable()
    {
        PlayerActions.OnPlayerShoot -= Shoot;
    }

    private void Awake()
    {
        _player = transform.parent.gameObject.GetComponent<Player>();
        _animator = transform.parent.gameObject.GetComponent<Animator>();
    }


    private void Shoot()
    {
        if (_nexusShootCoroutine == null && NexusEnergy.instance.CanUseEnergy(_projectileCost))
        {
            _animator.SetBool("Attacking", true);
            NexusEnergy.instance.UseEnergy(_projectileCost);
            _nexusShootCoroutine = StartCoroutine(ShootCoroutine());
            _animator.SetBool("Attacking", false);
        }
    }

    private IEnumerator ShootCoroutine()
    {
        GameObject projectile = Instantiate(_projectilePrefab);
        projectile.transform.position = transform.position;
        NexusProjectile nexusProjectile = projectile.GetComponent<NexusProjectile>();
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (pos - (Vector2)transform.position).normalized;
        nexusProjectile.SetUp(dir, _projectileSpeed, _projectileLifeTime, _projectileDamage, _explosionRadius, _explosionForce, transform.parent.gameObject);
        yield return new WaitForSeconds(_fireRate);
        _nexusShootCoroutine = null;
    }
}
