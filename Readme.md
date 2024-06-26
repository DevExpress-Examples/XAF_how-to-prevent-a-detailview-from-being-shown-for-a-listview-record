<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128592237/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E622)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XAF - Prevent Showing a Detail View of a List View Object

This example demonstrates how to prevent a user from invoking a Detail View of an object in a List View.

To allow users to edit objects directly in a List View, enable the [in-place edit](https://docs.devexpress.com/eXpressAppFramework/113249/ui-construction/views/list-view-edit-modes#in-place-editing) and [split layout](https://docs.devexpress.com/eXpressAppFramework/113249/ui-construction/views/list-view-edit-modes#split-layout-the-masterdetailmode-property) functionality.

## Implementation Details

Call the [Frame.GetController<ControllerType>](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Frame.GetController--1) method to access an instance of the [ListViewProcessCurrentObjectController](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController) class and disable the [ListViewProcessCurrentObjectController.ProcessCurrentObjectAction](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ListViewProcessCurrentObjectController.ProcessCurrentObjectAction) property.

## Additional Information
  
This example applies only when an XAF application displays a Detail View of an object after a user double-clicks this object in a List View, or focuses an object in a List View and presses Enter. To handle other scenarios, extend the controller's code. For example, if you do not want your XAF application to invoke a Detail View after a user clicks the **New** button to create an object in a List View, handle the [NewObjectViewController.ObjectCreating](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.NewObjectViewController.ObjectCreating) event and set the [ObjectCreatingEventArgs.ShowDetailView](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.SystemModule.ObjectCreatingEventArgs.ShowDetailView) property to `false`.
  
## Files to Review

* [DisableShowingViewController.cs](./CS/EFCore/MySolution/MySolution.Module/Controllers/DisableShowingViewController.cs)
  
## Documentation

* [Core - Make it easier to prevent showing a DetaiView from a ListView permanently or on a condition](https://supportcenter.devexpress.com/ticket/details/s34026/core-make-it-easier-to-prevent-showing-a-detaiview-from-a-listview-permanently-or-on-a)
* [List View Edit Modes](https://docs.devexpress.com/eXpressAppFramework/113249/ui-construction/views/list-view-edit-modes)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-prevent-a-detailview-from-being-shown-for-a-listview-record&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-prevent-a-detailview-from-being-shown-for-a-listview-record&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
