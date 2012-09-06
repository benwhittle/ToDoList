<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ToDoList.UI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2>
        Create A New Task:
    </h2>
    <asp:TextBox ID="txtTaskDescription" Text="Task description...." Width="400" runat="server" />
    <br />
    <asp:Button ID="btnAddTask" Text="Add Task" runat="server" OnClick="AddNewTask" />

    <h2>
        Current To Do List:
    </h2>
    <p>
        <asp:GridView ID="grdTasks" runat="server" DataKeyNames="ID" 
            CellPadding="4" ForeColor="#333333" GridLines="None" OnRowUpdating="MarkTaskAsComplete"
            OnRowDeleting="DeleteTask" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Description" HeaderText="Task" />
                <asp:BoundField DataField="Created" HeaderText="Date Addeded" />
                <asp:CheckBoxField DataField="IsComplete" HeaderText="Completed" />
                <asp:ButtonField ButtonType="Button" CommandName="Update" Text="Mark As Complete" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Remove" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>
</asp:Content>
