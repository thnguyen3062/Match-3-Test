using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }
    public Sprite GetSkin(int idSkin)
    {
        int typeIndex = 0;
        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                typeIndex = 0;
                break;
            case eNormalType.TYPE_TWO:
                typeIndex = 1;
                break;
            case eNormalType.TYPE_THREE:
                typeIndex = 2;
                break;
            case eNormalType.TYPE_FOUR:
                typeIndex = 3;
                break;
            case eNormalType.TYPE_FIVE:
                typeIndex = 4;
                break;
            case eNormalType.TYPE_SIX:
                typeIndex = 5;
                break;
            case eNormalType.TYPE_SEVEN:
                typeIndex = 6;
                break;
        }
        Sprite s = ItemSkinDataSO.Instance.GetItemSprite(idSkin , typeIndex);
        return s;
    }
    public override void SetView()
    {
        base.SetView();
        // tam fix cung texture fish id 1
        View.GetComponent<SpriteRenderer>().sprite = GetSkin(1);
    }
    protected override string GetPrefabName()
    {
        string prefabname = string.Empty;
        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_ONE;
                break;
            case eNormalType.TYPE_TWO:
                prefabname = Constants.PREFAB_NORMAL_TYPE_TWO;
                break;
            case eNormalType.TYPE_THREE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_THREE;
                break;
            case eNormalType.TYPE_FOUR:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FOUR;
                break;
            case eNormalType.TYPE_FIVE:
                prefabname = Constants.PREFAB_NORMAL_TYPE_FIVE;
                break;
            case eNormalType.TYPE_SIX:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SIX;
                break;
            case eNormalType.TYPE_SEVEN:
                prefabname = Constants.PREFAB_NORMAL_TYPE_SEVEN;
                break;
        }

        return prefabname;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
