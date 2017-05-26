<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.yonghu"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	int flag=0;
	DBbean bean = new DBbean();
	request.setCharacterEncoding("utf-8");
	response.setCharacterEncoding("utf-8");
	String id = request.getParameter("id");
	ArrayList<yonghu> data = new ArrayList<yonghu>();
	boolean result = bean.getnormol(data);
	Iterator<yonghu> iter = data.iterator();
	iter = data.listIterator();
	while (iter.hasNext()) {
		System.out.printf("%s\n", iter.next().toString());
	}
	iter = data.iterator();
	while (iter.hasNext()) {
	yonghu info = iter.next();
	if(info.getId().equals(id)){
		flag=1;
		break;
	}
	}
	String pwd = request.getParameter("pwd");
	if(flag==0){
		bean.addNormol(id,pwd);
	}else{
		out.print("false");
	}
	
%>

