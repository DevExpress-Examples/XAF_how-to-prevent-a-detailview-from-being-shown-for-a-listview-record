Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim p As Person = ObjectSpace.CreateObject(Of Person)()
            p.FirstName = "Dennis"
            p.LastName = "Garavsky"
            p.Birthday = New Date(1987, 2, 23)
            ObjectSpace.CommitChanges()
        End Sub
    End Class
End Namespace
