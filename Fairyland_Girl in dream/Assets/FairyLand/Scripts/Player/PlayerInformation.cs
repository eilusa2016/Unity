using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物信息的组件
/// </summary>
[Serializable]
public class PlayerInformation : MonoBehaviour {
    /// <summary>
    /// 组件的实例对象
    /// </summary>
    public static PlayerInformation _instance;
    private void Awake()
    {
        _instance = this;
      
    }
    private void Start()
    {
        //初始化得在start方法
        InitPlayer();
        //初始化装备的事件
       // PlayerPackageSystem._Instance.OnePackage_Left_RoleInfoChange += OnePackage_Left_RoleInfoChange;

    }

    //id
    private int _playerID;
    //姓名
    private string _name;
    //头像
    private string _headPortrail;
    //等级
    private int _level = 1;
    //战斗力
    private int _power = 1;
    //经验数
    private int _exp=0;
    private int _expMax = 0;
    //钻石数
    private int _diamond = 0;
    //金币数
    private int _coin;
    //体力数 hp
    private int _energy;
    private int _energyMax;//体力上限
    //历练数  这里表示sp
    private int _toughen;
    private int _toughenMax;//sp上限

    //hp
    private int _hp;
    private int _hpMax;
    private int damage;//伤害

    //以下是八个装备的ID
    //private int _helmId;//头部
    //private int _clothId;//衣服
    //private int _weaponId;//武器
    //private int _shoesId;//鞋子
    //private int _necklaceId;//项链
    //private int _braceleId;//手镯 
    //private int _ringId;//戒指
    //private int _wingId;//翅膀

    private Item _helmItem;//头部
    private Item _clothItem;//衣服
    private Item _weaponItem;//武器
    private Item _shoesItem;//鞋子
    private Item _necklaceItem;//项链
    private Item _braceleItem;//手镯 
    private Item _ringItem;//戒指
    private Item _wingItem;//翅膀

    //角色类型
    private RoleType role;


