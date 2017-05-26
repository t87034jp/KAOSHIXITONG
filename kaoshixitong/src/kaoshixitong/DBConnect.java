package kaoshixitong;

import java.sql.*;
public class DBConnect {
	public static Connection getConnection() {

	      Connection conn = null;
			try{
				// 注册
				Class.forName( "com.mysql.jdbc.Driver" );
				conn = DriverManager.getConnection(
				          "jdbc:mysql://localhost:3306/testsystem","root","123456");
			}
			catch( Exception ex ){
				System.out.println("数据库连接失败\n");
			}
			
			return conn;
	  }
}
