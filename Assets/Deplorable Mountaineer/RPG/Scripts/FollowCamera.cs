using UnityEngine;

namespace Deplorable_Mountaineer.RPG {
    public class FollowCamera : MonoBehaviour {
        [SerializeField] private Transform target;
        [SerializeField] private float maxSpeed = 10;

        private Transform _transform;

        private void Reset(){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Awake(){
            _transform = transform;
        }

        private void LateUpdate(){
            if(!target) return;
            Vector3 position = _transform.position;
            position = Vector3.MoveTowards(position, target.position, maxSpeed*Time.deltaTime);
            _transform.position = position;
        }
    }
}