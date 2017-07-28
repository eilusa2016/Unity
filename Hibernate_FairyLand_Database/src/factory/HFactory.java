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
		//�������ö���
		Configuration  configuration=new Configuration().configure();
		//�����ServiceRegistryBuilder  Ҫ�滻ΪStandardServiceRegistryBuilder �����  4.3��д��   ��  4.2�ֲ�һ��
		ServiceRegistry serviceregistry=new StandardServiceRegistryBuilder().applySettings(configuration.getProperties()).build();
		//�õ��Ự����
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
