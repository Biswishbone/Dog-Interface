Imports System.Data.SqlClient
Imports System.Data

Public Class WebForm1
    Inherits System.Web.UI.Page

    Public Shared conS As String = "Server=COBBISSQL01.ad.ilstu.edu\BIS362;Database=BIS362;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Name, Age, Sex, Breed, MC, SC, OC As String
        Dim IntD As Date

        If TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Or TextBox6.Text = Nothing Or TextBox7.Text = Nothing Then
            MsgBox("All Fields must be Completed!", vbExclamation, "Error!")
            Exit Sub
        End If

        Name = TextBox2.Text
        Age = TextBox4.Text
        Breed = TextBox3.Text
        Sex = RadioButtonList1.Text
        MC = TextBox7.Text
        SC = TextBox6.Text
        IntD = TextBox5.Text

        If TextBox2.Text = Nothing Then
            MsgBox("Please Enter a Name", vbExclamation, "Error")
            Exit Sub
        End If

        If TextBox5.Text = Nothing Then
            MsgBox("Please Enter an Intake Date", vbExclamation, "Error")
            Exit Sub
        End If

        Dim cmdInsert As New SqlCommand("Insert into Dogs (DogName, Age, Breed, Sex, MicrochipNumber, sourcecode, IntakeDate) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", con)

        With cmdInsert.Parameters
            .Clear()
            .AddWithValue("@p1", Name)
            .AddWithValue("@p2", Age)
            .AddWithValue("@p3", Breed)
            .AddWithValue("@p4", Sex)
            .AddWithValue("@p5", MC)
            .AddWithValue("@p6", SC)
            .AddWithValue("@p7", IntD)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdInsert.ExecuteNonQuery()
            Response.Write("Dog Added Successfully")
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
        RadioButtonList1.Text = Nothing
    End Sub
End Class