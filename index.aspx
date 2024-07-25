<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">
        
                        <div class="form-group">
                          <div  class="col-sm-12">
                               <h2 style="text-align: center; color: blue">Employee Details</h2>
                           </div>
                        </div>    

                        <hr/>
                        <div class="row">
                        <div class="form-group col-md-6"> 
                           <label>Employee No</label>
                           
                           <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        
                       <div class="form-group col-md-6"> 
                           <label>Name</label>
                           <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
  			               
                           </div>
                        
                           <div class="form-group col-md-6"> 
                           <label>Address</label>
                               <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
  			        
                           </div>

                          <div class="form-group col-md-6"> 
                           <label>Title</label>
  			             
                               <asp:TextBox ID="txttitle" runat="server" class="form-control" placeholder="Title"></asp:TextBox>
                          </div>
                        
                          <div class="form-group col-md-6" align="center"> 
                                 <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Add" OnClick="Button1_Click"></asp:Button>
                                <asp:Button ID="Button2" runat="server" class="btn btn-warning" Text="Update" OnClick="Button2_Click"></asp:Button>
                                <asp:Button ID="Button3" runat="server" class="btn btn-danger" Text="Delete" OnClick="Button3_Click"></asp:Button>
                           
                         </div>
                           
            </div>
            </div>
    </form>
</body>
</html>
