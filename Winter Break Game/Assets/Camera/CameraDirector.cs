using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Experimental.Rendering.Universal;

public class CameraDirector : MonoBehaviour
{
    [SerializeField] PixelPerfectCamera pixelPerfectSettings;

    [Header("FollowState")]
    [SerializeField, Range(0.01f, 1f)] float smoothSpeed;
    [SerializeField] Vector3 offset;

    StateMachine stateMachine;

    Transform target;
    public Transform GetTarget() => target;

    private void Start()
    {
        stateMachine = new StateMachine(new CameraFollowState(transform, this, smoothSpeed, offset), new CameraStationaryState(transform, this));

        CameraVolume.OnVolumeChanged += (transform, state) => ChangeCameraFocus(transform, state); 
    }

    public void OnDisable()
    {
        CameraVolume.OnVolumeChanged -= (transform, state) => ChangeCameraFocus(transform, state);
    }

    private void FixedUpdate()
    {
        stateMachine.InvokeCurrentState(); 
    }

    public void ChangeCameraFocus(Transform _target, CameraState state)
    {
        target = _target;

        switch (state)
        {
            case CameraState.Follow:
                stateMachine.SwitchState("CameraFollowState");
                break;

            case CameraState.Stationary:
                stateMachine.SwitchState("CameraStationaryState");
                break;
        }

        ChangeFov();
    }

    public async void MoveToPos(float speed)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        Vector3 startPos = transform.position;
        Vector3 moveToPos = new Vector3(target.position.x, target.position.y, -10);

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;
            percentComplete = percentComplete * Mathf.Sin(percentComplete);

            transform.position = Vector3.Lerp(startPos, moveToPos, percentComplete);

            await Task.Yield();
        }
    }

    public void ChangeFov()
    {
        pixelPerfectSettings.refResolutionX = (int)target.transform.localScale.x * 16;
    }

    public void ChangeFov(Vector2 fov)
    {
        pixelPerfectSettings.refResolutionX = (int)fov.x;
    }
    
}

public class CameraFollowState : IState
{
    Transform camHolder;
    CameraDirector director;

    float smoothSpeed;

    Vector3 offset;
    Vector3 velocity = Vector3.zero;

    public CameraFollowState(Transform _camHolder, CameraDirector _director, float _smoothSpeed, Vector3 _offset)
    {
        camHolder = _camHolder;

        director = _director;
        smoothSpeed = _smoothSpeed;

        offset = _offset;
    }

    public void OnEnter()
    {
      
    }

    public void WhileInState()
    {
       Vector3 targetPosition = director.GetTarget().position + offset;
       Vector3 smoothedPosition = Vector3.SmoothDamp(camHolder.transform.position, targetPosition, ref velocity, smoothSpeed);
       Vector3 desieredPosition = new Vector3(smoothedPosition.x, smoothedPosition.y, smoothedPosition.z);

       camHolder.transform.position = desieredPosition; 
    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {

    }
}


public class CameraStationaryState : IState
{
    Transform camHolder;
    CameraDirector director;

    public CameraStationaryState(Transform _camHolder, CameraDirector _director)
    {
        camHolder = _camHolder;
        director = _director;

    }

    public void OnEnter()
    {
        director.MoveToPos(.25f);
    }

    public void WhileInState()
    {

    }

    public void OnExit()
    {

    }

    public void Transition(StateMachine owner)
    {

    }

   
}

public enum CameraState
{
    Follow, Stationary
}
