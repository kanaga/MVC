<%@ Language=VBScript %>
<%
strDISKLOCATION  = "c:\"
	'YOU MUST CHANGE THE strDISKLOCATION variable.
	'FAILURE TO CHANGE THIS LOCATION WILL CAUSE THE 
	'UPLOADED FILES TO BE SAVED TO THE C: DRIVE.
	'Change this location to be the location where 
	'you want uploaded files to be saved.
%>
<HTML>
<HEAD>
	<!-- #include file="upload.asp" -->
	<%'Create the FileUploader
	Dim Uploader, File, ErrMsg
	Set Uploader = New FileUploader
	' This starts the upload process
	Uploader.Upload()
	
	'******************************************
	' Use [FileUploader object].Form to access 
	' additional form variables submitted with
	' the file upload(s). (used below)
	'******************************************

	' Check if any files were uploaded
	If Uploader.Files.Count = 0 Then
		Response.Redirect("uploadform.asp")
	Else
		' Loop through the uploaded files
		For Each File In Uploader.Files.Items
		
			' Check where the user wants to save the file
			If Uploader.Form("saveto") = "disk" Then
				' Save the file
				File.SaveToDisk strDISKLOCATION 
			End If
			Dim filename
			filename = File.FileName '& "<br>"
		Next
	End If%>
</HEAD>
<BODY>
	<%If ErrMsg <> "" Then%>
		<td align=center width="49%" class="heading">
			<p><BR><%=ErrMsg%><BR><BR> 
			<%ErrMsg = ""%>
	<%Else%>
		</td>
		<td align=center width="49%" class="heading">
			<p><BR><h3><font color=white>Thank You</h3>
			<p>You have just uploaded: <%=filename%> <BR><BR> 
		</td>
	<%End If %>
</body>
</HTML>
