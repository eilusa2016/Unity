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
 * 单元测试
 * @author Guardians
 *
 */
public class UTest {
	private  SessionFactory sessionfactory;
	private  Session session;
	private Transaction transaction;
	
	@Test
	public void  TestSaveDatabase(){
		
		Player p=new Player(1001, "三爷",  "sanye", 1, 100, 1, 100, 100, 100, 100, 100, 100, 100, 100, 100, 20, 0, 0, 0, 0, 0, 0, 0, 0);
		//Students student=new Students(1, "小明X", "male", new Date(), "北京");
		session.save(p);
		MissionTaskSystem task=new MissionTaskSystem(1001, TaskType.Reward, "血色还魂", "", "", 100, 20, "没什么好说的，准备好了就去死吧", 1, 1, -1f, TaskProgress.NotStart_1);
		session.save(task);
		//session.update(student);
		
	}
	
	
	
	@Before
	public void init(){
		//创建配置对象
		Configuration  configuration=new Configuration().configure();
		//这里的ServiceRegistryBuilder  要替换为StandardServiceRegistryBuilder 这个是  4.3的写法   与  4.2又不一样
		ServiceRegistry serviceregistry=new StandardServiceRegistryBuilder().applySettings(configuration.getProperties()).build();
		//得到会话工厂
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
