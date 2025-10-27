Imports Newtonsoft.Json

Public Class _Default
    Inherits Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub



    Protected Sub btnAction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAction.Click
        Dim txtNumber As Double = 0
        Try
            txtNumber = Double.Parse(InptTxtNumber.Text)
        Catch ex As Exception
            txtNumber = 0
        End Try

        Dim rep As New Representation()


        LblNumber.Text = rep.Convert(txtNumber)


    End Sub


End Class

