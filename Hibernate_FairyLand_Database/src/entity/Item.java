package entity;

import Enums.ItemType;

public class Item {
	// һ����Ʒ��ID
	private int _id;
	// ����
	private String _name;
	// ��Ʒ����:װ������ҩƷ��Equip��Drug��
	private ItemType _itemtype;
	// ����һ����Ʒ
	private ItemInformation _itemInfo;

	// ��Ʒ�ȼ�
	private int _level;
	// ��Ʒ����
	private int _count;
	// �Ƿ��Ѿ�װ������
	private Boolean _dressed = false;

	public Item() {

	}

	public Item(int _id, int _level, int _count, Boolean _dressed) {
		super();
		this._id = _id;
		this._level = _level;
		this._count = _count;
		this._dressed = _dressed;
	}

	
	public String get_name() {
		return _name;
	}

	public void set_name(String _name) {
		this._name = _name;
	}

	public ItemType get_itemtype() {
		return _itemtype;
	}

	public void set_itemtype(ItemType _itemtype) {
		this._itemtype = _itemtype;
	}

	public int get_id() {
		return _id;
	}

	public void set_id(int _id) {
		this._id = _id;
	}

	public ItemInformation get_itemInfo() {
		return _itemInfo;
	}

	public void set_itemInfo(ItemInformation _itemInfo) {
		this._itemInfo = _itemInfo;
	}

	public int get_level() {
		return _level;
	}

	public void set_level(int _level) {
		this._level = _level;
	}

	public int get_count() {
		return _count;
	}

	public void set_count(int _count) {
		this._count = _count;
	}

	public Boolean get_dressed() {
		return _dressed;
	}

	public void set_dressed(Boolean _dressed) {
		this._dressed = _dressed;
	}

}
