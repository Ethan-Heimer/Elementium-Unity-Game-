using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnCharacterUpdate{void OnCharacterUpdate();}

public interface IOnCharacterFixedUpdate{void OnCharacterFixedUpdate();} 

public interface IOnCharacterStart{void OnCharacterStart();}

//damage Manager
public interface IOnCharacterDamaged { void OnCharacterDamaged(float damage, GameObject damager); }

//health manager
public interface IOnCharacterHealthChanged {void OnCharacterHealthChanged(float health);}
public interface IOnCharacterHealthAdded {void OnCharacterHealthAdded(float health);}
public interface IOnCharacterHealthSubtracted {void OnCharacterHealthSubtracted(float health);}
public interface IOnCharacterHealthSet {void OnCharacterHealthSet(float health);}

public interface IOnCharacterKilled { void OnCharacterKilled(); }

//weapon manager
public interface IOnCharacterAttack{void OnCharacterAttack();}



