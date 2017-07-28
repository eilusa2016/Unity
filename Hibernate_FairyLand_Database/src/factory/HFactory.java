package factory;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;

public class HFactory {
	private  SessionFactory sessionfactory;
	private  Session session;
	private Transaction transaction;
	
	public HFactory() {
		//创建配置对象
		Configuration  configuration=new Configuration().configure();
		//这里的ServiceRegistryBuilder  要替换为StandardServiceRegistryBuilder 这个是  4.3的写法   与  4.2又不一样
		ServiceRegistry serviceregistry=new StandardServiceRegistryBuilder().applySettings(configuration.getProperties()).build();
		//得到会话工厂
		sessionfactory=configuration.buildSessionFactory(serviceregistry);
		session=sessionfactory.openSession();
		transaction=session.beginTransaction();
	}
	
	
	public  void HFactoryDispose(){
		transaction.commit();
		session.close();
		sessionfactory.close();
	}
	
}
