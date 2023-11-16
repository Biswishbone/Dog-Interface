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

Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Web.Services.Description
Imports AjaxControlToolkit

Public Class Dog
    Inherits System.Web.UI.Page

    ' Database connection string

    Public Shared conS As String = "Server=COBBISSQL01.ad.ilstu.edu\BIS362;Database=BIS362;Trusted_Connection=Yes;"

    Public Shared con As SqlConnection = New SqlConnection(conS) ' To pull data from WISHBONE database

    Public Shared Breedd As String = " " 'Declared as global variable because it will be used in other subprocedures. For instance the checkbox event handler subprocedure
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then 'This is to ensure that after adding the first dog, the button click sumbit doesn't trigger and say "Dog was added succesfully". The code was moved from Page init to pageload and added the if not isPostback

            'When the page initializes, the data from the parteners table is pulled and fill out the dropdownlist

            Dim SelectPartnersData As New SqlDataAdapter("Select SourceCode, PartnerName From 
        Partners", con) ' Selecting data from Partners table located in WISHBONE database

            Dim SelectBreedsData As New SqlDataAdapter("Select BreedID, BreedName From Breed", con) 'Selecting data from Breed table located in WISHBONE2 database

            'Declaring datatable where the data selected from the database will be stored on the front-end. In this case dropdownlists

            Dim PartnersDataTable, DT2 As New DataTable

            Dim BreedsDataTable, BreedsDataTable2 As New DataTable

            'For Partners data
            Try

                SelectPartnersData.Fill(PartnersDataTable)
                With DropDownList3
                    .DataSource = PartnersDataTable
                    .DataTextField = "PartnerName"
                    .DataValueField = "SourceCode"
                    .DataBind()
                    .Items.Insert(0, "Please select")
                    .Items.Add("Other")
                End With
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            'For Breed data
            Try

                SelectBreedsData.Fill(BreedsDataTable)

                With DropDownList4
                    .DataSource = BreedsDataTable
                    .DataTextField = "BreedName"
                    .DataValueField = "BreedID"
                    .DataBind()
                    .Items.Insert(0, "Please select")
                    .Items.Add("Other")
                End With
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try

            'For Breed data2/ second dropdownlist
            Try

                SelectBreedsData.Fill(BreedsDataTable2)

                With DropDownList5
                    .DataSource = BreedsDataTable
                    .DataTextField = "BreedName"
                    .DataValueField = "BreedID"
                    .DataBind()
                    .Items.Insert(0, "Select second breed")
                    .Items.Add("Other")
                End With
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Dog_Init(sender As Object, e As EventArgs) Handles Me.Init 'Page initialization

        ' No operations are defined for page initialization currently.

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Declaring variables

        Dim DogNamee As String = DogName.Text

        Dim Sexx As String = DropDownList1.SelectedItem.Text
        Dim PartnerNamee As String = DropDownList3.SelectedItem.Text
        Dim Outcomee As String = DropDownList2.SelectedItem.Text
        Dim Agee As Nullable(Of Integer) 'this datatype allows the variable to be Null so that the database can store Null values

        ' Define MicrochipNumberr as a String to hold the microchip number
        Dim MicrochipNumberr As String = MicrochipNumber.Text

        Dim IntakeDatee As Date

        ' --- VALIDATIONS START ---

        ' Validate DogName input - Check if it's empty
        If String.IsNullOrEmpty(DogNamee) Then
            MessageBox.Text = "Please enter a dog name"
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If

        'Validate Microchip number - Check if it's empty
        If String.IsNullOrEmpty(MicrochipNumberr) Then
            MessageBox.Text = "Please enter a Microchip number"
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If

        ' Validate IntakeDate - Check if the input is a valid date/ Parsing needed to convert the input to a suitable data type for processing. If the input field is empty it will throw an error prompting the user to select a valid date. Parsing has two parameters IN (IntakeDate.text/what the user typed) and OUT (IntakeDatee which is a variable that will store the parsed data).

        If Not Date.TryParse(IntakeDate.Text, IntakeDatee) Then
            MessageBox.Text = "Please select a date."
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If


        ' Validate Breed by checking if "Please select" is the selected item for breed
        If Breedd = "Please select" Then
            Breedd = Nothing ' Setting Breedd to Nothing so it can be interpreted as DBNull later
        End If

        'Validate Sex
        If Sexx = "Please select" Then
            Sexx = Nothing
        End If
        'Validate Partner name
        If PartnerNamee = "Please select" Then
            PartnerNamee = Nothing
        End If
        'Valide outcome
        If Outcomee = "Please select" Then
            Outcomee = Nothing
        End If
        ' Parse and Validate Age - Check if the input is a valid integer. A temporary variable tempAge was used before storing the permenant value inside Agee.
        Dim tempAge As Integer
        If Not String.IsNullOrEmpty(Age.Text) Then
            If Integer.TryParse(Age.Text, tempAge) Then
                Agee = tempAge
            Else
                MessageBox.Text = "Please enter a valid age."
                MessageBox.CssClass = "red-message"
                Exit Sub
            End If
        End If

        'Validation when checkbox is checked
        If CheckBox1.Checked AndAlso DropDownList4.SelectedIndex > 0 Then
            If DropDownList5.SelectedIndex > 0 Then
                Dim TempBreedd1 As String = DropDownList4.SelectedItem.Text
                Dim TempBreedd2 As String = DropDownList5.SelectedItem.Text
                Breedd = TempBreedd1 & "/" & TempBreedd2
            Else
                ' Clear the selection of DropDownList5, if needed
                DropDownList5.SelectedIndex = -1

                ' Display error
                MessageBox.Text = "Please select a second breed"
                MessageBox.CssClass = "red-message"
                Exit Sub

            End If
        Else

            Breedd = DropDownList4.SelectedItem.Text

        End If

        ' --- VALIDATIONS END --- '

        ' Check if MicrochipNumber already exists in the database. Wrapping the code in a Using block assures that the connection is closed/properly disposed after the operation.

        Using checkCmd As New SqlCommand("SELECT COUNT(*) FROM DOGS WHERE MicrochipNumber = @p1", con)
            checkCmd.Parameters.AddWithValue("@p1", MicrochipNumberr)

            con.Open()
            Dim existingCount As Integer = CInt(checkCmd.ExecuteScalar())
            con.Close()

            If existingCount > 0 Then

                'Making sure the message "Dog added successfuly" from the previous transaction is not visible when this part of the code is executed

                MessageBoxSuccess.Visible = False
                MessageBoxSuccessContainer.Visible = False
                MessageBox0.Visible = True
                MessageBox0.Text = "Microchip number already exists!"
                messageBoxContainer.Visible = True
                Exit Sub
            End If
        End Using

        '--- INSERTION --- '
        ' SQL command to insert data into DOGS table
        Dim cmdInsert As New SqlCommand("Insert Into DOGS (MicrochipNumber, DogName, Breed, Sex, PartnerName, Outcome, IntakeDate, Age) Values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", con)

        With cmdInsert.Parameters
            .Clear()
            ' Adding parameters to the SQL command
            ' If MicrochipNumberr is empty, insert NULL into the database. Otherwise, insert the MicrochipNumberr value.
            .AddWithValue("@p1", If(String.IsNullOrEmpty(MicrochipNumberr), DBNull.Value, MicrochipNumberr))
            .AddWithValue("@p2", DogNamee)
            .AddWithValue("@p3", If(String.IsNullOrEmpty(Breedd), DBNull.Value, Breedd))
            .AddWithValue("@p4", If(String.IsNullOrEmpty(Sexx), DBNull.Value, Sexx))
            .AddWithValue("@p5", If(String.IsNullOrEmpty(PartnerNamee), DBNull.Value, PartnerNamee))
            .AddWithValue("@p6", If(String.IsNullOrEmpty(Outcomee), DBNull.Value, Outcomee))
            .AddWithValue("@p7", IntakeDatee)
            ' If Agee has a value, insert that value into the database. Otherwise, insert NULL.
            .AddWithValue("@p8", If(Agee.HasValue, Agee.Value, DBNull.Value))
        End With


        Try
            If con.State = ConnectionState.Closed Then con.Open()

            cmdInsert.ExecuteNonQuery()
            messageBoxContainer.Visible = False
            MessageBoxSuccess.Text = "Dog added successfully"
            MessageBoxSuccess.Visible = True
            MessageBoxSuccessContainer.Visible = True
            MessageBox0.Visible = False
            EditButton.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "HideMessageBox", "setTimeout(hideMessageBox, 1000);", True) 'Javascript to hide the message after 1 seconds

            '   ' Clear all input fields for a fresh entry
            DogName.Text = ""
            DropDownList4.SelectedIndex = -1
            DropDownList1.SelectedIndex = -1
            DropDownList3.SelectedIndex = -1
            DropDownList2.SelectedIndex = -1
            DropDownList5.SelectedIndex = -1
            DropDownList5.Visible = False
            CheckBox1.Checked = False
            Age.Text = ""
            MicrochipNumber.Text = ""
            IntakeDate.Text = ""
            MessageBox.Text = ""
            MessageBox0.Text = ""

        Catch ex As Exception
            MessageBox0.Visible = True
            MessageBox0.Text = ex.Message
            messageBoxContainer.Visible = True

            'close the connection 

        Finally
            con.Close()
        End Try


        ''----DISPLAY/OUTPUT ADDED DOG -- '

        Dim DogGrid As New SqlDataAdapter("Select * from Dogs where MicrochipNumber = @p1", con)
        Dim DogGridDataTable As New DataTable
        With DogGrid.SelectCommand.Parameters
            .Clear()
            .AddWithValue("@p1", MicrochipNumberr)
        End With
        Try
            DogGrid.Fill(DogGridDataTable)
            AddedRecordGrideview.DataSource = DogGridDataTable
            AddedRecordGrideview.DataBind()

            EditButton.Visible = True
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

    End Sub

    'EVENT HANDLER WHEN CHECKBOX IS CLICKED
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        DropDownList5.Visible = True


        'Making sure the message "Dog added successfuly" from the previous transacation is not visible when the checkbox is clicked

        MessageBoxSuccess.Visible = False
        MessageBoxSuccessContainer.Visible = False

        'Hide dropdownlist for second breed if checkbox is unchecked

        If CheckBox1.Checked = False Then
            DropDownList5.Visible = False
        End If
    End Sub

    Protected Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click

        'Making sure the message "Dog added successfuly" from the previous transacation is not visible when the edit button is clicked

        MessageBoxSuccess.Visible = False
        MessageBoxSuccessContainer.Visible = False
        Button1.Visible = False
        UpdateButton.Visible = True
        CancelUpdateButton.Visible = True
        DeleteButton.Visible = True


        'Retrieve the last record from the databse

        Dim SelectLastRecord As New SqlCommand("SELECT TOP 1 * FROM Dogs ORDER BY DogID DESC", con)

        Try
            con.Open()

            'Used SqlDataReader to fetch the last record from the database. SqlDataAdapter can be used if working with data table but SqlDataReader is more efficient for retrieving a single-row result

            Dim reader As SqlDataReader = SelectLastRecord.ExecuteReader()

            If reader.Read() Then
                MicrochipNumber.Text = reader("MicrochipNumber").ToString()
                DogName.Text = reader("DogName").ToString()
                DropDownList4.SelectedItem.Text = reader("Breed").ToString()
                DropDownList1.SelectedItem.Text = reader("Sex").ToString
                DropDownList3.SelectedItem.Text = reader("PartnerName").ToString
                DropDownList2.SelectedItem.Text = reader("Outcome").ToString
                IntakeDate.Text = Convert.ToDateTime(reader("IntakeDate")).ToString("yyyy-MM-dd")
                Age.Text = reader("Age").ToString

                'Fetch DogID but it will not show on the front end since it is hidden. This is just to help with update/delete. DogID is auto-incremented in the database.

                HiddenDogID.Value = reader("DogID").ToString()

            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Protected Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        ''Saving current values to ViewState when editing begins

        'ViewState("OriginalData") = New Dictionary(Of String, String) From {
        '{"DogName", DogName.Text},
        '{"MicrochipNumber", MicrochipNumber.Text},

        'Declaring variables

        Dim DogNamee As String = DogName.Text

        Dim Sexx As String = DropDownList1.SelectedItem.Text
        Dim PartnerNamee As String = DropDownList3.SelectedItem.Text
        Dim Outcomee As String = DropDownList2.SelectedItem.Text
        Dim Agee As Nullable(Of Integer) 'this datatype allows the variable to be Null so that the database can store Null values

        ' Define MicrochipNumberr as a String to hold the microchip number
        Dim MicrochipNumberr As String = MicrochipNumber.Text

        Dim IntakeDatee As Date

        ' --- VALIDATIONS START ---

        ' Validate DogName input - Check if it's empty
        If String.IsNullOrEmpty(DogNamee) Then
            MessageBox.Text = "Please enter a dog name"
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If

        'Validate Microchip number - Check if it's empty
        If String.IsNullOrEmpty(MicrochipNumberr) Then
            MessageBox.Text = "Please enter a Microchip number"
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If

        ' Validate IntakeDate - Check if the input is a valid date/ Parsing needed to convert the input to a suitable data type for processing. If the input field is empty it will throw an error prompting the user to select a valid date. Parsing has two parameters IN (IntakeDate.text/what the user typed) and OUT (IntakeDatee which is a variable that will store the parsed data).

        If Not Date.TryParse(IntakeDate.Text, IntakeDatee) Then
            MessageBox.Text = "Please select a date."
            MessageBox.CssClass = "red-message"
            Exit Sub
        End If


        ' Validate Breed by checking if "Please select" is the selected item for breed
        If Breedd = "Please select" Then
            Breedd = Nothing ' Setting Breedd to Nothing so it can be interpreted as DBNull later
        End If

        'Validate Sex
        If Sexx = "Please select" Then
            Sexx = Nothing
        End If
        'Validate Partner name
        If PartnerNamee = "Please select" Then
            PartnerNamee = Nothing
        End If
        'Valide outcome
        If Outcomee = "Please select" Then
            Outcomee = Nothing
        End If
        ' Parse and Validate Age - Check if the input is a valid integer. A temporary variable tempAge was used before storing the permenant value inside Agee.
        Dim tempAge As Integer
        If Not String.IsNullOrEmpty(Age.Text) Then
            If Integer.TryParse(Age.Text, tempAge) Then
                Agee = tempAge
            Else
                MessageBox.Text = "Please enter a valid age."
                MessageBox.CssClass = "red-message"
                Exit Sub
            End If
        End If

        'Validation when checkbox is checked
        If CheckBox1.Checked AndAlso DropDownList4.SelectedIndex > 0 Then
            If DropDownList5.SelectedIndex > 0 Then
                Dim TempBreedd1 As String = DropDownList4.SelectedItem.Text
                Dim TempBreedd2 As String = DropDownList5.SelectedItem.Text
                Breedd = TempBreedd1 & "/" & TempBreedd2
            Else
                ' Clear the selection of DropDownList5, if needed
                DropDownList5.SelectedIndex = -1

                ' Display error
                MessageBox.Text = "Please select a second breed"
                MessageBox.CssClass = "red-message"
                Exit Sub

            End If
        Else

            Breedd = DropDownList4.SelectedItem.Text

        End If

        ' --- VALIDATIONS END --- '

        Dim cmdUpdate As New SqlCommand("Update DOGS set MicrochipNumber = @p1, DogName = @p2, Breed = @p3, Sex = @p4, PartnerName = @p5, Outcome = @p6, IntakeDate = @p7, Age = @p8 where DogID = @p9", con)
        With cmdUpdate.Parameters
            .Clear()
            ' Adding parameters to the SQL command
            ' If MicrochipNumberr is empty, insert NULL into the database. Otherwise, insert the MicrochipNumberr value.

            .AddWithValue("@p1", If(String.IsNullOrEmpty(MicrochipNumberr), DBNull.Value, MicrochipNumberr))
            .AddWithValue("@p2", DogNamee)
            .AddWithValue("@p3", If(String.IsNullOrEmpty(Breedd), DBNull.Value, Breedd))
            .AddWithValue("@p4", If(String.IsNullOrEmpty(Sexx), DBNull.Value, Sexx))
            .AddWithValue("@p5", If(String.IsNullOrEmpty(PartnerNamee), DBNull.Value, PartnerNamee))
            .AddWithValue("@p6", If(String.IsNullOrEmpty(Outcomee), DBNull.Value, Outcomee))
            .AddWithValue("@p7", IntakeDatee)
            ' If Agee has a value, insert that value into the database. Otherwise, insert NULL.
            .AddWithValue("@p8", If(Agee.HasValue, Agee.Value, DBNull.Value))
            .AddWithValue("@p9", Convert.ToInt32(HiddenDogID.Value))
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdUpdate.ExecuteNonQuery()
            messageBoxContainer.Visible = False
            MessageBoxSuccess.Text = "Record updated successfully"
            MessageBoxSuccess.Visible = True
            MessageBoxSuccessContainer.Visible = True
            MessageBox0.Visible = False
            EditButton.Visible = True

            ClientScript.RegisterStartupScript(Me.GetType(), "HideMessageBox", "setTimeout(hideMessageBox, 1000);", True) 'Javascript to hide the message after 1 seconds

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try

        ' After the update, the gridview is refreshed to show the updated data
        RefreshGridView(MicrochipNumber.Text)
    End Sub

    '-- PRIVATE SUBS TO REFRESH THE GRID AFTER UPDATE--'

    Private Sub RefreshGridView(microchipNumber As String)
        'fetch the updated data for the specfic microchip number

        Dim updateData As DataTable = GetUpdatedData(microchipNumber)

        'set updated data as datasource and rebind gridview

        AddedRecordGrideview.DataSource = updateData
        AddedRecordGrideview.DataBind()
    End Sub
    Private Function GetUpdatedData(microchipNumber As String) As DataTable

        'creating new DataTable
        Dim updateDataTable As New DataTable()

        'creating a new datatable to fetch the updated data for the specific microchip number
        Dim selectQuery As String = "SELECT * FROM Dogs WHERE MicrochipNumber = @p1"

        'Sqlcommand to execute the query

        Using command As New SqlCommand(selectQuery, con)
            command.Parameters.AddWithValue("@p1", microchipNumber)

            'new SqlDataAdapter to execute the command and fill the DataTable
            Using adapter As New SqlDataAdapter(command)
                'fill the DataTable with the result
                adapter.Fill(updateDataTable)
            End Using
        End Using

        Return updateDataTable

    End Function

    Protected Sub CancelUpdateButton_Click(sender As Object, e As EventArgs) Handles CancelUpdateButton.Click

        '   ' Clear all input fields for a fresh entry
        DogName.Text = ""
        DropDownList4.SelectedIndex = -1
        DropDownList1.SelectedIndex = -1
        DropDownList3.SelectedIndex = -1
        DropDownList2.SelectedIndex = -1
        DropDownList5.SelectedIndex = -1
        DropDownList5.Visible = False
        CheckBox1.Checked = False
        Age.Text = ""
        MicrochipNumber.Text = ""
        IntakeDate.Text = ""
        MessageBox.Text = ""
        MessageBox0.Text = ""

        UpdateButton.Visible = False
        CancelUpdateButton.Visible = False
        Button1.Visible = True
        DeleteButton.Visible = False
        MessageBoxSuccess.Visible = False
        MessageBoxSuccessContainer.Visible = False

    End Sub

    Protected Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click

        Dim cmdDelete As New SqlCommand("DELETE From Dogs where DogID = @p1", con)

        With cmdDelete.Parameters
            .Clear()
            .AddWithValue("@p1", HiddenDogID.Value)
        End With

        Try
            If con.State = ConnectionState.Closed Then con.Open()
            cmdDelete.ExecuteNonQuery()
            messageBoxContainer.Visible = False
            MessageBoxSuccess.Text = "Record was deleted"
            MessageBoxSuccess.Visible = True
            MessageBoxSuccessContainer.Visible = True
            MessageBox0.Visible = False
            EditButton.Visible = False

            ClientScript.RegisterStartupScript(Me.GetType(), "HideMessageBox", "setTimeout(hideMessageBox, 1000);", True) 'Javascript to hide the message after 1 seconds

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            con.Close()
        End Try

        ' After the update, the gridview is refreshed to show the updated data and clear all output

        '   ' Clear all input fields for a fresh entry
        DogName.Text = ""
        DropDownList4.SelectedIndex = -1
        DropDownList1.SelectedIndex = -1
        DropDownList3.SelectedIndex = -1
        DropDownList2.SelectedIndex = -1
        DropDownList5.SelectedIndex = -1
        DropDownList5.Visible = False
        CheckBox1.Checked = False
        Age.Text = ""
        MicrochipNumber.Text = ""
        IntakeDate.Text = ""
        MessageBox.Text = ""
        MessageBox0.Text = ""

        RefreshGridView(MicrochipNumber.Text)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles SearchButton.Click

        If TextBoxSearch.Text = Nothing Then
            Response.Write("Please enter a microchip number or dog name.")
            Exit Sub
        End If
        If RadioButtonSearchOptions.SelectedIndex = 0 Then
            Dim DAMicro As New SqlDataAdapter("Select * from Dogs where MicrochipNumber = @p1", con)
            Dim DT As New DataTable
            Dim Search As String

            Search = TextBoxSearch.Text



            With DAMicro.SelectCommand.Parameters
                .Clear()
                .AddWithValue("@p1", Search)
            End With

            DAMicro.Fill(DT)
            AddedRecordGrideview.DataSource = DT
            AddedRecordGrideview.DataBind()


            If DT.Rows.Count = 0 Then
                Response.Write("No records found!")
            End If

        ElseIf RadioButtonSearchOptions.SelectedIndex = 1 Then
            'code for search by name
            Dim DAName As New SqlDataAdapter("Select * from Dogs where Dogname like '%' + @p1 + '%'", con)
            Dim DT As New DataTable
            Dim Search As String

            Search = TextBoxSearch.Text

            With DAName.SelectCommand.Parameters
                .Clear()
                .AddWithValue("@p1", Search)
            End With

            DAName.Fill(DT)
            AddedRecordGrideview.DataSource = DT
            AddedRecordGrideview.DataBind()


            If DT.Rows.Count = 0 Then
                messageBoxContainer.Visible = True
                MessageBoxSuccess.Visible = False
                MessageBoxSuccessContainer.Visible = False
                MessageBox0.Text = "No record found!"
                MessageBox0.Visible = True

                EditButton.Visible = False

            End If
        Else
            Response.Write("Please select an option from the list!")
        End If

    End Sub

End Class

