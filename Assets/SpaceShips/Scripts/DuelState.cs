using System;
using SpaceShips.AI;
using SpaceShips.Ships;
using SpaceShips.UI;
using UnityEngine;

namespace SpaceShips
{
    internal class DuelState : MonoBehaviour
    {
        private IMultilineDialogue _dialogue;
        private Game _game;

        internal void Construct(IShipStructure constructTimeShipA, IShipStructure constructTimeShipB, IMultilineDialogue dialogue, Game game)
        {
            _dialogue = dialogue;
            _game = game;
            var runtimeShipA = new Ship(constructTimeShipA);
            var runtimeShipB = new Ship(constructTimeShipB);

            var shipATask = new DestroyTargetTask(ship: runtimeShipA, target: runtimeShipB);
            var shipBTask = new DestroyTargetTask(ship: runtimeShipB, target: runtimeShipA);

            shipATask.OnCompleted += () => OnShipDestroyed("B");
            shipBTask.OnCompleted += () => OnShipDestroyed("A");
        }

        private void OnShipDestroyed(string shipName)
        {
            var restartCommand = new ValueTuple<string, Action>("Restart", () => _game.Restart());
            
            _dialogue.Show(
                $"Ship {shipName} is destroyed", 
                restartCommand);
        }
    }
}