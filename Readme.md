# How to prevent a DetailView from being shown for a ListView record


<p><strong>Scenario</strong></p>
<p>For certain data forms, a developer needs to limit end-users to editing only through the ListView, i.e. without invoking a separate DetailView.  This is usually done by activating the inline editing and MasterDetailMode = ListViewAndDetailView features as described at <a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument113249">eXpressApp Framework > Concepts > UI Construction > Views > List View Edit Modes</a>. More real user scenarios are described <a href="https://www.devexpress.com/Support/Center/p/S34026">in this Support Center thread</a>.</p>
<p><br />For more convenience and flexibility, the following Model Editor extensions are implemented in the example to control this behavior:<br /> <strong>-</strong> The DefaultShowDetailViewFromListView  attribute at the <em>Views</em> node level allows you to control this functionality globally per application via the Model Editor;<br /> <strong>-</strong> The ShowDetailView attribute at the <em>Views | List</em><em>View</em> node level allows you to customize only certain List Views via the Model Editor;<br /><br /><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-prevent-a-detailview-from-being-shown-for-a-listview-record-e622/17.2.7+/media/f4c032a0-35fa-11e5-80bf-00155d62480c.png"><br /><br /><br /><strong>Steps to </strong><strong>implement<br /></strong></p>
<p><strong>1.</strong> Copy the <em>WinWebSolution.Module\ShowDetailViewFromListViewController.xx</em> file into the <em>YourSolutionName.Module</em> project and rebuild it.</p>
<p>The process of opening a DetailView by double clicking/pressing the Enter key on a record selected in a ListView is managed by the standard <u><a href="https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController">DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController</a></u> class and its ProcessCurrentObjectAction. Disabling this action turns off this functionality. For more information, refer to the following help topics:<br>
<a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument113169">eXpressApp Framework > Concepts > Application Model > Extend and Customize the Application Model in Code</a><br>
<a href="https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112810">eXpressApp Framework > Concepts > Application Model > Access the Application Model in Code</a><br>
<a href="https://documentation.devexpress.com/#eXpressAppFramework/DevExpressExpressAppActionsActionBase_Enabledtopic">ActionBase.Enabled Property</a><br></p>
<p><strong>2.</strong> For testing purposes, <a href="https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113326.aspx">invoke the Model Editor</a> and set the <em>DefaultShowDetailViewFromListView or ShowDetailView</em> properties for the<em> Views or Views | YourObjetType_ListView</em> nodes to <strong>False</strong> and run the test app to see that a required ListView no longer opens a DetailView in the aforementioned scenario.<br /><br />

**ASP.NET**<br />
By default, XAF Web uses a special fast callback handler for processing ListView records. This handler is intended to optimize performance of showing a DetailView from a ListView. If a DetailView is not shown on a row click, some UI elements may be refreshed incorrectly. So, we recommend disabling this optimization when this solution is used. To do this globally, add the following code to the App_Start event handler: 
  <br/>
  
```csharp
[C#]
DevExpress.ExpressApp.Web.WebApplication.OptimizationSettings.AllowFastProcessListViewRecordActions = false;
```

```vb
[VB]
DevExpress.ExpressApp.Web.WebApplication.OptimizationSettings.AllowFastProcessListViewRecordActions = False
```

To disable this optimization in a particular ListView, deactivate the ListViewFastCallbackHandlerController. See an example in the <a href="https://www.devexpress.com/Support/Center/Question/Details/T386142/faster-rendering-and-other-performance-optimizations-for-popular-web-ui-scenarios-in-xaf">Faster rendering and other performance optimizations for popular Web UI scenarios in XAF v16.1</a> article.<br />

<strong>IMPORTANT NOTES</strong><br />This article covers only the case when a DetailView is shown from the ListView after a User double clicks/presses the enter key on a record. Other scenarios should be handled separately by extending the code of this controller. For example, if you do not want to show a DetailView after a new object is created via the New Action, you can handle the NewObjectViewController.ObjectCreating event and set its ObjectCreatingEventArgs.ShowDetailView property to False. However, this is outside the purpose of this article.</p>

<br/>


