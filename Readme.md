<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592237/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E622)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - How to prevent a Detail View from being shown for a List View record

## Scenario

For certain data forms, a developer needs to limit end-users to editing only through the List View, i.e. without invoking a separate Detail View. This is usually done by activating the inline editing and `MasterDetailMode` = `ListViewAndDetailView` features as described in the following article: [List View Edit Modes](https://docs.devexpress.com/eXpressAppFramework/113249/ui-construction/views/list-view-edit-modes).

![](https://raw.githubusercontent.com/DevExpress-Examples/how-to-prevent-a-detailview-from-being-shown-for-a-listview-record-e622/17.2.7+/media/f4c032a0-35fa-11e5-80bf-00155d62480c.png)

## Implementation Details

1. Copy the _WinWebSolution.Module\ShowDetailViewFromListViewController.xx_ file into the _YourSolutionName.Module_ project and rebuild it.

   The process of opening a Detail View by double-clicking/pressing the Enter key on a record selected in a List View is managed by the standard [DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController) class and its [ProcessCurrentObjectAction](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController.ProcessCurrentObjectAction) Action.
   
   We can disable this Action to accomplish our task. The approaches from the [Change the Application Model](https://docs.devexpress.com/eXpressAppFramework/403527/ui-construction/application-model-ui-settings-storage/change-application-model), [Access the Application Model in Code](https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112810) and [ActionBase.Enabled Property](https://documentation.devexpress.com/#eXpressAppFramework/DevExpressExpressAppActionsActionBase_Enabledtopic) articles are used here.
   
   For more convenience and flexibility, the following Model Editor extensions are implemented in the example to control this behavior:
   
   * The **DefaultShowDetailViewFromListView** property at the **Views** node level allows you to control this functionality globally per application via the Model Editor.
   * The **ShowDetailView** property at the **Views** | **ListView** node level allows you to customize only certain List Views via the Model Editor.

2. For testing purposes, [invoke the Model Editor](https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113326.aspx) and set the **DefaultShowDetailViewFromListView** or **ShowDetailView** properties for the **Views** or **Views** | **YourObjetType_ListView** nodes to **False** and run the test app to see that a required List View no longer opens a Detail View in the aforementioned scenario.

### ASP.NET

By default, XAF Web uses a special fast callback handler for processing List View records. This handler is intended to optimize performance of showing a Detail View from a List View. If a Detail View is not shown on a row click, some UI elements may be refreshed incorrectly. So, we recommend disabling this optimization when this solution is used. To do this globally, add the following code to the `App_Start` event handler if you work with C#:
  
```cs
DevExpress.ExpressApp.Web.WebApplication.OptimizationSettings.AllowFastProcessListViewRecordActions = false;
```

If you work with VB, add this:

```vb
DevExpress.ExpressApp.Web.WebApplication.OptimizationSettings.AllowFastProcessListViewRecordActions = False
```

To disable this optimization in a particular List View, deactivate the `ListViewFastCallbackHandlerController`. See an example in the [Faster rendering and other performance optimizations for popular Web UI scenarios in XAF v16.1](https://www.devexpress.com/Support/Center/Question/Details/T386142/faster-rendering-and-other-performance-optimizations-for-popular-web-ui-scenarios-in-xaf) article.

## Additional Information

This article covers only the case when a Detail View is shown from the List View after a User double-clicks or presses Enter key on a record. Other scenarios should be handled separately by extending the code of this controller.

For example, if you do not want to show a Detail View after a new object is created via the New Action, you can handle the `NewObjectViewController.ObjectCreating` event and set its `ObjectCreatingEventArgs.ShowDetailView` property to `false`. However, this is outside the purpose of this article.

## Documentation

* [Core - Make it easier to prevent showing a DetaiView from a ListView permanently or on a condition](https://supportcenter.devexpress.com/ticket/details/s34026/core-make-it-easier-to-prevent-showing-a-detaiview-from-a-listview-permanently-or-on-a)
