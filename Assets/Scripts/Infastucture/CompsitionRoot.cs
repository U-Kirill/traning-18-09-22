using System.Collections.Generic;
using Danil;
using Infastucture;
using Scary;
using UnityEngine;

public class CompsitionRoot : MonoBehaviour
{
    [SerializeField] private NoteSystem _noteSystem;
    [SerializeField] private ScarySystem _scarySystem;
    [SerializeField] private Player _player;
    [SerializeField] private int _redEyeTimout;
    [SerializeField]private int _scaryWalkTimeout;

    private List<Timer> _timers;
    
    private IPlayerMove PlayerMove => _player;
    private IMessageSystem NoteSystem => _noteSystem;
    private IScarySystem ScarySystem => _scarySystem;

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
    }

    private void OnCollected()
    {
        PlayerMove.Freeze();
    }
}