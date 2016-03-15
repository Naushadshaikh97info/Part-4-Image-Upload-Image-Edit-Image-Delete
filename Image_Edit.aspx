<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Image_Edit.aspx.cs" Inherits="Image_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <h1>
                        Edit Image
                    </h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="Label1" runat="server"
                        Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" 
                        onclick="btn_submit_Click" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" Width="61px" 
                        onclick="btn_update_Click" />
                 
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                        AllowPaging="true" DataKeyNames="code" PageSize="5" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
                    <Columns>
                    <asp:CommandField HeaderText="Edit" ButtonType="Link" ShowEditButton="true" />
                    <asp:CommandField HeaderText="Delete" ButtonType="Link" ShowDeleteButton="true" />
                    <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("img_name") %>' Height="150px" Width="150px" />
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
