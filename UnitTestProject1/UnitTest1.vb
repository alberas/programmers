Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Programmers

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim form1 As New Representation()
        Console.WriteLine(form1.Convert("4546456"))



    End Sub

End Class