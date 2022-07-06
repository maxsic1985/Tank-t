using Pathfinding;
using UnityEngine;


public class ProtectorAIPresenter : MonoBehaviour, IProtector
{
    [SerializeField] private PlayerControls _playerView;
    [SerializeField] private ProtectorAiView _view;
    [SerializeField] private AIDestinationSetter _destinationSetter;
    [SerializeField] private AIPatrolPath _patrolPath;

    private PatrolAIModel _model;
    private bool _isPatrolling;

    private void Start()
    {
        _model = new PatrolAIModel(_view.Waypoints);
        _destinationSetter.target = _model.GetNextTarget();
        _isPatrolling = true;
        _patrolPath.TargetReached += OnTargetReached;

    }

    public void Deinit()
    {
        _patrolPath.TargetReached -= OnTargetReached;
    }

    private void OnTargetReached()
    {
        _destinationSetter.target = _isPatrolling
            ? _model.GetNextTarget()
            : _model.GetClosestTarget(_playerView.transform.position);
    }

    public void StartProtection(GameObject invader)
    {
        _isPatrolling = false;
        _destinationSetter.target = invader.transform;
    }

    public void FinishProtection(GameObject invader)
    {
        _isPatrolling = true;
        _destinationSetter.target = _model.GetClosestTarget(_playerView.transform.position);
    }

    private void OnDestroy()
    {
        Deinit();
    }
}
