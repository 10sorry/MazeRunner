using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class level1 : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private bool _timerIsOn;
    [SerializeField] private float _timerValue;
    [SerializeField] private Text _timerView;

    [Header("Objects")]
    [SerializeField] private Player _player;
    [SerializeField] private Exit _exitFromLevel;
    
    [SerializeField] private bool isOnLevel1;
    [SerializeField] private bool isOnLevel4;
    
    
    private float _timer = 0;
    private bool _gameIsEnded = false;

    private void Awake()
    {
        _timer = _timerValue;
    }

    private void Start()
    {
        _exitFromLevel.Close();
    }

    private void Update()
    {
        if(_gameIsEnded)
            return;
        
        TimerTick();
        LookAtPlayerHealth();
        LookAtPlayerInventory();
        TryCompleteLevel();
    }

    private void TimerTick()
    {
        if(_timerIsOn == false)
            return;
        
        _timer -= Time.deltaTime;
        _timerView.text = $"{_timer:F1}";
        
        if(_timer <= 0)
            Lose();
    }

    private void TryCompleteLevel()
    {
        if(_exitFromLevel.IsOpen == false)
            return;

        var flatExitPosition = new Vector2(_exitFromLevel.transform.position.x, _exitFromLevel.transform.position.z);
        var flatPlayerPosition = new Vector2(_player.transform.position.x, _player.transform.position.z);
        
        if(flatExitPosition == flatPlayerPosition)
            Victory();
    }
    
    private void LookAtPlayerHealth()
    {
        if(_player.IsAlive)
            return;

        Lose();
    }

    private void LookAtPlayerInventory()
    {
        if(_player.HasKey)
            _exitFromLevel.Open();
    }

    public void Victory()
    {
        _gameIsEnded = true;
        _player.Disable();
        if(isOnLevel1)
            SceneManager.LoadScene("level 2");
        if(isOnLevel4)
            SceneManager.LoadScene("victory");
        Debug.LogError("Victory");
    }
    
    public void Lose()
    {
        _gameIsEnded = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
