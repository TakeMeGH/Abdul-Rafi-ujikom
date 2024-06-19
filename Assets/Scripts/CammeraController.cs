using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraController : MonoBehaviour
{
    Animator _animator;
    [SerializeField] VoidEventChannel _onGameFinished;

    private void OnEnable()
    {
        _onGameFinished.OnEventRaised += OnFinish;
    }
    private void OnDisable()
    {
        _onGameFinished.OnEventRaised -= OnFinish;

    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnFinish()
    {
        _animator.Play("GameOver");
    }
}
