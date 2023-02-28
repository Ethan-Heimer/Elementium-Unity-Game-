using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using System.Linq;
using UnityEngine.Events; 

[CreateAssetMenu]
public class CharacterConfig : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] List<PossableUseableComponent> statHandlers = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> inputs = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> groundStatuses = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> wallStatuses = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> directionHandlers = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> physicsHandlers = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> climbStatuses = new List<PossableUseableComponent>();
    [SerializeField] List<PossableUseableComponent> movementHandlers = new List<PossableUseableComponent>();

    [Header("Damage")]
    [SerializeField] List<PossableUseableComponent> damageCheckers = new List<PossableUseableComponent>(); 
    [SerializeField] List<PossableUseableComponent> damageHandlers = new List<PossableUseableComponent>();

    [Header("Action Handler")]
    [SerializeField] List<PossableUseableComponent> actionHandlers = new List<PossableUseableComponent>();


    [Header("Movement")]
    [SerializeReference] public ICharacterStatsHandler statsHandler; 
    [SerializeReference] public ICharacterInputHandler input;
    [SerializeReference] public ICharacterGroundStatusProvider groundStatus;
    [SerializeReference] public IChararacterWallStatusProvider wallStatus;
    [SerializeReference] public ICharacterDirectionHandler directionHandler;
    [SerializeReference] public ICharacterPhysicsHandler physicsHandler;
    [SerializeReference] public ICharacterClimbStatusProvider climbStatus;
    [SerializeReference] public ICharacterMovementHandler movementHandler; 

    [Header("Damage")]
    [SerializeReference] public ICharacterDamageChecker damageChecker;
    [SerializeReference] public ICharacterDamageHandler damageHandler;

    [Header("Action Handler")]
    [SerializeReference] ICharacterActionHandler actionHandler; 

    public void Awake()
    {
        UpdateLists();
        UpdateInspector();

        statsHandler?.InitAllValues();
    }

    public void OnValidate()
    {
        //UpdateLists(); 
        UpdateInspector();

        statsHandler?.InitAllValues();
    }

    [ContextMenu("Reload Lists")]
    private void UpdateLists()
    {
        UpdateList(GetPossableClases<ICharacterStatsHandler>(), statHandlers);
        UpdateList(GetPossableClases<ICharacterInputHandler>(), inputs);
        UpdateList(GetPossableClases<ICharacterGroundStatusProvider>(), groundStatuses);
        UpdateList(GetPossableClases<IChararacterWallStatusProvider>(), wallStatuses);
        UpdateList(GetPossableClases<ICharacterDirectionHandler>(), directionHandlers);
        UpdateList(GetPossableClases<ICharacterPhysicsHandler>(), physicsHandlers);
        UpdateList(GetPossableClases<ICharacterClimbStatusProvider>(), climbStatuses);
        UpdateList(GetPossableClases<ICharacterDamageChecker>(), damageCheckers);
        UpdateList(GetPossableClases<ICharacterDamageHandler>(), damageHandlers);

        UpdateList(GetPossableClases<ICharacterActionHandler>(), actionHandlers);
        UpdateList(GetPossableClases<ICharacterMovementHandler>(), movementHandlers); 
    }

    private void UpdateInspector()
    {
        UpdateRefrences<ICharacterStatsHandler>(ref statsHandler, statHandlers);
        UpdateRefrences<ICharacterInputHandler>(ref input, inputs);
        UpdateRefrences<ICharacterGroundStatusProvider>(ref groundStatus, groundStatuses);
        UpdateRefrences<IChararacterWallStatusProvider>(ref wallStatus, wallStatuses);
        UpdateRefrences<ICharacterDirectionHandler>(ref directionHandler, directionHandlers);
        UpdateRefrences<ICharacterPhysicsHandler>(ref physicsHandler, physicsHandlers);
        UpdateRefrences<ICharacterClimbStatusProvider>(ref climbStatus, climbStatuses);
        UpdateRefrences<ICharacterDamageChecker>(ref damageChecker, damageCheckers);
        UpdateRefrences<ICharacterDamageHandler>(ref damageHandler, damageHandlers);

        UpdateRefrences<ICharacterActionHandler>(ref actionHandler, actionHandlers);
        UpdateRefrences<ICharacterMovementHandler>(ref movementHandler, movementHandlers); 
    }
    public ICharacterStatsHandler GetStatsHandler() => statsHandler.Clone() as ICharacterStatsHandler;
    public ICharacterInputHandler GetInputHandler() => input.Clone() as ICharacterInputHandler;
    public ICharacterGroundStatusProvider GetGroundHandler() => groundStatus.Clone() as ICharacterGroundStatusProvider;
    public IChararacterWallStatusProvider GetWallProvider() => wallStatus.Clone() as IChararacterWallStatusProvider;     
    public ICharacterDirectionHandler GetDirectionHandler() => directionHandler.Clone() as ICharacterDirectionHandler;
    public ICharacterPhysicsHandler GetPhysicsHandler() => physicsHandler.Clone() as ICharacterPhysicsHandler;
    public ICharacterClimbStatusProvider GetClimbHandler() => climbStatus.Clone() as ICharacterClimbStatusProvider;
    public ICharacterDamageChecker GetDamageChecker() => damageChecker.Clone() as ICharacterDamageChecker;
    public ICharacterDamageHandler GetDamageHandler() => damageHandler.Clone() as ICharacterDamageHandler;
    public ICharacterActionHandler GetActionHandler() => actionHandler.Clone() as ICharacterActionHandler; 
    public ICharacterMovementHandler GetMovementHandler() => movementHandler.Clone() as ICharacterMovementHandler; 

    string GetSelectedName(List<PossableUseableComponent> list) => list.First(x => x.use).name;
    List<string> GetPossableClases<T>() => AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(x => x.Name).ToList();
    void UpdateList(List<string> foundItems, List<PossableUseableComponent> list)
    {
        foreach (string o in foundItems)
        {
            if (list.FindAll(x => x.name == o).Count == 0)
            {
                PossableUseableComponent item = new PossableUseableComponent
                {
                    name = o,
                    use = list.Count == 0
                };

                list.Add(item);
            }
        }
    }
    bool CompareClassNames(string classOne, string classTwo) => classOne == classTwo; 
    object GetClassRefence(string name)
    {
        Type t = Type.GetType(name);
        return Activator.CreateInstance(t, this); 
    }
    void UpdateRefrences<T>(ref T refrence, List<PossableUseableComponent> list) where T : class
    {
        if (refrence is null || !CompareClassNames(refrence.GetType().Name, GetSelectedName(list)))
        { 
           refrence = GetClassRefence(list.Find(x => x.use).name) as T;
        }     
    }
}

[System.Serializable]
internal struct PossableUseableComponent
{
    public string name;
    public bool use; 
}