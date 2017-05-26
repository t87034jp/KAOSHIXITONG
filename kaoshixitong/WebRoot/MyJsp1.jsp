<%@page import="kaoshixitong.DBbean"%>
<%@page import="kaoshixitong.yonghu"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.Iterator"%>
<%@page import="java.util.ArrayList"%>
<%@ page contentType="text/html; charset=utf-8" pageEncoding="UTF-8"%>
<%
	DBbean bean = new DBbean();
	request.setCharacterEncoding("utf-8");
	response.setCharacterEncoding("utf-8");
	bean.addQuestion("0003", "3+3=？", "3", "5", "6", "0", "c");
%>