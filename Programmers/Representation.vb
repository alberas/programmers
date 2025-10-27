Imports System

Public Class Representation

    Private Property dict As Dictionary(Of Integer, String)

    Public Sub New()
        dict = New Dictionary(Of Integer, String)

        dict.Add(0, "")
        dict.Add(1, "One")
        dict.Add(2, "Two")
        dict.Add(3, "Three")
        dict.Add(4, "Four")
        dict.Add(5, "Five")
        dict.Add(6, "Six")
        dict.Add(7, "Seven")
        dict.Add(8, "Eight")
        dict.Add(9, "Nine")
        dict.Add(10, "Ten")
        dict.Add(11, "Eleven")
        dict.Add(12, "Twelve")
        dict.Add(13, "Thirteen")
        dict.Add(14, "Fourteen")
        dict.Add(15, "Fifteen")
        dict.Add(16, "Sixteen")
        dict.Add(17, "Seventeen")
        dict.Add(18, "Eighteen")
        dict.Add(19, "Nineteen")
        dict.Add(20, "Twenty")
        dict.Add(30, "Thirty")
        dict.Add(40, "Fourty")
        dict.Add(50, "Fifty")
        dict.Add(60, "Sixty")
        dict.Add(70, "Seventy")
        dict.Add(80, "Eighty")
        dict.Add(90, "Ninety")
    End Sub

    Public Function Convert(num As String) As String
        Dim txtNumber As Integer = Integer.Parse(num)

        Dim str As New List(Of String)

        If txtNumber < 0 Then
            str.Add("Minus")
            txtNumber = Math.Abs(txtNumber)
        End If

        Dim numBillion As Integer = Math.Floor(txtNumber / 1000000000)
        Dim numMillion As Integer = Math.Floor(txtNumber / 1000000)
        Dim numThousand As Integer = Math.Floor(txtNumber / 1000)
        Dim numHundred As Long = Math.Floor(txtNumber / 100)


        If (numBillion > 0) Then
            Dim billionPart As Long = Long.Parse(numBillion) * Long.Parse(1000000000)
            str.Add(Me.WriteHundred(numBillion) & " Billion")
            txtNumber = txtNumber - billionPart
        End If
        If txtNumber > 1000000 Then
            numMillion = Math.Floor(txtNumber / 1000000)
            Dim millionPart As Long = numMillion * 1000000
            str.Add(Me.WriteHundred(numMillion) & " Million")
            txtNumber = txtNumber - millionPart
        End If
        If txtNumber >= 1000 Then
            numThousand = Math.Floor(txtNumber / 1000)
            Dim thousandPart As Long = numThousand * 1000
            str.Add(Me.WriteHundred(numThousand) & " Thoudsand")
            txtNumber = txtNumber - thousandPart
        End If
        If txtNumber >= 100 Then
            numHundred = Math.Floor(txtNumber / 100)
            Dim hundredPart As Integer = numHundred * 100
            str.Add(Me.WriteHundred(numHundred) & " Hundred")
            txtNumber = txtNumber - hundredPart
        End If


        If txtNumber >= 0 Then
            str.Add(Me.WriteUnits(txtNumber))
            str.Add("Dollars")

            Dim dec As Integer = Math.Round(100 * (txtNumber - Integer.Parse(Math.Truncate(txtNumber))))
            If dec > 0 Then
                str.Add("And")
                str.Add(Me.WriteUnits(dec) & " cents")
            End If
        End If



        Return Strings.Join(str.ToArray)
    End Function


    Public Function WriteHundred(ByVal hundred As Integer) As String
        Dim ret As String = ""
        Dim res As Integer = Math.Floor(hundred / 100)
        If res > 0 Then
            ret = dict(res) & " hundred "
        End If

        ret = ret & WriteHDozens(hundred)

        Return ret
    End Function
    Public Function WriteHDozens(ByVal dozen As Integer) As String
        Dim ret As String = ""
        Dim counter As Integer = 1
        While (dozen >= 100)
            dozen = dozen - 100
            counter = counter + 1
        End While

        ret = WriteUnits(dozen)
        Return ret
    End Function
    Public Function WriteUnits(ByVal unit As Integer) As String
        If unit <= 19 Then
            Return dict(unit)
        Else
            Dim rest As Integer = Math.Floor(unit Mod 10)
            Return dict(unit - rest) & " " & dict(rest)
        End If
    End Function

End Class
