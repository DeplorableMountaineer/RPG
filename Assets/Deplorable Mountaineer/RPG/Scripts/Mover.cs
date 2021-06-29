using UnityEngine;
using UnityEngine.AI;

namespace Deplorable_Mountaineer.RPG {
    public class Mover : MonoBehaviour {
        [SerializeField] private Transform target;

        private void Update(){
            GetComponent<NavMeshAgent>().destination = target.position;
        }
    }
}