using SpaceShips.Ships;
using SpaceShips.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShips
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private MultilineDialogue _dialogue;
        [SerializeField] private ConstructionState _constructionState;
        [SerializeField] private DuelState _duelState;

        private void Start() => 
            _constructionState.Construct(this, _dialogue);

        internal void GoToDuelState(IShipStructure shipA, IShipStructure shipB) => 
            _duelState.Construct(shipA, shipB, _dialogue, this);

        internal void Restart() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}