<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592237/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E622)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# XAF - How to prevent a Detail View from being shown for a List View record

## Scenario

For certain data forms, a developer needs to limit end-users to editing only through the List View, i.e. without invoking a separate Detail View. This is usually done by activating the inline editing and `MasterDetailMode` = `ListViewAndDetailView` features as described in the following article: [List View Edit Modes](https://docs.devexpress.com/eXpressAppFramework/113249/ui-construction/views/list-view-edit-modes).

## Implementation Details

To accomplish this task, access the [ListViewProcessCurrentObjectController class](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController) using the [Frame.GetController<ControllerType>() method](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Frame.GetController--1) and disable the ListViewProcessCurrentObjectController.ProcessCurrentObjectAction.

## Additional Information

This article covers only the case when a Detail View is shown from the List View after a User double-clicks or presses Enter key on a record. Other scenarios should be handled separately by extending the code of this controller.

For example, if you do not want to show a Detail View after a new object is created via the New Action, you can handle the `NewObjectViewController.ObjectCreating` event and set its `ObjectCreatingEventArgs.ShowDetailView` property to `false`. However, this is outside the purpose of this article.

## Documentation

* [Core - Make it easier to prevent showing a DetaiView from a ListView permanently or on a condition](https://supportcenter.devexpress.com/ticket/details/s34026/core-make-it-easier-to-prevent-showing-a-detaiview-from-a-listview-permanently-or-on-a)

## Files to Review

* [DisableShowingViewController.cs](./CS/EFCore/MySolution/MySolution.Module/Controllers/DisableShowingViewController.cs)
