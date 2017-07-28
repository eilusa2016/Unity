package entity;

import Enums.RoleType;
import Enums.SkillPosType;
import Enums.SkillType;

public class Skill {
	 //a)	Id
    private int _id;
    //b)	����
    private String _name;
    //c)	ͼ��
    private String _icon;
    //d)	���õĽ�ɫ����(saber   archer  ...)
    private RoleType _role;
    //e)	�������ͣ����������� ���� Basic, Skill,Magic��
    private SkillType _skillType;
    //f)	λ��(����λ�ã�һ�ż���λ�ã����ż���λ�ã����ż���λ�� Basic, One, Two, Three)
    private SkillPosType _posType;
    //g)	��ȴʱ��
    private float _coldTime;
    //      �����˺�ʱ��
    private float _continuedTime;
    //h)	����������
    private int _damage;
    //i)	�ȼ�(Ĭ��Ϊ1��)
    private int _skillLevel=1;
    
    public Skill() {
		// TODO Auto-generated constructor stub
	}
    
    
	public Skill(int _id, String _name, String _icon, RoleType _role, SkillType _skillType, SkillPosType _posType,
			float _coldTime, float _continuedTime, int _damage, int _skillLevel) {
		super();
		this._id = _id;
		this._name = _name;
		this._icon = _icon;
		this._role = _role;
		this._skillType = _skillType;
		this._posType = _posType;
		this._coldTime = _coldTime;
		this._continuedTime = _continuedTime;
		this._damage = _damage;
		this._skillLevel = _skillLevel;
	}


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
	public RoleType get_role() {
		return _role;
	}
	public void set_role(RoleType _role) {
		this._role = _role;
	}
	public SkillType get_skillType() {
		return _skillType;
	}
	public void set_skillType(SkillType _skillType) {
		this._skillType = _skillType;
	}
	public SkillPosType get_posType() {
		return _posType;
	}
	public void set_posType(SkillPosType _posType) {
		this._posType = _posType;
	}
	public float get_coldTime() {
		return _coldTime;
	}
	public void set_coldTime(float _coldTime) {
		this._coldTime = _coldTime;
	}
	public float get_continuedTime() {
		return _continuedTime;
	}
	public void set_continuedTime(float _continuedTime) {
		this._continuedTime = _continuedTime;
	}
	public int get_damage() {
		return _damage;
	}
	public void set_damage(int _damage) {
		this._damage = _damage;
	}
	public int get_skillLevel() {
		return _skillLevel;
	}
	public void set_skillLevel(int _skillLevel) {
		this._skillLevel = _skillLevel;
	}
    
    
}
