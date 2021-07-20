Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Partial Public Class Imager
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        If Session("AUTHENTICATED") Then
            Dim picBuffer() As Byte = Session("PICTURE_BUFFER")
            Response.OutputStream.Write(picBuffer, 0, picBuffer.Length)
        End If
    End Sub

End Class