<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="TabContentType2.ascx.vb" Inherits="PageControlWithinCallbackPanel.TabsContent.TabContentType2" %>
<dx:ASPxGridView ID="grid" runat="server" DataSourceID="AccessDataSource1" 
    AutoGenerateColumns="False" KeyFieldName="ProductID">
    <Columns>
        <dx:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" 
            VisibleIndex="0">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ReorderLevel" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="7">
        </dx:GridViewDataCheckColumn>
    </Columns>
    <SettingsPager PageSize="15"></SettingsPager>
</dx:ASPxGridView>
<asp:AccessDataSource ID="AccessDataSource1" runat="server" 
    DataFile="~/nwind.mdb" 
    SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued] FROM [Products]">
</asp:AccessDataSource>