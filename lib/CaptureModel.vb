Imports System.IO
Imports System.Collections.Generic

Namespace KofaxCaptureTools

#Region "Base entity class"
    Partial Public Class EntityBase(Of T)

        Private Shared sSerializer As System.Xml.Serialization.XmlSerializer

        Private Shared ReadOnly Property Serializer() As System.Xml.Serialization.XmlSerializer
            Get
                If (sSerializer Is Nothing) Then
                    sSerializer = New System.Xml.Serialization.XmlSerializer(GetType(T))
                End If
                Return sSerializer
            End Get
        End Property

#Region "Serialize/Deserialize"
        '''<summary>
        '''Serializes current EntityBase object into an XML document
        '''</summary>
        '''<returns>string XML value</returns>
        <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")>
        Public Overridable Function Serialize() As String
            Dim streamReader As System.IO.StreamReader = Nothing
            Dim memoryStream As System.IO.MemoryStream = Nothing
            Try
                memoryStream = New System.IO.MemoryStream()
                Serializer.Serialize(memoryStream, Me)
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin)
                streamReader = New System.IO.StreamReader(memoryStream)
                Return streamReader.ReadToEnd
            Finally
                If (Not (streamReader) Is Nothing) Then
                    streamReader.Dispose()
                End If
                If (Not (memoryStream) Is Nothing) Then
                    memoryStream.Dispose()
                End If
            End Try
        End Function

        '''<summary>
        '''Deserializes workflow markup into an EntityBase object
        '''</summary>
        '''<param name="xml">string workflow markup to deserialize</param>
        '''<param name="obj">Output EntityBase object</param>
        '''<param name="exception">output Exception value if deserialize failed</param>
        '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        Public Overloads Shared Function Deserialize(ByVal xml As String, ByRef obj As T, ByRef exception As System.Exception) As Boolean
            exception = Nothing
            obj = CType(Nothing, T)
            Try
                obj = Deserialize(xml)
                Return True
            Catch ex As System.Exception
                exception = ex
                Return False
            End Try
        End Function

        Public Overloads Shared Function Deserialize(ByVal xml As String, ByRef obj As T) As Boolean
            Dim exception As System.Exception = Nothing
            Return Deserialize(xml, obj, exception)
        End Function

        Public Overloads Shared Function Deserialize(ByVal xml As String) As T
            Dim stringReader As System.IO.StringReader = Nothing
            Try
                stringReader = New System.IO.StringReader(xml)
                Return CType(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader)), T)
            Finally
                If (Not (stringReader) Is Nothing) Then
                    stringReader.Dispose()
                End If
            End Try
        End Function

        '''<summary>
        '''Serializes current EntityBase object into file
        '''</summary>
        '''<param name="fileName">full path of outupt xml file</param>
        '''<param name="exception">output Exception value if failed</param>
        '''<returns>true if can serialize and save into file; otherwise, false</returns>
        Public Overridable Overloads Function SaveToFile(ByVal fileName As String, ByRef exception As System.Exception) As Boolean
            exception = Nothing
            Try
                SaveToFile(fileName)
                Return True
            Catch e As System.Exception
                exception = e
                Return False
            End Try
        End Function

        <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")>
        Public Overridable Overloads Sub SaveToFile(ByVal fileName As String)
            Dim streamWriter As System.IO.StreamWriter = Nothing
            Try
                Dim xmlString As String = Serialize()
                Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
                streamWriter = xmlFile.CreateText
                streamWriter.WriteLine(xmlString)
                streamWriter.Close()
            Finally
                If (Not (streamWriter) Is Nothing) Then
                    streamWriter.Dispose()
                End If
            End Try
        End Sub

        '''<summary>
        '''Deserializes xml markup from file into an EntityBase object
        '''</summary>
        '''<param name="fileName">string xml file to load and deserialize</param>
        '''<param name="obj">Output EntityBase object</param>
        '''<param name="exception">output Exception value if deserialize failed</param>
        '''<returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        Public Overloads Shared Function LoadFromFile(ByVal fileName As String, ByRef obj As T, ByRef exception As System.Exception) As Boolean
            exception = Nothing
            obj = CType(Nothing, T)
            Try
                obj = LoadFromFile(fileName)
                Return True
            Catch ex As System.Exception
                exception = ex
                Return False
            End Try
        End Function

        Public Overloads Shared Function LoadFromFile(ByVal fileName As String, ByRef obj As T) As Boolean
            Dim exception As System.Exception = Nothing
            Return LoadFromFile(fileName, obj, exception)
        End Function

        <CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")>
        Public Overloads Shared Function LoadFromFile(ByVal fileName As String) As T
            Dim file As System.IO.FileStream = Nothing
            Dim sr As System.IO.StreamReader = Nothing
            Try
                file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
                sr = New System.IO.StreamReader(file)
                Dim xmlString As String = sr.ReadToEnd
                sr.Close()
                file.Close()
                Return Deserialize(xmlString)
            Finally
                If (Not (file) Is Nothing) Then
                    file.Dispose()
                End If
                If (Not (sr) Is Nothing) Then
                    sr.Dispose()
                End If
            End Try
        End Function
#End Region
    End Class
#End Region

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="", IsNullable:=False)>
    Partial Public Class AscentCaptureSetup
        Inherits EntityBase(Of AscentCaptureSetup)

        Private scriptsField As List(Of AscentCaptureSetupScript)

        Private releaseScriptsField As AscentCaptureSetupReleaseScripts

        Private imageCleanupProfilesField As List(Of AscentCaptureSetupImageCleanupProfile)

        Private colorImageCleanupProfilesField As AscentCaptureSetupColorImageCleanupProfiles

        Private imageCompressionProfilesField As AscentCaptureSetupImageCompressionProfiles

        Private functionsField As List(Of AscentCaptureSetupFunction)

        Private processesField As List(Of AscentCaptureSetupProcess)

        Private recognitionProfilesField As List(Of AscentCaptureSetupRecognitionProfile)

        Private separationFormIDProfilesField As List(Of AscentCaptureSetupSeparationFormIDProfile)

        Private fieldTypesField As List(Of AscentCaptureSetupFieldType)

        Private documentClassesField As List(Of AscentCaptureSetupDocumentClass)

        Private batchClassesField As List(Of AscentCaptureSetupBatchClass)

        Private databaseVersionField As Byte

        Private dataDefinitionVersionField As Byte

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("Script", IsNullable:=False)>
        Public Property Scripts() As List(Of AscentCaptureSetupScript)
            Get
                Return Me.scriptsField
            End Get
            Set
                Me.scriptsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
        Public Property ReleaseScripts() As AscentCaptureSetupReleaseScripts
            Get
                Return Me.releaseScriptsField
            End Get
            Set
                Me.releaseScriptsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=2),
         System.Xml.Serialization.XmlArrayItemAttribute("ImageCleanupProfile", IsNullable:=False)>
        Public Property ImageCleanupProfiles() As List(Of AscentCaptureSetupImageCleanupProfile)
            Get
                Return Me.imageCleanupProfilesField
            End Get
            Set
                Me.imageCleanupProfilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=3)>
        Public Property ColorImageCleanupProfiles() As AscentCaptureSetupColorImageCleanupProfiles
            Get
                Return Me.colorImageCleanupProfilesField
            End Get
            Set
                Me.colorImageCleanupProfilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=4)>
        Public Property ImageCompressionProfiles() As AscentCaptureSetupImageCompressionProfiles
            Get
                Return Me.imageCompressionProfilesField
            End Get
            Set
                Me.imageCompressionProfilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=5),
         System.Xml.Serialization.XmlArrayItemAttribute("Function", IsNullable:=False)>
        Public Property Functions() As List(Of AscentCaptureSetupFunction)
            Get
                Return Me.functionsField
            End Get
            Set
                Me.functionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=6),
         System.Xml.Serialization.XmlArrayItemAttribute("Process", IsNullable:=False)>
        Public Property Processes() As List(Of AscentCaptureSetupProcess)
            Get
                Return Me.processesField
            End Get
            Set
                Me.processesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=7),
         System.Xml.Serialization.XmlArrayItemAttribute("RecognitionProfile", IsNullable:=False)>
        Public Property RecognitionProfiles() As List(Of AscentCaptureSetupRecognitionProfile)
            Get
                Return Me.recognitionProfilesField
            End Get
            Set
                Me.recognitionProfilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=8),
         System.Xml.Serialization.XmlArrayItemAttribute("SeparationFormIDProfile", IsNullable:=False)>
        Public Property SeparationFormIDProfiles() As List(Of AscentCaptureSetupSeparationFormIDProfile)
            Get
                Return Me.separationFormIDProfilesField
            End Get
            Set
                Me.separationFormIDProfilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=9),
         System.Xml.Serialization.XmlArrayItemAttribute("FieldType", IsNullable:=False)>
        Public Property FieldTypes() As List(Of AscentCaptureSetupFieldType)
            Get
                Return Me.fieldTypesField
            End Get
            Set
                Me.fieldTypesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=10),
         System.Xml.Serialization.XmlArrayItemAttribute("DocumentClass", IsNullable:=False)>
        Public Property DocumentClasses() As List(Of AscentCaptureSetupDocumentClass)
            Get
                Return Me.documentClassesField
            End Get
            Set
                Me.documentClassesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=11),
         System.Xml.Serialization.XmlArrayItemAttribute("BatchClass", IsNullable:=False)>
        Public Property BatchClasses() As List(Of AscentCaptureSetupBatchClass)
            Get
                Return Me.batchClassesField
            End Get
            Set
                Me.batchClassesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DatabaseVersion() As Byte
            Get
                Return Me.databaseVersionField
            End Get
            Set
                Me.databaseVersionField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DataDefinitionVersion() As Byte
            Get
                Return Me.dataDefinitionVersionField
            End Get
            Set
                Me.dataDefinitionVersionField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupScript
        Inherits EntityBase(Of AscentCaptureSetupScript)

        Private sblScriptIDField As Byte

        Private typeField As Byte

        Private nameField As String

        Private languageField As Byte

        Private languageFieldSpecified As Boolean

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SblScriptID() As Byte
            Get
                Return Me.sblScriptIDField
            End Get
            Set
                Me.sblScriptIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Type() As Byte
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Language() As Byte
            Get
                Return Me.languageField
            End Get
            Set
                Me.languageField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property LanguageSpecified() As Boolean
            Get
                Return Me.languageFieldSpecified
            End Get
            Set
                Me.languageFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupReleaseScripts
        Inherits EntityBase(Of AscentCaptureSetupReleaseScripts)

        Private releaseScriptField As AscentCaptureSetupReleaseScriptsReleaseScript

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ReleaseScript() As AscentCaptureSetupReleaseScriptsReleaseScript
            Get
                Return Me.releaseScriptField
            End Get
            Set
                Me.releaseScriptField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupReleaseScriptsReleaseScript
        Inherits EntityBase(Of AscentCaptureSetupReleaseScriptsReleaseScript)

        Private supportsNonImageFilesField As Byte

        Private remainLoadedField As Byte

        Private supportsKofaxPDFField As Byte

        Private supportsOriginalFileNameField As Byte

        Private supportsMultipleInstancesField As Byte

        Private nameField As String

        Private releaseProgIDField As String

        Private releaseVersionField As String

        Private setupProgIDField As String

        Private setupVersionField As String

        Private displayNameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsNonImageFiles() As Byte
            Get
                Return Me.supportsNonImageFilesField
            End Get
            Set
                Me.supportsNonImageFilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RemainLoaded() As Byte
            Get
                Return Me.remainLoadedField
            End Get
            Set
                Me.remainLoadedField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsKofaxPDF() As Byte
            Get
                Return Me.supportsKofaxPDFField
            End Get
            Set
                Me.supportsKofaxPDFField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsOriginalFileName() As Byte
            Get
                Return Me.supportsOriginalFileNameField
            End Get
            Set
                Me.supportsOriginalFileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsMultipleInstances() As Byte
            Get
                Return Me.supportsMultipleInstancesField
            End Get
            Set
                Me.supportsMultipleInstancesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ReleaseProgID() As String
            Get
                Return Me.releaseProgIDField
            End Get
            Set
                Me.releaseProgIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ReleaseVersion() As String
            Get
                Return Me.releaseVersionField
            End Get
            Set
                Me.releaseVersionField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SetupProgID() As String
            Get
                Return Me.setupProgIDField
            End Get
            Set
                Me.setupProgIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SetupVersion() As String
            Get
                Return Me.setupVersionField
            End Get
            Set
                Me.setupVersionField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DisplayName() As String
            Get
                Return Me.displayNameField
            End Get
            Set
                Me.displayNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupImageCleanupProfile
        Inherits EntityBase(Of AscentCaptureSetupImageCleanupProfile)

        Private whiteNoiseGapField As Byte

        Private whiteNoiseGapFieldSpecified As Boolean

        Private minShadeWidthField As Byte

        Private minShadeWidthFieldSpecified As Boolean

        Private minAngleField As Byte

        Private despecEnableField As Byte

        Private despecEnableFieldSpecified As Boolean

        Private readOnlyField As Byte

        Private readOnlyFieldSpecified As Boolean

        Private defaultForField As Byte

        Private defaultForFieldSpecified As Boolean

        Private kofaxIDField As Byte

        Private kofaxIDFieldSpecified As Boolean

        Private nameField As String

        Private scriptNameField As String

        Private deskewEnableField As Byte

        Private deskewEnableFieldSpecified As Boolean

        Private despecHeightField As Byte

        Private despecHeightFieldSpecified As Boolean

        Private despecWidthField As Byte

        Private despecWidthFieldSpecified As Boolean

        Private borderEnableField As Byte

        Private borderEnableFieldSpecified As Boolean

        Private deshadeEnableField As Byte

        Private deshadeEnableFieldSpecified As Boolean

        Private fltEnableField As Byte

        Private fltEnableFieldSpecified As Boolean

        Private fltCharSmoothingField As Byte

        Private fltCharSmoothingFieldSpecified As Boolean

        Private fltFillLineField As Byte

        Private fltFillLineFieldSpecified As Boolean

        Private fltLightThickenField As Byte

        Private fltLightThickenFieldSpecified As Boolean

        Private horzLineEnableField As Byte

        Private horzLineEnableFieldSpecified As Boolean

        Private horzCharRepairField As Byte

        Private horzCharRepairFieldSpecified As Boolean

        Private horzMinLengthField As Byte

        Private horzMinLengthFieldSpecified As Boolean

        Private vertLineEnableField As Byte

        Private vertLineEnableFieldSpecified As Boolean

        Private vertCharRepairField As Byte

        Private vertCharRepairFieldSpecified As Boolean

        Private vertMinHeightField As Byte

        Private vertMinHeightFieldSpecified As Boolean

        Private vertMaxGapField As Byte

        Private vertMaxGapFieldSpecified As Boolean

        Private horzMaxHeightField As Byte

        Private horzMaxHeightFieldSpecified As Boolean

        Private horzEdgeCleanField As Byte

        Private horzEdgeCleanFieldSpecified As Boolean

        Private horzReconHeightField As Byte

        Private horzReconHeightFieldSpecified As Boolean

        Private vertMaxWidthField As Byte

        Private vertMaxWidthFieldSpecified As Boolean

        Private vertEdgeCleanField As Byte

        Private vertEdgeCleanFieldSpecified As Boolean

        Private vertReconWidthField As Byte

        Private vertReconWidthFieldSpecified As Boolean

        Private streakWidthField As Byte

        Private streakWidthFieldSpecified As Boolean

        Private fltSmoothCleanPreserveField As Byte

        Private fltSmoothCleanPreserveFieldSpecified As Boolean

        Private fltFillLinePreserveField As Byte

        Private fltFillLinePreserveFieldSpecified As Boolean

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property WhiteNoiseGap() As Byte
            Get
                Return Me.whiteNoiseGapField
            End Get
            Set
                Me.whiteNoiseGapField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property WhiteNoiseGapSpecified() As Boolean
            Get
                Return Me.whiteNoiseGapFieldSpecified
            End Get
            Set
                Me.whiteNoiseGapFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MinShadeWidth() As Byte
            Get
                Return Me.minShadeWidthField
            End Get
            Set
                Me.minShadeWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property MinShadeWidthSpecified() As Boolean
            Get
                Return Me.minShadeWidthFieldSpecified
            End Get
            Set
                Me.minShadeWidthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MinAngle() As Byte
            Get
                Return Me.minAngleField
            End Get
            Set
                Me.minAngleField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DespecEnable() As Byte
            Get
                Return Me.despecEnableField
            End Get
            Set
                Me.despecEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DespecEnableSpecified() As Boolean
            Get
                Return Me.despecEnableFieldSpecified
            End Get
            Set
                Me.despecEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [ReadOnly]() As Byte
            Get
                Return Me.readOnlyField
            End Get
            Set
                Me.readOnlyField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ReadOnlySpecified() As Boolean
            Get
                Return Me.readOnlyFieldSpecified
            End Get
            Set
                Me.readOnlyFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultFor() As Byte
            Get
                Return Me.defaultForField
            End Get
            Set
                Me.defaultForField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DefaultForSpecified() As Boolean
            Get
                Return Me.defaultForFieldSpecified
            End Get
            Set
                Me.defaultForFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxID() As Byte
            Get
                Return Me.kofaxIDField
            End Get
            Set
                Me.kofaxIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property KofaxIDSpecified() As Boolean
            Get
                Return Me.kofaxIDFieldSpecified
            End Get
            Set
                Me.kofaxIDFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DeskewEnable() As Byte
            Get
                Return Me.deskewEnableField
            End Get
            Set
                Me.deskewEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DeskewEnableSpecified() As Boolean
            Get
                Return Me.deskewEnableFieldSpecified
            End Get
            Set
                Me.deskewEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DespecHeight() As Byte
            Get
                Return Me.despecHeightField
            End Get
            Set
                Me.despecHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DespecHeightSpecified() As Boolean
            Get
                Return Me.despecHeightFieldSpecified
            End Get
            Set
                Me.despecHeightFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DespecWidth() As Byte
            Get
                Return Me.despecWidthField
            End Get
            Set
                Me.despecWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DespecWidthSpecified() As Boolean
            Get
                Return Me.despecWidthFieldSpecified
            End Get
            Set
                Me.despecWidthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BorderEnable() As Byte
            Get
                Return Me.borderEnableField
            End Get
            Set
                Me.borderEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property BorderEnableSpecified() As Boolean
            Get
                Return Me.borderEnableFieldSpecified
            End Get
            Set
                Me.borderEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DeshadeEnable() As Byte
            Get
                Return Me.deshadeEnableField
            End Get
            Set
                Me.deshadeEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DeshadeEnableSpecified() As Boolean
            Get
                Return Me.deshadeEnableFieldSpecified
            End Get
            Set
                Me.deshadeEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltEnable() As Byte
            Get
                Return Me.fltEnableField
            End Get
            Set
                Me.fltEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltEnableSpecified() As Boolean
            Get
                Return Me.fltEnableFieldSpecified
            End Get
            Set
                Me.fltEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltCharSmoothing() As Byte
            Get
                Return Me.fltCharSmoothingField
            End Get
            Set
                Me.fltCharSmoothingField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltCharSmoothingSpecified() As Boolean
            Get
                Return Me.fltCharSmoothingFieldSpecified
            End Get
            Set
                Me.fltCharSmoothingFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltFillLine() As Byte
            Get
                Return Me.fltFillLineField
            End Get
            Set
                Me.fltFillLineField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltFillLineSpecified() As Boolean
            Get
                Return Me.fltFillLineFieldSpecified
            End Get
            Set
                Me.fltFillLineFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltLightThicken() As Byte
            Get
                Return Me.fltLightThickenField
            End Get
            Set
                Me.fltLightThickenField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltLightThickenSpecified() As Boolean
            Get
                Return Me.fltLightThickenFieldSpecified
            End Get
            Set
                Me.fltLightThickenFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzLineEnable() As Byte
            Get
                Return Me.horzLineEnableField
            End Get
            Set
                Me.horzLineEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzLineEnableSpecified() As Boolean
            Get
                Return Me.horzLineEnableFieldSpecified
            End Get
            Set
                Me.horzLineEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzCharRepair() As Byte
            Get
                Return Me.horzCharRepairField
            End Get
            Set
                Me.horzCharRepairField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzCharRepairSpecified() As Boolean
            Get
                Return Me.horzCharRepairFieldSpecified
            End Get
            Set
                Me.horzCharRepairFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzMinLength() As Byte
            Get
                Return Me.horzMinLengthField
            End Get
            Set
                Me.horzMinLengthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzMinLengthSpecified() As Boolean
            Get
                Return Me.horzMinLengthFieldSpecified
            End Get
            Set
                Me.horzMinLengthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertLineEnable() As Byte
            Get
                Return Me.vertLineEnableField
            End Get
            Set
                Me.vertLineEnableField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertLineEnableSpecified() As Boolean
            Get
                Return Me.vertLineEnableFieldSpecified
            End Get
            Set
                Me.vertLineEnableFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertCharRepair() As Byte
            Get
                Return Me.vertCharRepairField
            End Get
            Set
                Me.vertCharRepairField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertCharRepairSpecified() As Boolean
            Get
                Return Me.vertCharRepairFieldSpecified
            End Get
            Set
                Me.vertCharRepairFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertMinHeight() As Byte
            Get
                Return Me.vertMinHeightField
            End Get
            Set
                Me.vertMinHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertMinHeightSpecified() As Boolean
            Get
                Return Me.vertMinHeightFieldSpecified
            End Get
            Set
                Me.vertMinHeightFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertMaxGap() As Byte
            Get
                Return Me.vertMaxGapField
            End Get
            Set
                Me.vertMaxGapField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertMaxGapSpecified() As Boolean
            Get
                Return Me.vertMaxGapFieldSpecified
            End Get
            Set
                Me.vertMaxGapFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzMaxHeight() As Byte
            Get
                Return Me.horzMaxHeightField
            End Get
            Set
                Me.horzMaxHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzMaxHeightSpecified() As Boolean
            Get
                Return Me.horzMaxHeightFieldSpecified
            End Get
            Set
                Me.horzMaxHeightFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzEdgeClean() As Byte
            Get
                Return Me.horzEdgeCleanField
            End Get
            Set
                Me.horzEdgeCleanField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzEdgeCleanSpecified() As Boolean
            Get
                Return Me.horzEdgeCleanFieldSpecified
            End Get
            Set
                Me.horzEdgeCleanFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property HorzReconHeight() As Byte
            Get
                Return Me.horzReconHeightField
            End Get
            Set
                Me.horzReconHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property HorzReconHeightSpecified() As Boolean
            Get
                Return Me.horzReconHeightFieldSpecified
            End Get
            Set
                Me.horzReconHeightFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertMaxWidth() As Byte
            Get
                Return Me.vertMaxWidthField
            End Get
            Set
                Me.vertMaxWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertMaxWidthSpecified() As Boolean
            Get
                Return Me.vertMaxWidthFieldSpecified
            End Get
            Set
                Me.vertMaxWidthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertEdgeClean() As Byte
            Get
                Return Me.vertEdgeCleanField
            End Get
            Set
                Me.vertEdgeCleanField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertEdgeCleanSpecified() As Boolean
            Get
                Return Me.vertEdgeCleanFieldSpecified
            End Get
            Set
                Me.vertEdgeCleanFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VertReconWidth() As Byte
            Get
                Return Me.vertReconWidthField
            End Get
            Set
                Me.vertReconWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VertReconWidthSpecified() As Boolean
            Get
                Return Me.vertReconWidthFieldSpecified
            End Get
            Set
                Me.vertReconWidthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property StreakWidth() As Byte
            Get
                Return Me.streakWidthField
            End Get
            Set
                Me.streakWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property StreakWidthSpecified() As Boolean
            Get
                Return Me.streakWidthFieldSpecified
            End Get
            Set
                Me.streakWidthFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltSmoothCleanPreserve() As Byte
            Get
                Return Me.fltSmoothCleanPreserveField
            End Get
            Set
                Me.fltSmoothCleanPreserveField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltSmoothCleanPreserveSpecified() As Boolean
            Get
                Return Me.fltSmoothCleanPreserveFieldSpecified
            End Get
            Set
                Me.fltSmoothCleanPreserveFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FltFillLinePreserve() As Byte
            Get
                Return Me.fltFillLinePreserveField
            End Get
            Set
                Me.fltFillLinePreserveField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FltFillLinePreserveSpecified() As Boolean
            Get
                Return Me.fltFillLinePreserveFieldSpecified
            End Get
            Set
                Me.fltFillLinePreserveFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupColorImageCleanupProfiles
        Inherits EntityBase(Of AscentCaptureSetupColorImageCleanupProfiles)

        Private colorImageCleanupProfileField As AscentCaptureSetupColorImageCleanupProfilesColorImageCleanupProfile

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ColorImageCleanupProfile() As AscentCaptureSetupColorImageCleanupProfilesColorImageCleanupProfile
            Get
                Return Me.colorImageCleanupProfileField
            End Get
            Set
                Me.colorImageCleanupProfileField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupColorImageCleanupProfilesColorImageCleanupProfile
        Inherits EntityBase(Of AscentCaptureSetupColorImageCleanupProfilesColorImageCleanupProfile)

        Private readOnlyField As Byte

        Private defaultForField As Byte

        Private kofaxIDField As Byte

        Private nameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [ReadOnly]() As Byte
            Get
                Return Me.readOnlyField
            End Get
            Set
                Me.readOnlyField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultFor() As Byte
            Get
                Return Me.defaultForField
            End Get
            Set
                Me.defaultForField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxID() As Byte
            Get
                Return Me.kofaxIDField
            End Get
            Set
                Me.kofaxIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupImageCompressionProfiles
        Inherits EntityBase(Of AscentCaptureSetupImageCompressionProfiles)

        Private imageCompressionProfileField As AscentCaptureSetupImageCompressionProfilesImageCompressionProfile

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ImageCompressionProfile() As AscentCaptureSetupImageCompressionProfilesImageCompressionProfile
            Get
                Return Me.imageCompressionProfileField
            End Get
            Set
                Me.imageCompressionProfileField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupImageCompressionProfilesImageCompressionProfile
        Inherits EntityBase(Of AscentCaptureSetupImageCompressionProfilesImageCompressionProfile)

        Private sensitivityField As Byte

        Private backgroundQualityField As Byte

        Private pictureQualityField As Byte

        Private readOnlyField As Byte

        Private defaultForField As Byte

        Private kofaxIDField As Byte

        Private nameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Sensitivity() As Byte
            Get
                Return Me.sensitivityField
            End Get
            Set
                Me.sensitivityField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BackgroundQuality() As Byte
            Get
                Return Me.backgroundQualityField
            End Get
            Set
                Me.backgroundQualityField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PictureQuality() As Byte
            Get
                Return Me.pictureQualityField
            End Get
            Set
                Me.pictureQualityField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [ReadOnly]() As Byte
            Get
                Return Me.readOnlyField
            End Get
            Set
                Me.readOnlyField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultFor() As Byte
            Get
                Return Me.defaultForField
            End Get
            Set
                Me.defaultForField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxID() As Byte
            Get
                Return Me.kofaxIDField
            End Get
            Set
                Me.kofaxIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupFunction
        Inherits EntityBase(Of AscentCaptureSetupFunction)

        Private workflowField As Byte

        Private workflowFieldSpecified As Boolean

        Private nameField As String

        Private orderField As Byte

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Workflow() As Byte
            Get
                Return Me.workflowField
            End Get
            Set
                Me.workflowField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property WorkflowSpecified() As Boolean
            Get
                Return Me.workflowFieldSpecified
            End Get
            Set
                Me.workflowFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Order() As Byte
            Get
                Return Me.orderField
            End Get
            Set
                Me.orderField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupProcess
        Inherits EntityBase(Of AscentCaptureSetupProcess)

        Private replacesFunctionsField As List(Of AscentCaptureSetupProcessReplaces)

        Private imageIndexField As UShort

        Private customField As Byte

        Private customFieldSpecified As Boolean

        Private supportsNonImageFilesField As Byte

        Private supportsTableFieldsField As Byte

        Private nameField As String

        Private originalProcessIDField As UShort

        Private descriptionField As String

        Private programField As String

        Private moduleIDField As String

        Private versionStringField As String

        Private iconFileField As String

        Private beforeField As String

        Private afterField As String

        Private splashScreenFileField As String

        Private versionNumberField As Byte

        Private versionNumberFieldSpecified As Boolean

        Private cLPField As String

        Private setupProgramField As String

        Private setupProgramFileField As String

        Private autoSignOutField As Byte

        Private autoSignOutFieldSpecified As Boolean

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("Replaces", IsNullable:=False)>
        Public Property ReplacesFunctions() As List(Of AscentCaptureSetupProcessReplaces)
            Get
                Return Me.replacesFunctionsField
            End Get
            Set
                Me.replacesFunctionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ImageIndex() As UShort
            Get
                Return Me.imageIndexField
            End Get
            Set
                Me.imageIndexField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Custom() As Byte
            Get
                Return Me.customField
            End Get
            Set
                Me.customField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property CustomSpecified() As Boolean
            Get
                Return Me.customFieldSpecified
            End Get
            Set
                Me.customFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsNonImageFiles() As Byte
            Get
                Return Me.supportsNonImageFilesField
            End Get
            Set
                Me.supportsNonImageFilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsTableFields() As Byte
            Get
                Return Me.supportsTableFieldsField
            End Get
            Set
                Me.supportsTableFieldsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OriginalProcessID() As UShort
            Get
                Return Me.originalProcessIDField
            End Get
            Set
                Me.originalProcessIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Program() As String
            Get
                Return Me.programField
            End Get
            Set
                Me.programField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ModuleID() As String
            Get
                Return Me.moduleIDField
            End Get
            Set
                Me.moduleIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VersionString() As String
            Get
                Return Me.versionStringField
            End Get
            Set
                Me.versionStringField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property IconFile() As String
            Get
                Return Me.iconFileField
            End Get
            Set
                Me.iconFileField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Before() As String
            Get
                Return Me.beforeField
            End Get
            Set
                Me.beforeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property After() As String
            Get
                Return Me.afterField
            End Get
            Set
                Me.afterField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SplashScreenFile() As String
            Get
                Return Me.splashScreenFileField
            End Get
            Set
                Me.splashScreenFileField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property VersionNumber() As Byte
            Get
                Return Me.versionNumberField
            End Get
            Set
                Me.versionNumberField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property VersionNumberSpecified() As Boolean
            Get
                Return Me.versionNumberFieldSpecified
            End Get
            Set
                Me.versionNumberFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property CLP() As String
            Get
                Return Me.cLPField
            End Get
            Set
                Me.cLPField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SetupProgram() As String
            Get
                Return Me.setupProgramField
            End Get
            Set
                Me.setupProgramField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SetupProgramFile() As String
            Get
                Return Me.setupProgramFileField
            End Get
            Set
                Me.setupProgramFileField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AutoSignOut() As Byte
            Get
                Return Me.autoSignOutField
            End Get
            Set
                Me.autoSignOutField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property AutoSignOutSpecified() As Boolean
            Get
                Return Me.autoSignOutFieldSpecified
            End Get
            Set
                Me.autoSignOutFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupProcessReplaces
        Inherits EntityBase(Of AscentCaptureSetupProcessReplaces)

        Private functionNameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FunctionName() As String
            Get
                Return Me.functionNameField
            End Get
            Set
                Me.functionNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupRecognitionProfile
        Inherits EntityBase(Of AscentCaptureSetupRecognitionProfile)

        Private shapeOptionsField As AscentCaptureSetupRecognitionProfileShapeOptions

        Private advancedOcrOptionsField As AscentCaptureSetupRecognitionProfileAdvancedOcrOptions

        Private barCodeOptionsField As AscentCaptureSetupRecognitionProfileBarCodeOptions

        Private icrOptionsField As AscentCaptureSetupRecognitionProfileIcrOptions

        Private formIDOptionsField As Object

        Private typeField As Byte

        Private imgCompressOptIDField As String

        Private readOnlyField As Byte

        Private readOnlyFieldSpecified As Boolean

        Private defaultForField As Byte

        Private defaultForFieldSpecified As Boolean

        Private kofaxIDField As Byte

        Private kofaxIDFieldSpecified As Boolean

        Private nameField As String

        Private scriptNameField As String

        Private imageCleanupProfileNameField As String

        Private originalNameField As String

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ShapeOptions() As AscentCaptureSetupRecognitionProfileShapeOptions
            Get
                Return Me.shapeOptionsField
            End Get
            Set
                Me.shapeOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
        Public Property AdvancedOcrOptions() As AscentCaptureSetupRecognitionProfileAdvancedOcrOptions
            Get
                Return Me.advancedOcrOptionsField
            End Get
            Set
                Me.advancedOcrOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=2)>
        Public Property BarCodeOptions() As AscentCaptureSetupRecognitionProfileBarCodeOptions
            Get
                Return Me.barCodeOptionsField
            End Get
            Set
                Me.barCodeOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=3)>
        Public Property IcrOptions() As AscentCaptureSetupRecognitionProfileIcrOptions
            Get
                Return Me.icrOptionsField
            End Get
            Set
                Me.icrOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=4)>
        Public Property FormIDOptions() As Object
            Get
                Return Me.formIDOptionsField
            End Get
            Set
                Me.formIDOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Type() As Byte
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ImgCompressOptID() As String
            Get
                Return Me.imgCompressOptIDField
            End Get
            Set
                Me.imgCompressOptIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [ReadOnly]() As Byte
            Get
                Return Me.readOnlyField
            End Get
            Set
                Me.readOnlyField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ReadOnlySpecified() As Boolean
            Get
                Return Me.readOnlyFieldSpecified
            End Get
            Set
                Me.readOnlyFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultFor() As Byte
            Get
                Return Me.defaultForField
            End Get
            Set
                Me.defaultForField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property DefaultForSpecified() As Boolean
            Get
                Return Me.defaultForFieldSpecified
            End Get
            Set
                Me.defaultForFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxID() As Byte
            Get
                Return Me.kofaxIDField
            End Get
            Set
                Me.kofaxIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property KofaxIDSpecified() As Boolean
            Get
                Return Me.kofaxIDFieldSpecified
            End Get
            Set
                Me.kofaxIDFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ImageCleanupProfileName() As String
            Get
                Return Me.imageCleanupProfileNameField
            End Get
            Set
                Me.imageCleanupProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OriginalName() As String
            Get
                Return Me.originalNameField
            End Get
            Set
                Me.originalNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupRecognitionProfileShapeOptions
        Inherits EntityBase(Of AscentCaptureSetupRecognitionProfileShapeOptions)

        Private lineWidthField As Byte

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LineWidth() As Byte
            Get
                Return Me.lineWidthField
            End Get
            Set
                Me.lineWidthField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupRecognitionProfileAdvancedOcrOptions
        Inherits EntityBase(Of AscentCaptureSetupRecognitionProfileAdvancedOcrOptions)

        Private exportFormatField As UShort

        Private outputResolutionField As UShort

        Private spellCheckFlagField As Byte

        Private jPEGQualityField As Byte

        Private jPEGQualityFieldSpecified As Boolean

        Private pDFAComplianceField As SByte

        Private pDFAComplianceFieldSpecified As Boolean

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ExportFormat() As UShort
            Get
                Return Me.exportFormatField
            End Get
            Set
                Me.exportFormatField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OutputResolution() As UShort
            Get
                Return Me.outputResolutionField
            End Get
            Set
                Me.outputResolutionField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SpellCheckFlag() As Byte
            Get
                Return Me.spellCheckFlagField
            End Get
            Set
                Me.spellCheckFlagField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property JPEGQuality() As Byte
            Get
                Return Me.jPEGQualityField
            End Get
            Set
                Me.jPEGQualityField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property JPEGQualitySpecified() As Boolean
            Get
                Return Me.jPEGQualityFieldSpecified
            End Get
            Set
                Me.jPEGQualityFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PDFACompliance() As SByte
            Get
                Return Me.pDFAComplianceField
            End Get
            Set
                Me.pDFAComplianceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property PDFAComplianceSpecified() As Boolean
            Get
                Return Me.pDFAComplianceFieldSpecified
            End Get
            Set
                Me.pDFAComplianceFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupRecognitionProfileBarCodeOptions
        Inherits EntityBase(Of AscentCaptureSetupRecognitionProfileBarCodeOptions)

        Private widthField As Byte

        Private useEnhancedEngineField As Byte

        Private barCodeMaskField As Byte

        Private barCodeMaskFieldSpecified As Boolean

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Width() As Byte
            Get
                Return Me.widthField
            End Get
            Set
                Me.widthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property UseEnhancedEngine() As Byte
            Get
                Return Me.useEnhancedEngineField
            End Get
            Set
                Me.useEnhancedEngineField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BarCodeMask() As Byte
            Get
                Return Me.barCodeMaskField
            End Get
            Set
                Me.barCodeMaskField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property BarCodeMaskSpecified() As Boolean
            Get
                Return Me.barCodeMaskFieldSpecified
            End Get
            Set
                Me.barCodeMaskFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupRecognitionProfileIcrOptions
        Inherits EntityBase(Of AscentCaptureSetupRecognitionProfileIcrOptions)

        Private languageField As UShort

        Private markLevelField As Byte

        Private textFlagField As Byte

        Private interpretationField As Byte

        Private interpretationFieldSpecified As Boolean

        Private absoluteMachinePrintMarkLevelField As Byte

        Private absoluteHandprintMarkLevelField As Byte

        Private trigramsField As UShort

        Private trigramsFieldSpecified As Boolean

        Private allowedCharsField As String

        Private syntaxModeField As Byte

        Private syntaxModeFieldSpecified As Boolean

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Language() As UShort
            Get
                Return Me.languageField
            End Get
            Set
                Me.languageField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property MarkLevel() As Byte
            Get
                Return Me.markLevelField
            End Get
            Set
                Me.markLevelField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TextFlag() As Byte
            Get
                Return Me.textFlagField
            End Get
            Set
                Me.textFlagField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Interpretation() As Byte
            Get
                Return Me.interpretationField
            End Get
            Set
                Me.interpretationField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property InterpretationSpecified() As Boolean
            Get
                Return Me.interpretationFieldSpecified
            End Get
            Set
                Me.interpretationFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AbsoluteMachinePrintMarkLevel() As Byte
            Get
                Return Me.absoluteMachinePrintMarkLevelField
            End Get
            Set
                Me.absoluteMachinePrintMarkLevelField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AbsoluteHandprintMarkLevel() As Byte
            Get
                Return Me.absoluteHandprintMarkLevelField
            End Get
            Set
                Me.absoluteHandprintMarkLevelField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Trigrams() As UShort
            Get
                Return Me.trigramsField
            End Get
            Set
                Me.trigramsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property TrigramsSpecified() As Boolean
            Get
                Return Me.trigramsFieldSpecified
            End Get
            Set
                Me.trigramsFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AllowedChars() As String
            Get
                Return Me.allowedCharsField
            End Get
            Set
                Me.allowedCharsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SyntaxMode() As Byte
            Get
                Return Me.syntaxModeField
            End Get
            Set
                Me.syntaxModeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SyntaxModeSpecified() As Boolean
            Get
                Return Me.syntaxModeFieldSpecified
            End Get
            Set
                Me.syntaxModeFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupSeparationFormIDProfile
        Inherits EntityBase(Of AscentCaptureSetupSeparationFormIDProfile)

        Private separationProfileField As AscentCaptureSetupSeparationFormIDProfileSeparationProfile

        Private formIDProfileField As AscentCaptureSetupSeparationFormIDProfileFormIDProfile

        Private readOnlyField As Byte

        Private kofaxIDField As Byte

        Private nameField As String

        Private scriptNameField As String

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property SeparationProfile() As AscentCaptureSetupSeparationFormIDProfileSeparationProfile
            Get
                Return Me.separationProfileField
            End Get
            Set
                Me.separationProfileField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
        Public Property FormIDProfile() As AscentCaptureSetupSeparationFormIDProfileFormIDProfile
            Get
                Return Me.formIDProfileField
            End Get
            Set
                Me.formIDProfileField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [ReadOnly]() As Byte
            Get
                Return Me.readOnlyField
            End Get
            Set
                Me.readOnlyField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxID() As Byte
            Get
                Return Me.kofaxIDField
            End Get
            Set
                Me.kofaxIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupSeparationFormIDProfileSeparationProfile
        Inherits EntityBase(Of AscentCaptureSetupSeparationFormIDProfileSeparationProfile)

        Private methodField As Byte

        Private confidenceField As Byte

        Private differenceField As Byte

        Private separatorSheetRecognitionProfileNameField As String

        Private firstPageRecognitionProfileNameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Method() As Byte
            Get
                Return Me.methodField
            End Get
            Set
                Me.methodField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Confidence() As Byte
            Get
                Return Me.confidenceField
            End Get
            Set
                Me.confidenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Difference() As Byte
            Get
                Return Me.differenceField
            End Get
            Set
                Me.differenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SeparatorSheetRecognitionProfileName() As String
            Get
                Return Me.separatorSheetRecognitionProfileNameField
            End Get
            Set
                Me.separatorSheetRecognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FirstPageRecognitionProfileName() As String
            Get
                Return Me.firstPageRecognitionProfileNameField
            End Get
            Set
                Me.firstPageRecognitionProfileNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupSeparationFormIDProfileFormIDProfile
        Inherits EntityBase(Of AscentCaptureSetupSeparationFormIDProfileFormIDProfile)

        Private methodField As Byte

        Private confidenceField As Byte

        Private differenceField As Byte

        Private pageRecognitionProfileNameField As String

        Private zoneRecognitionProfileNameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Method() As Byte
            Get
                Return Me.methodField
            End Get
            Set
                Me.methodField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Confidence() As Byte
            Get
                Return Me.confidenceField
            End Get
            Set
                Me.confidenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Difference() As Byte
            Get
                Return Me.differenceField
            End Get
            Set
                Me.differenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PageRecognitionProfileName() As String
            Get
                Return Me.pageRecognitionProfileNameField
            End Get
            Set
                Me.pageRecognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneRecognitionProfileName() As String
            Get
                Return Me.zoneRecognitionProfileNameField
            End Get
            Set
                Me.zoneRecognitionProfileNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupFieldType
        Inherits EntityBase(Of AscentCaptureSetupFieldType)

        Private valuesField As List(Of AscentCaptureSetupFieldTypeValue)

        Private sqlTypeField As Byte

        Private widthField As Byte

        Private nameField As String

        Private originalNameField As String

        Private scriptNameField As String

        Private enableValuesField As Byte

        Private enableValuesFieldSpecified As Boolean

        Private forceMatchField As Byte

        Private forceMatchFieldSpecified As Boolean

        Private descriptionField As String

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("Value", IsNullable:=False)>
        Public Property Values() As List(Of AscentCaptureSetupFieldTypeValue)
            Get
                Return Me.valuesField
            End Get
            Set
                Me.valuesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SqlType() As Byte
            Get
                Return Me.sqlTypeField
            End Get
            Set
                Me.sqlTypeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Width() As Byte
            Get
                Return Me.widthField
            End Get
            Set
                Me.widthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OriginalName() As String
            Get
                Return Me.originalNameField
            End Get
            Set
                Me.originalNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property EnableValues() As Byte
            Get
                Return Me.enableValuesField
            End Get
            Set
                Me.enableValuesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property EnableValuesSpecified() As Boolean
            Get
                Return Me.enableValuesFieldSpecified
            End Get
            Set
                Me.enableValuesFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ForceMatch() As Byte
            Get
                Return Me.forceMatchField
            End Get
            Set
                Me.forceMatchField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ForceMatchSpecified() As Boolean
            Get
                Return Me.forceMatchFieldSpecified
            End Get
            Set
                Me.forceMatchFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupFieldTypeValue
        Inherits EntityBase(Of AscentCaptureSetupFieldTypeValue)

        Private textField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Text() As String
            Get
                Return Me.textField
            End Get
            Set
                Me.textField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClass
        Inherits EntityBase(Of AscentCaptureSetupDocumentClass)

        Private indexFieldDefinitionsField As List(Of AscentCaptureSetupDocumentClassIndexFieldDefinition)

        Private formTypesField As AscentCaptureSetupDocumentClassFormTypes

        Private documentClassCustomStorageStringsField As List(Of AscentCaptureSetupDocumentClassDocumentClassCustomStorageString)

        Private kofaxPDFSelectedField As Byte

        Private kofaxPDFSelectedFieldSpecified As Boolean

        Private nameField As String

        Private originalNameField As String

        Private scriptNameField As String

        Private ocrFullTextRecognitionProfileNameField As String

        Private kofaxPDFRecognitionProfileNameField As String

        Private pDFDictionaryField As String

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("IndexFieldDefinition", IsNullable:=False)>
        Public Property IndexFieldDefinitions() As List(Of AscentCaptureSetupDocumentClassIndexFieldDefinition)
            Get
                Return Me.indexFieldDefinitionsField
            End Get
            Set
                Me.indexFieldDefinitionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
        Public Property FormTypes() As AscentCaptureSetupDocumentClassFormTypes
            Get
                Return Me.formTypesField
            End Get
            Set
                Me.formTypesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=2),
         System.Xml.Serialization.XmlArrayItemAttribute("DocumentClassCustomStorageString", IsNullable:=False)>
        Public Property DocumentClassCustomStorageStrings() As List(Of AscentCaptureSetupDocumentClassDocumentClassCustomStorageString)
            Get
                Return Me.documentClassCustomStorageStringsField
            End Get
            Set
                Me.documentClassCustomStorageStringsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxPDFSelected() As Byte
            Get
                Return Me.kofaxPDFSelectedField
            End Get
            Set
                Me.kofaxPDFSelectedField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property KofaxPDFSelectedSpecified() As Boolean
            Get
                Return Me.kofaxPDFSelectedFieldSpecified
            End Get
            Set
                Me.kofaxPDFSelectedFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OriginalName() As String
            Get
                Return Me.originalNameField
            End Get
            Set
                Me.originalNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OcrFullTextRecognitionProfileName() As String
            Get
                Return Me.ocrFullTextRecognitionProfileNameField
            End Get
            Set
                Me.ocrFullTextRecognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxPDFRecognitionProfileName() As String
            Get
                Return Me.kofaxPDFRecognitionProfileNameField
            End Get
            Set
                Me.kofaxPDFRecognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PDFDictionary() As String
            Get
                Return Me.pDFDictionaryField
            End Get
            Set
                Me.pDFDictionaryField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassIndexFieldDefinition
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassIndexFieldDefinition)

        Private requiredField As Byte

        Private requiredFieldSpecified As Boolean

        Private _2XReleaseIDField As UInteger

        Private nameField As String

        Private fieldTypeNameField As String

        Private tableNameField As String

        Private displayLabelField As String

        Private defaultValueField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Required() As Byte
            Get
                Return Me.requiredField
            End Get
            Set
                Me.requiredField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RequiredSpecified() As Boolean
            Get
                Return Me.requiredFieldSpecified
            End Get
            Set
                Me.requiredFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property _2XReleaseID() As UInteger
            Get
                Return Me._2XReleaseIDField
            End Get
            Set
                Me._2XReleaseIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FieldTypeName() As String
            Get
                Return Me.fieldTypeNameField
            End Get
            Set
                Me.fieldTypeNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property TableName() As String
            Get
                Return Me.tableNameField
            End Get
            Set
                Me.tableNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DisplayLabel() As String
            Get
                Return Me.displayLabelField
            End Get
            Set
                Me.displayLabelField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultValue() As String
            Get
                Return Me.defaultValueField
            End Get
            Set
                Me.defaultValueField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypes
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypes)

        Private formTypeField As AscentCaptureSetupDocumentClassFormTypesFormType

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property FormType() As AscentCaptureSetupDocumentClassFormTypesFormType
            Get
                Return Me.formTypeField
            End Get
            Set
                Me.formTypeField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypesFormType
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypesFormType)

        Private formTypeCustomStorageStringsField As AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStrings

        Private registrationZonesField As List(Of AscentCaptureSetupDocumentClassFormTypesFormTypeRegistrationZone)

        Private indexZonesField As List(Of AscentCaptureSetupDocumentClassFormTypesFormTypeIndexZone)

        Private barCodeRecognitionProfileNameField As String

        Private fixedPageCountField As Byte

        Private fixedPageCountFieldSpecified As Boolean

        Private samplePageCountField As Byte

        Private samplePageCountFieldSpecified As Boolean

        Private samplePagePublishDirectoryNumberField As Byte

        Private samplePagePublishDirectoryNumberFieldSpecified As Boolean

        Private registrationConfidenceField As Byte

        Private registrationConfidenceFieldSpecified As Boolean

        Private indexZoneConfidenceField As Byte

        Private indexZoneConfidenceFieldSpecified As Boolean

        Private samplePageHDPIField As Byte

        Private samplePageHDPIFieldSpecified As Boolean

        Private samplePageVDPIField As Byte

        Private samplePageVDPIFieldSpecified As Boolean

        Private sampleImageDirectoryNumberField As Byte

        Private nameField As String

        Private scriptNameField As String

        Private formsProcessingImageCleanupProfileNameField As String

        Private searchTextField As String

        Private newSamplePagesField As Byte

        Private newSamplePagesFieldSpecified As Boolean

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property FormTypeCustomStorageStrings() As AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStrings
            Get
                Return Me.formTypeCustomStorageStringsField
            End Get
            Set
                Me.formTypeCustomStorageStringsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=1),
         System.Xml.Serialization.XmlArrayItemAttribute("RegistrationZone", IsNullable:=False)>
        Public Property RegistrationZones() As List(Of AscentCaptureSetupDocumentClassFormTypesFormTypeRegistrationZone)
            Get
                Return Me.registrationZonesField
            End Get
            Set
                Me.registrationZonesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=2),
         System.Xml.Serialization.XmlArrayItemAttribute("IndexZone", IsNullable:=False)>
        Public Property IndexZones() As List(Of AscentCaptureSetupDocumentClassFormTypesFormTypeIndexZone)
            Get
                Return Me.indexZonesField
            End Get
            Set
                Me.indexZonesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BarCodeRecognitionProfileName() As String
            Get
                Return Me.barCodeRecognitionProfileNameField
            End Get
            Set
                Me.barCodeRecognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FixedPageCount() As Byte
            Get
                Return Me.fixedPageCountField
            End Get
            Set
                Me.fixedPageCountField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property FixedPageCountSpecified() As Boolean
            Get
                Return Me.fixedPageCountFieldSpecified
            End Get
            Set
                Me.fixedPageCountFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SamplePageCount() As Byte
            Get
                Return Me.samplePageCountField
            End Get
            Set
                Me.samplePageCountField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SamplePageCountSpecified() As Boolean
            Get
                Return Me.samplePageCountFieldSpecified
            End Get
            Set
                Me.samplePageCountFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SamplePagePublishDirectoryNumber() As Byte
            Get
                Return Me.samplePagePublishDirectoryNumberField
            End Get
            Set
                Me.samplePagePublishDirectoryNumberField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SamplePagePublishDirectoryNumberSpecified() As Boolean
            Get
                Return Me.samplePagePublishDirectoryNumberFieldSpecified
            End Get
            Set
                Me.samplePagePublishDirectoryNumberFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RegistrationConfidence() As Byte
            Get
                Return Me.registrationConfidenceField
            End Get
            Set
                Me.registrationConfidenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property RegistrationConfidenceSpecified() As Boolean
            Get
                Return Me.registrationConfidenceFieldSpecified
            End Get
            Set
                Me.registrationConfidenceFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property IndexZoneConfidence() As Byte
            Get
                Return Me.indexZoneConfidenceField
            End Get
            Set
                Me.indexZoneConfidenceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property IndexZoneConfidenceSpecified() As Boolean
            Get
                Return Me.indexZoneConfidenceFieldSpecified
            End Get
            Set
                Me.indexZoneConfidenceFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SamplePageHDPI() As Byte
            Get
                Return Me.samplePageHDPIField
            End Get
            Set
                Me.samplePageHDPIField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SamplePageHDPISpecified() As Boolean
            Get
                Return Me.samplePageHDPIFieldSpecified
            End Get
            Set
                Me.samplePageHDPIFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SamplePageVDPI() As Byte
            Get
                Return Me.samplePageVDPIField
            End Get
            Set
                Me.samplePageVDPIField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SamplePageVDPISpecified() As Boolean
            Get
                Return Me.samplePageVDPIFieldSpecified
            End Get
            Set
                Me.samplePageVDPIFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SampleImageDirectoryNumber() As Byte
            Get
                Return Me.sampleImageDirectoryNumberField
            End Get
            Set
                Me.sampleImageDirectoryNumberField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScriptName() As String
            Get
                Return Me.scriptNameField
            End Get
            Set
                Me.scriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property FormsProcessingImageCleanupProfileName() As String
            Get
                Return Me.formsProcessingImageCleanupProfileNameField
            End Get
            Set
                Me.formsProcessingImageCleanupProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SearchText() As String
            Get
                Return Me.searchTextField
            End Get
            Set
                Me.searchTextField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property NewSamplePages() As Byte
            Get
                Return Me.newSamplePagesField
            End Get
            Set
                Me.newSamplePagesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NewSamplePagesSpecified() As Boolean
            Get
                Return Me.newSamplePagesFieldSpecified
            End Get
            Set
                Me.newSamplePagesFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStrings
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStrings)

        Private formTypeCustomStorageStringField As AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStringsFormTypeCustomStorageString

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property FormTypeCustomStorageString() As AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStringsFormTypeCustomStorageString
            Get
                Return Me.formTypeCustomStorageStringField
            End Get
            Set
                Me.formTypeCustomStorageStringField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStringsFormTypeCustomStorageString
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypesFormTypeFormTypeCustomStorageStringsFormTypeCustomStorageString)

        Private nameField As String

        Private valueField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypesFormTypeRegistrationZone
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypesFormTypeRegistrationZone)

        Private recognitionProfileNameField As String

        Private pageNumberField As Byte

        Private xField As UShort

        Private yField As UShort

        Private zoneTopField As UShort

        Private zoneLeftField As UShort

        Private zoneWidthField As UShort

        Private zoneHeightField As UShort

        Private searchTextField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RecognitionProfileName() As String
            Get
                Return Me.recognitionProfileNameField
            End Get
            Set
                Me.recognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PageNumber() As Byte
            Get
                Return Me.pageNumberField
            End Get
            Set
                Me.pageNumberField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property X() As UShort
            Get
                Return Me.xField
            End Get
            Set
                Me.xField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Y() As UShort
            Get
                Return Me.yField
            End Get
            Set
                Me.yField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneTop() As UShort
            Get
                Return Me.zoneTopField
            End Get
            Set
                Me.zoneTopField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneLeft() As UShort
            Get
                Return Me.zoneLeftField
            End Get
            Set
                Me.zoneLeftField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneWidth() As UShort
            Get
                Return Me.zoneWidthField
            End Get
            Set
                Me.zoneWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneHeight() As UShort
            Get
                Return Me.zoneHeightField
            End Get
            Set
                Me.zoneHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SearchText() As String
            Get
                Return Me.searchTextField
            End Get
            Set
                Me.searchTextField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassFormTypesFormTypeIndexZone
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassFormTypesFormTypeIndexZone)

        Private recognitionProfileNameField As String

        Private pageNumberField As Byte

        Private zoneTopField As UShort

        Private zoneLeftField As UShort

        Private zoneWidthField As UShort

        Private zoneHeightField As UShort

        Private indexFieldDefinitionNameField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RecognitionProfileName() As String
            Get
                Return Me.recognitionProfileNameField
            End Get
            Set
                Me.recognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PageNumber() As Byte
            Get
                Return Me.pageNumberField
            End Get
            Set
                Me.pageNumberField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneTop() As UShort
            Get
                Return Me.zoneTopField
            End Get
            Set
                Me.zoneTopField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneLeft() As UShort
            Get
                Return Me.zoneLeftField
            End Get
            Set
                Me.zoneLeftField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneWidth() As UShort
            Get
                Return Me.zoneWidthField
            End Get
            Set
                Me.zoneWidthField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ZoneHeight() As UShort
            Get
                Return Me.zoneHeightField
            End Get
            Set
                Me.zoneHeightField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property IndexFieldDefinitionName() As String
            Get
                Return Me.indexFieldDefinitionNameField
            End Get
            Set
                Me.indexFieldDefinitionNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupDocumentClassDocumentClassCustomStorageString
        Inherits EntityBase(Of AscentCaptureSetupDocumentClassDocumentClassCustomStorageString)

        Private nameField As String

        Private valueField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClass
        Inherits EntityBase(Of AscentCaptureSetupBatchClass)

        Private modulesField As List(Of AscentCaptureSetupBatchClassModule)

        Private separationZoneField As AscentCaptureSetupBatchClassSeparationZone

        Private documentClassLinksField As List(Of AscentCaptureSetupBatchClassDocumentClassLink)

        Private batchClassCustomStorageStringsField As List(Of AscentCaptureSetupBatchClassBatchClassCustomStorageString)

        Private batchDefNameFormatField As AscentCaptureSetupBatchClassBatchDefNameFormat

        Private separationFormIDProfileNameField As String

        Private scanImageCleanupProfileNameField As String

        Private modifiedDateTimeField As String

        Private relStartDateTimeField As String

        Private relEndDateTimeField As String

        Private relPriorityField As Byte

        Private qCReEndorseOptionsField As Byte

        Private scnDocSeparationField As Byte

        Private scnDocSeparationFieldSpecified As Boolean

        Private alwaysPostProcessField As Byte

        Private eADigitsField As Byte

        Private advanceBatchesInErrorModuleIDField As String

        Private supportsNonImageFilesField As Byte

        Private supportsNonImageFilesFieldSpecified As Boolean

        Private colorImgProcOptIDField As String

        Private nonTiffAreNonImageField As Byte

        Private nonTiffAreNonImageFieldSpecified As Boolean

        Private pdfAsImageField As Byte

        Private pdfAsImageFieldSpecified As Boolean

        Private allowInteractiveAutoFolderCreationField As Byte

        Private allowInteractiveAutoFolderCreationFieldSpecified As Boolean

        Private batchClassIDField As Byte

        Private nameField As String

        Private originalBatchDefIDField As Byte

        Private imageDirectoryField As String

        Private defaultFormTypeNameField As String

        Private endorseScriptNameField As String

        Private lastPublishedField As String

        Private externalBatchClassIDField As Byte

        Private batchFieldScriptIDField As String

        Private scnCapModeField As Byte

        Private scnCapModeFieldSpecified As Boolean

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("Module", IsNullable:=False)>
        Public Property Modules() As List(Of AscentCaptureSetupBatchClassModule)
            Get
                Return Me.modulesField
            End Get
            Set
                Me.modulesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>
        Public Property SeparationZone() As AscentCaptureSetupBatchClassSeparationZone
            Get
                Return Me.separationZoneField
            End Get
            Set
                Me.separationZoneField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=2),
         System.Xml.Serialization.XmlArrayItemAttribute("DocumentClassLink", IsNullable:=False)>
        Public Property DocumentClassLinks() As List(Of AscentCaptureSetupBatchClassDocumentClassLink)
            Get
                Return Me.documentClassLinksField
            End Get
            Set
                Me.documentClassLinksField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=3),
         System.Xml.Serialization.XmlArrayItemAttribute("BatchClassCustomStorageString", IsNullable:=False)>
        Public Property BatchClassCustomStorageStrings() As List(Of AscentCaptureSetupBatchClassBatchClassCustomStorageString)
            Get
                Return Me.batchClassCustomStorageStringsField
            End Get
            Set
                Me.batchClassCustomStorageStringsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlElementAttribute(Order:=4)>
        Public Property BatchDefNameFormat() As AscentCaptureSetupBatchClassBatchDefNameFormat
            Get
                Return Me.batchDefNameFormatField
            End Get
            Set
                Me.batchDefNameFormatField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SeparationFormIDProfileName() As String
            Get
                Return Me.separationFormIDProfileNameField
            End Get
            Set
                Me.separationFormIDProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScanImageCleanupProfileName() As String
            Get
                Return Me.scanImageCleanupProfileNameField
            End Get
            Set
                Me.scanImageCleanupProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ModifiedDateTime() As String
            Get
                Return Me.modifiedDateTimeField
            End Get
            Set
                Me.modifiedDateTimeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RelStartDateTime() As String
            Get
                Return Me.relStartDateTimeField
            End Get
            Set
                Me.relStartDateTimeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RelEndDateTime() As String
            Get
                Return Me.relEndDateTimeField
            End Get
            Set
                Me.relEndDateTimeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RelPriority() As Byte
            Get
                Return Me.relPriorityField
            End Get
            Set
                Me.relPriorityField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property QCReEndorseOptions() As Byte
            Get
                Return Me.qCReEndorseOptionsField
            End Get
            Set
                Me.qCReEndorseOptionsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScnDocSeparation() As Byte
            Get
                Return Me.scnDocSeparationField
            End Get
            Set
                Me.scnDocSeparationField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ScnDocSeparationSpecified() As Boolean
            Get
                Return Me.scnDocSeparationFieldSpecified
            End Get
            Set
                Me.scnDocSeparationFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AlwaysPostProcess() As Byte
            Get
                Return Me.alwaysPostProcessField
            End Get
            Set
                Me.alwaysPostProcessField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property EADigits() As Byte
            Get
                Return Me.eADigitsField
            End Get
            Set
                Me.eADigitsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AdvanceBatchesInErrorModuleID() As String
            Get
                Return Me.advanceBatchesInErrorModuleIDField
            End Get
            Set
                Me.advanceBatchesInErrorModuleIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SupportsNonImageFiles() As Byte
            Get
                Return Me.supportsNonImageFilesField
            End Get
            Set
                Me.supportsNonImageFilesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SupportsNonImageFilesSpecified() As Boolean
            Get
                Return Me.supportsNonImageFilesFieldSpecified
            End Get
            Set
                Me.supportsNonImageFilesFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ColorImgProcOptID() As String
            Get
                Return Me.colorImgProcOptIDField
            End Get
            Set
                Me.colorImgProcOptIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property NonTiffAreNonImage() As Byte
            Get
                Return Me.nonTiffAreNonImageField
            End Get
            Set
                Me.nonTiffAreNonImageField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property NonTiffAreNonImageSpecified() As Boolean
            Get
                Return Me.nonTiffAreNonImageFieldSpecified
            End Get
            Set
                Me.nonTiffAreNonImageFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property PdfAsImage() As Byte
            Get
                Return Me.pdfAsImageField
            End Get
            Set
                Me.pdfAsImageField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property PdfAsImageSpecified() As Boolean
            Get
                Return Me.pdfAsImageFieldSpecified
            End Get
            Set
                Me.pdfAsImageFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property AllowInteractiveAutoFolderCreation() As Byte
            Get
                Return Me.allowInteractiveAutoFolderCreationField
            End Get
            Set
                Me.allowInteractiveAutoFolderCreationField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property AllowInteractiveAutoFolderCreationSpecified() As Boolean
            Get
                Return Me.allowInteractiveAutoFolderCreationFieldSpecified
            End Get
            Set
                Me.allowInteractiveAutoFolderCreationFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BatchClassID() As Byte
            Get
                Return Me.batchClassIDField
            End Get
            Set
                Me.batchClassIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property OriginalBatchDefID() As Byte
            Get
                Return Me.originalBatchDefIDField
            End Get
            Set
                Me.originalBatchDefIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ImageDirectory() As String
            Get
                Return Me.imageDirectoryField
            End Get
            Set
                Me.imageDirectoryField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DefaultFormTypeName() As String
            Get
                Return Me.defaultFormTypeNameField
            End Get
            Set
                Me.defaultFormTypeNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property EndorseScriptName() As String
            Get
                Return Me.endorseScriptNameField
            End Get
            Set
                Me.endorseScriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property LastPublished() As String
            Get
                Return Me.lastPublishedField
            End Get
            Set
                Me.lastPublishedField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ExternalBatchClassID() As Byte
            Get
                Return Me.externalBatchClassIDField
            End Get
            Set
                Me.externalBatchClassIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BatchFieldScriptID() As String
            Get
                Return Me.batchFieldScriptIDField
            End Get
            Set
                Me.batchFieldScriptIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ScnCapMode() As Byte
            Get
                Return Me.scnCapModeField
            End Get
            Set
                Me.scnCapModeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property ScnCapModeSpecified() As Boolean
            Get
                Return Me.scnCapModeFieldSpecified
            End Get
            Set
                Me.scnCapModeFieldSpecified = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassModule
        Inherits EntityBase(Of AscentCaptureSetupBatchClassModule)

        Private exceptionModuleIDField As String

        Private moduleIDField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ExceptionModuleID() As String
            Get
                Return Me.exceptionModuleIDField
            End Get
            Set
                Me.exceptionModuleIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ModuleID() As String
            Get
                Return Me.moduleIDField
            End Get
            Set
                Me.moduleIDField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassSeparationZone
        Inherits EntityBase(Of AscentCaptureSetupBatchClassSeparationZone)

        Private recognitionProfileNameField As String

        Private confidenceField As Byte

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RecognitionProfileName() As String
            Get
                Return Me.recognitionProfileNameField
            End Get
            Set
                Me.recognitionProfileNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Confidence() As Byte
            Get
                Return Me.confidenceField
            End Get
            Set
                Me.confidenceField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassDocumentClassLink
        Inherits EntityBase(Of AscentCaptureSetupBatchClassDocumentClassLink)

        Private releaseSetupsField As AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetups

        Private documentClassNameField As String

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ReleaseSetups() As AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetups
            Get
                Return Me.releaseSetupsField
            End Get
            Set
                Me.releaseSetupsField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DocumentClassName() As String
            Get
                Return Me.documentClassNameField
            End Get
            Set
                Me.documentClassNameField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetups
        Inherits EntityBase(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetups)

        Private releaseSetupField As AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetup

        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>
        Public Property ReleaseSetup() As AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetup
            Get
                Return Me.releaseSetupField
            End Get
            Set
                Me.releaseSetupField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetup
        Inherits EntityBase(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetup)

        Private customPropertiesField As List(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupCustomProperty)

        Private releaseLinksField As List(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupReleaseLink)

        Private newField As Byte

        Private relSetupIDField As Byte

        Private nameField As String

        Private documentClassNameField As String

        Private releaseScriptNameField As String

        Private kofaxPDFDirField As String

        <System.Xml.Serialization.XmlArrayAttribute(Order:=0),
         System.Xml.Serialization.XmlArrayItemAttribute("CustomProperty", IsNullable:=False)>
        Public Property CustomProperties() As List(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupCustomProperty)
            Get
                Return Me.customPropertiesField
            End Get
            Set
                Me.customPropertiesField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlArrayAttribute(Order:=1),
         System.Xml.Serialization.XmlArrayItemAttribute("ReleaseLink", IsNullable:=False)>
        Public Property ReleaseLinks() As List(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupReleaseLink)
            Get
                Return Me.releaseLinksField
            End Get
            Set
                Me.releaseLinksField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property [New]() As Byte
            Get
                Return Me.newField
            End Get
            Set
                Me.newField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property RelSetupID() As Byte
            Get
                Return Me.relSetupIDField
            End Get
            Set
                Me.relSetupIDField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property DocumentClassName() As String
            Get
                Return Me.documentClassNameField
            End Get
            Set
                Me.documentClassNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property ReleaseScriptName() As String
            Get
                Return Me.releaseScriptNameField
            End Get
            Set
                Me.releaseScriptNameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property KofaxPDFDir() As String
            Get
                Return Me.kofaxPDFDirField
            End Get
            Set
                Me.kofaxPDFDirField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupCustomProperty
        Inherits EntityBase(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupCustomProperty)

        Private nameField As String

        Private valueField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupReleaseLink
        Inherits EntityBase(Of AscentCaptureSetupBatchClassDocumentClassLinkReleaseSetupsReleaseSetupReleaseLink)

        Private sourceTypeField As Byte

        Private sourceTypeFieldSpecified As Boolean

        Private sourceField As String

        Private destinationField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property SourceType() As Byte
            Get
                Return Me.sourceTypeField
            End Get
            Set
                Me.sourceTypeField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlIgnoreAttribute()>
        Public Property SourceTypeSpecified() As Boolean
            Get
                Return Me.sourceTypeFieldSpecified
            End Get
            Set
                Me.sourceTypeFieldSpecified = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Source() As String
            Get
                Return Me.sourceField
            End Get
            Set
                Me.sourceField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Destination() As String
            Get
                Return Me.destinationField
            End Get
            Set
                Me.destinationField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassBatchClassCustomStorageString
        Inherits EntityBase(Of AscentCaptureSetupBatchClassBatchClassCustomStorageString)

        Private nameField As String

        Private valueField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = Value
            End Set
        End Property

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property Value() As String
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = Value
            End Set
        End Property
    End Class

    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),
     System.SerializableAttribute(),
     System.ComponentModel.DesignerCategoryAttribute("code"),
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
    Partial Public Class AscentCaptureSetupBatchClassBatchDefNameFormat
        Inherits EntityBase(Of AscentCaptureSetupBatchClassBatchDefNameFormat)

        Private batchNameFormatField As String

        <System.Xml.Serialization.XmlAttributeAttribute()>
        Public Property BatchNameFormat() As String
            Get
                Return Me.batchNameFormatField
            End Get
            Set
                Me.batchNameFormatField = Value
            End Set
        End Property
    End Class
End Namespace
