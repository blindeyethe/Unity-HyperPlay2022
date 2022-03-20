using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float laneDistance = 2.5f;//The distance between tow lanes
    
    private Transform _transform;
    private CharacterController _controller;
    private Animator _animator;

    private Vector3 _move;
    private int _desiredLane = 1; //0:left, 1:middle, 2:right
    private bool _toggle;

    private void Awake()
    {
        _transform = transform;
        _controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    private void FixedUpdate()
    {
        //Increase Speed
        if (_toggle)
        {
            _toggle = false;
            if (forwardSpeed < maxSpeed)
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
        }
        else
        {
            _toggle = true;
            if (Time.timeScale < 2f)
                Time.timeScale += 0.005f * Time.fixedDeltaTime;
        }
    }

    private void Update()
    {
        _move.z = forwardSpeed;

        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight)
        {
            _desiredLane++;
            if (_desiredLane == 3)
                _desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            _desiredLane--;
            if (_desiredLane == -1)
                _desiredLane = 0;
        }

        //Calculate where we should be in the future
        var position = _transform.position;
        var targetPosition = position.z * _transform.forward + position.y * _transform.up;
            
        switch (_desiredLane)
        {
            case 0:
                targetPosition += Vector3.left * laneDistance;
                break;
            
            case 2:
                targetPosition += Vector3.right * laneDistance;
                break;
        }

        if (_transform.position != targetPosition)
        {
            var diff = targetPosition - _transform.position;
            var moveDir = diff.normalized * 30 * Time.deltaTime;

            _controller.Move(moveDir.sqrMagnitude < diff.magnitude ? moveDir : diff);
        }

        _controller.Move(_move * Time.deltaTime);
    }
}