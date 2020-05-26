<%@ Page Title="Inscripciones" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario de inscripciones</h2>
    <form>
        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Primer nombre</label>
            <div class="col-sm-9">
                <asp:TextBox ID="nombre_1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Segundo nombre</label>
            <div class="col-sm-9">
                <asp:TextBox ID="nombre_2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Primer Apellido</label>
            <div class="col-sm-9">
                <asp:TextBox ID="apellido_1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Segundo Apellido</label>
            <div class="col-sm-9">
                <asp:TextBox ID="apellido_2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Fecha de nacimiento</label>
            <div class="col-sm-9">
                <asp:TextBox ID="fecha_nacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Sexo</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="Sexo" runat="server" CssClass="custom-select">
                    <asp:ListItem Enabled="true" Text="Seleccione el sexo" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                </asp:DropDownList>
            </div>

            
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Dirección</label>
            <div class="col-sm-9">
                <asp:TextBox ID="direccion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="nombre_1">Teléfono</label>
            <div class="col-sm-9">
                <asp:TextBox ID="telefono" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="Departamento">Departamento</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="Departamento" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="Departamento_SelectedIndexChanged" ></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="Municipio">Municipio</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="Municipio" runat="server" CssClass="custom-select"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="Carrera">Carrera</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="Carrera" runat="server" CssClass="custom-select"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="Jornada">Jornada</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="Jornada" runat="server" CssClass="custom-select"></asp:DropDownList>
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-3 col-form-label" for="Carrera">Contraseña</label>
            <div class="col-sm-9">
                <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
        </div>

        <div class="my-5">
            <button runat="server" id="btnSave" class="btn btn-outline-dark btn-lg" title="Guardar" onserverclick="SaveInscripcion">
                <i class="fa fa-save"></i> Guardar inscripcion
            </button>
        </div>

    
    </form>
</asp:Content>
