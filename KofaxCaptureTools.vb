Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Namespace KofaxCaptureTools

    Public Class CaptureModelTools


        Private _ACsyscfg As AscentCaptureSetup
        Public ReadOnly Property ACsyscfg As AscentCaptureSetup
            Get
                Return _ACsyscfg
            End Get
        End Property


        Public Function ExtractCABFile(ByVal cabFilePath As String) As AscentCaptureSetup
            Dim extrarchivefile As New SevenZipExtractor.ArchiveFile(cabFilePath)
            Dim tmpPath As String = Path.GetTempPath()

            'create a new temp folder
            tmpPath = Path.Combine(tmpPath, "1159_KC_" & Path.GetRandomFileName())
            'create a new temp folder
            Directory.CreateDirectory(tmpPath)

            ' Set the output directory for the extracted files                                                                                          
            extrarchivefile.Extract(tmpPath)

            'Deserialoze the XML file
            _ACsyscfg = DeserializeXML(Path.Combine(tmpPath, "admin.xml"))

            'remove the temp folder
            Directory.Delete(tmpPath, True)

            Return _ACsyscfg

        End Function

#Region "General Tools"
        Private Sub RemoveDoctype(xmlFilePath As String)
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(xmlFilePath)
            Dim iNode As Integer
            For iNode = 0 To xmlDoc.ChildNodes.Count - 1
                If xmlDoc.ChildNodes(iNode).OuterXml.Contains("DOCTYPE") Then
                    xmlDoc.RemoveChild(xmlDoc.ChildNodes(iNode))
                    xmlDoc.Save(xmlFilePath)
                    Exit For
                End If
            Next
        End Sub


#End Region

#Region "ConversionTools"
        Private Sub CreateXSDFromXML(xmlFilePath As String, xsdFilePath As String)
            Try
                RemoveDoctype(xmlFilePath)
                Dim xmlReader As XmlReader = XmlReader.Create(xmlFilePath)
                Dim xsdInference As New XmlSchemaInference()
                Dim xsdSchemaSet As XmlSchemaSet = xsdInference.InferSchema(xmlReader)

                Using writer As New StreamWriter(xsdFilePath)
                    For Each schema As XmlSchema In xsdSchemaSet.Schemas()
                        schema.Write(writer)
                    Next
                End Using

            Catch ex As Exception
                Console.WriteLine("An error occurred: " & ex.Message)
            End Try
        End Sub
#End Region

#Region "Serialize/Deserialize"


        'Deserialize an XML file to a class
        Private Function DeserializeXML(ByVal xmlFilePath As String) As AscentCaptureSetup
            Dim serializer As New XmlSerializer(GetType(AscentCaptureSetup))
            Dim oACXml As AscentCaptureSetup
            Using fileStream As New FileStream(xmlFilePath, FileMode.Open)
                oACXml = DirectCast(serializer.Deserialize(fileStream), AscentCaptureSetup)
            End Using
            Return oACXml
        End Function

        'Deserialize an XML file to a class
        Private Sub DeserializeXML(ByVal xmlFilePath As String, ByVal xsdFilePath As String)
            Dim serializer As New XmlSerializer(GetType(AscentCaptureSetup))
            Using fileStream As New FileStream(xmlFilePath, FileMode.Open)
                Dim kofaxXML As AscentCaptureSetup = DirectCast(serializer.Deserialize(fileStream), AscentCaptureSetup)
            End Using
        End Sub

        Private Sub DeserializeXML(ByVal xmlFilePath As String, ByVal xsdFilePath As String, ByVal xsdSchema As String)
            Dim serializer As New XmlSerializer(GetType(AscentCaptureSetup))
            Using fileStream As New FileStream(xmlFilePath, FileMode.Open)
                Dim kofaxXML As AscentCaptureSetup = DirectCast(serializer.Deserialize(fileStream), AscentCaptureSetup)
            End Using
        End Sub

        'Serialize a class to an XML file
        Private Sub SerializeXML(ByVal xmlFilePath As String)
            Dim serializer As New XmlSerializer(GetType(AscentCaptureSetup))
            Using fileStream As New FileStream(xmlFilePath, FileMode.Create)
                serializer.Serialize(fileStream, New AscentCaptureSetup())
            End Using
        End Sub

        'Serialize a class to an XML file
        Private Sub SerializeXML(ByVal xmlFilePath As String, ByVal xsdFilePath As String)
            Dim serializer As New XmlSerializer(GetType(AscentCaptureSetup))
            Using fileStream As New FileStream(xmlFilePath, FileMode.Create)
                serializer.Serialize(fileStream, New AscentCaptureSetup())
            End Using
        End Sub
#End Region


    End Class

End Namespace
