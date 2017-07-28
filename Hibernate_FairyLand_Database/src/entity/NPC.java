package entity;

public class NPC {
	private int npcId;
	private String npcName;
	private String des;
	public NPC(int npcId, String npcName, String des) {
		super();
		this.npcId = npcId;
		this.npcName = npcName;
		this.des = des;
	}
	public int getNpcId() {
		return npcId;
	}
	public void setNpcId(int npcId) {
		this.npcId = npcId;
	}
	public String getNpcName() {
		return npcName;
	}
	public void setNpcName(String npcName) {
		this.npcName = npcName;
	}
	public String getDes() {
		return des;
	}
	public void setDes(String des) {
		this.des = des;
	}
	
	
}
