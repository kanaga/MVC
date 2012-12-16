<%@ Language=VBScript %>
<%
%>

	<html>
	<BODY>
	<BR><BR>
	<DIV align=center>
		<form METHOD="post" ENCTYPE="multipart/form-data" ACTION="uploadexmple.asp" name="uploadfrm" ><FONT face=Arial>
		<font color=white> Please select a file to upload:<br></FONT>
		<input TYPE="file" SIZE="50" NAME="FILE1"><BR><FONT face=Arial>
		<font color=white> Save To:&nbsp;&nbsp;Disk&nbsp;
		<input TYPE="radio" NAME="saveto" value="disk" checked>&nbsp;&nbsp; </FONT>
		<input TYPE="submit" VALUE="Upload File" id="submit1" style="WIDTH: 119px; HEIGHT: 27px" size="35" name="submit1">
		</form>
	</DIV>
	</BODY>
	</html>