using Danil;
using UnityEngine;

public class CompsitionRoot : MonoBehaviour
{
    [SerializeField] private NoteSystem _noteSystem;

    private IPlayerMove _playerMove;
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
