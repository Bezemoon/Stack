using UnityEngine;

namespace Boxes
{
    [RequireComponent(typeof(BoxMovement), typeof(Rigidbody))]
    public class Box : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private MeshRenderer _renderer;
        
        private BoxMovement _boxMovement;
        private Rigidbody _rigidbody;

        public BoxMovement BoxMovement => _boxMovement;
        public Rigidbody Rigidbody => _rigidbody;
        public Transform Transform => _transform;
        public Material Material => _renderer.material;

        private void Awake()
        {
            _boxMovement = GetComponent<BoxMovement>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Init(Color color, bool isKimenatic)
        {
            Material.color = color;
            _rigidbody.isKinematic = isKimenatic;
        }
    }
}