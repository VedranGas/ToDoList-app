<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="todolist2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ToDo LIST APP</title>
</head>
<body>
    <h1 style="font-family:verdana;">Enter your items list</h1>
    <form id="form1" runat="server">
    <div>
    <asp:CheckBoxList AutoPostBack="true" ID="ToDoListBoxes" runat="server" OnSelectedIndexChanged="ToDoListBoxes_OnSelectedIndexChanged"></asp:CheckBoxList>
        <br /><br />
        <asp:TextBox runat="server" ID="ToDoName"></asp:TextBox> <asp:Button ID ="CreateToDo" runat="server" Text="Add Item" OnClick="CreateToDo_OnClick" />
    </div>
    </form>
</body>
</html>
