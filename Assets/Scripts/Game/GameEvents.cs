using UnityEngine;
using UnityEngine.Events;
using System;

[CreateAssetMenu(fileName = "GameEvents", menuName = "Scriptable Objects/GameEvents", order = 0)]
public class GameEvents : ScriptableObject {
    public Action<EnemyController> onEnemyReachCollector;
    public Action<CandyController> onCandyReachCollector;
    public Action<EnemyController, PlayerManager> onEnemyHitPlayer;
    public Action<CandyController, PlayerManager> onCandyHitPlayer;
}