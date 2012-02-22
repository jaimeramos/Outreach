using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SesionManager sesion = new SesionManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Focus();
        sesion.IDMenu = 0;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Usuarios user = new Usuarios();
        user.UserName = txtUserName.Text;
        user.Password = txtPassWord.Text;

        if (user.Login())
        {
            sesion.IDUsuario = user.ID;
            sesion.NombreUsuario = user.Nombre;

            Response.Redirect("~/inicio.aspx");
        }
        else
        {
            Utilerias.MostrarAlert("Datos incorrectos, intente de nuevo.", this.Page);
        }

    }
}
