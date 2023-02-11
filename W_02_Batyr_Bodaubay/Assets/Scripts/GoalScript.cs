using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalScript : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    private GameObject _ball;
    private Rigidbody _ballRB;
    private Vector3 vector3 = new Vector3(0, 0, 0);
    [SerializeField] private Scoring _scoring;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _ballRB = _ball.GetComponent<Rigidbody>();
        _agent = players[0].GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball"){
            StartCoroutine(Reset());
            _scoring.Goal(tag);
        }
    }

    
    IEnumerator Reset(){
        yield return new WaitForSeconds(0.3f);
        _ball.transform.SetPositionAndRotation(new Vector3(0, 0.5f, 0), new Quaternion());
        _ballRB.velocity = vector3;
        _ballRB.angularVelocity = vector3;
        players[0].transform.position = new Vector3(8, 1, 0);
        players[1].transform.position = new Vector3(-20, 1, 8);
        players[2].transform.position = new Vector3(-20, 1, -8);
        players[3].transform.position = new Vector3(-10, 1, 0);
        players[4].transform.position = new Vector3(20, 1, 8);
        players[5].transform.position = new Vector3(20, 1, -8);
        
        players[1].GetComponent<NavMeshAgent>().velocity=vector3;
        players[2].GetComponent<NavMeshAgent>().velocity=vector3;
        players[3].GetComponent<NavMeshAgent>().velocity=vector3;
        players[4].GetComponent<NavMeshAgent>().velocity=vector3;
        players[5].GetComponent<NavMeshAgent>().velocity=vector3;

        _agent.velocity = vector3;
        _agent.SetDestination(new Vector3(8, 1, 0));
        
    }
}
