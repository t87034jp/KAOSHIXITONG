<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.yonghu"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	DBbean bean = new DBbean();
	ArrayList<yonghu> data = new ArrayList<yonghu>();
	String id = request.getParameter("id");
	String pwd = request.getParameter("pwd");
	String type = request.getParameter("type");
	boolean result = false;
	if(type.equals("1")){
		result = bean.getadmin(data);
	}else if(type.equals("2")){
		result = bean.getnormol(data);
	}
	Iterator<yonghu> iter = data.iterator();
	iter = data.listIterator();
	while (iter.hasNext()) {
		System.out.printf("%s\n", iter.next().toString());
	}
	iter = data.iterator();
	int flag=0;
	while (iter.hasNext()) {
	yonghu info = iter.next();
	if(info.getId().equals(id)&&info.getPwd().equals(pwd)){
		out.println("true");
		flag=1;
		break;
	}
	if(flag==0){
	out.println("false");
	}
	}
%>

