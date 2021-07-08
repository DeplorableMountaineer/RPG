using UnityEngine;
using UnityEngine.AI;

namespace Deplorable_Mountaineer.RPG {
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour {
        private static readonly int ForwardSpeed = Animator.StringToHash("ForwardSpeed");

        private Camera _mainCamera;
        private NavMeshAgent _navMeshAgent;
        private Transform _transform;
        private Animator _animator;

        private void Awake(){
            _transform = transform;
            _mainCamera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void Update(){
            if(Input.GetMouseButton(0)){
                MoveToCursor();
            }

            UpdateAnimator();
        }

        private void UpdateAnimator(){
            float forwardSpeed = Vector3.Dot(_navMeshAgent.velocity, _transform.forward);
            _animator.SetFloat(ForwardSpeed, forwardSpeed);
        }

        private void MoveToCursor(){
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if(hasHit) _navMeshAgent.destination = hit.point;
        }
    }
}