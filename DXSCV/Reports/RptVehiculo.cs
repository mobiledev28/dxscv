using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using System.Text;
using SCVData;
using System.Linq;
using System.Data.Objects.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for RptVehiculo
/// </summary>
public class RptVehiculo : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private PageHeaderBand pageHeaderBand1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLine xrLine1;
    private XRLine xrLine2;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private PageFooterBand pageFooterBand1;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel33;
    private XRLine xrLine3;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
    private PageHeaderBand pageHeaderBand2;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel46;
    private XRLabel xrLabel47;
    private XRLabel xrLabel48;
    private XRLabel xrLabel49;
    private XRLine xrLine4;
    private XRLine xrLine5;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel54;
    private XRLabel xrLabel55;
    private XRLabel xrLabel56;
    private XRLabel xrLabel57;
    private XRLabel xrLabel58;
    private XRLabel xrLabel59;
    private XRLabel xrLabel63;
    private XRLabel xrLabel64;
    private XRLabel xrLabel65;
    private XRLabel xrLabel66;
    private XRLabel xrLabel67;
    private XRLabel xrLabel68;
    private PageFooterBand pageFooterBand2;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    private ReportHeaderBand reportHeaderBand2;
    private XRLabel xrLabel74;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    public DevExpress.XtraReports.Parameters.Parameter Empresa;
    private DevExpress.XtraReports.Parameters.Parameter Ciudad;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource3;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource4;
    private XRPictureBox xrPictureBox4;
    private XRPictureBox xrPictureBox3;
    private XRPictureBox xrPictureBox2;
    private XRPictureBox xrPictureBox1;
    private CalculatedField cfUsuario;  
    private DevExpress.DataAccess.Sql.SqlDataSource dsRptVehiculos;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroEmpresa;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroCiudad;
    private XRLabel xrLabel41;
    private XRLabel xrLabel40;
    private CalculatedField calculatedField1;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroProveedor;
    private DevExpress.XtraReports.Parameters.Parameter Proveedor;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public RptVehiculo()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        // Assign a set of values to the report parameter.
        this.Empresa.Value = new string[] {};
        this.Ciudad.Value = new int[] {};
        this.Proveedor.Value = new int[] {};

        // Handle the DataSourceDemanded event of a report.
        this.DataSourceDemanded += XtraReport1_DataSourceDemanded;
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    void InitQuery(ref CustomSqlQuery querytest)
    {
        StringBuilder query = new StringBuilder();
        if (querytest.Sql.Contains("WHERE "))
        {
            query.Append("select \"SCV_Vehiculo\".\"VehiculoId\",\r\n       \"SCV_Vehiculo\".\"Marca\",\r\n       \"SCV_Vehiculo\".\"Modelo\",\r\n       \"SCV_Vehiculo\".\"Anio\",\r\n       \"SCV_Vehiculo\".\"NoSerie\",\r\n       ISNULL(\"SCV_Vehiculo\".\"Apodo\",'') AS \"Apodo\",\r\n       \"SCV_Vehiculo\".\"Placa\",\r\n       ISNULL(\"SCV_Vehiculo\".\"NoMotor\",'') AS \"NoMotor\",\r\n       \"SCV_Vehiculo\".\"UsuarioIdAsignado\",\r\n       \"SCV_Vehiculo\".\"CiudadId\",\r\n       \"SCV_Vehiculo\".\"EmpresaId\",\r\n       \"SCV_Usuario\".\"Nombre\",\r\n       \"SCV_Usuario\".\"ApPaterno\",\r\n       \"SCV_Usuario\".\"ApMaterno\",\r\n       \"SCV_Mantenimiento\".\"MantenimientoId\",\r\n       \"SCV_Mantenimiento\".\"DescripcionMtto\",\r\n       ISNULL(\"SCV_Mantenimiento\".\"NumFactura\",'') AS \"NumFactura\",\r\n       ISNULL(\"SCV_Mantenimiento\".\"EstatusFactura\",'') AS \"EstatusFactura\",       \r\n       \"SCV_Proveedor\".\"RazonSocial\",\r\n       \"SCV_Empresa\".\"Nombre\" as \"SCV_Empresa_Nombre\",\r\n       \"SCV_Ciudad\".\"Descripcion\"\r\n  from (((((\"dbo\".\"SCV_Vehiculo\" \"SCV_Vehiculo\"\r\n  inner join \"dbo\".\"SCV_Usuario\" \"SCV_Usuario\"\r\n       on (\"SCV_Usuario\".\"UsuarioId\" = \"SCV_Vehiculo\".\"UsuarioIdAsignado\"))\r\n  inner join \"dbo\".\"SCV_Mantenimiento\"\r\n       \"SCV_Mantenimiento\"\r\n       on (\"SCV_Mantenimiento\".\"VehiculoId\" = \"SCV_Vehiculo\".\"VehiculoId\"))\r\n  inner join \"dbo\".\"SCV_Proveedor\" \"SCV_Proveedor\"\r\n       on (\"SCV_Proveedor\".\"ProveedorId\" = \"SCV_Mantenimiento\".\"ProveedorId\"))\r\n  inner join \"dbo\".\"SCV_Empresa\" \"SCV_Empresa\"\r\n       on (\"SCV_Empresa\".\"EmpresaId\" = \"SCV_Vehiculo\".\"EmpresaId\"))\r\n  inner join \"dbo\".\"SCV_Ciudad\" \"SCV_Ciudad\"\r\n       on (\"SCV_Ciudad\".\"CiudadId\" = \"SCV_Vehiculo\".\"CiudadId\"))");
            querytest.Sql = query.ToString();
       
        }
    }

    void XtraReport1_DataSourceDemanded(object sender, EventArgs e)
    {
        SqlQueryCollection query = this.dsRptVehiculos.Queries as SqlQueryCollection;
        CustomSqlQuery querytest = this.dsRptVehiculos.Queries[0] as CustomSqlQuery;
        TCADBHMTEntities db = new TCADBHMTEntities();
        StringBuilder builder = new StringBuilder();
        bool isFirstParam = true;
        int count = 0;

        InitQuery(ref querytest);

        //Empresa
        count = (this.Empresa.Value as IList).Count;

        if (count > 0)
        {
            builder.Append('(');

            for (int i = 0; i < count; i++)
            {
                builder.Append((this.Empresa.Value as IList)[i]);
                if (i != count - 1)
                {
                    builder.Append(',');
                }
            }

            builder.Append(')');

            if (isFirstParam)
            {
                
                querytest.Sql += " WHERE [SCV_Empresa].[EmpresaId] IN " + builder.ToString();
                isFirstParam = false;
            }
            
        }

        

        //Ciudad
        count = (this.Ciudad.Value as IList).Count;

        if (count > 0)
        {
            builder = new StringBuilder();
            builder.Append('(');
            for (int i = 0; i < count; i++)
            {
                //builder.Append('\''); // Uncomment this line when parsing a string parameter value.
                builder.Append((this.Ciudad.Value as IList)[i]);
                //builder.Append('\''); // Uncomment this line when parsing a string parameter value.
                if (i != count - 1)
                    builder.Append(',');
            }
            builder.Append(')');

            if (isFirstParam)
            {
                querytest.Sql += " WHERE [SCV_Ciudad].[CiudadId] IN " + builder.ToString();
                isFirstParam = false;
            }
            else
            {
                querytest.Sql += " AND [SCV_Ciudad].[CiudadId] IN " + builder.ToString();
            }
        }

        //Proveedor
        count = (this.Proveedor.Value as IList).Count;

        if (count > 0)
        {
            builder = new StringBuilder();
            builder.Append('(');
            for (int i = 0; i < count; i++)
            {
                //builder.Append('\''); // Uncomment this line when parsing a string parameter value.
                builder.Append((this.Proveedor.Value as IList)[i]);
                //builder.Append('\''); // Uncomment this line when parsing a string parameter value.
                if (i != count - 1)
                    builder.Append(',');
            }
            builder.Append(')');

            if (isFirstParam)
            {
                querytest.Sql += " WHERE [SCV_Proveedor].[ProveedorId] IN " + builder.ToString();
                isFirstParam = false;
            }
            else
            {
                querytest.Sql += " AND [SCV_Proveedor].[ProveedorId] IN " + builder.ToString();
            }
        }

        dsRptVehiculos.RebuildResultSchema();



    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptVehiculo));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery5 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery6 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery7 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings3 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.dsFiltroEmpresa = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.dsFiltroCiudad = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.dsFiltroProveedor = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.sqlDataSource3 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.sqlDataSource4 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pageHeaderBand2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel67 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel68 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand2 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Empresa = new DevExpress.XtraReports.Parameters.Parameter();
            this.Ciudad = new DevExpress.XtraReports.Parameters.Parameter();
            this.cfUsuario = new DevExpress.XtraReports.UI.CalculatedField();
            this.dsRptVehiculos = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.calculatedField1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.Proveedor = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dsFiltroEmpresa
            // 
            this.dsFiltroEmpresa.ConnectionName = "10.1.2.25_TCADBHMT_Connection";
            this.dsFiltroEmpresa.Name = "dsFiltroEmpresa";
            customSqlQuery1.Name = "SCV_Empresa";
            customSqlQuery1.Sql = "select \"SCV_Empresa\".\"EmpresaId\",\r\n       \"SCV_Empresa\".\"Nombre\"\r\n  from \"dbo\".\"S" +
    "CV_Empresa\" \"SCV_Empresa\"";
            this.dsFiltroEmpresa.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dsFiltroEmpresa.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0iZHNGaWx0cm9FbXByZXNhIj48VmlldyBOYW1lPSJTQ1ZfRW1wcmVzYSI+PEZpZ" +
    "WxkIE5hbWU9IkVtcHJlc2FJZCIgVHlwZT0iSW50MzIiIC8+PEZpZWxkIE5hbWU9Ik5vbWJyZSIgVHlwZ" +
    "T0iU3RyaW5nIiAvPjwvVmlldz48L0RhdGFTZXQ+";
            // 
            // dsFiltroCiudad
            // 
            this.dsFiltroCiudad.ConnectionName = "10.1.2.25_TCADBHMT_Connection";
            this.dsFiltroCiudad.Name = "dsFiltroCiudad";
            customSqlQuery2.Name = "SCV_Ciudad";
            customSqlQuery2.Sql = "select \"SCV_Ciudad\".\"CiudadId\",\r\n       \"SCV_Ciudad\".\"Descripcion\"\r\n  from \"dbo\"." +
    "\"SCV_Ciudad\" \"SCV_Ciudad\"\r\n";
            this.dsFiltroCiudad.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.dsFiltroCiudad.ResultSchemaSerializable = resources.GetString("dsFiltroCiudad.ResultSchemaSerializable");
            // 
            // dsFiltroProveedor
            // 
            this.dsFiltroProveedor.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsFiltroProveedor.Name = "dsFiltroProveedor";
            customSqlQuery3.Name = "SCV_Proveedor";
            customSqlQuery3.Sql = "select \"SCV_Proveedor\".\"ProveedorId\",\r\n       \"SCV_Proveedor\".\"RazonSocial\"\r\n  fr" +
    "om \"dbo\".\"SCV_Proveedor\" \"SCV_Proveedor\"";
            this.dsFiltroProveedor.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery3});
            this.dsFiltroProveedor.ResultSchemaSerializable = resources.GetString("dsFiltroProveedor.ResultSchemaSerializable");
            // 
            // sqlDataSource3
            // 
            this.sqlDataSource3.ConnectionName = "TCADBHMT_Connection_PROD";
            this.sqlDataSource3.Name = "sqlDataSource3";
            customSqlQuery4.Name = "SCV_Empresa";
            customSqlQuery4.Sql = "select \"SCV_Empresa\".\"EmpresaId\",\r\n       \"SCV_Empresa\".\"Nombre\"\r\n  from \"dbo\".\"S" +
    "CV_Empresa\" \"SCV_Empresa\"\r\nUNION SELECT 0 AS EmpresaId, \'TODAS\' AS Nombre";
            this.sqlDataSource3.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery4});
            this.sqlDataSource3.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0ic3FsRGF0YVNvdXJjZTMiPjxWaWV3IE5hbWU9IlNDVl9FbXByZXNhIj48Rmllb" +
    "GQgTmFtZT0iRW1wcmVzYUlkIiBUeXBlPSJJbnQzMiIgLz48RmllbGQgTmFtZT0iTm9tYnJlIiBUeXBlP" +
    "SJTdHJpbmciIC8+PC9WaWV3PjwvRGF0YVNldD4=";
            // 
            // sqlDataSource4
            // 
            this.sqlDataSource4.ConnectionName = "TCADBHMT_Connection_PROD";
            this.sqlDataSource4.Name = "sqlDataSource4";
            customSqlQuery5.Name = "SCV_Ciudad";
            customSqlQuery5.Sql = "select \"SCV_Ciudad\".\"CiudadId\",\r\n       \"SCV_Ciudad\".\"Descripcion\"\r\n  from \"dbo\"." +
    "\"SCV_Ciudad\" \"SCV_Ciudad\"\r\nUNION SELECT 0 AS EmpresaId, \'TODAS\' AS Nombre";
            this.sqlDataSource4.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery5});
            this.sqlDataSource4.ResultSchemaSerializable = resources.GetString("sqlDataSource4.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionName = "TCADBHMT_Connection_PROD";
            this.sqlDataSource2.Name = "sqlDataSource2";
            customSqlQuery6.Name = "SCV_Vehiculo";
            customSqlQuery6.Sql = resources.GetString("customSqlQuery6.Sql");
            this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery6});
            this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
            // 
            // pageHeaderBand2
            // 
            this.pageHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel42,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel45,
            this.xrLabel46,
            this.xrLabel47,
            this.xrLabel48,
            this.xrLabel49,
            this.xrLine4,
            this.xrLine5});
            this.pageHeaderBand2.Dpi = 100F;
            this.pageHeaderBand2.HeightF = 27.91668F;
            this.pageHeaderBand2.Name = "pageHeaderBand2";
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 7.000001F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(85.80453F, 18.29165F);
            this.xrLabel34.StylePriority.UseFont = false;
            this.xrLabel34.Text = "Tipo Servicio";
            // 
            // xrLabel35
            // 
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(91.80453F, 6.916682F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(74.43243F, 18.37497F);
            this.xrLabel35.StylePriority.UseFont = false;
            this.xrLabel35.Text = "Vehículo";
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(860F, 6.916682F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(76.98822F, 18.37497F);
            this.xrLabel36.StylePriority.UseFont = false;
            this.xrLabel36.Text = "Estatus Fac";
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(936.9882F, 6.916682F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(63.76971F, 18.37499F);
            this.xrLabel37.StylePriority.UseFont = false;
            this.xrLabel37.Text = "Factura";
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(166.237F, 6.916682F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(110.7324F, 18.37499F);
            this.xrLabel38.StylePriority.UseFont = false;
            this.xrLabel38.Text = "Descripcion Mtto";
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(276.9693F, 6.916682F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(98.99405F, 18.37499F);
            this.xrLabel39.StylePriority.UseFont = false;
            this.xrLabel39.Text = "Proveedor";
            // 
            // xrLabel42
            // 
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(1000.758F, 7.000001F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(70.57281F, 18.29165F);
            this.xrLabel42.StylePriority.UseFont = false;
            this.xrLabel42.Text = "Usuario";
            // 
            // xrLabel43
            // 
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(375.9634F, 7.000001F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(59.375F, 18.29167F);
            this.xrLabel43.StylePriority.UseFont = false;
            this.xrLabel43.Text = "Sucursal";
            // 
            // xrLabel44
            // 
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(435.3384F, 7.000001F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(70.99997F, 18.29165F);
            this.xrLabel44.StylePriority.UseFont = false;
            this.xrLabel44.Text = "Placa";
            // 
            // xrLabel45
            // 
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(506.3384F, 7.000001F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(59.6748F, 18.29166F);
            this.xrLabel45.StylePriority.UseFont = false;
            this.xrLabel45.Text = "Serie";
            // 
            // xrLabel46
            // 
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(567.0945F, 7.000001F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(63.63824F, 18.29166F);
            this.xrLabel46.StylePriority.UseFont = false;
            this.xrLabel46.Text = "Modelo";
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(630.7327F, 7.000001F);
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(69.74884F, 18.29166F);
            this.xrLabel47.StylePriority.UseFont = false;
            this.xrLabel47.Text = "Linea";
            // 
            // xrLabel48
            // 
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(700.4816F, 7F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(80.52271F, 18.29166F);
            this.xrLabel48.StylePriority.UseFont = false;
            this.xrLabel48.Text = "Marca";
            // 
            // xrLabel49
            // 
            this.xrLabel49.Dpi = 100F;
            this.xrLabel49.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(781.0043F, 7.000001F);
            this.xrLabel49.Name = "xrLabel49";
            this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel49.SizeF = new System.Drawing.SizeF(78.99573F, 18.29166F);
            this.xrLabel49.StylePriority.UseFont = false;
            this.xrLabel49.Text = "Empresa";
            // 
            // xrLine4
            // 
            this.xrLine4.Dpi = 100F;
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(6F, 3.916678F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1065.331F, 2.08332F);
            // 
            // xrLine5
            // 
            this.xrLine5.Dpi = 100F;
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(6F, 25.91668F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(1065.331F, 2F);
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel41,
            this.xrLabel40,
            this.xrLabel54,
            this.xrLabel55,
            this.xrLabel56,
            this.xrLabel57,
            this.xrLabel58,
            this.xrLabel59,
            this.xrLabel63,
            this.xrLabel64,
            this.xrLabel65,
            this.xrLabel66,
            this.xrLabel67,
            this.xrLabel68});
            this.groupHeaderBand2.Dpi = 100F;
            this.groupHeaderBand2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TipoServicio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Apodo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("EstatusFactura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("NumFactura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("DescripcionMtto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("RazonSocial", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("ApMaterno", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("ApPaterno", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("SCV_Usuario_Nombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Descripcion", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Placa", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("NoSerie", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Anio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Modelo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Marca", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Nombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("VehiculoId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand2.HeightF = 62.16666F;
            this.groupHeaderBand2.Name = "groupHeaderBand2";
            // 
            // xrLabel41
            // 
            this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "calculatedField1")});
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(1000.758F, 0F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(70.57312F, 15.70833F);
            // 
            // xrLabel40
            // 
            this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.SCV_Empresa_Nombre")});
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(781.0044F, 0F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(78.99567F, 15.70833F);
            // 
            // xrLabel54
            // 
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.TipoServicio")});
            this.xrLabel54.Dpi = 100F;
            this.xrLabel54.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(85.80453F, 15.70833F);
            this.xrLabel54.StylePriority.UseFont = false;
            // 
            // xrLabel55
            // 
            this.xrLabel55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.Apodo")});
            this.xrLabel55.Dpi = 100F;
            this.xrLabel55.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(91.80453F, 0F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(74.4324F, 15.70833F);
            this.xrLabel55.StylePriority.UseFont = false;
            // 
            // xrLabel56
            // 
            this.xrLabel56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.EstatusFactura")});
            this.xrLabel56.Dpi = 100F;
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(76.98822F, 15.70833F);
            // 
            // xrLabel57
            // 
            this.xrLabel57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.NumFactura")});
            this.xrLabel57.Dpi = 100F;
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(936.9882F, 0F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(63.76971F, 15.70833F);
            // 
            // xrLabel58
            // 
            this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.DescripcionMtto")});
            this.xrLabel58.Dpi = 100F;
            this.xrLabel58.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(166.2369F, 0F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(110.7324F, 15.70833F);
            this.xrLabel58.StylePriority.UseFont = false;
            // 
            // xrLabel59
            // 
            this.xrLabel59.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.RazonSocial")});
            this.xrLabel59.Dpi = 100F;
            this.xrLabel59.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(276.9693F, 0F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(98.99405F, 15.70833F);
            this.xrLabel59.StylePriority.UseFont = false;
            // 
            // xrLabel63
            // 
            this.xrLabel63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Descripcion")});
            this.xrLabel63.Dpi = 100F;
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(375.9634F, 0F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(59.37503F, 15.70833F);
            // 
            // xrLabel64
            // 
            this.xrLabel64.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.Placa")});
            this.xrLabel64.Dpi = 100F;
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(435.3384F, 0F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(70.99997F, 15.70833F);
            // 
            // xrLabel65
            // 
            this.xrLabel65.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.NoSerie")});
            this.xrLabel65.Dpi = 100F;
            this.xrLabel65.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(506.3384F, 0F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(63.67987F, 15.70833F);
            this.xrLabel65.StylePriority.UseFont = false;
            // 
            // xrLabel66
            // 
            this.xrLabel66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.Anio")});
            this.xrLabel66.Dpi = 100F;
            this.xrLabel66.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(570.0183F, 0F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(60.71448F, 15.70833F);
            this.xrLabel66.StylePriority.UseFont = false;
            // 
            // xrLabel67
            // 
            this.xrLabel67.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.Modelo")});
            this.xrLabel67.Dpi = 100F;
            this.xrLabel67.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(630.7327F, 0F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(69.74896F, 15.70833F);
            this.xrLabel67.StylePriority.UseFont = false;
            // 
            // xrLabel68
            // 
            this.xrLabel68.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource2, "SCV_Vehiculo.Marca")});
            this.xrLabel68.Dpi = 100F;
            this.xrLabel68.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(700.4817F, 0F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(80.52271F, 15.70833F);
            this.xrLabel68.StylePriority.UseFont = false;
            // 
            // pageFooterBand2
            // 
            this.pageFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.xrPageInfo4});
            this.pageFooterBand2.Dpi = 100F;
            this.pageFooterBand2.HeightF = 29.00001F;
            this.pageFooterBand2.Name = "pageFooterBand2";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(313F, 23F);
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Dpi = 100F;
            this.xrPageInfo4.Format = "Page {0} of {1}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(758.3307F, 6.00001F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand2
            // 
            this.reportHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel74});
            this.reportHeaderBand2.Dpi = 100F;
            this.reportHeaderBand2.HeightF = 48.5F;
            this.reportHeaderBand2.Name = "reportHeaderBand2";
            this.reportHeaderBand2.StylePriority.UseTextAlignment = false;
            this.reportHeaderBand2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel74
            // 
            this.xrLabel74.Dpi = 100F;
            this.xrLabel74.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(384.3995F, 10.00001F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(246.3333F, 29.45834F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.Text = "Reporte de Vehiculos";
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox4,
            this.xrPictureBox3,
            this.xrPictureBox2,
            this.xrPictureBox1});
            this.topMarginBand1.Dpi = 100F;
            this.topMarginBand1.HeightF = 84.33334F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.Dpi = 100F;
            this.xrPictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox4.Image")));
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(722.0857F, 18.33334F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(187.2189F, 56F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.Dpi = 100F;
            this.xrPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox3.Image")));
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(513.1847F, 18.33335F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(194.2076F, 56F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Dpi = 100F;
            this.xrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox2.Image")));
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(312.7322F, 18.33334F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(188.5467F, 56.00002F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(109.8045F, 18.33334F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(188.5417F, 56F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 100F;
            this.bottomMarginBand1.HeightF = 27.25F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // Empresa
            // 
            this.Empresa.Description = "Empresa";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "SCV_Empresa";
            dynamicListLookUpSettings1.DataSource = this.dsFiltroEmpresa;
            dynamicListLookUpSettings1.DisplayMember = "Nombre";
            dynamicListLookUpSettings1.ValueMember = "EmpresaId";
            this.Empresa.LookUpSettings = dynamicListLookUpSettings1;
            this.Empresa.MultiValue = true;
            this.Empresa.Name = "Empresa";
            this.Empresa.ValueInfo = "Int32[] Array";
            // 
            // Ciudad
            // 
            this.Ciudad.Description = "Ciudad";
            dynamicListLookUpSettings2.DataAdapter = null;
            dynamicListLookUpSettings2.DataMember = "SCV_Ciudad";
            dynamicListLookUpSettings2.DataSource = this.dsFiltroCiudad;
            dynamicListLookUpSettings2.DisplayMember = "Descripcion";
            dynamicListLookUpSettings2.ValueMember = "CiudadId";
            this.Ciudad.LookUpSettings = dynamicListLookUpSettings2;
            this.Ciudad.MultiValue = true;
            this.Ciudad.Name = "Ciudad";
            // 
            // cfUsuario
            // 
            this.cfUsuario.DisplayName = "UsuarioFullName";
            this.cfUsuario.Expression = "Concat([SCV_Vehiculo.SCV_Usuario_Nombre], [SCV_Vehiculo.ApPaterno], [SCV_Vehiculo" +
    ".ApMaterno])";
            this.cfUsuario.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.cfUsuario.Name = "cfUsuario";
            // 
            // dsRptVehiculos
            // 
            this.dsRptVehiculos.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsRptVehiculos.Name = "dsRptVehiculos";
            customSqlQuery7.Name = "SCV_Vehiculo";
            customSqlQuery7.Sql = resources.GetString("customSqlQuery7.Sql");
            this.dsRptVehiculos.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery7});
            this.dsRptVehiculos.ResultSchemaSerializable = resources.GetString("dsRptVehiculos.ResultSchemaSerializable");
            // 
            // calculatedField1
            // 
            this.calculatedField1.DataSource = this.sqlDataSource2;
            this.calculatedField1.DisplayName = "UsrNomCompleto";
            this.calculatedField1.Expression = "Concat([SCV_Vehiculo.SCV_Usuario_Nombre],[SCV_Vehiculo.ApPaterno],[SCV_Vehiculo.A" +
    "pMaterno] )";
            this.calculatedField1.Name = "calculatedField1";
            // 
            // Proveedor
            // 
            dynamicListLookUpSettings3.DataAdapter = null;
            dynamicListLookUpSettings3.DataMember = "SCV_Proveedor";
            dynamicListLookUpSettings3.DataSource = this.dsFiltroProveedor;
            dynamicListLookUpSettings3.DisplayMember = "RazonSocial";
            dynamicListLookUpSettings3.ValueMember = "ProveedorId";
            this.Proveedor.LookUpSettings = dynamicListLookUpSettings3;
            this.Proveedor.MultiValue = true;
            this.Proveedor.Name = "Proveedor";
            // 
            // RptVehiculo
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.pageHeaderBand2,
            this.groupHeaderBand2,
            this.pageFooterBand2,
            this.reportHeaderBand2,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.cfUsuario,
            this.calculatedField1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource2,
            this.sqlDataSource3,
            this.sqlDataSource4,
            this.dsRptVehiculos,
            this.dsFiltroCiudad,
            this.dsFiltroEmpresa,
            this.dsFiltroProveedor});
            this.DataMember = "SCV_Vehiculo";
            this.DataSource = this.dsRptVehiculos;
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(11, 15, 84, 27);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Empresa,
            this.Ciudad,
            this.Proveedor});
            this.Version = "16.2";
            this.Watermark.Image = ((System.Drawing.Image)(resources.GetObject("RptVehiculo.Watermark.Image")));
            this.Watermark.ImageTransparency = 224;
            this.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Zoom;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
