package kaoshixitong;

import java.sql.*;
public class DBConnect {
	public static Connection getConnection() {

	      Connection conn = null;
			try{
				// ע��
				Class.forName( "com.mysql.jdbc.Driver" );
				conn = DriverManager.getConnection(
				          "jdbc:mysql://localhost:3306/testsystem","root","123456");
			}
			catch( Exception ex ){
				System.out.println("���ݿ�����ʧ��\n");
			}
			
			return conn;
	  }
}
