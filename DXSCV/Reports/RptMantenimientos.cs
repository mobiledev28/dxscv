using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using SCVData;
using System.Text;
using DevExpress.XtraReports.Parameters;

/// <summary>
/// Summary description for RptMantenimientos
/// </summary>
public class RptMantenimientos : DevExpress.XtraReports.UI.XtraReport
{
    LookUpValueCollection _reportColumns;

    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel1;
    private XRPictureBox pbLogoGpoForem;
    private DevExpress.XtraReports.Parameters.Parameter Placa;
    private DevExpress.XtraReports.Parameters.Parameter Serie;
    private DevExpress.XtraReports.Parameters.Parameter Proveedor;
    private DevExpress.XtraReports.Parameters.Parameter Usuario;
    private DevExpress.XtraReports.Parameters.Parameter TipoServicio;
    private DevExpress.XtraReports.Parameters.Parameter Mes;
    private DevExpress.XtraReports.Parameters.Parameter Desde;
    private DevExpress.XtraReports.Parameters.Parameter Hasta;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroPlaca;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroSerie;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroProveedor;
    private DevExpress.DataAccess.Sql.SqlDataSource dsFiltroUsuario;
    private PageHeaderBand PageHeader;
    private XRTable tblDetail;
    private XRTableRow trDetail;
    private XRTableCell xrTableCell1;
    private XRTableCell DescripcionMtto_D;
    private DevExpress.DataAccess.Sql.SqlDataSource dsRptMttos;
    private XRTable tblHeader;
    private XRTableRow trHeader;
    private XRTableCell Id;
    private XRTableCell Descripción;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    private Parameter Columnas;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRTableCell xrTableCell31;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell3;
    private XRTableCell TipoServicioH;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public RptMantenimientos()
    {
        InitializeComponent();

        _reportColumns = new LookUpValueCollection() {
                    new LookUpValue("MantenimientoId", "MantenimientoId"),
                    new LookUpValue("DescripcionMtto", "DescripcionMtto"),
                    new LookUpValue("TipoServicio", "TipoServicio"),
                    new LookUpValue("RazonSocial", "RazonSocial"),
                    new LookUpValue("Ciudad", "Ciudad"),
                    new LookUpValue("Empresa", "Empresa"),
                    new LookUpValue("NombreUsuario", "NombreUsuario"),
                    new LookUpValue("Kilometraje", "Kilometraje"),
                    new LookUpValue("FechaIngresoaServicio", "FechaIngresoaServicio"),
                    new LookUpValue("FechaPromesaEntrega", "FechaPromesaEntrega"),
                    new LookUpValue("FechaRealEntrega", "FechaRealEntrega"),   
                    new LookUpValue("Placa", "Placa"),  
                    new LookUpValue("NumFactura", "NumFactura"),
                    new LookUpValue("EstatusFactura", "EstatusFactura"),
                    new LookUpValue("Subtotal", "Subtotal"),
                    new LookUpValue("IVA", "IVA"),
                    new LookUpValue("Total", "Total"),
                    new LookUpValue("FechaAlta", "FechaAlta")
            };

        StaticListLookUpSettings reportColumnsLookUpSettings = new StaticListLookUpSettings();
        reportColumnsLookUpSettings.LookUpValues.AddRange(_reportColumns);


        this.Parameters["Columnas"].LookUpSettings = reportColumnsLookUpSettings;
        this.Parameters["Columnas"].Value = new string[] 
        { 
            "MantenimientoId", "DescripcionMtto", "TipoServicio", "RazonSocial", 
            "Ciudad", "Empresa", "NombreUsuario", "Kilometraje", "FechaIngresoaServicio", "FechaPromesaEntrega", 
            "FechaRealEntrega", "Placa", "NumFactura", "EstatusFactura", "Subtotal", "IVA", "Total" ,"FechaAlta"
        };

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

    void XtraReport1_DataSourceDemanded(object sender, EventArgs e)
    {
        string[] columns = (string[])this.Parameters["Columnas"].Value;

        this.tblHeader.BeginInit();
        this.tblDetail.BeginInit();
        this.trHeader.Cells.Clear();
        this.trDetail.Cells.Clear();
        foreach (string column in columns)
        {
            string description = string.Empty;
            foreach (LookUpValue item in _reportColumns)
            {
                if (item.Description == column){
                    description = this.ReturnColumnDescription(item.Description);
                    break;
                }
                
            }

            XRTableCell headerCell = new XRTableCell()
            {
                Text = description
            };
            this.trHeader.Cells.Add(headerCell);

            XRTableCell detailCell = new XRTableCell();
            switch (column)
            {
                case "FechaIngresoaServicio":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:dd/MM/yyyy}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                    break;
                case "FechaPromesaEntrega":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:dd/MM/yyyy}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                    break;
                case "FechaRealEntrega":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:dd/MM/yyyy}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                    break;
                case "FechaAlta":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:dd/MM/yyyy}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                    break;
                case "Subtotal":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:$0.00}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                    break;
                case "IVA":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:$0.00}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                    break;
                case "Total":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column), "{0:$0.00}");
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                    break;
                case "Kilometraje":
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column));
                    detailCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                    break;
                default:
                    detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column));
                    break;
            }

            
                

            //detailCell.DataBindings.Add("Text", null, String.Format("{0}.{1}", this.DataMember, column));
            
            this.trDetail.Cells.Add(detailCell);
        }
        this.tblHeader.EndInit();
        this.tblDetail.EndInit();



    }

    private void xrTableCell22_BeforePrint(object sender, EventArgs e)
    {
        DateTime fIngreso = Convert.ToDateTime(GetCurrentColumnValue("FechaIngresoaServicio"));
        xrTableCell22.Text = string.Format("{0:d}", fIngreso);
    }

    public string ReturnColumnDescription(string columnName)
    {
        string description = "Columna";
        switch (columnName)
        {
            case "MantenimientoId":
                description = "Id";
                break;
            case "DescripcionMtto":
                description = "Descripción";
                break;
            case "TipoServicio":
                description = "Tipo Servicio";
                break;
            case "RazonSocial":
                description = "Proveedor";
                break;
            case "Ciudad":
                description = "Sucursal";
                break;
            case "Empresa":
                description = "Empresa";
                break;
            case "NombreUsuario":
                description = "Usuario";
                break;
            case "Kilometraje":
                description = "Kilometraje";
                break;
            case "FechaIngresoaServicio":
                description = "F. Ingreso";
                break;
            case "FechaPromesaEntrega":
                description = "F. Promesa";
                break;
            case "FechaRealEntrega":
                description = "F. Entrega";
                break;
            case "Placa":
                description = "Vehiculo";
                break;
            case "NumFactura":
                description = "Factura";
                break;
            case "EstatusFactura":
                description = "Estatus F.";
                break;
            case "Subtotal":
                description = "Subtotal";
                break;
            case "IVA":
                description = "IVA";
                break;
            case "Total":
                description = "Total";
                break;
            case "FechaAlta":
                description = "F. Alta";
                break;
        }

        return description;
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery3 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptMantenimientos));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery4 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings3 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings4 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings1 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.Parameters.StaticListLookUpSettings staticListLookUpSettings2 = new DevExpress.XtraReports.Parameters.StaticListLookUpSettings();
            this.dsFiltroPlaca = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.dsFiltroSerie = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.dsFiltroProveedor = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.dsFiltroUsuario = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.tblDetail = new DevExpress.XtraReports.UI.XRTable();
            this.trDetail = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DescripcionMtto_D = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.pbLogoGpoForem = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Placa = new DevExpress.XtraReports.Parameters.Parameter();
            this.Serie = new DevExpress.XtraReports.Parameters.Parameter();
            this.Proveedor = new DevExpress.XtraReports.Parameters.Parameter();
            this.Usuario = new DevExpress.XtraReports.Parameters.Parameter();
            this.TipoServicio = new DevExpress.XtraReports.Parameters.Parameter();
            this.Mes = new DevExpress.XtraReports.Parameters.Parameter();
            this.Desde = new DevExpress.XtraReports.Parameters.Parameter();
            this.Hasta = new DevExpress.XtraReports.Parameters.Parameter();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.tblHeader = new DevExpress.XtraReports.UI.XRTable();
            this.trHeader = new DevExpress.XtraReports.UI.XRTableRow();
            this.Id = new DevExpress.XtraReports.UI.XRTableCell();
            this.Descripción = new DevExpress.XtraReports.UI.XRTableCell();
            this.TipoServicioH = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dsRptMttos = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Columnas = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dsFiltroPlaca
            // 
            this.dsFiltroPlaca.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsFiltroPlaca.Name = "dsFiltroPlaca";
            customSqlQuery1.Name = "SCV_Vehiculo";
            customSqlQuery1.Sql = "select \'\' as \"Placa\", \'\' as \"PlacaApodo\"\r\nunion all\r\nselect \"SCV_Vehiculo\".\"Placa" +
    "\",\r\n\t \"SCV_Vehiculo\".\"Placa\" as \"PlacaApodo\"\r\n  from \"dbo\".\"SCV_Vehiculo\" \"SCV_V" +
    "ehiculo\"";
            this.dsFiltroPlaca.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dsFiltroPlaca.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0iZHNGaWx0cm9QbGFjYSI+PFZpZXcgTmFtZT0iU0NWX1ZlaGljdWxvIj48Rmllb" +
    "GQgTmFtZT0iUGxhY2EiIFR5cGU9IlN0cmluZyIgLz48RmllbGQgTmFtZT0iUGxhY2FBcG9kbyIgVHlwZ" +
    "T0iU3RyaW5nIiAvPjwvVmlldz48L0RhdGFTZXQ+";
            // 
            // dsFiltroSerie
            // 
            this.dsFiltroSerie.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsFiltroSerie.Name = "dsFiltroSerie";
            customSqlQuery2.Name = "SCV_Vehiculo";
            customSqlQuery2.Sql = "select \'\' as \"NoSerie\"\r\nunion all\r\nselect RIGHT(\"SCV_Vehiculo\".\"NoSerie\",5) as \"N" +
    "oSerie\"\r\n  from \"dbo\".\"SCV_Vehiculo\" \"SCV_Vehiculo\"";
            this.dsFiltroSerie.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.dsFiltroSerie.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0iZHNGaWx0cm9TZXJpZSI+PFZpZXcgTmFtZT0iU0NWX1ZlaGljdWxvIj48Rmllb" +
    "GQgTmFtZT0iTm9TZXJpZSIgVHlwZT0iU3RyaW5nIiAvPjwvVmlldz48L0RhdGFTZXQ+";
            // 
            // dsFiltroProveedor
            // 
            this.dsFiltroProveedor.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsFiltroProveedor.Name = "dsFiltroProveedor";
            customSqlQuery3.Name = "SCV_Proveedor";
            customSqlQuery3.Sql = "select 0 as \"ProveedorId\", \' \' as \"RazonSocial\"\r\nunion all\r\nselect \"SCV_Proveedor" +
    "\".\"ProveedorId\",\r\n       \"SCV_Proveedor\".\"RazonSocial\"\r\n  from \"dbo\".\"SCV_Provee" +
    "dor\" \"SCV_Proveedor\"";
            this.dsFiltroProveedor.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery3});
            this.dsFiltroProveedor.ResultSchemaSerializable = resources.GetString("dsFiltroProveedor.ResultSchemaSerializable");
            // 
            // dsFiltroUsuario
            // 
            this.dsFiltroUsuario.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsFiltroUsuario.Name = "dsFiltroUsuario";
            customSqlQuery4.Name = "SCV_Usuario";
            customSqlQuery4.Sql = resources.GetString("customSqlQuery4.Sql");
            this.dsFiltroUsuario.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery4});
            this.dsFiltroUsuario.ResultSchemaSerializable = resources.GetString("dsFiltroUsuario.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tblDetail});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // tblDetail
            // 
            this.tblDetail.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblDetail.Dpi = 100F;
            this.tblDetail.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.tblDetail.LocationFloat = new DevExpress.Utils.PointFloat(0.000111262F, 0F);
            this.tblDetail.Name = "tblDetail";
            this.tblDetail.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.trDetail});
            this.tblDetail.SizeF = new System.Drawing.SizeF(1402.084F, 25F);
            this.tblDetail.StylePriority.UseBorders = false;
            this.tblDetail.StylePriority.UseFont = false;
            // 
            // trDetail
            // 
            this.trDetail.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.DescripcionMtto_D,
            this.xrTableCell3,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30,
            this.xrTableCell31,
            this.xrTableCell32});
            this.trDetail.Dpi = 100F;
            this.trDetail.Name = "trDetail";
            this.trDetail.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.MantenimientoId")});
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Weight = 0.52083332061767573D;
            // 
            // DescripcionMtto_D
            // 
            this.DescripcionMtto_D.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.DescripcionMtto")});
            this.DescripcionMtto_D.Dpi = 100F;
            this.DescripcionMtto_D.Name = "DescripcionMtto_D";
            this.DescripcionMtto_D.Weight = 1.9999999618530273D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.TipoServicio")});
            this.xrTableCell3.Dpi = 100F;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Weight = 0.71875015258789055D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.RazonSocial")});
            this.xrTableCell18.Dpi = 100F;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Weight = 0.71875015258789055D;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Ciudad")});
            this.xrTableCell19.Dpi = 100F;
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Weight = 0.71875015258789055D;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Empresa")});
            this.xrTableCell20.Dpi = 100F;
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Weight = 0.71875015258789055D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.NombreUsuario")});
            this.xrTableCell21.Dpi = 100F;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Weight = 0.71875015258789055D;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.FechaIngresoaServicio", "{0:dd/MM/yyyy}")});
            this.xrTableCell22.Dpi = 100F;
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Weight = 0.71875015258789055D;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.FechaPromesaEntrega", "{0:dd/MM/yyyy}")});
            this.xrTableCell23.Dpi = 100F;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Weight = 0.71875015258789055D;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.FechaRealEntrega", "{0:dd/MM/yyyy}")});
            this.xrTableCell24.Dpi = 100F;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Weight = 0.71875015258789055D;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Placa")});
            this.xrTableCell25.Dpi = 100F;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Weight = 0.71875015258789055D;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Kilometraje")});
            this.xrTableCell26.Dpi = 100F;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.StylePriority.UseTextAlignment = false;
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell26.Weight = 0.71875015258789055D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.NumFactura")});
            this.xrTableCell27.Dpi = 100F;
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseTextAlignment = false;
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell27.Weight = 0.71875015258789055D;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.EstatusFactura")});
            this.xrTableCell28.Dpi = 100F;
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.StylePriority.UseTextAlignment = false;
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.xrTableCell28.Weight = 0.71875015258789055D;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Subtotal", "{0:$0.00}")});
            this.xrTableCell29.Dpi = 100F;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.StylePriority.UseTextAlignment = false;
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell29.Weight = 0.71875015258789055D;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.IVA", "{0:$0.00}")});
            this.xrTableCell30.Dpi = 100F;
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.StylePriority.UseTextAlignment = false;
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell30.Weight = 0.71875015258789055D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.Total", "{0:$0.00}")});
            this.xrTableCell31.Dpi = 100F;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseTextAlignment = false;
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell31.Weight = 0.71875015258789055D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Mantenimiento.FechaAlta", "{0:dd/MM/yyyy}")});
            this.xrTableCell32.Dpi = 100F;
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseTextAlignment = false;
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell32.Weight = 0.71875015258789055D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pbLogoGpoForem,
            this.xrLabel1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 79.00781F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pbLogoGpoForem
            // 
            this.pbLogoGpoForem.Dpi = 100F;
            this.pbLogoGpoForem.Image = ((System.Drawing.Image)(resources.GetObject("pbLogoGpoForem.Image")));
            this.pbLogoGpoForem.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.pbLogoGpoForem.LocationFloat = new DevExpress.Utils.PointFloat(1157.75F, 18.00001F);
            this.pbLogoGpoForem.Name = "pbLogoGpoForem";
            this.pbLogoGpoForem.SizeF = new System.Drawing.SizeF(281.2499F, 58.41666F);
            this.pbLogoGpoForem.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(570.5F, 38.83335F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(286.4583F, 37.58331F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Reporte de Mantenimientos";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 1.041667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Placa
            // 
            this.Placa.Description = "Placa";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "SCV_Vehiculo";
            dynamicListLookUpSettings1.DataSource = this.dsFiltroPlaca;
            dynamicListLookUpSettings1.DisplayMember = "PlacaApodo";
            dynamicListLookUpSettings1.ValueMember = "Placa";
            this.Placa.LookUpSettings = dynamicListLookUpSettings1;
            this.Placa.Name = "Placa";
            // 
            // Serie
            // 
            this.Serie.Description = "Serie";
            dynamicListLookUpSettings2.DataAdapter = null;
            dynamicListLookUpSettings2.DataMember = "SCV_Vehiculo";
            dynamicListLookUpSettings2.DataSource = this.dsFiltroSerie;
            dynamicListLookUpSettings2.DisplayMember = "NoSerie";
            dynamicListLookUpSettings2.ValueMember = "NoSerie";
            this.Serie.LookUpSettings = dynamicListLookUpSettings2;
            this.Serie.Name = "Serie";
            // 
            // Proveedor
            // 
            this.Proveedor.Description = "Proveedor";
            dynamicListLookUpSettings3.DataAdapter = null;
            dynamicListLookUpSettings3.DataMember = "SCV_Proveedor";
            dynamicListLookUpSettings3.DataSource = this.dsFiltroProveedor;
            dynamicListLookUpSettings3.DisplayMember = "RazonSocial";
            dynamicListLookUpSettings3.ValueMember = "ProveedorId";
            this.Proveedor.LookUpSettings = dynamicListLookUpSettings3;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Type = typeof(int);
            this.Proveedor.ValueInfo = "0";
            // 
            // Usuario
            // 
            this.Usuario.Description = "Usuario";
            dynamicListLookUpSettings4.DataAdapter = null;
            dynamicListLookUpSettings4.DataMember = "SCV_Usuario";
            dynamicListLookUpSettings4.DataSource = this.dsFiltroUsuario;
            dynamicListLookUpSettings4.DisplayMember = "NombreCompleto";
            dynamicListLookUpSettings4.ValueMember = "UsuarioId";
            this.Usuario.LookUpSettings = dynamicListLookUpSettings4;
            this.Usuario.Name = "Usuario";
            this.Usuario.Type = typeof(int);
            this.Usuario.ValueInfo = "0";
            // 
            // TipoServicio
            // 
            this.TipoServicio.Description = "Tipo de Servicio";
            this.TipoServicio.Name = "TipoServicio";
            // 
            // Mes
            // 
            this.Mes.Description = "Mes";
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(0, " "));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(1, "Enero"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(2, "Febrero"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(3, "Marzo"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(4, "Abril"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(5, "Mayo"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(6, "Junio"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(7, "Julio"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(8, "Agosto"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(9, "Septiembre"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(10, "Octubre"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(11, "Noviembre"));
            staticListLookUpSettings1.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue(12, "Diciembre"));
            this.Mes.LookUpSettings = staticListLookUpSettings1;
            this.Mes.Name = "Mes";
            this.Mes.Type = typeof(int);
            this.Mes.ValueInfo = "0";
            // 
            // Desde
            // 
            this.Desde.Description = "Desde";
            this.Desde.Name = "Desde";
            this.Desde.Type = typeof(System.DateTime);
            this.Desde.ValueInfo = "2016-11-03";
            // 
            // Hasta
            // 
            this.Hasta.Description = "Hasta";
            this.Hasta.Name = "Hasta";
            this.Hasta.Type = typeof(System.DateTime);
            this.Hasta.ValueInfo = "2017-11-03";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.tblHeader});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 28.58333F;
            this.PageHeader.Name = "PageHeader";
            // 
            // tblHeader
            // 
            this.tblHeader.BackColor = System.Drawing.Color.Silver;
            this.tblHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.tblHeader.Dpi = 100F;
            this.tblHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 9.000007F);
            this.tblHeader.Name = "tblHeader";
            this.tblHeader.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.trHeader});
            this.tblHeader.SizeF = new System.Drawing.SizeF(1402.084F, 19.58332F);
            this.tblHeader.StylePriority.UseBackColor = false;
            this.tblHeader.StylePriority.UseBorders = false;
            this.tblHeader.StylePriority.UseTextAlignment = false;
            this.tblHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // trHeader
            // 
            this.trHeader.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Id,
            this.Descripción,
            this.TipoServicioH,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell14,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell15,
            this.xrTableCell16,
            this.xrTableCell17});
            this.trHeader.Dpi = 100F;
            this.trHeader.Name = "trHeader";
            this.trHeader.Weight = 1D;
            // 
            // Id
            // 
            this.Id.Dpi = 100F;
            this.Id.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.Id.Name = "Id";
            this.Id.StylePriority.UseFont = false;
            this.Id.Text = "Id";
            this.Id.Weight = 0.52083332061767584D;
            // 
            // Descripción
            // 
            this.Descripción.Dpi = 100F;
            this.Descripción.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.Descripción.Name = "Descripción";
            this.Descripción.StylePriority.UseFont = false;
            this.Descripción.Text = "Descripción";
            this.Descripción.Weight = 1.9999999618530273D;
            // 
            // TipoServicioH
            // 
            this.TipoServicioH.Dpi = 100F;
            this.TipoServicioH.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.TipoServicioH.Name = "TipoServicioH";
            this.TipoServicioH.StylePriority.UseFont = false;
            this.TipoServicioH.Text = "Tipo Servicio";
            this.TipoServicioH.Weight = 0.71875015258789055D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "Proveedor";
            this.xrTableCell2.Weight = 0.71875015258789055D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "Sucursal";
            this.xrTableCell4.Weight = 0.71875015258789055D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Empresa";
            this.xrTableCell5.Weight = 0.71875015258789055D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.Text = "Usuario Asignado";
            this.xrTableCell6.Weight = 0.71875015258789055D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.Text = "F. Ingreso";
            this.xrTableCell7.Weight = 0.71875015258789055D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.Text = "F. Promesa";
            this.xrTableCell8.Weight = 0.71875015258789055D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Text = "F. Entrega";
            this.xrTableCell9.Weight = 0.71875015258789055D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.Text = "Vehiculo";
            this.xrTableCell10.Weight = 0.71875015258789055D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Dpi = 100F;
            this.xrTableCell14.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.Text = "Kilometraje";
            this.xrTableCell14.Weight = 0.71875015258789055D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 100F;
            this.xrTableCell11.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.Text = "Factura";
            this.xrTableCell11.Weight = 0.71875015258789055D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.Text = "Estatus Fac.";
            this.xrTableCell12.Weight = 0.71875015258789055D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.Text = "Subtotal";
            this.xrTableCell13.Weight = 0.71875015258789055D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Dpi = 100F;
            this.xrTableCell15.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.Text = "IVA";
            this.xrTableCell15.Weight = 0.71875015258789055D;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 100F;
            this.xrTableCell16.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.StylePriority.UseFont = false;
            this.xrTableCell16.Text = "Total";
            this.xrTableCell16.Weight = 0.71875015258789055D;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Dpi = 100F;
            this.xrTableCell17.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.StylePriority.UseFont = false;
            this.xrTableCell17.Text = "F. Alta";
            this.xrTableCell17.Weight = 0.71875015258789055D;
            // 
            // dsRptMttos
            // 
            this.dsRptMttos.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsRptMttos.Name = "dsRptMttos";
            storedProcQuery1.Name = "SCV_Mantenimiento";
            queryParameter1.Name = "@Placa";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.Placa]", typeof(string));
            queryParameter2.Name = "@Proveedor";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("[Parameters.Proveedor]", typeof(int));
            queryParameter3.Name = "@Desde";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("[Parameters.Desde]", typeof(System.DateTime));
            queryParameter4.Name = "@Hasta";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("[Parameters.Hasta]", typeof(System.DateTime));
            queryParameter5.Name = "@Mes";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("[Parameters.Mes]", typeof(int));
            queryParameter6.Name = "@NoSerie";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("[Parameters.Serie]", typeof(string));
            queryParameter7.Name = "@TipoServicio";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("[Parameters.TipoServicio]", typeof(string));
            queryParameter8.Name = "@Usuario";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("[Parameters.Usuario]", typeof(int));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.Parameters.Add(queryParameter7);
            storedProcQuery1.Parameters.Add(queryParameter8);
            storedProcQuery1.StoredProcName = "spRptMantenimientos";
            this.dsRptMttos.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.dsRptMttos.ResultSchemaSerializable = resources.GetString("dsRptMttos.ResultSchemaSerializable");
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo4,
            this.xrPageInfo3});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 36.45833F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPageInfo4
            // 
            this.xrPageInfo4.Dpi = 100F;
            this.xrPageInfo4.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.xrPageInfo4.Format = "Page {0} of {1}";
            this.xrPageInfo4.LocationFloat = new DevExpress.Utils.PointFloat(726F, 10.00001F);
            this.xrPageInfo4.Name = "xrPageInfo4";
            this.xrPageInfo4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo4.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo4.StylePriority.UseFont = false;
            this.xrPageInfo4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Dpi = 100F;
            this.xrPageInfo3.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(10.20838F, 10.00001F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo3.StylePriority.UseFont = false;
            // 
            // Columnas
            // 
            this.Columnas.Description = "Columnas";
            staticListLookUpSettings2.LookUpValues.Add(new DevExpress.XtraReports.Parameters.LookUpValue("MantenimientoId", "MantenimientoId"));
            this.Columnas.LookUpSettings = staticListLookUpSettings2;
            this.Columnas.MultiValue = true;
            this.Columnas.Name = "Columnas";
            // 
            // RptMantenimientos
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsFiltroPlaca,
            this.dsFiltroSerie,
            this.dsFiltroProveedor,
            this.dsFiltroUsuario,
            this.dsRptMttos});
            this.DataMember = "SCV_Mantenimiento";
            this.DataSource = this.dsRptMttos;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 26, 79, 1);
            this.PageHeight = 927;
            this.PageWidth = 1500;
            this.PaperKind = System.Drawing.Printing.PaperKind.LegalExtra;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Placa,
            this.Serie,
            this.Proveedor,
            this.Usuario,
            this.TipoServicio,
            this.Mes,
            this.Desde,
            this.Hasta,
            this.Columnas});
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this.tblDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
