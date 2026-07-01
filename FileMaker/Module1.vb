'TODO:1. Change Procedure name to your own procedure name
'TODO:2.  Add Json package to the resources
'TODO:3. Create A Project Class
'TODO:4.  Create A Json file for the Project Class
'TODO:5.  Refactor writeFile procedure to take a string for data input
'TODO:6.  move the input variable up to the global class variable access
'TODO:7.  Seralize Project Class
'TODO:8.  Deseralize The Project json Class
'TODO:9.  Use snippets (insert comment) to add comments to procedures and functions
'TODO:10.Refactor your code to create subfolders in a separate procedure
'TODO:11.Remove reference comments

Module Module1

    'READ: 'More information on file reading and writing in the coursebook: pg 68: FileRead
    'https://drive.google.com/file/d/1qwb9Sq3bf9sWPdAUeiFX_xM1Knb4Ikpp/view


    Dim ProjectName As String
    Dim FullDirectory As String
    Sub Main()
        'Text in following prompts can be changed for more immersive experience'
        Dim input As String = 0
        While input <> "exit"
            Console.WriteLine("please enter product name.")
            ProjectName = Console.ReadLine
            Console.WriteLine("Please enter a command  Exit | create")

            input = Console.ReadLine.ToString()
            If input = "create" Then
                MakeP2PProjectFolders()
            End If
        End While

    End Sub

    Private Sub MakeP2PProjectFolders()
        'TODO: Add Json database
        'TODO: Change MakeP2PProjectFolders to MakeProjectFolders


        Dim newFolderPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop
        If ProjectName = "" Then
            ProjectName = " Not Set\"
        End If

        '  My.Computer.FileSystem.CreateDirectory(newFolderPath + ProjectName)
        CreateProjectFolder(newFolderPath, ProjectName)
        newFolderPath += "\" + ProjectName
        FullDirectory = newFolderPath

        'INSERT new folders by copy and pasting "CreateProjectFolder($"{newFolderPath}\" followed by new main folder name'

        CreateProjectFolder(newFolderPath, "\Project")
        CreateProjectFolder($"{newFolderPath}\Project", "Images")
        CreateProjectFolder($"{newFolderPath}\Project", "Notes")
        CreateProjectFolder($"{newFolderPath}\Project", "Main")


        CreateProjectFolder(newFolderPath, "\NonProd")
        CreateProjectFolder($"{newFolderPath}\NonProd", "Possible Additions")
        CreateProjectFolder($"{newFolderPath}\NonProd", "Other")

        WriteFile("ReadMe", newFolderPath)




        Console.WriteLine("Project created in: " + FullDirectory)
    End Sub

    Private Sub WriteFile(fileName As String, location As String)

        'Ref:https://docs.microsoft.com/en-us/dotnet/visual-basic/developing-apps/programming/drives-directories-files/how-to-write-text-to-files-with-a-streamwriter

        If fileName <> "" Then

            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(location + "\" + fileName + ".txt", True)
            'Change the bottom text in ("") for updated ReadMe files'
            file.WriteLine("Explain what your app creates and why it is useful.
	- Application creates a template of folders and subfolders to provide an organized file system between all users.

## How To Run
Explain how to open and run the VB.NET project.
	- Launch project and Run once opened.

## Folder Structure Created
List the folders and files your app generates.
	- Project
		> Images
		> Notes
		> Main
	- NonProd
		> possible additions
		> Other

## Story to App Connection
Explain how your story or backstory led to this utility.
	- Countless discoveries, technologies, and other bits of information had been lost as they were tracked and written using paper. The modules members of the guild use and this new method of storing and tracking objectives.

## Team Members
Individual project.")

            file.Close()

        End If

    End Sub

    Sub CreateProjectFolder(newFolderPath As String, ProjectName As String)

        My.Computer.FileSystem.CreateDirectory(newFolderPath + "\" + ProjectName)

    End Sub

End Module