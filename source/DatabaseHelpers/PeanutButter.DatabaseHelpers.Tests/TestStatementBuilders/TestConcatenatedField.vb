Imports NUnit.Framework
Imports PeanutButter.DatabaseHelpers.StatementBuilders
Imports PeanutButter.RandomGenerators

Namespace TestStatementBuilders

    <TestFixture()>
    Public class TestConcatenatedField
        <Test()>
        Public Sub ToString_ShouldProvideConcatenatedResultOfStringFields_WithAlias()
            Dim field1 = RandomValueGen.GetRandomString(2),
                field2 = RandomValueGen.GetRandomString(3),
                theAlias = RandomValueGen.GetRandomString(2)
            Dim sut = new ConcatenatedField(theAlias, field1, field2)
            Assert.AreEqual("[" + field1 + "]+[" + field2 + "] as [" + theAlias + "]", sut.ToString())
        End Sub

        <Test()>
        Public Sub ToString_ShouldProvideConcatenatedResultsOfSelectFields_WithAlias()
            Dim field1 = New SelectField(RandomValueGen.GetRandomString(2)),
                field2 = New SelectField(RandomValueGen.GetRandomString(2)),
                theAlias = RandomValueGen.GetRandomString(2)
            Dim sut = new ConcatenatedField(theAlias, field1, field2)
            Assert.AreEqual(field1.ToString() + "+" + field2.ToString() + " as [" + theAlias + "]", sut.ToString())

        End Sub
    End Class
End NameSpace