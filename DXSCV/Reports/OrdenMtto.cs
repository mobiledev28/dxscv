using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for OrdenMtto
/// </summary>
public class OrdenMtto : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.Parameters.Parameter MantenimientoId;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private PageHeaderBand pageHeaderBand1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRLabel xrLabel10;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel22;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel26;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRLabel xrLabel39;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel42;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private PageFooterBand pageFooterBand1;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel51;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private TopMarginBand topMarginBand1;
    private BottomMarginBand bottomMarginBand1;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabel8;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel3;
    private XRPictureBox xrPictureBox4;
    private XRPictureBox xrPictureBox3;
    private XRPictureBox xrPictureBox2;
    private XRLine xrLine3;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel46;
    private XRLabel xrLabel29;
    private XRLabel xrLabel25;
    private XRLabel xrLabel48;
    private XRLabel xrLabel47;
    private DevExpress.DataAccess.Sql.SqlDataSource dsCuentas;
    private DevExpress.XtraReports.Parameters.Parameter Usuario;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public OrdenMtto()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
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

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenMtto));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            this.dsCuentas = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.MantenimientoId = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.pageHeaderBand1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Usuario = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dsCuentas
            // 
            this.dsCuentas.ConnectionName = "TCADBHMT_Connection_PROD";
            this.dsCuentas.Name = "dsCuentas";
            customSqlQuery1.Name = "SCV_Cuenta";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.dsCuentas.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dsCuentas.ResultSchemaSerializable = resources.GetString("dsCuentas.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // MantenimientoId
            // 
            this.MantenimientoId.Description = "Mantenimiento ID";
            this.MantenimientoId.Name = "MantenimientoId";
            this.MantenimientoId.Type = typeof(long);
            this.MantenimientoId.ValueInfo = "1";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "TCADBHMT_Connection_PROD";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery2.Name = "SCV_Mantenimiento";
            queryParameter1.Name = "MantenimientoId";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.MantenimientoId]", typeof(long));
            customSqlQuery2.Parameters.Add(queryParameter1);
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // pageHeaderBand1
            // 
            this.pageHeaderBand1.Dpi = 100F;
            this.pageHeaderBand1.Expanded = false;
            this.pageHeaderBand1.HeightF = 24.16666F;
            this.pageHeaderBand1.Name = "pageHeaderBand1";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 219.0418F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(450.2161F, 21.41666F);
            this.xrLabel7.StyleName = "FieldCaption";
            this.xrLabel7.Text = "Descripcion de Mantenimiento / Comentarios Adicionales";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(200.9021F, 155.9585F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(143.4905F, 23.00002F);
            this.xrLabel9.StyleName = "FieldCaption";
            this.xrLabel9.Text = "Ingreso\r\n";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(361.591F, 156.9584F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(142.0269F, 23.00001F);
            this.xrLabel10.StyleName = "FieldCaption";
            this.xrLabel10.Text = "Prometida";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(528.1389F, 156.9584F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(150.751F, 23.00002F);
            this.xrLabel11.StyleName = "FieldCaption";
            this.xrLabel11.Text = "Terminada";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(250.5394F, 370.7083F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(137.5783F, 19.00003F);
            this.xrLabel13.StyleName = "FieldCaption";
            this.xrLabel13.Text = "Marca";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(161.9854F, 483.1251F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(135.1616F, 24.00003F);
            this.xrLabel14.StyleName = "FieldCaption";
            this.xrLabel14.Text = "Estatus Factura";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(398.6756F, 370.7082F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(145.6049F, 19F);
            this.xrLabel15.StyleName = "FieldCaption";
            this.xrLabel15.Text = "Linea";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 100F;
            this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(150.9854F, 370.7082F);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.SizeF = new System.Drawing.SizeF(87.5891F, 19.00009F);
            this.xrLabel16.StyleName = "FieldCaption";
            this.xrLabel16.Text = "Serie";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 100F;
            this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(7.208332F, 483.1251F);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.SizeF = new System.Drawing.SizeF(131.3967F, 24F);
            this.xrLabel17.StyleName = "FieldCaption";
            this.xrLabel17.Text = "# Factura";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(10.00004F, 370.7083F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(131.3967F, 19.00003F);
            this.xrLabel18.StyleName = "FieldCaption";
            this.xrLabel18.Text = "Placa";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(200.9021F, 64.16667F);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(152.5888F, 19.33333F);
            this.xrLabel19.StyleName = "FieldCaption";
            this.xrLabel19.Text = "Proveedor";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 156.9584F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(66.81335F, 23.00001F);
            this.xrLabel20.StyleName = "FieldCaption";
            this.xrLabel20.Text = "Motivo";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(426.6756F, 483.1252F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(97.91101F, 24.00003F);
            this.xrLabel21.StyleName = "FieldCaption";
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "IVA";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 100F;
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(538.5556F, 483.125F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(112.4943F, 24.00006F);
            this.xrLabel22.StyleName = "FieldCaption";
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Total";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 64.16667F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(60.37021F, 19.33333F);
            this.xrLabel1.StyleName = "FieldCaption";
            this.xrLabel1.Text = "Usuario";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(555F, 370.7082F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(70.77124F, 18.99997F);
            this.xrLabel2.StyleName = "FieldCaption";
            this.xrLabel2.Text = "Modelo\r\n";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(200.272F, 10.00001F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(144.1206F, 22.99999F);
            this.xrLabel6.StyleName = "FieldCaption";
            this.xrLabel6.Text = "Sucursal Asignada";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(131.3967F, 22.99999F);
            this.xrLabel12.StyleName = "FieldCaption";
            this.xrLabel12.Text = "Mantenimiento ID";
            // 
            // groupHeaderBand1
            // 
            this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel48,
            this.xrLabel47,
            this.xrLabel46,
            this.xrLabel29,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLine3,
            this.xrLabel23,
            this.xrLabel8,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel3,
            this.xrLabel26,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel30,
            this.xrLabel31,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel39,
            this.xrLabel40,
            this.xrLabel41,
            this.xrLabel42,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel45,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel12,
            this.xrLabel6,
            this.xrLabel20,
            this.xrLabel9,
            this.xrLabel10,
            this.xrLabel11,
            this.xrLabel19,
            this.xrLabel7,
            this.xrLabel18,
            this.xrLabel15,
            this.xrLabel16,
            this.xrLabel13,
            this.xrLabel17,
            this.xrLabel14,
            this.xrLabel21,
            this.xrLabel22});
            this.groupHeaderBand1.Dpi = 100F;
            this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("SCV_Usuario_Nombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Anio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("ApMaterno", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Apodo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("ApPaterno", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Descripcion", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("DescripcionMtto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("EstatusFactura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("FechaIngresoaServicio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("FechaPromesaEntrega", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("FechaRealEntrega", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("MantenimientoId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Marca", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Modelo", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Nombre", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("NoSerie", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("NumFactura", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Placa", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("RazonSocial", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("TipoServicio", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.groupHeaderBand1.HeightF = 641.5418F;
            this.groupHeaderBand1.Name = "groupHeaderBand1";
            this.groupHeaderBand1.StyleName = "DataField";
            // 
            // xrLabel48
            // 
            this.xrLabel48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Kilometraje")});
            this.xrLabel48.Dpi = 100F;
            this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(637.4675F, 390.7082F);
            this.xrLabel48.Name = "xrLabel48";
            this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel48.SizeF = new System.Drawing.SizeF(112.438F, 16.79178F);
            // 
            // xrLabel47
            // 
            this.xrLabel47.Dpi = 100F;
            this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(637.4675F, 370.7082F);
            this.xrLabel47.Multiline = true;
            this.xrLabel47.Name = "xrLabel47";
            this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel47.SizeF = new System.Drawing.SizeF(112.4379F, 18.99997F);
            this.xrLabel47.StyleName = "FieldCaption";
            this.xrLabel47.Text = "Kilometraje";
            // 
            // xrLabel46
            // 
            this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Total", "{0:$0.00}")});
            this.xrLabel46.Dpi = 100F;
            this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(538.5556F, 507.125F);
            this.xrLabel46.Name = "xrLabel46";
            this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel46.SizeF = new System.Drawing.SizeF(112.4943F, 17.79196F);
            this.xrLabel46.StylePriority.UseTextAlignment = false;
            this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.IVA", "{0:$0.00}")});
            this.xrLabel29.Dpi = 100F;
            this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(426.6756F, 507.1253F);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.SizeF = new System.Drawing.SizeF(97.91107F, 17.79135F);
            this.xrLabel29.StylePriority.UseTextAlignment = false;
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Subtotal", "{0:$0.00}")});
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(315.5055F, 507.125F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(96.61221F, 17.79147F);
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(10.00525F, 32.99999F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(36.65663F, 20.79166F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "OM -";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 100F;
            this.xrLine3.LocationFloat = new DevExpress.Utils.PointFloat(601.6064F, 604.5418F);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.SizeF = new System.Drawing.SizeF(148.9583F, 2F);
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.Usuario, "Text", "")});
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(602.6064F, 608.5418F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(143.75F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Usuario
            // 
            this.Usuario.Description = "Firma de Usuario";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "SCV_Cuenta";
            dynamicListLookUpSettings1.DataSource = this.dsCuentas;
            dynamicListLookUpSettings1.DisplayMember = "FullName";
            dynamicListLookUpSettings1.ValueMember = "FullName";
            this.Usuario.LookUpSettings = dynamicListLookUpSettings1;
            this.Usuario.Name = "Usuario";
            this.Usuario.ValueInfo = "Oscar de la Luz";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(315.5055F, 483.1251F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(96.61221F, 24.00003F);
            this.xrLabel8.StyleName = "FieldCaption";
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Subtotal";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(414.6756F, 10.00001F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(81.24432F, 24.00006F);
            this.xrLabel5.StyleName = "FieldCaption";
            this.xrLabel5.Text = "Empresa";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 446.125F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(193.75F, 21.41666F);
            this.xrLabel4.StyleName = "FieldCaption";
            this.xrLabel4.Text = "Datos de Facturación";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(9.164079F, 426.0417F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(743.1923F, 2.083344F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(10.00525F, 317.625F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(743.1923F, 2.083344F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.00525F, 334.375F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(131.3967F, 21.41666F);
            this.xrLabel3.StyleName = "FieldCaption";
            this.xrLabel3.Text = "Datos del Vehículo";
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NombreUsuario")});
            this.xrLabel26.Dpi = 100F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 84.04166F);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.SizeF = new System.Drawing.SizeF(173.272F, 16.75F);
            this.xrLabel26.StylePriority.UseFont = false;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Anio")});
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(555F, 390.7083F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(70.7713F, 17.79169F);
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.ApMaterno")});
            this.xrLabel28.Dpi = 100F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 118.7917F);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.SizeF = new System.Drawing.SizeF(173.272F, 16.75002F);
            this.xrLabel28.StylePriority.UseFont = false;
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.ApPaterno")});
            this.xrLabel30.Dpi = 100F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 101.9166F);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.SizeF = new System.Drawing.SizeF(173.272F, 16.75F);
            this.xrLabel30.StylePriority.UseFont = false;
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NombreCiudad")});
            this.xrLabel31.Dpi = 100F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(200.272F, 32.99999F);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.SizeF = new System.Drawing.SizeF(193.728F, 19.875F);
            this.xrLabel31.StylePriority.UseFont = false;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.DescripcionMtto")});
            this.xrLabel32.Dpi = 100F;
            this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 240.4585F);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.SizeF = new System.Drawing.SizeF(743.1976F, 63.62498F);
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.EstatusFactura")});
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(161.9854F, 507.1252F);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(135.1616F, 17.79166F);
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.FechaIngresoaServicio", "{0:dd/MM/yyyy}")});
            this.xrLabel34.Dpi = 100F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(200.272F, 179.9584F);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.SizeF = new System.Drawing.SizeF(144.1206F, 17.79167F);
            this.xrLabel34.StylePriority.UseFont = false;
            // 
            // xrLabel35
            // 
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.FechaPromesaEntrega", "{0:dd/MM/yyyy}")});
            this.xrLabel35.Dpi = 100F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(361.591F, 179.9584F);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.SizeF = new System.Drawing.SizeF(142.0269F, 17.79167F);
            this.xrLabel35.StylePriority.UseFont = false;
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.FechaRealEntrega", "{0:dd/MM/yyyy}")});
            this.xrLabel36.Dpi = 100F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(528.1389F, 179.9584F);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.SizeF = new System.Drawing.SizeF(150.751F, 17.79167F);
            this.xrLabel36.StylePriority.UseFont = false;
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.MantenimientoId")});
            this.xrLabel37.Dpi = 100F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(46.95354F, 32.99999F);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.SizeF = new System.Drawing.SizeF(112.3185F, 20.79166F);
            this.xrLabel37.StylePriority.UseFont = false;
            // 
            // xrLabel38
            // 
            this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Marca")});
            this.xrLabel38.Dpi = 100F;
            this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(250.5394F, 390.7083F);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.SizeF = new System.Drawing.SizeF(137.5783F, 17.79169F);
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Modelo")});
            this.xrLabel39.Dpi = 100F;
            this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(398.6756F, 390.7082F);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.SizeF = new System.Drawing.SizeF(145.6049F, 17.79172F);
            // 
            // xrLabel40
            // 
            this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NombreEmpresa")});
            this.xrLabel40.Dpi = 100F;
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(414.6756F, 33.99998F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(335.8891F, 17.79166F);
            // 
            // xrLabel41
            // 
            this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NoSerie")});
            this.xrLabel41.Dpi = 100F;
            this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(150.9854F, 390.7083F);
            this.xrLabel41.Name = "xrLabel41";
            this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel41.SizeF = new System.Drawing.SizeF(87.58911F, 17.79169F);
            // 
            // xrLabel42
            // 
            this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NumFactura")});
            this.xrLabel42.Dpi = 100F;
            this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(7.208332F, 507.125F);
            this.xrLabel42.Name = "xrLabel42";
            this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel42.SizeF = new System.Drawing.SizeF(131.3967F, 17.79166F);
            // 
            // xrLabel43
            // 
            this.xrLabel43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.Placa")});
            this.xrLabel43.Dpi = 100F;
            this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(9.164079F, 389.7085F);
            this.xrLabel43.Name = "xrLabel43";
            this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel43.SizeF = new System.Drawing.SizeF(132.2326F, 17.79169F);
            // 
            // xrLabel44
            // 
            this.xrLabel44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.NombreProveedor")});
            this.xrLabel44.Dpi = 100F;
            this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(200.272F, 84.04166F);
            this.xrLabel44.Name = "xrLabel44";
            this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel44.SizeF = new System.Drawing.SizeF(552.0844F, 16.75F);
            // 
            // xrLabel45
            // 
            this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlDataSource1, "SCV_Mantenimiento.TipoServicio")});
            this.xrLabel45.Dpi = 100F;
            this.xrLabel45.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 179.9584F);
            this.xrLabel45.Name = "xrLabel45";
            this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel45.SizeF = new System.Drawing.SizeF(173.272F, 17.79167F);
            this.xrLabel45.StylePriority.UseFont = false;
            // 
            // pageFooterBand1
            // 
            this.pageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.pageFooterBand1.Dpi = 100F;
            this.pageFooterBand1.HeightF = 29F;
            this.pageFooterBand1.Name = "pageFooterBand1";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(388F, 23F);
            this.xrPageInfo1.StyleName = "PageInfo";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Format = "Page {0} of {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(406F, 6F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(388F, 23F);
            this.xrPageInfo2.StyleName = "PageInfo";
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // reportHeaderBand1
            // 
            this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox4,
            this.xrPictureBox3,
            this.xrPictureBox2,
            this.xrPictureBox1,
            this.xrLabel51});
            this.reportHeaderBand1.Dpi = 100F;
            this.reportHeaderBand1.HeightF = 141.7917F;
            this.reportHeaderBand1.Name = "reportHeaderBand1";
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.Dpi = 100F;
            this.xrPictureBox4.ImageUrl = "C:\\Users\\GJORTI\\Documents\\Proyectos\\HERRAMENTAL MONTERREY\\Control de Vehiculos\\So" +
    "urce Code\\SCVSolution\\DXSCV\\Content\\Images\\ML.png";
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(575F, 38.00001F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(188.5417F, 37.58335F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.Dpi = 100F;
            this.xrPictureBox3.ImageUrl = "C:\\Users\\GJORTI\\Documents\\Proyectos\\HERRAMENTAL MONTERREY\\Control de Vehiculos\\So" +
    "urce Code\\SCVSolution\\DXSCV\\Content\\Images\\MTI.png";
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(386.591F, 38.00001F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(171.875F, 37.58335F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Dpi = 100F;
            this.xrPictureBox2.ImageUrl = "C:\\Users\\GJORTI\\Documents\\Proyectos\\HERRAMENTAL MONTERREY\\Control de Vehiculos\\So" +
    "urce Code\\SCVSolution\\DXSCV\\Content\\Images\\MTL.png";
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(237.0394F, 38.00001F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(141.4515F, 37.58335F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.ImageUrl = "C:\\Users\\GJORTI\\Documents\\Proyectos\\HERRAMENTAL MONTERREY\\Control de Vehiculos\\So" +
    "urce Code\\SCVSolution\\DXSCV\\Content\\Images\\logo-herramental.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(31F, 38.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(193.75F, 37.58334F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrLabel51
            // 
            this.xrLabel51.Dpi = 100F;
            this.xrLabel51.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel51.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 97.7917F);
            this.xrLabel51.Name = "xrLabel51";
            this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel51.SizeF = new System.Drawing.SizeF(789F, 43F);
            this.xrLabel51.StyleName = "Title";
            this.xrLabel51.StylePriority.UseFont = false;
            this.xrLabel51.StylePriority.UseForeColor = false;
            this.xrLabel51.StylePriority.UseTextAlignment = false;
            this.xrLabel51.Text = "Orden de Mantenimiento";
            this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Teal;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 100F;
            this.topMarginBand1.HeightF = 6.66666F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 100F;
            this.bottomMarginBand1.HeightF = 28.29164F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // OrdenMtto
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.pageHeaderBand1,
            this.groupHeaderBand1,
            this.pageFooterBand1,
            this.reportHeaderBand1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1,
            this.dsCuentas});
            this.DataMember = "SCV_Cuenta";
            this.DataSource = this.dsCuentas;
            this.Margins = new System.Drawing.Printing.Margins(15, 34, 7, 28);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.MantenimientoId,
            this.Usuario});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "16.2";
            this.Watermark.Image = ((System.Drawing.Image)(resources.GetObject("OrdenMtto.Watermark.Image")));
            this.Watermark.ImageTransparency = 209;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void xrPictureBox5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        
    }

    private void xrPictureBox6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void xrPictureBox7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }

    private void xrPictureBox8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}
