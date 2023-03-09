using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; 

public class Elemite : MonoBehaviour
{
    StateMachine stateMachiene = new StateMachine();

    public ElementRayData representedRay; 

    public ElemitePositionHandler PositionHandler; 
    public ElemiteDirectionManager DirectionManager;
    public ElemiteVisualsHandler VisualsHandler;
  
    bool _selected;
    public bool selected
    {
        get
        {
            return _selected;
        }

        set
        {
            if (value is true)
            {
                stateMachiene.SwitchState("SelectedState");
            }
            else
            {
                stateMachiene.SwitchState("FollowState");
            }

            _selected = value;
        }
    }

    public void Init(Character _target, int _delay, ElementRayData _elementRayData)
    {
        PositionHandler = new ElemitePositionHandler(this, _target.transform, _delay);

        DirectionManager = new ElemiteDirectionManager(this, _target);
        VisualsHandler = new ElemiteVisualsHandler(GetComponent<SpriteRenderer>());

        stateMachiene = new StateMachine(new FollowState(this), new SelectedState(this));
        stateMachiene.SwitchState("FollowState");

        transform.SetParent(_target.transform);

        representedRay = _elementRayData; 
    }

    void Update()
    {
        if (selected)
            Tick();
    }

    void FixedUpdate()
    {
        if (!selected)
            Tick();
    }

    public void Select(bool value) => selected = value;  

    void Tick()
    {
        stateMachiene.InvokeCurrentState();
        PositionHandler.RecordPosition();

        VisualsHandler.FlipSprite(DirectionManager.GetDirection() == -1); 
    }
}

public class ElemitePositionHandler
{
    PositionRecorder recorder;
    Elemite elemite;

    Transform target;
    float delay; 
    public ElemitePositionHandler(Elemite _elemite, Transform character, float _delay)
    {
        target = character;
        delay = _delay; 
        recorder = new PositionRecorder(target, delay);
        elemite = _elemite; 
    }

    public void UpdatePosition()
    {
        elemite.transform.position = new Vector3(recorder.GetLastPos().x, recorder.GetLastPos().y - GetYOffset(Time.time));
    }

    public void CopyCharacterPosition()
    {
        elemite.transform.position = new Vector3(target.position.x, target.position.y + .6f);
    }

    public void RecordPosition()
    {
        recorder.Record(); 
    }
    public async Task MoveToCurrentPosition(float speed)
    {
        await MoveToPosition(speed, recorder.GetLastPos());
    }

    public async Task MoveToCharacterPosition(float speed)
    {
        await MoveToPosition(speed, target);
    }

    async Task MoveToPosition(float time, Vector3 position)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        Vector3 startPos = elemite.transform.position;

        await Task.Yield();

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / time;

            elemite.transform.position = Vector3.Lerp(startPos, position, percentComplete);

            await Task.Yield();
        }
    }
    async Task MoveToPosition(float time, Transform transform)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        Vector3 startPos = elemite.transform.position;

        await Task.Yield();

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / time;

            elemite.transform.position = Vector3.Lerp(startPos, transform.position, percentComplete);

            await Task.Yield();
        }
    }

    float GetYOffset(float x) => Mathf.Sin(x*4 + delay) * .25f;
}

public class PositionRecorder
{
   
    Queue<Vector2> positions = new Queue<Vector2>();
    Vector3 latestPos;

    Transform target;
    float delay;

    public PositionRecorder(Transform _target, float _delay)
    {
        target = _target;
        delay = _delay; 
    }
   
    public void Record()
    {
        positions.Enqueue(target.position);

        if (positions.Count > delay)
        {
            latestPos = positions.Dequeue();
        }
    }

    public Vector3 GetLastPos()
    {
        if(latestPos != Vector3.zero)
        {
            return latestPos; 
        }
        else
        {
            return target.position; 
        }
    }
}

public class ElemiteDirectionManager
{
    ICharacterDirectionHandler directionHandler;
    ICharacterInputHandler characterInputHandler; 

    IElementRayInputProvider rayInputHandler; 

    Elemite elemite; 

    public ElemiteDirectionManager(Elemite _elemite, Character _character)
    {
        elemite = _elemite;

        rayInputHandler = GameObject.FindGameObjectWithTag("Ray").GetComponent<ElementRay>().input; 

        directionHandler = _character.directionHandler;
        characterInputHandler = _character.input; 

    }

    public int GetDirection()
    {
        if (elemite.selected && characterInputHandler.GetActionInput())
        {
            if(rayInputHandler.GetAimVector().x > 0)
            {
                return 1; 
            }
            else
            {
                return -1; 
            }
        }
        else
        {
            return directionHandler.GetCurrentDirection(); 
        }
    }
    
}

public class ElemiteVisualsHandler
{
    SpriteRenderer renderer;
    public ElemiteVisualsHandler(SpriteRenderer _renderer)
    {
        renderer = _renderer;
    }

    public void FlipSprite(bool flip)
    {
        renderer.flipX = flip;
    }
}

public class FollowState : IState
{
    Elemite elemite; 
    bool inSpot = false; 

    public FollowState(Elemite _elemite)
    {
        elemite = _elemite; 
    }

       
    public async void OnEnter() 
    {
        await elemite.PositionHandler.MoveToCurrentPosition(.1f);
        inSpot = true; 
    }
    public void WhileInState() 
    {
        if (inSpot)
            elemite.PositionHandler.UpdatePosition(); 
    }

    public void OnExit() 
    {
        inSpot = false;
    }

    public void Transition(StateMachine owner) { }
}

public class SelectedState : IState
{
    Elemite elemite;

    bool inSpot = false; 

    public SelectedState(Elemite _elemite)
    {
        elemite = _elemite;
    }

    public async void OnEnter() 
    {
        await elemite.PositionHandler.MoveToCharacterPosition(.1f);
        inSpot = true; 
    }
    public void WhileInState()
    {
        if (inSpot)
            elemite.PositionHandler.CopyCharacterPosition(); 
    }

    public void OnExit() 
    {
        inSpot = false; 
    }
    public void Transition(StateMachine owner) { }
}
