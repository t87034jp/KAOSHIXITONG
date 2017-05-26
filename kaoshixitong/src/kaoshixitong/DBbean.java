package kaoshixitong;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class DBbean {
	private Connection conn;

	public boolean getadmin(ArrayList<yonghu> data) {
		data.clear();
		conn = DBConnect.getConnection();

		try {

			StringBuffer sBuffer = new StringBuffer();
			sBuffer.append(" select id,pwd ").append(" from ").append("admin");

			PreparedStatement st = conn.prepareStatement(sBuffer.toString());
			System.out.printf("sql = %s\n", st.toString());
			ResultSet rs = st.executeQuery();
			while (rs.next()) {
				yonghu info = new yonghu();
				info.setId(rs.getString("id"));
				info.setPwd(rs.getString("pwd"));
				data.add(info);
			}

		} catch (SQLException e) {
			System.out.printf(" ß∞‹1\n" + e.getMessage());
			return false;
		} finally {
			if (conn != null) {
				try {
					conn.close();
				} catch (SQLException e) {
					System.out.printf(" ß∞‹2\n" + e.getMessage());
					return false;
				}// try
			}// if

		}// finally

		return true;

	}
	
	public boolean getnormol(ArrayList<yonghu> data) {
		data.clear();
		conn = DBConnect.getConnection();

		try {

			StringBuffer sBuffer = new StringBuffer();
			sBuffer.append(" select id,pwd ").append(" from ").append("normol");

			PreparedStatement st = conn.prepareStatement(sBuffer.toString());
			System.out.printf("sql = %s\n", st.toString());
			ResultSet rs = st.executeQuery();
			while (rs.next()) {
				yonghu info = new yonghu();
				info.setId(rs.getString("id"));
				info.setPwd(rs.getString("pwd"));
				data.add(info);
			}

		} catch (SQLException e) {
			System.out.printf(" ß∞‹01\n" + e.getMessage());
			return false;
		} finally {
			if (conn != null) {
				try {
					conn.close();
				} catch (SQLException e) {
					System.out.printf(" ß∞‹2\n" + e.getMessage());
					return false;
				}// try
			}// if

		}// finally

		return true;

	}

	public boolean getQuestion(ArrayList<Question> data) {
		data.clear();
		conn = DBConnect.getConnection();

		try {

			StringBuffer sBuffer = new StringBuffer();
			sBuffer.append(" select num,question,a,b,c,d,answer ").append(" from ")
					.append("question");

			PreparedStatement st = conn.prepareStatement(sBuffer.toString());
			System.out.printf("sql = %s\n", st.toString());
			ResultSet rs = st.executeQuery();
			while (rs.next()) {
				Question info = new Question();
				info.setNum(rs.getString("num"));
				info.setA(rs.getString("a"));
				info.setB(rs.getString("b"));
				info.setC(rs.getString("c"));
				info.setD(rs.getString("d"));
				info.setQuestion(rs.getString("question"));
				info.setAnswer(rs.getString("answer"));
				data.add(info);
			}

		} catch (SQLException e) {
			System.out.printf("ªÒ»° ß∞‹\n" + e.getMessage());
			return false;
		} finally {
			if (conn != null) {
				try {
					conn.close();
				} catch (SQLException e) {
					System.out.printf(" ß∞‹22\n" + e.getMessage());
					return false;
				}// try
			}// if

		}// finally

		return true;

	}

	public boolean addQuestion(String num, String question, String a, String b,
			String c, String d, String answer) {
		conn = DBConnect.getConnection();

		try {

			Statement st = (Statement) conn.createStatement();
			String sBuffer;
			sBuffer = (" insert into question(num,question,a,b,c,d,answer)value"
					+ "('"
					+ num
					+ "','"
					+ question
					+ "','"
					+ a
					+ "','"
					+ b
					+ "','"
					+ c
					+ "','" + d + "','" + answer + "')");

			System.out.printf("sql = %s\n", st.toString());
			st.executeUpdate(sBuffer);

		} catch (SQLException e) {
			System.out.printf("ÃÌº” ß∞‹\n" + e.getMessage());
			return false;
		} finally {
			if (conn != null) {
				try {
					conn.close();
				} catch (SQLException e) {
					System.out.printf(" ß∞‹222\n" + e.getMessage());
					return false;
				}// try
			}// if

		}// finally

		return true;

	}
	
	public boolean DeleteQuestion(String num) {
		conn = DBConnect.getConnection();

		try {

			Statement st = (Statement) conn.createStatement();
			String sBuffer;
			sBuffer = (" delete from question where num ='"+num+"'");

			System.out.printf("sql = %s\n", st.toString());
			st.executeUpdate(sBuffer);

		} catch (SQLException e) {
			System.out.printf("…æ≥˝ ß∞‹\n" + e.getMessage());
			return false;
		} finally {
			if (conn != null) {
				try {
					conn.close();
				} catch (SQLException e) {
					System.out.printf(" ß∞‹2222\n" + e.getMessage());
					return false;
				}// try
			}// if

		}// finally

		return true;

	}
}
