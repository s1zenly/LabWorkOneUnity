using UnityEngine;
using TMPro;
using static Core.ResObjects;

namespace Core
{
    public class ResourceVisual : MonoBehaviour
    {
        public GameResource res;
        public int amount = 0;

        public TextMeshProUGUI text;

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            if (ResourceBank.GetResource(res) != amount)
            {
                amount = ResourceBank.GetResource(res);
                text.text = amount.ToString();
            }
        }
    }
}
