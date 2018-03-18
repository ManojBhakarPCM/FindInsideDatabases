
Imports System.Data.SQLite
Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.InteropServices
'ME: Manoj Bhakar PCM
'TODO:
'XLSX***
'   Sheet names retrieval.
'   dateTime retrivel
'   Header columns correspondens.
'   All Header Columns are not shown
'*VCF***
'   NICE formatting
'*ALL over**
'   result design. and options f.e. - open file. copy path etc.
Public Class Form1
    Dim xlsFileList As List(Of String) = New List(Of String)
    Dim extension(2) As String
    Dim MyFont As Font
    Dim labFilePathFont As Font
    Dim blackBoldFont As Font
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        doSearch()
    End Sub
    Private Sub doFullSearch()
        xlsFileList.Clear()
        ToolStripStatusLabel2.Text = "Indexing Files::"
        ToolStripStatusLabel1.Text = "Desktop"
        searchDirs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
        ToolStripStatusLabel1.Text = "My Documents"
        searchDirs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        ToolStripStatusLabel1.Text = "Downloads"
        searchDirs(GetDownloadsPath)

        For Each di As DriveInfo In DriveInfo.GetDrives
            If Not (di.DriveType = DriveType.CDRom Or di.DriveType = DriveType.Network) Then
                If di.IsReady Then
                    If (IO.Directory.Exists(di.Name & "Windows") AndAlso IO.Directory.Exists(di.Name & "Program Files")) Then ListBox1.Items.Add("Skipping system drive:" & di.Name) : Continue For
                    ToolStripStatusLabel1.Text = di.Name & "(" & di.VolumeLabel & ")"
                    searchDirs(di.Name)
                End If
            End If
        Next
        ToolStripStatusLabel1.Text = "indexing Done!! Total " & xlsFileList.Count & " Found"
        'saving the cache file.
        IO.File.WriteAllLines("FileList.cache", xlsFileList)
        chkUseCache.Checked = True
    End Sub
    Private Sub xlsFileOpenLoop(searchWhat As String)
        Dim ext As String

        For Each f In xlsFileList
            ToolStripStatusLabel1.Text = "Searching in File::" & f
            Application.DoEvents()

            ext = Path.GetExtension(f).ToLower
            If ext.Equals(".xlsx") Then
                If chkSearchXLSX.Checked Then searchExcelzip(tbSearch.Text, f)
            ElseIf ext.Equals(".vcf") Then
                If chkSearchVCF.Checked Then searchVcardFile(tbSearch.Text, f)
            ElseIf ext.Equals(".db") Then
                If chkSearchSqlite.Checked Then searchInSqlite(tbSearch.Text, f)
            End If

        Next
        ToolStripStatusLabel1.Text = "Done"
    End Sub
    Private Sub searchAndDisplayCSV(csvSheet As String, wsName As String, filePath As String, searchWhat As String)
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(csvSheet)
        Dim a As String
        Dim firstLine As String = ""
        Dim result As String = ""
        Dim count As Integer = 0
        Do
            a = reader.ReadLine
            count += 1
            If count = 1 Then firstLine = a : ListBox1.Items.Insert(1, firstLine) : Application.DoEvents()

            If InStr(LCase(a), searchWhat) > 0 Then
                result = wsName & "(" & filePath & ")" & vbCrLf
                Dim ar As String() = Split(a, ",")
                Dim arh As String() = Split(firstLine, ",")
                For Each b As String In ar
                    For Each c As String In arh
                        result &= c & Space(20 - Len(c)) & ":" & b & vbCrLf
                    Next
                Next
                addResult(result)
            End If
        Loop Until a Is Nothing
        reader.Close()
    End Sub
    Private Sub searchDirs(sdir As String)
        Dim f As String
        Dim foundDirectory As String


        For Each foundDirectory In My.Computer.FileSystem.GetFiles(sdir, FileIO.SearchOption.SearchTopLevelOnly, extension)
            If InStr(foundDirectory, "\Thumbs.db") > 0 Then Continue For
            xlsFileList.Add(foundDirectory)

        Next
        For Each f In IO.Directory.GetDirectories(sdir)
            Try
                searchDirs(f)
            Catch
                ListBox1.Items.Add("Can't search in: " & f)
                Application.DoEvents()
            End Try
        Next
    End Sub
    Private Sub addResult(txt As String)

        Dim t As New TextBox
        t.Multiline = True
        t.WordWrap = False
        t.ScrollBars = ScrollBars.Vertical
        t.Text = txt
        t.Font = MyFont
        t.BackColor = Color.Yellow
        t.Height = 145
        t.Width = 500
        t.Location = New Point(0, 145 * Panel1.Controls.OfType(Of TextBox)().Count + 100 * Panel1.Controls.OfType(Of PictureBox)().Count)
        Panel1.Controls.Add(t)
    End Sub
    Public Shared Function GetDownloadsPath() As String
        If Environment.OSVersion.Version.Major < 6 Then Throw New NotSupportedException()
        Dim pathPtr As IntPtr = IntPtr.Zero
        Try
            SHGetKnownFolderPath(FolderDownloads, 0, IntPtr.Zero, pathPtr)
            Return Marshal.PtrToStringUni(pathPtr)
        Finally
            Marshal.FreeCoTaskMem(pathPtr)
        End Try
    End Function

    Private Shared FolderDownloads As Guid = New Guid("374DE290-123F-4565-9164-39C4925E467B")

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SHGetKnownFolderPath(ByRef id As Guid, ByVal flags As Integer, ByVal token As IntPtr, <Out> ByRef path As IntPtr) As Integer
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        searchExcelzip("manoj", "E:\Databases\GUPS  Khardiya.xlsx")
    End Sub
    Sub searchExcelzip(searchWhat As String, filepath As String)
        Dim zipPath As String = filepath
        Dim totRows As Integer = 0
        Dim xml As String = ""
        Dim shsar() As String
        Dim hdrColName As String = ""
        Dim CellValue As String

        Dim sheets As List(Of String) = New List(Of String)
        Try
            Using archive = ZipFile.Open(zipPath, ZipArchiveMode.Read)
                For Each entryy As ZipArchiveEntry In archive.Entries
                    If (Mid(entryy.FullName, 1, 14) = "xl/worksheets/") Then
                        sheets.Add(Mid(entryy.FullName, 15))
                    End If
                Next
                '------------------------Reading shared strings-------------------------
                Dim entry = archive.GetEntry("xl/sharedStrings.xml")
                If entry Is Nothing Then ListBox1.Items.Add("has no entry::" & filepath) : Exit Sub 'because excel file is empty then

                Using reader As New StreamReader(entry.Open())
                    xml = reader.ReadToEnd
                End Using
                Dim xmldoc As Xml.XmlDocument = New Xml.XmlDocument
                xmldoc.LoadXml(xml)
                Dim sst As Xml.XmlNodeList = xmldoc.GetElementsByTagName("t")
                totRows = sst.Count
                ReDim shsar(0 To sst.Count - 1) : Dim i As Integer = 0
                For Each nm As Xml.XmlNode In sst
                    shsar(i) = nm.InnerText : i += 1
                Next
                '--------------------Searching the text--------------------------------
                For i = 0 To totRows - 1 'search in shsar(shared strings array)
                    If (InStr(LCase(shsar(i)), searchWhat) > 0) Then 'found!
                        Dim searchNUM = "<v>" & i & "<"
                        '///// performence improvement tips:: get all sheets data in string array.
                        For Each sheetName As String In sheets ''sheet by sheet searching and displaying.
                            entry = archive.GetEntry("xl/worksheets/" & sheetName)
                            Using reader As New StreamReader(entry.Open())
                                xml = reader.ReadToEnd
                            End Using
                            Dim xmldoc2 As Xml.XmlDocument = New Xml.XmlDocument : xmldoc2.LoadXml(xml)
                            Dim rows As Xml.XmlNodeList = xmldoc2.GetElementsByTagName("row")
                            For Each row As Xml.XmlNode In rows
                                If InStr(row.InnerXml, searchNUM) > 0 Then
                                    'found in the row, lets make a search result.
                                    Dim searchResult As String = sheetName & "$(" & filepath & ")" & vbCrLf
                                    For j = 0 To rows(0).ChildNodes.Count - 1
                                        'Try
                                        If (rows(0).ChildNodes(j).Attributes.ItemOf("t") Is Nothing) Then
                                            hdrColName = rows(0).ChildNodes(j).InnerText
                                        Else
                                            hdrColName = shsar(Val(rows(0).ChildNodes(j).InnerText))
                                        End If

                                        If Len(hdrColName) < 20 Then
                                            searchResult &= hdrColName & Space(20 - Len(hdrColName)) & ":"
                                        Else
                                            searchResult &= hdrColName & ":"
                                        End If
                                        Try
                                            If (row.ChildNodes(j).Attributes.ItemOf("t") Is Nothing) Then
                                                CellValue = row.ChildNodes(j).InnerText
                                            Else
                                                CellValue = shsar(Val(row.ChildNodes(j).InnerText))
                                            End If
                                            'CellValue = ifDateThenConvert(CellValue, shsar.Count)
                                            searchResult &= CellValue & vbCrLf
                                        Catch
                                            searchResult &= vbCrLf
                                        End Try
                                    Next
                                    addResult(searchResult)
                                    Application.DoEvents()
                                End If
                            Next
                        Next
                    End If
                Next
            End Using
        Catch
            ListBox1.Items.Add("Not a valid xlsx(zip):" & filepath)
        End Try
    End Sub
    Private Function ifDateThenConvert(s As String, shsarCount As Integer) As String
        'if isNumber and greater then number shsar.count then.
        If IsNumeric(s) Then
            Dim num As Integer = Val(s)
            If num > shsarCount Then
                Dim edate = "01/01/1900"
                Dim expenddt As Date = Date.ParseExact(edate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                expenddt.AddDays(num)
                Return expenddt.ToString
            Else
                Return s
            End If
        Else
            Return s
        End If
    End Function
    Private Function searchVcardFile(searchWhat As String, filepath As String)
        'search line by line.
        Dim arVC() As String = IO.File.ReadAllLines(filepath)
        For i = 0 To arVC.Count - 1
            If InStr(arVC(i).ToLower, searchWhat) > 0 Then 'found. now go reverse and search BIGIN:VCARD.
                For j = i To 0 Step -1
                    If arVC(j).Equals("BEGIN:VCARD") Then 'found. now go downwards and search END:VCARD
                        For k = j To arVC.Count - 1
                            If arVC(k).Equals("END:VCARD") Then ' found. this is end. now display data.
                                parseSingleVcardEntry(arVC, j, k, filepath)
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
                i += 1
            End If
        Next
    End Function
    Private Function parseSingleVcardEntry(ar() As String, start As Integer, endd As Integer, filepath As String)
        Dim line As String
        Dim fn As String = ""
        Dim tel As String = ""

        For i = start To endd
            line = ar(i)
            If Mid(line, 1, 3).Equals("FN:") Then
                fn = Replace(line, "FN:", "")
            ElseIf Mid(line, 1, 3).Equals("TEL") Then
                tel &= Mid(line, InStr(line, ":") + 1) & vbCrLf
            End If
        Next
        showContact(fn, tel, filepath)
    End Function

    Private Sub searchInSqlite(searchWhat As String, filepath As String)
        'searchVcardFile("ravi", "G:\Uncat\data\0002.vcf")
        'Dim searchWhat As String = "nandu"
        Dim result As String = ""
        Dim tableName As String
        Dim cnn As SQLite.SQLiteConnection = New SQLite.SQLiteConnection("Data Source=" & filepath)
        cnn.Open()

        'getting table list
        Dim dt As DataTable
        Try
            dt = cnn.GetSchema("Tables")
        Catch
            ListBox1.Items.Add("Not valid sqlite:" & filepath) : Exit Sub
        End Try
        For Each dr As DataRow In dt.Rows
            tableName = dr(2).ToString
            'ListBox1.Items.Add(dr(2).ToString)

            Dim mycommand As SQLiteCommand = New SQLiteCommand(cnn)
            mycommand.CommandText = "select * from " & tableName

            Dim reader As SQLiteDataReader = mycommand.ExecuteReader()
            Dim dtt As New DataTable
            dtt.Load(reader)
            'line by line searching. when found, make a result.
            Dim dtr As DataRow
            Dim totcols As Integer = dtt.Columns.Count - 1
            For Each dtr In dtt.Rows
                For i = 0 To totcols
                    If InStr(dtr(i).ToString.ToLower, searchWhat) > 0 Then
                        result = tableName & "$(" & filepath & ")" & vbCrLf
                        For j = 0 To totcols
                            result &= makeEqualSpace(dtt.Columns(j).ToString) & dtr(j).ToString & vbCrLf
                        Next
                        addResult(result)
                        Exit For
                    End If
                Next
            Next

        Next
        cnn.Close()
    End Sub
    Private Function makeEqualSpace(ByRef data As String) As String
        'works only with monospace fonts
        Dim lendata As Integer = Len(data)
        If lendata > 20 Then
            Return data & ":"
        Else
            Return data & Space(20 - lendata) & ":"
        End If
    End Function
    Private Sub doSearch()
        Panel1.Controls.Clear()
        ListBox1.Items.Clear()

        If (chkUseCache.Checked = False) Then
            doFullSearch()
        Else
            'directly open fileList.cache and fill array
            'it may not exists. in this position, begin a full search.
            If IO.File.Exists("FileList.cache") Then
                xlsFileList = IO.File.ReadAllLines("FileList.cache").ToList
            Else
                ListBox1.Items.Add("Cached List not found: doing full search")
                doFullSearch()
            End If
        End If
        ToolStripStatusLabel2.Text = "Searching in Files"
        Application.DoEvents()
        xlsFileOpenLoop(tbSearch.Text.ToLower)
    End Sub

    Private Sub showContact(name As String, fons As String, filepath As String)
        Dim pic As New PictureBox
        Dim labfilepath As New Label
        pic.Width = Panel1.Width
        pic.Height = 100
        pic.BackColor = Color.Yellow
        pic.BorderStyle = BorderStyle.FixedSingle
        '-----------filepathlable------------
        labfilepath.BackColor = Color.White
        labfilepath.Width = pic.Width
        labfilepath.BorderStyle = BorderStyle.FixedSingle
        labfilepath.Font = labFilePathFont
        labfilepath.Text = filepath
        labfilepath.Height = labFilePathFont.Height + 2
        pic.Controls.Add(labfilepath)
        '-----------picture-----------------
        Dim foto As New PictureBox
        foto.Width = 70 : foto.Height = 70
        foto.Location = New Point(10, labfilepath.Height + 5)
        foto.BackColor = Color.AliceBlue
        pic.Controls.Add(foto)
        Dim gr As Graphics = foto.CreateGraphics
        gr.DrawString(name, MyFont, Brushes.Black, 0, 0)
        foto.Image = foto.Image
        '----------Name Label--------------
        Dim FN As New Label
        FN.Text = name
        FN.Width = pic.Width
        FN.Height = blackBoldFont.Height
        FN.Font = blackBoldFont
        FN.Location = New Point(foto.Left + foto.Width + 5, foto.Top)
        pic.Controls.Add(FN)
        '---------fon Number Label---------
        Dim TEL As New TextBox
        TEL.BorderStyle = BorderStyle.None
        TEL.BackColor = Color.Yellow
        TEL.Width = pic.Width
        TEL.Height = 500
        TEL.Multiline = True
        TEL.Text = fons
        TEL.Location = New Point(foto.Left + foto.Width + 5, foto.Top + blackBoldFont.Height + 5)
        pic.Controls.Add(TEL)
        pic.Location = New Point(0, 145 * Panel1.Controls.OfType(Of TextBox)().Count + 100 * Panel1.Controls.OfType(Of PictureBox)().Count)
        Panel1.Controls.Add(pic)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        extension(0) = "*.vcf"
        extension(1) = "*.xlsx"
        extension(2) = "*.db"
        MyFont = New Font("Courier New", 10, FontStyle.Regular)
        labFilePathFont = New Font("Courier New", 8, FontStyle.Regular)
        blackBoldFont = New Font("Segoe UI", 12, FontStyle.Bold)
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        menuPanel.BringToFront()
        menuPanel.Visible = Not menuPanel.Visible
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged

    End Sub

    Private Sub tbSearch_GotFocus(sender As Object, e As EventArgs) Handles tbSearch.GotFocus
        menuPanel.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
    End Sub
End Class
