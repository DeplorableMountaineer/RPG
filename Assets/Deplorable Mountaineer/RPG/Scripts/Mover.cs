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
                _lastRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            }

            Debug.DrawRay(_lastRay.origin, _lastRay.direction*100, Color.blue, 1);

            GetComponent<NavMeshAgent>().destination = target.position;
        }
    }
}