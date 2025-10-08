using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSkinData", menuName = "Items/Item Skin Data")]
public class ItemSkinDataSO : ScriptableObject
{
    private static ItemSkinDataSO instance;
    public static ItemSkinDataSO Instance
    {
        get
        {
            if (instance == null)
                return instance = Resources.Load<ItemSkinDataSO>("Data/ItemSkinDataSO"); ;
            return instance;
        }
    }
    public ItemSkinData[] items;
    public Sprite GetItemSprite(int idSkin,int typeIndex)
    {
        foreach (var item in items)
        {
            if (item.id == idSkin)
                return item.itemSkinSprites[typeIndex];
        }
        return null;
    }

}
[Serializable]
public struct ItemSkinData
{
    public int id;
    public Sprite[] itemSkinSprites;
}
