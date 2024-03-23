using UnityEngine;
using static Core.ResObjects;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            ResourceBank.ChangeResource(GameResource.Food, 5);
            ResourceBank.ChangeResource(GameResource.Wood, 5);
            ResourceBank.ChangeResource(GameResource.Humans, 10);
        }

    }
}
