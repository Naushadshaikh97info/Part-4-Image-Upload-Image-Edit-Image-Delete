<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fhoto.aspx.cs" Inherits="Fhoto" %>

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
                    Fhoto
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_Click1" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                        PageSize="5" DataKeyNames="code" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                        <Columns>
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button" />
                            <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("fhoto_nm") %>' Width="50px"
                                        Height="50px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--  <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnk_img_edit" Text="Edit Picture"  CommandArgument='<%#Eval("code") %>'
                                        runat="server" OnClick="lnk_img_edit_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                           <HeaderStyle Font-Bold="true" BackColor="Brown" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
