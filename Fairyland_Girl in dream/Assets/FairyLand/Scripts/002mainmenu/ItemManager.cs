using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品管理的类
/// </summary>
public class ItemManager : MonoBehaviour {



    public static ItemManager _itemInstance;
    public TextAsset textAsset;
    //物品信息的字典
    public  Dictionary<int, ItemInformation> itemInfoDic = new Dictionary<int, ItemInformation>();
    //物品的字典
   // public  Dictionary<int, Item> itemDic = new Dictionary<int, Item>();
    public List<Item> itemList = new List<Item>();
    /// <summary>
    /// 事件
    /// </summary>
    public delegate void OnItemChangeEvent();
    /// <summary>
    /// 物品信息发生变化的时候
    /// </summary>
    public event OnItemChangeEvent OnItemChange;


    private void Awake()
    {
        _itemInstance = this;
        ReadItemListInfo();//这个目前必须得在这，因为其他地方在awake的使用到这里
       

    }
    private void Start()
    {
        ReadItem();


    }
    /// <summary>
    /// 物品信息的初始化
    /// 这个以后要改的  
    /// 单机游戏中  
    /// 商店的数量是没有上限的
    /// </summary>
    void ReadItemListInfo() {
        if (textAsset != null)
        {
            string str=textAsset.ToString();
            string[] listArray = str.Split("\n"[0]);
            foreach (string lineInfo in listArray) {
                //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 
                //品质 伤害 生命 战斗力 作用类型 作用值 描述
                string[] itemStr = lineInfo.Split("|"[0]);
                ItemInformation itemInfo = new ItemInformation();
                itemInfo.Id = GameController.ParseInt(itemStr[0]);
                itemInfo.Name = itemStr[1];
                itemInfo.Icon = itemStr[2];
                itemInfo.Itemtype = GameController.GetItemType(itemStr[3]);
                itemInfo.EquType = GameController.GetEquipType(itemStr[4]);
                itemInfo.Price = GameController.ParseFloat(itemStr[5]);
                itemInfo.StarLevel = GameController.ParseInt(itemStr[6]);
                itemInfo.QualityLevel = GameController.ParseInt(itemStr[7]);
                itemInfo.Damage = GameController.ParseInt(itemStr[8]);
                itemInfo.Hp = GameController.ParseInt(itemStr[9]);
                itemInfo.FightPower = GameController.ParseInt(itemStr[10]);
                itemInfo.InfoType = GameController.GetPlayerInfoType(itemStr[11]);
                itemInfo.ApplyValue = GameController.ParseInt(itemStr[12]);
                itemInfo.Describe = itemStr[13];
                //添加到字典
                itemInfoDic.Add(itemInfo.Id, itemInfo);

            }
        }
        else {
            Debug.LogError("文本物品资源为空!");
        }
    }
    /// <summary>
    /// 生成物品
    /// </summary>
    void ReadItem() {
        if (itemInfoDic.Count <= 0) {
            return;
        }
        //TODO  需要读取当前角色需要的物品信息
        //模拟一下  随机生成
        for (int i = 0; i < 19; i++) {
            int id = UnityEngine.Random.Range(1001, 1020);
            ItemInformation ifo;
            itemInfoDic.TryGetValue(id, out ifo);
            if (ifo == null) {
                continue;
            }
            if (ifo.Itemtype == ItemType.Equip)
            {
                //装备
                Item im = new Item();
                im.ItemInfo = ifo;
                im.Level = UnityEngine.Random.Range(1, 20);
                im.Count = 1;
                //itemDic.Add(id, im);
                itemList.Add(im);   
            }
            else {
                //药品
                Item im = null;
                if (itemList.Count<=0)
                {
                    im = new Item();
                    im.Level = 1;//其实药品没什么等级，有的是效果
                    im.Count = im.Count + 1;
                    im.ItemInfo = ifo;
                    itemList.Add(im);
                }
                else {
                    //if (!itemList.Exists(v1 => v1.ItemInfo.Id == id))
                    //{
                    //    im = new Item();
                    //    im.Level = 1;//其实药品没什么等级，有的是效果
                    //    im.Count = im.Count + 1;
                    //    itemList.Add(im);
                    //    return;
                    //}
                    try
                    {
                        im = itemList.Find(v1 => v1.ItemInfo.Id == id);
                    }
                    catch (Exception)
                    {

                        im = null;
                    }
                    if (im == null) {
                        im = new Item();
                        im.Level = 1;//其实药品没什么等级，有的是效果
                    }
                    im.ItemInfo = ifo;
                    im.Count = im.Count + 1;
                    itemList.Add(im);
                }
               
              
            }
        }
        //if (OnItemChange != null)
        //{
            OnItemChange();
        //}
       
    }
    /// <summary>
    /// 物品发生改变
    /// </summary>
    public void StartItemChanged() {
        if (OnItemChange != null) {
            OnItemChange();
        }
    }

    /// <summary>
    /// 物品用掉了
    /// 主要指的是药物之类的消耗品
    ///     或者是卖出装备物品
    ///     或者是一次性消耗的宝箱之类
    /// 要从持有的物品集合中删除
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public List<Item> RemoveItemList(Item item) {
        itemList.Remove(item);
        StartItemChanged();
        return itemList;
    }


    /// <summary>
    /// 物品升级
    /// 主要还是装备
    /// 一级一级的升级
    /// </summary>
    /// <param name="it"></param>
    public void ItemLevelUp(Item it) {

        if (it != null) {
            it.Level += 1;
            float percent = 1;
            //这里需要判断下  不拿float计算 小于1的时候 一直都是0升级会没有加成的
            percent+=(it.Level - 1) / 10 > 1 ? ((it.Level - 1) / 10 + (it.Level - 1) % 10) : (it.Level - 1) % 10;
            float damage = it.ItemInfo.Damage;
            float hp = it.ItemInfo.Hp;
            float power = it.ItemInfo.FightPower;
            damage *= percent;
            hp *= percent;
            power *= percent;
            it.ItemInfo.Damage= (int)damage;
            it.ItemInfo.Hp = (int)damage;
            it.ItemInfo.FightPower= (int)damage;
            OnItemChange();
        }
    }


}


