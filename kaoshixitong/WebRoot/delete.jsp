<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.Question"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	DBbean bean = new DBbean();
	int flag = 0;
	String num = request.getParameter("num");
	String type = request.getParameter("type");
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
	if(info.getNum().equals(num))
	{
		flag=1;
		if(type.equals("1")){
			out.print(info.getQuestion());
		}else{
			result = bean.DeleteQuestion(num);
			out.print("true");
		}
		break;
	}
	}
	if(flag==0){
		out.print("false");
	}
%>

