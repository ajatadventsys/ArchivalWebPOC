<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetData.aspx.cs" Inherits="ArchivalWebPOC.GetData" %>

<%@ Register assembly="DevExpress.Web.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Archival Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="ProjectCode">
            </dx:ASPxLabel>
            <br />
            <asp:DropDownList ID="ProjectSelectAdd" runat="server">
            </asp:DropDownList>
            <br />
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="FromDate">
            </dx:ASPxLabel>
            <dx:ASPxDateEdit ID="FromDateAdd" runat="server">
            </dx:ASPxDateEdit>
            <br />
            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="ToDate">
            </dx:ASPxLabel>
            <dx:ASPxDateEdit ID="ToDateAdd" runat="server">
            </dx:ASPxDateEdit>
            <br />
            <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="AddTask_Click" Text="Add">
            </dx:ASPxButton>
            <br />
            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Archival Task Details">
            </dx:ASPxLabel>
            <br />
            <dx:ASPxGridView ID="TaskDetails" runat="server">
               <SettingsPopup>
                  <FilterControl AutoUpdatePosition="False"></FilterControl>
               </SettingsPopup>
               <Columns>
                <dx:GridViewDataTextColumn FieldName="SystemId" Caption="SystemId" VisibleIndex="2" />
                <dx:GridViewDataTextColumn FieldName="ProjectCode" Caption="ProjectCode" VisibleIndex="3" />
                   <dx:GridViewDataTextColumn FieldName="FromDate" Caption="FromDate" VisibleIndex="4" />
                   <dx:GridViewDataTextColumn FieldName="ToDate" Caption="ToDate" VisibleIndex="5" />
                   <dx:GridViewDataTextColumn FieldName="Status" Caption="Status" VisibleIndex="6" />
                   <dx:GridViewDataTextColumn FieldName="CreatedOn" Caption="CreatedOn" VisibleIndex="7" />
                   <dx:GridViewDataTextColumn FieldName="CreatedBy" Caption="CreatedBy" VisibleIndex="8" />
                   <dx:GridViewDataTextColumn FieldName="Remarks" Caption="Remarks" VisibleIndex="9" />
                   <dx:GridViewDataTextColumn FieldName="LastUpdate" Caption="LastUpdate" VisibleIndex="10" />
               </Columns>
            </dx:ASPxGridView>
            <br />
            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Table Select">
            </dx:ASPxLabel>
            <br />
            <asp:DropDownList ID="TableSelectView" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="ProjectCode">
            </dx:ASPxLabel>
            <br />
            <asp:DropDownList ID="ProjectCodeView" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="FromDate">
            </dx:ASPxLabel>
            <dx:ASPxDateEdit ID="FromDateView" runat="server">
            </dx:ASPxDateEdit>
            <br />
            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="ToDate">
            </dx:ASPxLabel>
            <br />
            <dx:ASPxDateEdit ID="ToDateView" runat="server">
            </dx:ASPxDateEdit>
            <br />
            <dx:ASPxButton ID="ViewRecords" runat="server" Text="View">
            </dx:ASPxButton>
            <br />
            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Archived Records Details">
            </dx:ASPxLabel>
            <dx:ASPxGridView ID="ArchivedRecords" runat="server">
            </dx:ASPxGridView>
        </div>
    </form>
</body>
</html>
