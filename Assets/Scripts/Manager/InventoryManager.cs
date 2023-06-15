using System;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    /// <summary>
    /// 库存管理
    /// </summary>
    public class InventoryManager : Singleton<InventoryManager>
    {
        public Inventory myBag;
        public GameObject slotGrid;

        public Slot slotPrefab;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
    }

    public class Slot : MonoBehaviour
    {
        public Item slotItem;
        public Image slotImage;
        public Text slotName;
    }

    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
    public class Item : ScriptableObject
    {
        public String itemName;
        public Sprite itemImage;
        public int itemHeld;
        [TextArea] public String itemInfo;

        /// <summary>
        /// 装备
        /// </summary>
        public bool equipped;
    }

    public class Inventory : MonoBehaviour
    {
    }
}