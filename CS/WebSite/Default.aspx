<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PageControlWithinCallbackPanel.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How you can dynamically add and remove controls within an ASPxCallbackPanel on callbacks</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <script type="text/javascript">
    function AddTab(type) {
        callbackPanel.PerformCallback('add:' + type);
    }
    function RemoveTab(index) {
        callbackPanel.PerformCallback('remove:' + index);
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <div class="buttons">
            <div>
                <dx:ASPxButton ID="Button1" runat="server" Text="Add Tab Type 1" AutoPostBack="false">
                    <ClientSideEvents Click="function(s, e) { AddTab('Type 1'); }" />
                </dx:ASPxButton>
            </div>
            <div style="padding-left: 7px">
                <dx:ASPxButton ID="Button2" runat="server" Text="Add Tab Type 2" AutoPostBack="false">
                    <ClientSideEvents Click="function(s, e) { AddTab('Type 2'); }" />
                </dx:ASPxButton>
            </div>
            <div class="clear"></div>
        </div>

        <dx:ASPxCallbackPanel ID="CallbackPanel" runat="server" ClientInstanceName="callbackPanel" OnCallback="CallbackHandler">
            <PanelCollection>
                <dx:PanelContent>
                    <dx:ASPxPageControl ID="PageControl" runat="server" EnableViewState="false" Height="500" Width="100%">
                        <TabTemplate>
                            <div class="tab">
                                <div><%# Container.TabPage.Text %></div>
                                <div class="close">
                                    <a onclick="RemoveTab(<%# Container.TabPage.Index %>); return ASPxClientUtils.PreventEventAndBubble(event);">x</a>
                                </div>
                            </div>
                        </TabTemplate>
                    </dx:ASPxPageControl>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
        <br />
        <dx:ASPxButton ID="SampleButton" runat="server" Text="PostBack"></dx:ASPxButton>

    </div>
    </form>
</body>
</html>
