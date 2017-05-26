<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.Question"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	DBbean bean = new DBbean();
	ArrayList<Question> data = new ArrayList<Question>();
	boolean result = bean.getQuestion(data);
	Iterator<Question> iter = data.iterator();
	iter = data.listIterator();
	while (iter.hasNext()) {
		System.out.printf("%s\n", iter.next().toString());
	}
	iter = data.iterator();
	while (iter.hasNext()) {
	Question info = iter.next();
	out.print(info.getNum()+"@"+info.getQuestion()+"@");
	out.print(info.getA()+"@");
	out.print(info.getB()+"@");
	out.print(info.getC()+"@");
	out.print(info.getD()+"@");
	out.print(info.getAnswer()+"@");
	}
%>

