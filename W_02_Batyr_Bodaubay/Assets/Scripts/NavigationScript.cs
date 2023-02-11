using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    
    [SerializeField] private GameObject targetObject;
    private NavMeshAgent _agent;
    private Vector3 _currentTarget;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit)){
                _currentTarget = hit.point;
            }
        }
        if(tag == "Player"){
            _agent.SetDestination(_currentTarget);
        }else{
            _agent.SetDestination(targetObject.transform.position);
        }
        
        
    }
}
