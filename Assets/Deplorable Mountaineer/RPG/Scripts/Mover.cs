using UnityEngine;
using UnityEngine.AI;

namespace Deplorable_Mountaineer.RPG {
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour {
        private Camera _mainCamera;
        private NavMeshAgent _navMeshAgent;

        private void Awake(){
            _mainCamera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update(){
            if(Input.GetMouseButtonDown(0)){
                MoveToCursor();
            }
        }

        private void MoveToCursor(){
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if(hasHit) _navMeshAgent.destination = hit.point;
        }
    }
}