    #region//封装各个字段
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }
    /// <summary>
    /// 头像
    /// </summary>
    public string HeadPortrail
    {
        get
        {
            return _headPortrail;
        }

        set
        {
            _headPortrail = value;
        }
    }
    /// <summary>
    /// 等级
    /// </summary>
    public int Level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
        }
    }
    /// <summary>
    /// 战斗力
    /// </summary>
    public int Power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }
    /// <summary>
    /// 经验
    /// </summary>
    public int Exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }
    /// <summary>
    /// 钻石数
    /// </summary>
    public int Diamond
    {
        get
        {
            return _diamond;
        }

        set
        {
            _diamond = value;
        }
    }
    /// <summary>
    /// 金币
    /// </summary>
    public int Coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }
    /// <summary>
    /// 能量
    /// </summary>
    public int Energy
    {
        get
        {
            return _energy;
        }

        set
        {
            _energy = value;
        }
    }
    /// <summary>
    /// sp  或者作为历练
    /// </summary>
    public int Toughen
    {
        get
        {
            return _toughen;
        }

        set
        {    
            _toughen = value;
        }
    }

    public int EnergyMax
    {
        get
        {
            return _energyMax;
            //return GameController.GetRequirePlayerHpByLevel(this.Level);
        }

        set
        {
            _energyMax = value;
        }
    }

    public int ToughenMax
    {
        get
        {
            return _toughenMax;
        }

        set
        {
            _toughenMax = value;
        }
    }

    /// <summary>
    /// 经验升级规则
    /// 1-0
    /// 2-0+100 
    /// 3-0+100+110 
    /// 4-0+100+110+120
    /// ...
    /// n- 0+100+.....(100+10(n-2))
    /// 
    /// 公式： (A1+An)*N/2  A1=100  An=(100+10(n-2))   N(个数)=n-1
    /// </summary>
    public int ExpMax
    {
        get
        {
            return _expMax;
        }

        set
        {
            _expMax =value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
            //return GameController.GetRequirePlayerDamageByLevel(this.Level);
        }

        set
        {
            //OnPlayInfoChanged(PlayerInfoType.Damage);
            damage = value;
        }
    }

    public int Hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }

    public int HpMax
    {
        get
        {
            return _hpMax;
            //return GameController.GetRequirePlayerHpByLevel(this.Level);
        }

        set
        {
            _hpMax = value;
        }
    }

    public Item HelmItem
    {
        get
        {
            return _helmItem;
        }

        set
        {
            _helmItem = value;
        }
    }

    public Item ClothItem
    {
        get
        {
            return _clothItem;
        }

        set
        {
            _clothItem = value;
        }
    }

    public Item WeaponItem
    {
        get
        {
            return _weaponItem;
        }

        set
        {
            _weaponItem = value;
        }
    }

    public Item ShoesItem
    {
        get
        {
            return _shoesItem;
        }

        set
        {
            _shoesItem = value;
        }
    }

    public Item NecklaceItem
    {
        get
        {
            return _necklaceItem;
        }

        set
        {
            _necklaceItem = value;
        }
    }

    public Item BraceleItem
    {
        get
        {
            return _braceleItem;
        }

        set
        {
            _braceleItem = value;
        }
    }

    public Item RingItem
    {
        get
        {
            return _ringItem;
        }

        set
        {
            _ringItem = value;
        }
    }

    public Item WingItem
    {
        get
        {
            return _wingItem;
        }

        set
        {
            _wingItem = value;
        }
    }

    public int PlayerID
    {
        get
        {
            return _playerID;
        }

        set
        {
            _playerID = value;
        }
    }

    public RoleType Role
    {
        get
        {
            return role;
        }

        set
        {
            role = value;
        }
    }

    //public int HelmId
    //{
    //    get
    //    {
    //        return _helmId;
    //    }

    //    set
    //    {
    //        _helmId = value;
    //    }
    //}

    //public int ClothId
    //{
    //    get
    //    {
    //        return _clothId;
    //    }

    //    set
    //    {
    //        _clothId = value;
    //    }
    //}

    //public int WeaponId
    //{
    //    get
    //    {
    //        return _weaponId;
    //    }

    //    set
    //    {
    //        _weaponId = value;
    //    }
    //}

    //public int ShoesId
    //{
    //    get
    //    {
    //        return _shoesId;
    //    }

    //    set
    //    {
    //        _shoesId = value;
    //    }
    //}

    //public int NecklaceId
    //{
    //    get
    //    {
    //        return _necklaceId;
    //    }

    //    set
    //    {
    //        _necklaceId = value;
    //    }
    //}

    //public int BraceleId
    //{
    //    get
    //    {
    //        return _braceleId;
    //    }

    //    set
    //    {
    //        _braceleId = value;
    //    }
    //}

    //public int RingId
    //{
    //    get
    //    {
    //        return _ringId;
    //    }

    //    set
    //    {
    //        _ringId = value;
    //    }
    //}

    //public int WingId
    //{
    //    get
    //    {
    //        return _wingId;
    //    }

    //    set
    //    {
    //        _wingId = value;
    //    }
    //}

    //8个装备(存储ID)






    #endregion

    /***人物的事件  事件  和  委托**/
    //主角信息被更改的委托
    public delegate void OnPlayInfoChangedEvent(PlayerInfoType infoType);
    //主角信息变化的事件
    public event OnPlayInfoChangedEvent OnPlayInfoChanged;

    /********装备信息发生改变的时候************/
    public delegate void OnePackage_Left_RoleInfoChangeEvent(Item it, EquChangeType equChangeType);
    /// <summary>
    /// 人物装备发生改变的时候  装备面板上也需要发生改变的事件监听
    /// </summary>
    public event OnePackage_Left_RoleInfoChangeEvent OnePackage_Left_RoleInfoChange;


    /// <summary>
    /// 初始化属性
    /// </summary>
    void InitPlayer() {
        //首先设置各个计量的上限
        this.EnergyMax = GameController.GetRequirePlayerHpByLevel(this.Level);
        this.Power = GameController.GetRequirePlayerPowerByHpAndDamage(this.HpMax, this.Damage);
        this.HpMax = GameController.GetRequirePlayerHpByLevel(this.Level);
        this.Damage = GameController.GetRequirePlayerDamageByLevel(this.Level);
        this.ExpMax = GameController.GetRequirePlayerExpByLevel(this.Level);

        //在设置显示的值
        //原则上面来说这里应该要从内存中读取的
        this.PlayerID = 1001;
        this.Coin = 20000;
        this.Diamond = 100;
        this.Energy = 90;
        this.Hp = 80;
        this.Exp = 1;
        this.Toughen = 45;
        this.ToughenMax = 100;
        this.HeadPortrail = "sanye";
        this.Level = 2;
        this.Name = "三爷";
        this.Role = RoleType.Saber;
        //接下来  带上一些装备   
        InitEquips();

        //所有的都被修改了
        //需要有对象注册了这个事件
        OnPlayInfoChanged(PlayerInfoType.All);
    }
    /// <summary>
    /// 初始化玩家的装备
    /// </summary>
    private void InitEquips()
    {
        
        //这里初始化的时候应该读取内存的存档
        //判断人物是否有装备
    }




    /****控制人物属性的自增长（自动回复）***/

    private void Update()
    {
        //战斗中自动恢复 一分钟会执行一次这个方法
        HpAndSpAutoRecovery();
    }

    /// <summary>
    /// 能量计数器
    /// </summary>
    public float energyTimer = 0;//

    /// <summary>
    /// HP的计数器
    /// </summary>
    public float hpTimer = 0;
    /// <summary>
    /// sp的计数器
    /// </summary>
    public float toughenTimer = 0;//
    /// <summary>
    /// 每次恢复两点
    /// </summary>
    public int recoverPoint = 1;//
    /// <summary>
    /// 每次恢复的时间(秒)
    /// </summary>
    public int recoverCount =60;//
    /// <summary>
    /// 自动恢复的方法
    /// </summary>
    void HpAndSpAutoRecovery() {
        //HP自动恢复
        if (this.Hp < this.HpMax)
        {
            hpTimer += Time.deltaTime;
            //
            if (hpTimer > recoverCount)
            {
                this.Hp += recoverPoint;//每次恢复2点
                if (this.Hp > this.HpMax)
                {
                    this.Hp = this.HpMax;
                }
                //前面要显示下一次恢复的时间
                hpTimer -= recoverCount;
                if(OnPlayInfoChanged!=null)
                OnPlayInfoChanged(PlayerInfoType.Hp);
            }
        }
        else if(this.Hp >= this.HpMax)
        {
            this.Hp = this.HpMax;
            hpTimer = 0;//计时器归零

        }

        //能量自动恢复
        if (this.Energy < this.EnergyMax)
        {
            energyTimer += Time.deltaTime;
            //
            if (energyTimer > recoverCount)
            {
                this.Energy += recoverPoint;//每次恢复2点
                if (this.Energy > this.EnergyMax) {
                    this.Energy = this.EnergyMax;
                }
                //前面要显示下一次恢复的时间
                energyTimer -= recoverCount;
                if (OnPlayInfoChanged != null)
                    OnPlayInfoChanged(PlayerInfoType.Energy);
            }
        }
        else if(this.Energy >= this.EnergyMax)
        {
            this.Energy = this.EnergyMax;
            energyTimer = 0;//计时器归零
        }
        //历练或者说SP自动恢复
        if (this.Toughen < this.ToughenMax)
        {
            toughenTimer += Time.deltaTime;
            if (toughenTimer > recoverCount) {
                this.Toughen += recoverPoint;
                if (this.Toughen >= this.ToughenMax)
                {
                    this.Toughen = this.ToughenMax;
                }
                toughenTimer -= recoverCount;
                if(OnPlayInfoChanged!=null)
                OnPlayInfoChanged(PlayerInfoType.Sp);
            }
        }
        else if (this.Toughen >= this.ToughenMax) {
            this.Toughen = this.ToughenMax;
            toughenTimer = 0;
        }
       
    }

    /// <summary>
    /// 玩家信息变化   
    /// 用来广播的方法
    /// </summary>
    /// <param name="type"></param>
    public void OnPlayerValueChanged(PlayerInfoType type) {
        OnPlayInfoChanged(type);
    }
    /// <summary>
    /// 物品管理器
    /// </summary>
    private ItemManager itemManager;

   
    /// <summary>
    /// 穿上装备
    /// </summary>
    /// <param name="id"></param>
    public void PutonEquip(Item it)
    {
        //穿上装备  对主角有加成的作用
        if (it != null)
        {
            it.Dressed = true;
            Item item = this.PutOnSwitchPart(it.ItemInfo.EquType, it);
            if (item != null) {
                //表示上次穿了一件装备了
                //先得卸载一次（方式两次穿上装备出现的bug）
                PutoffEquip(item);
                this.PutOnSwitchPart(it.ItemInfo.EquType, it);
                it.Dressed = true;//再再穿上
            }
            this.Hp += it.ItemInfo.Hp;
            this.HpMax += it.ItemInfo.Hp;
            this.Damage += it.ItemInfo.Damage;
            this.Power += it.ItemInfo.FightPower;
            OnPlayInfoChanged(PlayerInfoType.All);
            OnePackage_Left_RoleInfoChange(it, EquChangeType.PutOn);
        }
    }
    /// <summary>
    /// 脱下装备
    /// </summary>
    /// <param name="id"></param>
    public void PutoffEquip(Item it) {     
        //卸下装备  对主角有加成的作用
        if (it != null)
        {
            it.Dressed = false;
            this.PutOnSwitchPart(it.ItemInfo.EquType, null);
            this.Hp -= it.ItemInfo.Hp;
            this.HpMax -= it.ItemInfo.Hp;
            this.Damage -= it.ItemInfo.Damage;
            this.Power -= it.ItemInfo.FightPower;
            OnPlayInfoChanged(PlayerInfoType.All);
            OnePackage_Left_RoleInfoChange(it, EquChangeType.PutOff);
        }
    }
    /// <summary>
    /// 玩家使用药水
    /// </summary>
    /// <param name="item"></param>
    public void PlayerUserDrug(Item item) {
        ApplyInWitchPlayerInfo(item);
    }
    /// <summary>
    /// 是否有足够的钱
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    public bool HaveEnoughMoney(float cost) {
        bool enough = true;
        enough = (this.Coin - (int)cost) > 0 ? true : false;
        return enough;
    }

    /// <summary>
    /// 付钱
    /// </summary>
    /// <param name="cost">代付的金额</param>
    /// <returns>返回现持有金币</returns>
    public int PayMoney(float cost) {
        this.Coin-=(int)cost;
        OnPlayInfoChanged(PlayerInfoType.Coin);
        return this.Coin;
    }
    /// <summary>
    /// 收入钱财
    /// </summary>
    /// <param name="money">增加的金额</param>
    /// <returns>返回现持有金币</returns>
    public int IncomeMoney(float money) {
        this.Coin += (int)money;
        OnPlayInfoChanged(PlayerInfoType.Coin);
        return this.Coin;
    }

    /// <summary>
    /// 选择穿戴在哪个部位上
    /// </summary>
    /// <param name="type">装备类型 装备在那个部位</param>
    /// <param name="it">需要装备或者卸下装备对象</param>
    /// <return>返回上次穿戴的装备</return>
     Item PutOnSwitchPart(EquipType type,Item it) {
        Item item = null;
        switch (type) {
            case EquipType.Helm:
                item = HelmItem;
                this.HelmItem = it;
                break;
            case EquipType.Cloth:
                item = ClothItem;
                this.ClothItem = it;
                break;
            case EquipType.Weapon:
                item = WeaponItem;
                this.WeaponItem = it;
                break;
            case EquipType.Shoes:
                item = ShoesItem;
                this.ShoesItem = it;
                break;
            case EquipType.Necklace:
                item = NecklaceItem;
                this.NecklaceItem = it;
                break;
            case EquipType.Bracelet:
                item = BraceleItem;
                this.BraceleItem = it;
                break;
            case EquipType.Ring:
                item = RingItem;
                this.RingItem = it;
                break;
            case EquipType.Wing:
                item = WingItem;
                this.WingItem = it;
                break;

        }
        return item;
    }
    /// <summary>
    /// 是那种作用类型的药水
    /// </summary>
    /// <param name="it"></param>
    void ApplyInWitchPlayerInfo(Item it) {
        PlayerInfoType type = it.ItemInfo.InfoType;
        switch (type) {
            case PlayerInfoType.All:
                break;
            case PlayerInfoType.Coin:
                this.Coin += it.ItemInfo.ApplyValue;
              //  OnPlayInfoChanged(PlayerInfoType.Coin);
                break;
            case PlayerInfoType.Damage:
                this.Damage += it.ItemInfo.ApplyValue;
              //  OnPlayInfoChanged(PlayerInfoType.Damage);
                break;
            case PlayerInfoType.Diamond:
                this.Diamond += it.ItemInfo.ApplyValue;
              //  OnPlayInfoChanged(PlayerInfoType.Diamond);
                break;
            case PlayerInfoType.Energy:
                this.Energy += it.ItemInfo.ApplyValue;
               // OnPlayInfoChanged(PlayerInfoType.Energy);
                break;
            case PlayerInfoType.Exp:
                this.Exp += it.ItemInfo.ApplyValue;
              //  OnPlayInfoChanged(PlayerInfoType.Exp);
                break;
            case PlayerInfoType.HeadPortail:
                //头像的物品不知道怎么改
              //  OnPlayInfoChanged(PlayerInfoType.HeadPortail);
                break;
            case PlayerInfoType.Hp:
                this.Hp += it.ItemInfo.ApplyValue;
                if (this.Hp > this.HpMax) {
                    this.Hp = this.HpMax;
                }
              //  OnPlayInfoChanged(PlayerInfoType.Hp);
                break;
            case PlayerInfoType.Item:
                //类型是道具
               // OnPlayInfoChanged(PlayerInfoType.Item);
                break;
            case PlayerInfoType.Level:
                this.Level += it.ItemInfo.ApplyValue;
               // OnPlayInfoChanged(PlayerInfoType.Level);
                break;
            case PlayerInfoType.Name:
                //玩家姓名 不用改
                break;
            case PlayerInfoType.Power:
                this.Power += it.ItemInfo.ApplyValue;
                //OnPlayInfoChanged(PlayerInfoType.Power);
                break;
            case PlayerInfoType.Sp:
                this.Toughen += it.ItemInfo.ApplyValue;
                if (this.Toughen > this.ToughenMax) {
                    this.Toughen = this.ToughenMax;
                }
               // OnPlayInfoChanged(PlayerInfoType.Sp);
                break;
            default:
                break;
        }
        if(OnPlayInfoChanged!=null)
        OnPlayInfoChanged(type);
    }

    /// <summary>
    /// 领取任务
    /// </summary>
    /// <param name="task"></param>
    public void GetThisTask(MissionTaskSystem task) {
        if (task != null) {
            TaskManager._instance.ExcuteTask(task,this.PlayerID);
        }
    }


}


