
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using KnightAdventure.Utils;
using System;

public class EnemyAI : MonoBehaviour
{
    private Animator animator;


    [SerializeField] private State _startingState;
    // [SerializeField] private float _roamingDistanceMax = 7f;
    // [SerializeField] private float _roamimgDistanceMin = 3f;
    // [SerializeField] private float _roamimgTimerMax = 2f;

    [SerializeField] private bool _isChasingEnemy = false;
    [SerializeField] private float _chasingDistance = 4f;
    [SerializeField] private float _chasingSpeedMultiplier = 2f;

    // [SerializeField] private bool _isAttackingEnemy = false;
    // [SerializeField] private float _attackingDistance = 2f;
    // [SerializeField] private float _attackRate = 2f;
    // private float _nextAttackTime = 0f;

    private NavMeshAgent _navMeshAgent;
    private State _currentState;
    // private float _roamingTimer;
    private Vector3 _roamPosition;
    private Vector3 _startingPosition;

    private float _roamingSpeed;
    private float _chasingSpeed;

    private float _nextCheckDirectionTime = 0f;
    private float _checkDirectionDuration = 0.1f;
    private Vector3 _lastPosition;

    // public event EventHandler OnEnemyAttack;

    public GameObject playerObject;
    public Vector3 playerPosition;

    public List<Vector3> roamingPoints;
    private int roamingCurrentIndex = 0;
    void Start()
    {

    }

    public bool IsRunning
    {
        get
        {
            if (_navMeshAgent.velocity == Vector3.zero)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }


    private enum State
    {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Death
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _currentState = _startingState;

        _roamingSpeed = _navMeshAgent.speed;
        _chasingSpeed = _navMeshAgent.speed * _chasingSpeedMultiplier;
    }


    private void Update()
    {

        if (playerObject != null){
            playerPosition = playerObject.transform.position;
        }
        StateHandler();
        MovementDirectionHandler();
    }


    private void StateHandler()
    {
        switch (_currentState)
        {
            case State.Roaming:
                Roaming();
                CheckCurrentState();
                break;
            case State.Chasing:
                ChasingTarget();
                CheckCurrentState();
                break;
            default:
            case State.Idle:
                break;
        }
    }

    private void ChasingTarget()
    {
        _navMeshAgent.SetDestination(playerPosition);
    }

    public float GetRoamingAnimationSpeed()
    {
        return _navMeshAgent.speed / _roamingSpeed;
    }

    private void CheckCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        State newState = State.Roaming;

        if (_isChasingEnemy)
        {
            if (distanceToPlayer <= _chasingDistance)
            {
                newState = State.Chasing;
            }
        }
        if (newState != _currentState)
        {
            if (newState == State.Chasing)
            {
                _navMeshAgent.ResetPath();
                _navMeshAgent.speed = _chasingSpeed;
            }
            else if (newState == State.Roaming)
            {
                // _roamingTimer = 0f;
                _navMeshAgent.speed = _roamingSpeed;
            }
            else if (newState == State.Attacking)
            {
                _navMeshAgent.ResetPath();
            }

            _currentState = newState;
        }
    }


    private void MovementDirectionHandler()
    {
        if (Time.time > _nextCheckDirectionTime)
        {


            _lastPosition = transform.position;
            _nextCheckDirectionTime = Time.time + _checkDirectionDuration;
        }
    }


    private void Roaming()
    {
        // _startingPosition = transform.position;
        

        int nextRoamingIndex = (roamingCurrentIndex + 1) % roamingPoints.Count;
        if (Math.Abs(transform.position.x - roamingPoints[nextRoamingIndex].x )< 5 && Math.Abs(transform.position.y - roamingPoints[nextRoamingIndex].y )< 5) {
            // дошел до точки
            _roamPosition = GetRoamingPosition();
        }
        _navMeshAgent.SetDestination(_roamPosition);
    }



    private Vector3 GetRoamingPosition()
    {
        // return _startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(_roamimgDistanceMin, _roamingDistanceMax);
        Vector3 result = roamingPoints[roamingCurrentIndex];
        roamingCurrentIndex = (roamingCurrentIndex + 1) % roamingPoints.Count;
        return result;
    }


}
