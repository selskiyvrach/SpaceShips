using System;
using SpaceShips.Repository;
using SpaceShips.Ships;
using SpaceShips.UI;
using UnityEngine;

namespace SpaceShips
{
    internal class ConstructionState : MonoBehaviour
    {
        [SerializeField] private ShipFactory _shipAFactory;
        [SerializeField] private ShipFactory _shipBFactory;
        [SerializeField] private AttachablesRepository _attachablesRepo;
        [SerializeField] private Transform _shipASpawnPoint;
        [SerializeField] private Transform _shipBSpawnPoint;
        
        internal async void Construct(Game game, IMultilineDialogue dialogue)
        {
            var shipA = _shipAFactory.Create(_attachablesRepo, _shipASpawnPoint);
            var shipB = _shipBFactory.Create(_attachablesRepo, _shipBSpawnPoint);

            await shipA.ConstructAsync(dialogue);
            await shipB.ConstructAsync(dialogue);
            
            var startDuelCommand = new ValueTuple<string, Action>(
                "Start duel (check console for the details)", 
                () => game.GoToDuelState(shipA.Model, shipB.Model));
            dialogue.Show("Everything is ready", startDuelCommand);
        }
    }
}