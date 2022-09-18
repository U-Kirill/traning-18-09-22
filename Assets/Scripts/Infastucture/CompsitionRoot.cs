using Danil;
using Infastucture;
using UnityEngine;

public class CompsitionRoot : MonoBehaviour
{
    [SerializeField] private NoteSystem _noteSystem;
    [SerializeField] private Player _player;
    private IPlayerMove _playerMove => _player;
    private IMessageSystem _messageSystem => _noteSystem;

    private void Awake()
    {
        Compose();
    }

    private void Compose()
    {
        _messageSystem.AllCollected += OnCollected;
        _playerMove.Moved += OnPlayerMove;
    }

    private void OnPlayerMove()
    {
        _messageSystem.OnPlayerMoved(_playerMove.Position);
    }

    private void OnCollected()
    {
        _playerMove.Freeze();
    }
}
