<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="Task_8._1_THREE_LAYER.Pages.UsersOperations" %>
<%@ Import namespace="BLL" %>
<%@ Import namespace="Entities" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Users</title>

    <script runat="server">

    private void Page_Load(Object sender, EventArgs e)
    {
        IBLL<User> bll = new UserBLL();
        var listOfUsers = bll.GetAll();

        for (int i = 0; i < listOfUsers.Count(); i++)
        {
            TableRow row = new TableRow();

            TableCell id = new TableCell();
            TableCell name = new TableCell();
            TableCell age = new TableCell();
            TableCell dateOfBirth = new TableCell();
            TableCell todo = new TableCell();

            id.Controls.Add(new LiteralControl(listOfUsers[i].Id.ToString()));
            row.Cells.Add(id);

            name.Controls.Add(new LiteralControl(listOfUsers[i].Name));
            row.Cells.Add(name);

            age.Controls.Add(new LiteralControl(listOfUsers[i].Age.ToString()));
            row.Cells.Add(age);

            dateOfBirth.Controls.Add(new LiteralControl(listOfUsers[i].DateOfBirth.ToString()));
            row.Cells.Add(dateOfBirth);

            todo.Controls.Add(new LiteralControl("TODO"));
            row.Cells.Add(todo);

            table.Rows.Add(row);
        }
    }

</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="table" 
                GridLines="Both" 
                HorizontalAlign="Center" 
                Font-Names="Verdana" 
                Font-Size="8pt" 
                CellPadding="15" 
                CellSpacing="0"
                runat="server" Width="100%"> 
                <asp:TableRow>
                    <asp:TableCell>ID</asp:TableCell>
                    <asp:TableCell>Name</asp:TableCell>
                    <asp:TableCell>Age</asp:TableCell>
                    <asp:TableCell>Birth date</asp:TableCell>
                    <asp:TableCell>TODO</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
    </form>
</body>
</html>
