using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static Core.ResObjects;

namespace Core
{
    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField] private Slider _prodSl;
        [SerializeField] private Button _prodBut;

        public GameResource res;
        private GameResource lvlRes;
        
        public float prodTime = 5;
        private float slTimer = 0;
        private bool finishTime = false;
        private int _prodLvl = 1;

        public void StartProd()
        {
            _prodBut.interactable = false;
            StartCoroutine(startTimeTick());
        }

        private IEnumerator startTimeTick()
        {
            while (!finishTime)
            {
                slTimer += Time.deltaTime;
                yield return new WaitForSeconds(0.001f);
                if (slTimer >= prodTime)
                {
                    finishTime = true;
                    slTimer = 0;
                    _prodSl.value = slTimer;
                    ResourceBank.ChangeResource(res, 1);
                }
                if (!finishTime)
                {
                    _prodSl.value = slTimer;
                }
            }
            finishTime = false;
            _prodBut.interactable = true;
        }

        private void Awake()
        {
            _prodSl.interactable = false;
            _prodBut.onClick.RemoveAllListeners();
            _prodBut.onClick.AddListener(() => StartProd());
            _prodSl.maxValue = prodTime;
            _prodSl.value = slTimer;
            switch (res)
            {
                case GameResource.Gold:
                    lvlRes = GameResource.GoldProdLvl;
                    break;
                case GameResource.Humans:
                    lvlRes = GameResource.HumansProdLvl;
                    break;
                case GameResource.Food:
                    lvlRes = GameResource.FoodProdLvl;
                    break;
                case GameResource.Wood:
                    lvlRes = GameResource.WoodProdLvl;
                    break;
                case GameResource.Stone:
                    lvlRes = GameResource.StoneProdLvl;
                    break;
                default:
                    break;
            }
        }

        private void Update()
        {
            if (ResourceBank.GetResource(lvlRes) != _prodLvl)
            {
                _prodLvl = ResourceBank.GetResource(lvlRes);
                prodTime *= (1f - _prodLvl / 100f);
                _prodSl.maxValue = prodTime;
            }
        }
    }
}
