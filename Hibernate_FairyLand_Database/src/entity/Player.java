package entity;
/**
 * 玩家
 * @author Administrator
 *
 */
public class Player {
	 //id
    private int _playerID;
    //姓名
    private String _name;
    //头像
    private String _headPortrail;
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
    
    
    private int _helmId;//头部
    private int _clothId;//衣服
    private int _weaponId;//武器
    private int _shoesId;//鞋子
    private int _necklaceId;//项链
    private int _braceleId;//手镯 
    private int _ringId;//戒指
    private int _wingId;//翅膀
    
    public Player() {
		// TODO Auto-generated constructor stub
	}
    
    
	public Player(int _playerID, String _name, String _headPortrail, int _level, int _power, int _exp, int _expMax,
			int _diamond, int _coin, int _energy, int _energyMax, int _toughen, int _toughenMax, int _hp, int _hpMax,
			int damage, int _helmId, int _clothId, int _weaponId, int _shoesId, int _necklaceId, int _braceleId,
			int _ringId, int _wingId) {
		super();
		this._playerID = _playerID;
		this._name = _name;
		this._headPortrail = _headPortrail;
		this._level = _level;
		this._power = _power;
		this._exp = _exp;
		this._expMax = _expMax;
		this._diamond = _diamond;
		this._coin = _coin;
		this._energy = _energy;
		this._energyMax = _energyMax;
		this._toughen = _toughen;
		this._toughenMax = _toughenMax;
		this._hp = _hp;
		this._hpMax = _hpMax;
		this.damage = damage;
		this._helmId = _helmId;
		this._clothId = _clothId;
		this._weaponId = _weaponId;
		this._shoesId = _shoesId;
		this._necklaceId = _necklaceId;
		this._braceleId = _braceleId;
		this._ringId = _ringId;
		this._wingId = _wingId;
	}
	public int get_playerID() {
		return _playerID;
	}
	public void set_playerID(int _playerID) {
		this._playerID = _playerID;
	}
	public String get_name() {
		return _name;
	}
	public void set_name(String _name) {
		this._name = _name;
	}
	public String get_headPortrail() {
		return _headPortrail;
	}
	public void set_headPortrail(String _headPortrail) {
		this._headPortrail = _headPortrail;
	}
	public int get_level() {
		return _level;
	}
	public void set_level(int _level) {
		this._level = _level;
	}
	public int get_power() {
		return _power;
	}
	public void set_power(int _power) {
		this._power = _power;
	}
	public int get_exp() {
		return _exp;
	}
	public void set_exp(int _exp) {
		this._exp = _exp;
	}
	public int get_expMax() {
		return _expMax;
	}
	public void set_expMax(int _expMax) {
		this._expMax = _expMax;
	}
	public int get_diamond() {
		return _diamond;
	}
	public void set_diamond(int _diamond) {
		this._diamond = _diamond;
	}
	public int get_coin() {
		return _coin;
	}
	public void set_coin(int _coin) {
		this._coin = _coin;
	}
	public int get_energy() {
		return _energy;
	}
	public void set_energy(int _energy) {
		this._energy = _energy;
	}
	public int get_energyMax() {
		return _energyMax;
	}
	public void set_energyMax(int _energyMax) {
		this._energyMax = _energyMax;
	}
	public int get_toughen() {
		return _toughen;
	}
	public void set_toughen(int _toughen) {
		this._toughen = _toughen;
	}
	public int get_toughenMax() {
		return _toughenMax;
	}
	public void set_toughenMax(int _toughenMax) {
		this._toughenMax = _toughenMax;
	}
	public int get_hp() {
		return _hp;
	}
	public void set_hp(int _hp) {
		this._hp = _hp;
	}
	public int get_hpMax() {
		return _hpMax;
	}
	public void set_hpMax(int _hpMax) {
		this._hpMax = _hpMax;
	}
	public int getDamage() {
		return damage;
	}
	public void setDamage(int damage) {
		this.damage = damage;
	}
	public int get_helmId() {
		return _helmId;
	}
	public void set_helmId(int _helmId) {
		this._helmId = _helmId;
	}
	public int get_clothId() {
		return _clothId;
	}
	public void set_clothId(int _clothId) {
		this._clothId = _clothId;
	}
	public int get_weaponId() {
		return _weaponId;
	}
	public void set_weaponId(int _weaponId) {
		this._weaponId = _weaponId;
	}
	public int get_shoesId() {
		return _shoesId;
	}
	public void set_shoesId(int _shoesId) {
		this._shoesId = _shoesId;
	}
	public int get_necklaceId() {
		return _necklaceId;
	}
	public void set_necklaceId(int _necklaceId) {
		this._necklaceId = _necklaceId;
	}
	public int get_braceleId() {
		return _braceleId;
	}
	public void set_braceleId(int _braceleId) {
		this._braceleId = _braceleId;
	}
	public int get_ringId() {
		return _ringId;
	}
	public void set_ringId(int _ringId) {
		this._ringId = _ringId;
	}
	public int get_wingId() {
		return _wingId;
	}
	public void set_wingId(int _wingId) {
		this._wingId = _wingId;
	}
    
    
    
    
}
