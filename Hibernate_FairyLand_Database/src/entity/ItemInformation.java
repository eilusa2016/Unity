package entity;

import Enums.EquipType;
import Enums.ItemType;
import Enums.PlayerInfoType;

public class ItemInformation {
	//ID
    private int _id;
    //名称
    private String _name;
    //图标 图集中的名称
    private String _icon;
    //物品类型:装备还是药品（Equip，Drug）
    private ItemType _itemtype;

    //装备类型:穿在哪里
    private EquipType equType;
    //售价
    private float _price;
    //星级
    private int _starLevel;
    //品质
    private int  _qualityLevel;
    //伤害
    private int _damage=0;
    //生命
    private int _hp = 0;
    //战斗力
    private int _fightPower=0;
    //作用类型
    private PlayerInfoType _infoType;
    //作用值
    private int _applyValue;
    //描述
    private String _describe;
	public int get_id() {
		return _id;
	}
	public void set_id(int _id) {
		this._id = _id;
	}
	public String get_name() {
		return _name;
	}
	public void set_name(String _name) {
		this._name = _name;
	}
	public String get_icon() {
		return _icon;
	}
	public void set_icon(String _icon) {
		this._icon = _icon;
	}
	public ItemType get_itemtype() {
		return _itemtype;
	}
	public void set_itemtype(ItemType _itemtype) {
		this._itemtype = _itemtype;
	}
	public EquipType getEquType() {
		return equType;
	}
	public void setEquType(EquipType equType) {
		this.equType = equType;
	}
	public float get_price() {
		return _price;
	}
	public void set_price(float _price) {
		this._price = _price;
	}
	public int get_starLevel() {
		return _starLevel;
	}
	public void set_starLevel(int _starLevel) {
		this._starLevel = _starLevel;
	}
	public int get_qualityLevel() {
		return _qualityLevel;
	}
	public void set_qualityLevel(int _qualityLevel) {
		this._qualityLevel = _qualityLevel;
	}
	public int get_damage() {
		return _damage;
	}
	public void set_damage(int _damage) {
		this._damage = _damage;
	}
	public int get_hp() {
		return _hp;
	}
	public void set_hp(int _hp) {
		this._hp = _hp;
	}
	public int get_fightPower() {
		return _fightPower;
	}
	public void set_fightPower(int _fightPower) {
		this._fightPower = _fightPower;
	}
	public PlayerInfoType get_infoType() {
		return _infoType;
	}
	public void set_infoType(PlayerInfoType _infoType) {
		this._infoType = _infoType;
	}
	public int get_applyValue() {
		return _applyValue;
	}
	public void set_applyValue(int _applyValue) {
		this._applyValue = _applyValue;
	}
	public String get_describe() {
		return _describe;
	}
	public void set_describe(String _describe) {
		this._describe = _describe;
	}
	public ItemInformation(int _id, String _name, String _icon, ItemType _itemtype, EquipType equType, float _price,
			int _starLevel, int _qualityLevel, int _damage, int _hp, int _fightPower, PlayerInfoType _infoType,
			int _applyValue, String _describe) {
		super();
		this._id = _id;
		this._name = _name;
		this._icon = _icon;
		this._itemtype = _itemtype;
		this.equType = equType;
		this._price = _price;
		this._starLevel = _starLevel;
		this._qualityLevel = _qualityLevel;
		this._damage = _damage;
		this._hp = _hp;
		this._fightPower = _fightPower;
		this._infoType = _infoType;
		this._applyValue = _applyValue;
		this._describe = _describe;
	}
    
}
