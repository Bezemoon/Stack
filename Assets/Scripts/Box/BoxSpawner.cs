using System;
using Extensions;
using Scripts;
using Slicers;
using UnityEngine;

namespace Boxes
{
    public class BoxSpawner : MonoBehaviour
    {
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private Box _baseBox;
        [SerializeField] private Point[] _spawnPoints;

        private int _currentIndex;
        private Box _previousBox;
        private Box _currentBox;
        private Slicer _slicer;
        private ColorChanger _colorChanger;

        private readonly float _stepLift = 0.5f;

        public Box CurrentBox => _currentBox;

        public event Action<Box> CameraMoved;

        private void OnEnable()
        {
            BoxInput.Instance.BoxSpawned += OnSpawn;
        }

        private void OnDisable()
        {
            BoxInput.Instance.BoxSpawned -= OnSpawn;
        }

        private void Start()
        {
            _colorChanger = new ColorChanger();
            _baseBox.Material.color = _colorChanger.GetColor();
            SpawnBox(_boxPrefab);
        }

        private void OnSpawn()
        {
            _slicer = new Slicer();
            _slicer.Slice(_currentBox, _previousBox);
            _currentBox.gameObject.SetActive(false);

            if (_slicer.InsideSlice == null)
            {
                SpawnSlice(_slicer.OutsideSlice, false);
                BoxInput.Instance.BoxSpawned -= OnSpawn;
                return;
            }

            if (_slicer.OutsideSlice != null)
                SpawnSlice(_slicer.OutsideSlice, false);
            
            SpawnBox(SpawnSlice(_slicer.InsideSlice, true));
        }

        private Box SpawnSlice(Slice slice, bool isKinematic)
        {
            var sliceBox = Instantiate(_boxPrefab, slice.SlicePosition, Quaternion.identity);
            sliceBox.Init(slice.SliceColor, isKinematic);
            sliceBox.BoxMovement.enabled = false;
            sliceBox.Transform.Resize(slice.SliceScale);
            
            return sliceBox;
        }

        private void SpawnBox(Box currentBox)
        {
            _previousBox = currentBox;
            _currentBox = Instantiate(_previousBox, GetSpawnPoint(), Quaternion.identity);
            _currentBox.Init(_colorChanger.GetColor(), true);
            _currentBox.BoxMovement.enabled = true;

            IncreaseIndex();
            Lift();
            CameraMoved?.Invoke(_currentBox);
        }

        private Vector3 GetSpawnPoint()
        {
            var spawnPointPosition = _spawnPoints[_currentIndex].transform.position;
            spawnPointPosition.x += _previousBox.Transform.position.x;
            spawnPointPosition.z += _previousBox.Transform.position.z;

            return spawnPointPosition;
        }

        private void IncreaseIndex()
        {
            _currentIndex++;

            if (_currentIndex >= _spawnPoints.Length)
                _currentIndex = 0;
        }

        private void Lift()
        {
            transform.position += Vector3.up * _stepLift;
        }
    }
}

