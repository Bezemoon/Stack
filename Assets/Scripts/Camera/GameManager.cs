using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Cutter _cutter;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Player _player;

    private Block _currentBlock;
    private Block _previousBlock;

    public Block CurrentBlock => _currentBlock;

    private void Start()
    {
        _previousBlock = _blockPrefab;
        _currentBlock = _spawner.CreateSpawn(_previousBlock);
    }

    private void Update()
    {
        if (_currentBlock.GetComponent<BlockMovement>().CurrentSpeed == 0)
        {
            _cutter.Cut(_previousBlock, _currentBlock);
            Respawn();
            _player.IncreaseScore();
        }
    }

    private void Respawn()
    {
        ChangeParametersPreviousBlock();
        _currentBlock = _spawner.CreateSpawn(_previousBlock);
        _currentBlock.Material.color = _colorChanger.CreateNewColor();
    }

    private void ChangeParametersPreviousBlock()
    {
        _previousBlock = _currentBlock;
    }
}
