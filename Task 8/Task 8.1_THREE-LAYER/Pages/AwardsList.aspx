<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AwardsList.aspx.cs" Inherits="Task_8._1_THREE_LAYER.Pages.AwardsList" %>
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
        IBLL<Award> bll = new AwardBLL();
        var listOfAwards = bll.GetAll();

        for (int i = 0; i < listOfAwards.Count(); i++)
        {
            TableRow row = new TableRow();

            TableCell id = new TableCell();
            TableCell title = new TableCell();
            TableCell todo = new TableCell();

            id.Controls.Add(new LiteralControl(listOfAwards[i].Id.ToString()));
            row.Cells.Add(id);

            title.Controls.Add(new LiteralControl(listOfAwards[i].Title));
            row.Cells.Add(title);

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
                    <asp:TableCell>Title</asp:TableCell>
                    <asp:TableCell>TODO</asp:TableCell>
                </asp:TableRow>
            </asp:Table>  
        </div>
    </form>
</body>
</html>