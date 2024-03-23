using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Core{
    public class ResObjects : MonoBehaviour
    {
        public enum GameResource
        {
            Humans,
            Food,
            Wood,
            Stone,
            Gold,
            HumansProdLvl,
            FoodProdLvl,
            WoodProdLvl,
            StoneProdLvl,
            GoldProdLvl
        }

        public class ResourceBank
        {
            private static Dictionary<GameResource, ObservableInt> _resources = new Dictionary<GameResource, ObservableInt>();

            public static void ChangeResource(GameResource res, int value)
            {
                if (_resources.ContainsKey(res))
                {
                    _resources[res].Value += value;
                }
                else
                {
                    _resources.Add(res, new ObservableInt(value));
                }
            }

            public static int GetResource(GameResource res)
            {
                if (_resources.ContainsKey(res))
                {
                    return _resources[res].Value;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
