using System.Collections.Generic;
using Danil;
using Infastucture;
using Scary;
using UnityEngine;

public class CompsitionRoot : MonoBehaviour
{
    [SerializeField] private NoteSystem _noteSystem;
    [SerializeField] private ScarySystem _scarySystemObject;
    [SerializeField] private Player _playerObject;
    [SerializeField] private int _redEyeTimout;
    [SerializeField]private int _scaryWalkTimeout;

    private List<Timer> _timers;
    
    private IPlayerMove PlayerMove => _playerObject;
    private IMessageSystem NoteSystem => _noteSystem;
    private IScarySystem ScarySystem => _scarySystemObject;

    private void Awake() => 
        Compose();

    private void Update()
    {
        foreach (Timer timer in _timers) 
            timer.Tick(Time.deltaTime);
    }

    private void Compose()
    {
        NoteSystem.AllCollected += OnCollected;
        PlayerMove.Moved += OnPlayerMove;

        _redEyeTimout = 120;
        _scaryWalkTimeout = 600;
        _timers = new List<Timer>
        {
            new Timer(_redEyeTimout, ScarySystem.ShowRedEye),
            new Timer(_scaryWalkTimeout, ScarySystem.ScaryWalkAndScreamer)
        };
    }

    private void OnPlayerMove()
    {
        NoteSystem.OnPlayerMoved(PlayerMove.Position);
        print(1);
    }

    private void OnCollected()
    {
        PlayerMove.Freeze();
    }
}