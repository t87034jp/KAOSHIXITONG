<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.Question"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	int flag=0;
	DBbean bean = new DBbean();
	request.setCharacterEncoding("utf-8");
	response.setCharacterEncoding("utf-8");
	String num = request.getParameter("num");
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
	if(info.getNum().equals(num)){
		flag=1;
		break;
	}
	}
	String question = request.getParameter("question");
	//question = new String(question.getBytes("iso-8859-1"),"utf-8");
	String a = request.getParameter("a");
	String b = request.getParameter("b");
	String c = request.getParameter("c");
	String d = request.getParameter("d");
	String answer = request.getParameter("answer");
	if(flag==0){
		bean.addQuestion(num, question, a, b, c, d, answer.toUpperCase());
	}else{
		out.print("false");
	}
	
%>

