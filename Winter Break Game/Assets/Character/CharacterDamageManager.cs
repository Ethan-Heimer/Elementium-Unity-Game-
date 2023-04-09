using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Reflection;
using System.Linq;

public class CharacterDamageManager
{
    event Action<Character> OnDamaged;
    event Action<Character> OnDeath;

    Character character;

    CharacterDamageCheckerInterfacer damageChecker;
    CharacterDamageHandlerInterfacer damageHandler;

    public CharacterDamageManager() { }

    public CharacterDamageManager(Character _character, CharacterDamageCheckerInterfacer _damageChecker, CharacterDamageHandlerInterfacer _damageHandler)
    {
        character = _character;

        damageChecker = _damageChecker;
        damageHandler = _damageHandler;
    }

    bool damaged;
    public void Tick()
    {
        damaged = damageChecker.CheckDamage();

        if (damaged)
        {
            damageHandler.OnDamaged();
            OnDamaged?.Invoke(character);
        }
    }

    public async void KillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke(character);

        await Task.Delay(500);

        GameObject.Destroy(character.gameObject);
    }

    public void SilentlyKillCharacter()
    {
        character.DisableCharacter(true);

        character.PauseExecution(true);
        OnDeath?.Invoke(character);
    }

    public CharacterEvent[] GetEvents()
    {
        EventInfo[] events = this.GetType().GetEvents(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.EventHandlerType == typeof(Action<Character>)).ToArray();
        List<CharacterEvent> cEvents = new List<CharacterEvent>();

        foreach (EventInfo e in events)
        {
            CharacterEvent cEvent = new CharacterEvent(e.Name);
            cEvents.Add(cEvent);

            MethodInfo invokeEvent = cEvent.GetType().GetMethod("Invoke", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            Delegate eventInvoker = Delegate.CreateDelegate(e.EventHandlerType, cEvent, invokeEvent);

            var addMethod = e.GetAddMethod(true);
            addMethod.Invoke(this, new[] { eventInvoker });
        }

        return cEvents.ToArray();
    }
}
