<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.yonghu"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	DBbean bean = new DBbean();
	int flag = 0;
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
	if(info.getId().equals(id))
	{
			result = bean.DeleteNormol(id);
			out.print("true");
	}
	if(flag==0){
		out.print("false");
	}
	}
%>

