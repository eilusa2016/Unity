package UnitTest;

import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;

import java.util.Date;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import Enums.TaskProgress;
import Enums.TaskType;
import entity.MissionTaskSystem;
import entity.Player;
import entity.Students;
/**
 * ��Ԫ����
 * @author Guardians
 *
 */
public class UTest {
	private  SessionFactory sessionfactory;
	private  Session session;
	private Transaction transaction;
	
	@Test
	public void  TestSaveDatabase(){
		
		Player p=new Player(1001, "��ү",  "sanye", 1, 100, 1, 100, 100, 100, 100, 100, 100, 100, 100, 100, 20, 0, 0, 0, 0, 0, 0, 0, 0);
		//Students student=new Students(1, "С��X", "male", new Date(), "����");
		session.save(p);
		MissionTaskSystem task=new MissionTaskSystem(1001, TaskType.Reward, "Ѫɫ����", "", "", 100, 20, "ûʲô��˵�ģ�׼�����˾�ȥ����", 1, 1, -1f, TaskProgress.NotStart_1);
		session.save(task);
		//session.update(student);
		
	}
	
	
	
	@Before
	public void init(){
		//�������ö���
		Configuration  configuration=new Configuration().configure();
		//�����ServiceRegistryBuilder  Ҫ�滻ΪStandardServiceRegistryBuilder �����  4.3��д��   ��  4.2�ֲ�һ��
		ServiceRegistry serviceregistry=new StandardServiceRegistryBuilder().applySettings(configuration.getProperties()).build();
		//�õ��Ự����
		sessionfactory=configuration.buildSessionFactory(serviceregistry);
		session=sessionfactory.openSession();
		transaction=session.beginTransaction();
		
		
	}
	
	@After
	public void destory(){
		transaction.commit();
		session.close();
		sessionfactory.close();
	}
	
	
}
