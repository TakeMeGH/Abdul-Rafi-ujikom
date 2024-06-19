using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _score;
    [SerializeField] float _timer;
    [SerializeField] TMP_Text _timerText;
    [SerializeField] TMP_Text _scoreText;
    [SerializeField] IntEventChannel _onScoreInc;
    [SerializeField] VoidEventChannel _onGameFinished;
    [SerializeField] GameObject GameOverUI;
    bool isEnded = false;

    private void OnEnable()
    {
        _onScoreInc.OnEventRaised += UpdateScore;
    }
    private void OnDisable()
    {
        _onScoreInc.OnEventRaised -= UpdateScore;
    }
    void Start()
    {

    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        if (isEnded) return;

        _timer -= Time.deltaTime;
        if (_timer <= 0) _timer = 0;

        _timerText.text = "Timer: " + (int)_timer;

        if (isEnded == false && _timer <= 0)
        {
            isEnded = true;
            _onGameFinished.RaiseEvent();
            GameOverUI.SetActive(true);
        }
    }

    void UpdateScore(int val)
    {
        _score += val;
        _scoreText.text = "Score: " + _score;
    }
}
