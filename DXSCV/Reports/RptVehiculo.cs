using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

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
    private XRLabel xrLabel69;
    private PageFooterBand pageFooterBand2;
    private XRPageInfo xrPageInfo3;
    private XRPageInfo xrPageInfo4;
    private ReportHeaderBand reportHeaderBand2;
    private XRLabel xrLabel74;
    private XRLine xrLine6;
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
    private XRLabel xrLabel40;
    private CalculatedField cfUsuario;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource5;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource7;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource6;
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
            DevExpress.DataAccess.ConnectionParameters.CustomStringConnectionParameters customStringConnectionParameters1 = new DevExpress.DataAccess.ConnectionParameters.CustomStringConnectionParameters();
            DevExpress.DataAccess.Sql.TableQuery tableQuery1 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.TableInfo tableInfo1 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo1 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo2 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.ConnectionParameters.CustomStringConnectionParameters customStringConnectionParameters2 = new DevExpress.DataAccess.ConnectionParameters.CustomStringConnectionParameters();
            DevExpress.DataAccess.Sql.TableQuery tableQuery2 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.TableInfo tableInfo2 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo3 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo4 = new DevExpress.DataAccess.Sql.ColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptVehiculo));
            DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters msSqlConnectionParameters1 = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters();
            DevExpress.DataAccess.Sql.TableQuery tableQuery3 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo1 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo2 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo3 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo3 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo4 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo4 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo5 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo3 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo5 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo6 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo7 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo8 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo9 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo10 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo11 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo12 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo13 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo14 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo4 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo15 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo5 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo16 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo6 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo17 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo18 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo19 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo7 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo20 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo21 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo22 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo23 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo8 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo24 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.XtraReports.Parameters.DynamicListLookUpSettings dynamicListLookUpSettings2 = new DevExpress.XtraReports.Parameters.DynamicListLookUpSettings();
            DevExpress.DataAccess.Sql.TableQuery tableQuery6 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo6 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo6 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo7 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo7 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo8 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo8 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo9 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo9 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.RelationInfo relationInfo10 = new DevExpress.DataAccess.Sql.RelationInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo10 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo11 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo29 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo30 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo31 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo32 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo33 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo34 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo35 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo36 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo37 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo38 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo12 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo39 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo40 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo41 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo13 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo42 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo43 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo44 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo45 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo46 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo14 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo47 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo15 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo48 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableInfo tableInfo16 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo49 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableQuery tableQuery5 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.TableInfo tableInfo10 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo27 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo28 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.TableQuery tableQuery4 = new DevExpress.DataAccess.Sql.TableQuery();
            DevExpress.DataAccess.Sql.TableInfo tableInfo9 = new DevExpress.DataAccess.Sql.TableInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo25 = new DevExpress.DataAccess.Sql.ColumnInfo();
            DevExpress.DataAccess.Sql.ColumnInfo columnInfo26 = new DevExpress.DataAccess.Sql.ColumnInfo();
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
            this.xrLabel69 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageFooterBand2 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo4 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.reportHeaderBand2 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel74 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrPictureBox4 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Empresa = new DevExpress.XtraReports.Parameters.Parameter();
            this.Ciudad = new DevExpress.XtraReports.Parameters.Parameter();
            this.cfUsuario = new DevExpress.XtraReports.UI.CalculatedField();
            this.sqlDataSource5 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.sqlDataSource6 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.sqlDataSource7 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource3
            // 
            this.sqlDataSource3.ConnectionName = "TCADBHMTEntities (DXSCV)";
            customStringConnectionParameters1.ConnectionString = "XpoProvider=MSSqlServer;Data Source=acer;Initial Catalog=TCADBHMT;Persist Securit" +
    "y Info=True;User ID=sa;Password=mateo2015;MultipleActiveResultSets=True;Applicat" +
    "ion Name=EntityFramework";
            this.sqlDataSource3.ConnectionParameters = customStringConnectionParameters1;
            this.sqlDataSource3.Name = "sqlDataSource3";
            tableQuery1.Name = "SCV_Empresa";
            tableInfo1.Name = "SCV_Empresa";
            columnInfo1.Name = "EmpresaId";
            columnInfo2.Name = "Nombre";
            tableInfo1.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo1,
            columnInfo2});
            tableQuery1.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo1});
            this.sqlDataSource3.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery1});
            this.sqlDataSource3.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0ic3FsRGF0YVNvdXJjZTMiPjxWaWV3IE5hbWU9IlNDVl9FbXByZXNhIj48Rmllb" +
    "GQgTmFtZT0iRW1wcmVzYUlkIiBUeXBlPSJJbnQzMiIgLz48RmllbGQgTmFtZT0iTm9tYnJlIiBUeXBlP" +
    "SJTdHJpbmciIC8+PC9WaWV3PjwvRGF0YVNldD4=";
            // 
            // sqlDataSource4
            // 
            this.sqlDataSource4.ConnectionName = "TCADBHMTEntities (DXSCVWeb)";
            customStringConnectionParameters2.ConnectionString = "XpoProvider=MSSqlServer;Data Source=acer;Initial Catalog=TCADBHMT;Persist Securit" +
    "y Info=True;User ID=sa;Password=mateo2015;MultipleActiveResultSets=True;Applicat" +
    "ion Name=EntityFramework";
            this.sqlDataSource4.ConnectionParameters = customStringConnectionParameters2;
            this.sqlDataSource4.Name = "sqlDataSource4";
            tableQuery2.Name = "SCV_Ciudad";
            tableInfo2.Name = "SCV_Ciudad";
            columnInfo3.Name = "CiudadId";
            columnInfo4.Name = "Descripcion";
            tableInfo2.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo3,
            columnInfo4});
            tableQuery2.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo2});
            this.sqlDataSource4.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery2});
            this.sqlDataSource4.ResultSchemaSerializable = resources.GetString("sqlDataSource4.ResultSchemaSerializable");
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 23F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionName = "ACER_TCADBHMT_Connection";
            msSqlConnectionParameters1.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer;
            msSqlConnectionParameters1.DatabaseName = "TCADBHMT";
            msSqlConnectionParameters1.Password = "mateo2015";
            msSqlConnectionParameters1.ServerName = "ACER";
            msSqlConnectionParameters1.UserName = "sa";
            this.sqlDataSource2.ConnectionParameters = msSqlConnectionParameters1;
            this.sqlDataSource2.Name = "sqlDataSource2";
            tableQuery3.Name = "SCV_Vehiculo";
            relationColumnInfo1.NestedKeyColumn = "EmpresaId";
            relationColumnInfo1.ParentKeyColumn = "EmpresaId";
            relationInfo1.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo1});
            relationInfo1.NestedTable = "SCV_Empresa";
            relationInfo1.ParentTable = "SCV_Vehiculo";
            relationColumnInfo2.NestedKeyColumn = "CiudadId";
            relationColumnInfo2.ParentKeyColumn = "CiudadId";
            relationInfo2.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo2});
            relationInfo2.NestedTable = "SCV_Ciudad";
            relationInfo2.ParentTable = "SCV_Vehiculo";
            relationColumnInfo3.NestedKeyColumn = "UsuarioId";
            relationColumnInfo3.ParentKeyColumn = "UsuarioIdAsignado";
            relationInfo3.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo3});
            relationInfo3.NestedTable = "SCV_Usuario";
            relationInfo3.ParentTable = "SCV_Vehiculo";
            relationColumnInfo4.NestedKeyColumn = "VehiculoId";
            relationColumnInfo4.ParentKeyColumn = "VehiculoId";
            relationInfo4.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo4});
            relationInfo4.NestedTable = "SCV_Mantenimiento";
            relationInfo4.ParentTable = "SCV_Vehiculo";
            relationColumnInfo5.NestedKeyColumn = "ProveedorId";
            relationColumnInfo5.ParentKeyColumn = "ProveedorId";
            relationInfo5.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo5});
            relationInfo5.NestedTable = "SCV_Proveedor";
            relationInfo5.ParentTable = "SCV_Mantenimiento";
            tableQuery3.Relations.AddRange(new DevExpress.DataAccess.Sql.RelationInfo[] {
            relationInfo1,
            relationInfo2,
            relationInfo3,
            relationInfo4,
            relationInfo5});
            tableInfo3.Name = "SCV_Vehiculo";
            columnInfo5.Name = "VehiculoId";
            columnInfo6.Name = "Marca";
            columnInfo7.Name = "Modelo";
            columnInfo8.Name = "Anio";
            columnInfo9.Name = "NoSerie";
            columnInfo10.Name = "Apodo";
            columnInfo11.Name = "Placa";
            columnInfo12.Name = "CiudadId";
            columnInfo13.Name = "EmpresaId";
            columnInfo14.Name = "UsuarioIdAsignado";
            tableInfo3.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo5,
            columnInfo6,
            columnInfo7,
            columnInfo8,
            columnInfo9,
            columnInfo10,
            columnInfo11,
            columnInfo12,
            columnInfo13,
            columnInfo14});
            tableInfo4.Name = "SCV_Empresa";
            columnInfo15.Name = "Nombre";
            tableInfo4.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo15});
            tableInfo5.Name = "SCV_Ciudad";
            columnInfo16.Name = "Descripcion";
            tableInfo5.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo16});
            tableInfo6.Name = "SCV_Usuario";
            columnInfo17.Alias = "SCV_Usuario_Nombre";
            columnInfo17.Name = "Nombre";
            columnInfo18.Name = "ApPaterno";
            columnInfo19.Name = "ApMaterno";
            tableInfo6.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo17,
            columnInfo18,
            columnInfo19});
            tableInfo7.Name = "SCV_Mantenimiento";
            columnInfo20.Name = "DescripcionMtto";
            columnInfo21.Name = "EstatusFactura";
            columnInfo22.Name = "NumFactura";
            columnInfo23.Name = "TipoServicio";
            tableInfo7.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo20,
            columnInfo21,
            columnInfo22,
            columnInfo23});
            tableInfo8.Name = "SCV_Proveedor";
            columnInfo24.Name = "RazonSocial";
            tableInfo8.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo24});
            tableQuery3.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo3,
            tableInfo4,
            tableInfo5,
            tableInfo6,
            tableInfo7,
            tableInfo8});
            this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery3});
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
            this.pageHeaderBand2.HeightF = 27.91668F;
            this.pageHeaderBand2.Name = "pageHeaderBand2";
            // 
            // xrLabel34
            // 
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
            this.xrLine4.LocationFloat = new DevExpress.Utils.PointFloat(6F, 3.916678F);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.SizeF = new System.Drawing.SizeF(1065.331F, 2.08332F);
            // 
            // xrLine5
            // 
            this.xrLine5.LocationFloat = new DevExpress.Utils.PointFloat(6F, 25.91668F);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.SizeF = new System.Drawing.SizeF(1065.331F, 2F);
            // 
            // groupHeaderBand2
            // 
            this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
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
            this.xrLabel68,
            this.xrLabel69});
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
            // xrLabel40
            // 
            this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cfUsuario")});
            this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(1000.758F, 0F);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel40.SizeF = new System.Drawing.SizeF(70.57269F, 15.70833F);
            this.xrLabel40.Text = "xrLabel40";
            // 
            // xrLabel54
            // 
            this.xrLabel54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.TipoServicio")});
            this.xrLabel54.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(6.000002F, 0F);
            this.xrLabel54.Name = "xrLabel54";
            this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel54.SizeF = new System.Drawing.SizeF(85.80453F, 15.70833F);
            this.xrLabel54.StylePriority.UseFont = false;
            this.xrLabel54.Text = "xrLabel54";
            // 
            // xrLabel55
            // 
            this.xrLabel55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Apodo")});
            this.xrLabel55.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel55.LocationFloat = new DevExpress.Utils.PointFloat(91.80453F, 0F);
            this.xrLabel55.Name = "xrLabel55";
            this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel55.SizeF = new System.Drawing.SizeF(74.4324F, 15.70833F);
            this.xrLabel55.StylePriority.UseFont = false;
            this.xrLabel55.Text = "xrLabel55";
            // 
            // xrLabel56
            // 
            this.xrLabel56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.EstatusFactura")});
            this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(860F, 0F);
            this.xrLabel56.Name = "xrLabel56";
            this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel56.SizeF = new System.Drawing.SizeF(76.98822F, 15.70833F);
            this.xrLabel56.Text = "xrLabel56";
            // 
            // xrLabel57
            // 
            this.xrLabel57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.NumFactura")});
            this.xrLabel57.LocationFloat = new DevExpress.Utils.PointFloat(936.9882F, 0F);
            this.xrLabel57.Name = "xrLabel57";
            this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel57.SizeF = new System.Drawing.SizeF(63.76971F, 15.70833F);
            this.xrLabel57.Text = "xrLabel57";
            // 
            // xrLabel58
            // 
            this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.DescripcionMtto")});
            this.xrLabel58.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel58.LocationFloat = new DevExpress.Utils.PointFloat(166.2369F, 0F);
            this.xrLabel58.Name = "xrLabel58";
            this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel58.SizeF = new System.Drawing.SizeF(110.7324F, 15.70833F);
            this.xrLabel58.StylePriority.UseFont = false;
            this.xrLabel58.Text = "xrLabel58";
            // 
            // xrLabel59
            // 
            this.xrLabel59.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.RazonSocial")});
            this.xrLabel59.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel59.LocationFloat = new DevExpress.Utils.PointFloat(276.9693F, 0F);
            this.xrLabel59.Name = "xrLabel59";
            this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel59.SizeF = new System.Drawing.SizeF(98.99405F, 15.70833F);
            this.xrLabel59.StylePriority.UseFont = false;
            this.xrLabel59.Text = "xrLabel59";
            // 
            // xrLabel63
            // 
            this.xrLabel63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Descripcion")});
            this.xrLabel63.LocationFloat = new DevExpress.Utils.PointFloat(375.9634F, 0F);
            this.xrLabel63.Name = "xrLabel63";
            this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel63.SizeF = new System.Drawing.SizeF(59.37503F, 15.70833F);
            this.xrLabel63.Text = "xrLabel63";
            // 
            // xrLabel64
            // 
            this.xrLabel64.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Placa")});
            this.xrLabel64.LocationFloat = new DevExpress.Utils.PointFloat(435.3384F, 0F);
            this.xrLabel64.Name = "xrLabel64";
            this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel64.SizeF = new System.Drawing.SizeF(70.99997F, 15.70833F);
            this.xrLabel64.Text = "xrLabel64";
            // 
            // xrLabel65
            // 
            this.xrLabel65.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.NoSerie")});
            this.xrLabel65.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel65.LocationFloat = new DevExpress.Utils.PointFloat(506.3384F, 0F);
            this.xrLabel65.Name = "xrLabel65";
            this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel65.SizeF = new System.Drawing.SizeF(63.67987F, 15.70833F);
            this.xrLabel65.StylePriority.UseFont = false;
            this.xrLabel65.Text = "xrLabel65";
            // 
            // xrLabel66
            // 
            this.xrLabel66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Anio")});
            this.xrLabel66.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel66.LocationFloat = new DevExpress.Utils.PointFloat(570.0183F, 0F);
            this.xrLabel66.Name = "xrLabel66";
            this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel66.SizeF = new System.Drawing.SizeF(60.71448F, 15.70833F);
            this.xrLabel66.StylePriority.UseFont = false;
            this.xrLabel66.Text = "xrLabel66";
            // 
            // xrLabel67
            // 
            this.xrLabel67.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Modelo")});
            this.xrLabel67.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel67.LocationFloat = new DevExpress.Utils.PointFloat(630.7327F, 0F);
            this.xrLabel67.Name = "xrLabel67";
            this.xrLabel67.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel67.SizeF = new System.Drawing.SizeF(69.74896F, 15.70833F);
            this.xrLabel67.StylePriority.UseFont = false;
            this.xrLabel67.Text = "xrLabel67";
            // 
            // xrLabel68
            // 
            this.xrLabel68.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Marca")});
            this.xrLabel68.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel68.LocationFloat = new DevExpress.Utils.PointFloat(700.4817F, 0F);
            this.xrLabel68.Name = "xrLabel68";
            this.xrLabel68.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel68.SizeF = new System.Drawing.SizeF(80.52271F, 15.70833F);
            this.xrLabel68.StylePriority.UseFont = false;
            this.xrLabel68.Text = "xrLabel68";
            // 
            // xrLabel69
            // 
            this.xrLabel69.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SCV_Vehiculo.Nombre")});
            this.xrLabel69.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel69.LocationFloat = new DevExpress.Utils.PointFloat(781.0043F, 0F);
            this.xrLabel69.Name = "xrLabel69";
            this.xrLabel69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel69.SizeF = new System.Drawing.SizeF(78.99567F, 15.70833F);
            this.xrLabel69.StylePriority.UseFont = false;
            this.xrLabel69.Text = "xrLabel69";
            // 
            // pageFooterBand2
            // 
            this.pageFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo3,
            this.xrPageInfo4});
            this.pageFooterBand2.HeightF = 29.00001F;
            this.pageFooterBand2.Name = "pageFooterBand2";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(6F, 6F);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.SizeF = new System.Drawing.SizeF(313F, 23F);
            // 
            // xrPageInfo4
            // 
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
            this.xrLabel74,
            this.xrLine6});
            this.reportHeaderBand2.HeightF = 48.5F;
            this.reportHeaderBand2.Name = "reportHeaderBand2";
            // 
            // xrLabel74
            // 
            this.xrLabel74.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel74.LocationFloat = new DevExpress.Utils.PointFloat(5.999994F, 10F);
            this.xrLabel74.Name = "xrLabel74";
            this.xrLabel74.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel74.SizeF = new System.Drawing.SizeF(638F, 29.45834F);
            this.xrLabel74.StylePriority.UseFont = false;
            this.xrLabel74.Text = "Reporte de Vehiculos";
            // 
            // xrLine6
            // 
            this.xrLine6.LocationFloat = new DevExpress.Utils.PointFloat(6F, 0F);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.SizeF = new System.Drawing.SizeF(1065.331F, 2F);
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox4,
            this.xrPictureBox3,
            this.xrPictureBox2,
            this.xrPictureBox1});
            this.topMarginBand1.HeightF = 84.33334F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // xrPictureBox4
            // 
            this.xrPictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox4.Image")));
            this.xrPictureBox4.LocationFloat = new DevExpress.Utils.PointFloat(795.5876F, 10.00001F);
            this.xrPictureBox4.Name = "xrPictureBox4";
            this.xrPictureBox4.SizeF = new System.Drawing.SizeF(268.4125F, 56F);
            this.xrPictureBox4.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox3
            // 
            this.xrPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox3.Image")));
            this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(523.2551F, 10.00001F);
            this.xrPictureBox3.Name = "xrPictureBox3";
            this.xrPictureBox3.SizeF = new System.Drawing.SizeF(257.7493F, 56F);
            this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox2.Image")));
            this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(264.6667F, 10.00001F);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.SizeF = new System.Drawing.SizeF(241.6717F, 56.00001F);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 10.00001F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(241.6667F, 56F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 27.25F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // Empresa
            // 
            this.Empresa.Description = "Empresa";
            dynamicListLookUpSettings1.DataAdapter = null;
            dynamicListLookUpSettings1.DataMember = "SCV_Empresa";
            dynamicListLookUpSettings1.DataSource = this.sqlDataSource7;
            dynamicListLookUpSettings1.DisplayMember = "Nombre";
            dynamicListLookUpSettings1.ValueMember = "EmpresaId";
            this.Empresa.LookUpSettings = dynamicListLookUpSettings1;
            this.Empresa.Name = "Empresa";
            this.Empresa.Type = typeof(int);
            this.Empresa.ValueInfo = "0";
            // 
            // Ciudad
            // 
            this.Ciudad.Description = "Ciudad";
            dynamicListLookUpSettings2.DataAdapter = null;
            dynamicListLookUpSettings2.DataMember = "SCV_Ciudad";
            dynamicListLookUpSettings2.DataSource = this.sqlDataSource6;
            dynamicListLookUpSettings2.DisplayMember = "Descripcion";
            dynamicListLookUpSettings2.ValueMember = "CiudadId";
            this.Ciudad.LookUpSettings = dynamicListLookUpSettings2;
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Type = typeof(int);
            this.Ciudad.ValueInfo = "0";
            // 
            // cfUsuario
            // 
            this.cfUsuario.DisplayName = "UsuarioFullName";
            this.cfUsuario.Expression = "Concat([SCV_Vehiculo.SCV_Usuario_Nombre], [SCV_Vehiculo.ApPaterno], [SCV_Vehiculo" +
    ".ApMaterno])";
            this.cfUsuario.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.cfUsuario.Name = "cfUsuario";
            // 
            // sqlDataSource5
            // 
            this.sqlDataSource5.ConnectionName = "10.1.2.25_TCADBHMT_Connection";
            this.sqlDataSource5.Name = "sqlDataSource5";
            tableQuery6.Name = "SCV_Vehiculo";
            relationColumnInfo6.NestedKeyColumn = "UsuarioId";
            relationColumnInfo6.ParentKeyColumn = "UsuarioIdAsignado";
            relationInfo6.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo6});
            relationInfo6.NestedTable = "SCV_Usuario";
            relationInfo6.ParentTable = "SCV_Vehiculo";
            relationColumnInfo7.NestedKeyColumn = "VehiculoId";
            relationColumnInfo7.ParentKeyColumn = "VehiculoId";
            relationInfo7.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo7});
            relationInfo7.NestedTable = "SCV_Mantenimiento";
            relationInfo7.ParentTable = "SCV_Vehiculo";
            relationColumnInfo8.NestedKeyColumn = "ProveedorId";
            relationColumnInfo8.ParentKeyColumn = "ProveedorId";
            relationInfo8.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo8});
            relationInfo8.NestedTable = "SCV_Proveedor";
            relationInfo8.ParentTable = "SCV_Mantenimiento";
            relationColumnInfo9.NestedKeyColumn = "EmpresaId";
            relationColumnInfo9.ParentKeyColumn = "EmpresaId";
            relationInfo9.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo9});
            relationInfo9.NestedTable = "SCV_Empresa";
            relationInfo9.ParentTable = "SCV_Vehiculo";
            relationColumnInfo10.NestedKeyColumn = "CiudadId";
            relationColumnInfo10.ParentKeyColumn = "CiudadId";
            relationInfo10.KeyColumns.AddRange(new DevExpress.DataAccess.Sql.RelationColumnInfo[] {
            relationColumnInfo10});
            relationInfo10.NestedTable = "SCV_Ciudad";
            relationInfo10.ParentTable = "SCV_Vehiculo";
            tableQuery6.Relations.AddRange(new DevExpress.DataAccess.Sql.RelationInfo[] {
            relationInfo6,
            relationInfo7,
            relationInfo8,
            relationInfo9,
            relationInfo10});
            tableInfo11.Name = "SCV_Vehiculo";
            columnInfo29.Name = "VehiculoId";
            columnInfo30.Name = "Marca";
            columnInfo31.Name = "Modelo";
            columnInfo32.Name = "Anio";
            columnInfo33.Name = "NoSerie";
            columnInfo34.Name = "Apodo";
            columnInfo35.Name = "Placa";
            columnInfo36.Name = "UsuarioIdAsignado";
            columnInfo37.Name = "CiudadId";
            columnInfo38.Name = "EmpresaId";
            tableInfo11.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo29,
            columnInfo30,
            columnInfo31,
            columnInfo32,
            columnInfo33,
            columnInfo34,
            columnInfo35,
            columnInfo36,
            columnInfo37,
            columnInfo38});
            tableInfo12.Name = "SCV_Usuario";
            columnInfo39.Name = "Nombre";
            columnInfo40.Name = "ApPaterno";
            columnInfo41.Name = "ApMaterno";
            tableInfo12.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo39,
            columnInfo40,
            columnInfo41});
            tableInfo13.Name = "SCV_Mantenimiento";
            columnInfo42.Name = "MantenimientoId";
            columnInfo43.Name = "TipoServicio";
            columnInfo44.Name = "DescripcionMtto";
            columnInfo45.Name = "NumFactura";
            columnInfo46.Name = "EstatusFactura";
            tableInfo13.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo42,
            columnInfo43,
            columnInfo44,
            columnInfo45,
            columnInfo46});
            tableInfo14.Name = "SCV_Proveedor";
            columnInfo47.Name = "RazonSocial";
            tableInfo14.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo47});
            tableInfo15.Name = "SCV_Empresa";
            columnInfo48.Alias = "SCV_Empresa_Nombre";
            columnInfo48.Name = "Nombre";
            tableInfo15.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo48});
            tableInfo16.Name = "SCV_Ciudad";
            columnInfo49.Name = "Descripcion";
            tableInfo16.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo49});
            tableQuery6.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo11,
            tableInfo12,
            tableInfo13,
            tableInfo14,
            tableInfo15,
            tableInfo16});
            this.sqlDataSource5.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery6});
            this.sqlDataSource5.ResultSchemaSerializable = resources.GetString("sqlDataSource5.ResultSchemaSerializable");
            // 
            // sqlDataSource6
            // 
            this.sqlDataSource6.ConnectionName = "10.1.2.25_TCADBHMT_Connection";
            this.sqlDataSource6.Name = "sqlDataSource6";
            tableQuery5.Name = "SCV_Ciudad";
            tableInfo10.Name = "SCV_Ciudad";
            columnInfo27.Name = "CiudadId";
            columnInfo28.Name = "Descripcion";
            tableInfo10.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo27,
            columnInfo28});
            tableQuery5.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo10});
            this.sqlDataSource6.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery5});
            this.sqlDataSource6.ResultSchemaSerializable = resources.GetString("sqlDataSource6.ResultSchemaSerializable");
            // 
            // sqlDataSource7
            // 
            this.sqlDataSource7.ConnectionName = "10.1.2.25_TCADBHMT_Connection";
            this.sqlDataSource7.Name = "sqlDataSource7";
            tableQuery4.Name = "SCV_Empresa";
            tableInfo9.Name = "SCV_Empresa";
            columnInfo25.Name = "EmpresaId";
            columnInfo26.Name = "Nombre";
            tableInfo9.SelectedColumns.AddRange(new DevExpress.DataAccess.Sql.ColumnInfo[] {
            columnInfo25,
            columnInfo26});
            tableQuery4.Tables.AddRange(new DevExpress.DataAccess.Sql.TableInfo[] {
            tableInfo9});
            this.sqlDataSource7.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            tableQuery4});
            this.sqlDataSource7.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0ic3FsRGF0YVNvdXJjZTciPjxWaWV3IE5hbWU9IlNDVl9FbXByZXNhIj48Rmllb" +
    "GQgTmFtZT0iRW1wcmVzYUlkIiBUeXBlPSJJbnQzMiIgLz48RmllbGQgTmFtZT0iTm9tYnJlIiBUeXBlP" +
    "SJTdHJpbmciIC8+PC9WaWV3PjwvRGF0YVNldD4=";
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
            this.cfUsuario});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource2,
            this.sqlDataSource3,
            this.sqlDataSource4,
            this.sqlDataSource5,
            this.sqlDataSource6,
            this.sqlDataSource7});
            this.DataMember = "SCV_Vehiculo";
            this.DataSource = this.sqlDataSource5;
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(11, 15, 84, 27);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Empresa,
            this.Ciudad});
            this.Version = "15.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
