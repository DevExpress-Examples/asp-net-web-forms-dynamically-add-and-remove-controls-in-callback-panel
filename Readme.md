<!-- default file list -->
*Files to look at*:

* **[Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))**
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [TabContentType1.ascx](./CS/WebSite/TabsContent/TabContentType1.ascx) (VB: [TabContentType1.ascx](./VB/WebSite/TabsContent/TabContentType1.ascx))
* [TabContentType2.ascx](./CS/WebSite/TabsContent/TabContentType2.ascx) (VB: [TabContentType2.ascx](./VB/WebSite/TabsContent/TabContentType2.ascx))
<!-- default file list end -->
# How to dynamically add and remove controls within ASPxCallbackPanel on callbacks


<p>This example demonstrates how you can dynamically add and remove controls within an ASPxCallbackPanel on callbacks. In this case, a ViewState is not applied so it should be disabled (the EnableViewState property is set to false). A hierarchy of controls, which have been created on callbacks, should be recreated on <a href="http://msdn.microsoft.com/en-us/library/system.web.ui.control.init">Page.Init</a> event.</p><br />
<p>In this example, tabs with custom content can be dynamically added to an ASPxPageControl on callbacks. In order to recreate a hierarchy of dynamically created controls (within tab pages) the tab information is saved to a Session object. </p><br />
<p>Additionally, the example demonstrates the usage of ASPxPageControl.TabTemplate property to specify a tab text and a close button.</p>

<br/>


