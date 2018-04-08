Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.SystemModule

Namespace WinWebSolution.Module
    Public Class ShowDetailViewFromListViewController
        Inherits ViewController(Of ListView)
        Implements IModelExtender

        Public Const EnabledKeyShowDetailView As String = "ShowDetailViewFromListViewController"
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim targetController As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)()
            If targetController IsNot Nothing Then
                targetController.ProcessCurrentObjectAction.Enabled(EnabledKeyShowDetailView) = DirectCast(View.Model, IModelShowDetailView).ShowDetailView
            End If
        End Sub
        Public Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders) Implements IModelExtender.ExtendModelInterfaces
            extenders.Add(Of IModelViews, IModelDefaultShowDetailView)()
            extenders.Add(Of IModelListView, IModelShowDetailView)()
        End Sub
    End Class
    Public Interface IModelDefaultShowDetailView
        Inherits IModelNode

        <DefaultValue(True)> _
        Property DefaultShowDetailViewFromListView() As Boolean
    End Interface
    Public Interface IModelShowDetailView
        Inherits IModelNode

        Property ShowDetailView() As Boolean
    End Interface
    <DomainLogic(GetType(IModelShowDetailView))> _
    Public Class ModelShowDetailViewLogic
        Public Shared Function Get_ShowDetailView(ByVal showDetailView As IModelShowDetailView) As Boolean
            Dim defaultShowDetailViewFromListView As IModelDefaultShowDetailView = TryCast(showDetailView.Parent, IModelDefaultShowDetailView)
            If defaultShowDetailViewFromListView IsNot Nothing Then
                Return defaultShowDetailViewFromListView.DefaultShowDetailViewFromListView
            End If
            Return True
        End Function
    End Class
End Namespace