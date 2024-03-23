using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Core.ResObjects;

namespace Core
{
    public class UpgrLvl : MonoBehaviour
    {
        [SerializeField] private Button _upgrBut;

        public GameResource res;
        public int amount = 1;

        public TextMeshProUGUI text;

        private void Awake()
        {
            _upgrBut.onClick.RemoveAllListeners();
            _upgrBut.onClick.AddListener(() => ResourceBank.ChangeResource(res, 1));
            text = text.GetComponent<TextMeshProUGUI>();
            ResourceBank.ChangeResource(res, 1);
        }

        private void Update()
        {
            if (ResourceBank.GetResource(res) != amount)
            {
                amount = ResourceBank.GetResource(res);
                text.text = "ур: " + amount.ToString();
            }
        }
    }
}
