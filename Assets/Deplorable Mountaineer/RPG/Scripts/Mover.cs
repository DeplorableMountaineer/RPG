using UnityEngine;
using UnityEngine.AI;

namespace Deplorable_Mountaineer.RPG {
    public class Mover : MonoBehaviour {
        [SerializeField] private Transform target;

        private Ray _lastRay;
        private Camera _mainCamera;

        private void Awake(){
            _mainCamera = Camera.main;
        }

        private void Update(){
            if(Input.GetMouseButtonDown(0)){
                MoveToCursor();
            }
        }

        private void MoveToCursor(){
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            bool hasHit = Physics.Raycast(ray, out RaycastHit hit);
            if(hasHit) GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}