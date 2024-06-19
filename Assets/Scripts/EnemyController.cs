using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _hungerNeed;
    [SerializeField] int _score;
    [SerializeField] Animator _animator;
    [SerializeField] HitBox _hitBox;
    [SerializeField] Image _enemyFillBar;
    [SerializeField] IntEventChannel _onScoreAdd;
    Rigidbody _rigidbody;
    float _currentHunger = 0;

    private void OnEnable()
    {
        _hitBox.HungerAdded += OnGetHit;
    }

    private void OnDisable()
    {
        _hitBox.HungerAdded -= OnGetHit;
    }
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyFillBar.fillAmount = 0;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(0, 0, -_maxSpeed - GetPlayerHorizontalVelocity()), ForceMode.VelocityChange);
    }

    public float GetPlayerHorizontalVelocity()
    {
        Vector3 value = _rigidbody.velocity;
        return value.z;
    }


    void OnGetHit(int value)
    {
        _currentHunger += value;
        _enemyFillBar.fillAmount = Mathf.Min(1, _currentHunger / _hungerNeed);

        if (_currentHunger >= _hungerNeed)
        {
            OnDead();
        }
    }

    void OnDead()
    {
        _onScoreAdd.RaiseEvent(_score);
        Destroy(gameObject);
    }
}
