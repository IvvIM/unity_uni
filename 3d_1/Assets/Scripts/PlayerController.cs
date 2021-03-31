using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Camera _cam;
    private bool _leftPointerClicked;
    private Animator _playerAnimator;

    private void Start()
    {
        _cam = Camera.main;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        _leftPointerClicked = Input.GetButton("Fire1");
    }

    private void FixedUpdate()
    {
        if(_leftPointerClicked)
        {
            RaycastHit hitInfo;
            if(Physics.Raycast(_cam.ScreenPointToRay(Input.mousePosition), out hitInfo, 5000))
            {
                _navMeshAgent.destination = hitInfo.point;
                _playerAnimator.SetBool("Run", true);
            }
        }

        if(Vector3.Distance(transform.position, _navMeshAgent.destination) <= _navMeshAgent.stoppingDistance
            && _playerAnimator.GetBool("Run"))
        {
            _playerAnimator.SetBool("Run", false);
            _navMeshAgent.destination = transform.position;
        }
    }


}
