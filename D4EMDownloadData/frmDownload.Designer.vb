<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownload
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownload))
        Me.grpBASINS = New System.Windows.Forms.GroupBox
        Me.btnBrowseWDMmet = New System.Windows.Forms.Button
        Me.chkBASINS_Met = New System.Windows.Forms.CheckBox
        Me.chkBASINS_PCS3 = New System.Windows.Forms.CheckBox
        Me.chkBASINS_NHD = New System.Windows.Forms.CheckBox
        Me.chkBASINS_NED = New System.Windows.Forms.CheckBox
        Me.chkBASINS_LSTORET = New System.Windows.Forms.CheckBox
        Me.chkBASINS_GIRAS = New System.Windows.Forms.CheckBox
        Me.chkBASINS_DEMG = New System.Windows.Forms.CheckBox
        Me.chkBASINS_DEM = New System.Windows.Forms.CheckBox
        Me.chkBASINS_Census = New System.Windows.Forms.CheckBox
        Me.grpNWIS = New System.Windows.Forms.GroupBox
        Me.btnBrowseWDMdailydischarge = New System.Windows.Forms.Button
        Me.chkNWIS_GetNWISStations = New System.Windows.Forms.CheckBox
        Me.chkNWIS_GetNWISDischarge = New System.Windows.Forms.CheckBox
        Me.chkTerraServerWebService_Urban = New System.Windows.Forms.CheckBox
        Me.grpTerraServerWebService = New System.Windows.Forms.GroupBox
        Me.chkTerraServerWebService_DRG = New System.Windows.Forms.CheckBox
        Me.chkTerraServerWebService_DOQ = New System.Windows.Forms.CheckBox
        Me.grpNLCD2001 = New System.Windows.Forms.GroupBox
        Me.chkNLCD_Canopy = New System.Windows.Forms.CheckBox
        Me.chkNLCD_Impervious = New System.Windows.Forms.CheckBox
        Me.chkNLCD_LandCover = New System.Windows.Forms.CheckBox
        Me.grpNHDplus = New System.Windows.Forms.GroupBox
        Me.chkNHDplus_streamgageevent = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_hydrologicunits = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_hydrography = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_fac = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_fdr = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_elev_cm = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_All = New System.Windows.Forms.CheckBox
        Me.chkNHDplus_Catchment = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDownload = New System.Windows.Forms.Button
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblRegion = New System.Windows.Forms.Label
        Me.chkClip = New System.Windows.Forms.CheckBox
        Me.chkMerge = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.grpSTORET = New System.Windows.Forms.GroupBox
        Me.chkSTORET_Stations = New System.Windows.Forms.CheckBox
        Me.grpBASINS.SuspendLayout()
        Me.grpNWIS.SuspendLayout()
        Me.grpTerraServerWebService.SuspendLayout()
        Me.grpNLCD2001.SuspendLayout()
        Me.grpNHDplus.SuspendLayout()
        Me.grpSTORET.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBASINS
        '
        Me.grpBASINS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBASINS.Controls.Add(Me.btnBrowseWDMmet)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_Met)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_PCS3)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_NHD)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_NED)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_LSTORET)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_GIRAS)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_DEMG)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_DEM)
        Me.grpBASINS.Controls.Add(Me.chkBASINS_Census)
        Me.grpBASINS.Location = New System.Drawing.Point(12, 39)
        Me.grpBASINS.Name = "grpBASINS"
        Me.grpBASINS.Size = New System.Drawing.Size(356, 96)
        Me.grpBASINS.TabIndex = 0
        Me.grpBASINS.TabStop = False
        Me.grpBASINS.Text = "Basins"
        '
        'btnBrowseWDMmet
        '
        Me.btnBrowseWDMmet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseWDMmet.Image = CType(resources.GetObject("btnBrowseWDMmet.Image"), System.Drawing.Image)
        Me.btnBrowseWDMmet.Location = New System.Drawing.Point(199, 62)
        Me.btnBrowseWDMmet.Name = "btnBrowseWDMmet"
        Me.btnBrowseWDMmet.Size = New System.Drawing.Size(28, 20)
        Me.btnBrowseWDMmet.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.btnBrowseWDMmet, "Browse to choose WDM file name")
        Me.btnBrowseWDMmet.UseVisualStyleBackColor = True
        '
        'chkBASINS_Met
        '
        Me.chkBASINS_Met.AutoSize = True
        Me.chkBASINS_Met.Location = New System.Drawing.Point(112, 65)
        Me.chkBASINS_Met.Name = "chkBASINS_Met"
        Me.chkBASINS_Met.Size = New System.Drawing.Size(81, 17)
        Me.chkBASINS_Met.TabIndex = 5
        Me.chkBASINS_Met.Text = "Meterologic"
        Me.chkBASINS_Met.UseVisualStyleBackColor = True
        '
        'chkBASINS_PCS3
        '
        Me.chkBASINS_PCS3.AutoSize = True
        Me.chkBASINS_PCS3.Location = New System.Drawing.Point(233, 65)
        Me.chkBASINS_PCS3.Name = "chkBASINS_PCS3"
        Me.chkBASINS_PCS3.Size = New System.Drawing.Size(53, 17)
        Me.chkBASINS_PCS3.TabIndex = 8
        Me.chkBASINS_PCS3.Text = "PCS3"
        Me.chkBASINS_PCS3.UseVisualStyleBackColor = True
        '
        'chkBASINS_NHD
        '
        Me.chkBASINS_NHD.AutoSize = True
        Me.chkBASINS_NHD.Location = New System.Drawing.Point(233, 42)
        Me.chkBASINS_NHD.Name = "chkBASINS_NHD"
        Me.chkBASINS_NHD.Size = New System.Drawing.Size(50, 17)
        Me.chkBASINS_NHD.TabIndex = 7
        Me.chkBASINS_NHD.Text = "NHD"
        Me.chkBASINS_NHD.UseVisualStyleBackColor = True
        '
        'chkBASINS_NED
        '
        Me.chkBASINS_NED.AutoSize = True
        Me.chkBASINS_NED.Location = New System.Drawing.Point(233, 19)
        Me.chkBASINS_NED.Name = "chkBASINS_NED"
        Me.chkBASINS_NED.Size = New System.Drawing.Size(49, 17)
        Me.chkBASINS_NED.TabIndex = 6
        Me.chkBASINS_NED.Text = "NED"
        Me.chkBASINS_NED.UseVisualStyleBackColor = True
        '
        'chkBASINS_LSTORET
        '
        Me.chkBASINS_LSTORET.AutoSize = True
        Me.chkBASINS_LSTORET.Location = New System.Drawing.Point(112, 42)
        Me.chkBASINS_LSTORET.Name = "chkBASINS_LSTORET"
        Me.chkBASINS_LSTORET.Size = New System.Drawing.Size(108, 17)
        Me.chkBASINS_LSTORET.TabIndex = 4
        Me.chkBASINS_LSTORET.Text = "Legacy STORET"
        Me.chkBASINS_LSTORET.UseVisualStyleBackColor = True
        '
        'chkBASINS_GIRAS
        '
        Me.chkBASINS_GIRAS.AutoSize = True
        Me.chkBASINS_GIRAS.Location = New System.Drawing.Point(112, 19)
        Me.chkBASINS_GIRAS.Name = "chkBASINS_GIRAS"
        Me.chkBASINS_GIRAS.Size = New System.Drawing.Size(59, 17)
        Me.chkBASINS_GIRAS.TabIndex = 3
        Me.chkBASINS_GIRAS.Text = "GIRAS"
        Me.chkBASINS_GIRAS.UseVisualStyleBackColor = True
        '
        'chkBASINS_DEMG
        '
        Me.chkBASINS_DEMG.AutoSize = True
        Me.chkBASINS_DEMG.Location = New System.Drawing.Point(6, 65)
        Me.chkBASINS_DEMG.Name = "chkBASINS_DEMG"
        Me.chkBASINS_DEMG.Size = New System.Drawing.Size(72, 17)
        Me.chkBASINS_DEMG.TabIndex = 2
        Me.chkBASINS_DEMG.Text = "DEM Grid"
        Me.chkBASINS_DEMG.UseVisualStyleBackColor = True
        '
        'chkBASINS_DEM
        '
        Me.chkBASINS_DEM.AutoSize = True
        Me.chkBASINS_DEM.Location = New System.Drawing.Point(6, 42)
        Me.chkBASINS_DEM.Name = "chkBASINS_DEM"
        Me.chkBASINS_DEM.Size = New System.Drawing.Size(84, 17)
        Me.chkBASINS_DEM.TabIndex = 1
        Me.chkBASINS_DEM.Text = "DEM Shape"
        Me.chkBASINS_DEM.UseVisualStyleBackColor = True
        '
        'chkBASINS_Census
        '
        Me.chkBASINS_Census.AutoSize = True
        Me.chkBASINS_Census.Location = New System.Drawing.Point(6, 19)
        Me.chkBASINS_Census.Name = "chkBASINS_Census"
        Me.chkBASINS_Census.Size = New System.Drawing.Size(61, 17)
        Me.chkBASINS_Census.TabIndex = 0
        Me.chkBASINS_Census.Text = "Census"
        Me.chkBASINS_Census.UseVisualStyleBackColor = True
        '
        'grpNWIS
        '
        Me.grpNWIS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNWIS.Controls.Add(Me.btnBrowseWDMdailydischarge)
        Me.grpNWIS.Controls.Add(Me.chkNWIS_GetNWISStations)
        Me.grpNWIS.Controls.Add(Me.chkNWIS_GetNWISDischarge)
        Me.grpNWIS.Location = New System.Drawing.Point(12, 260)
        Me.grpNWIS.Name = "grpNWIS"
        Me.grpNWIS.Size = New System.Drawing.Size(356, 42)
        Me.grpNWIS.TabIndex = 1
        Me.grpNWIS.TabStop = False
        Me.grpNWIS.Text = "NWIS"
        '
        'btnBrowseWDMdailydischarge
        '
        Me.btnBrowseWDMdailydischarge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseWDMdailydischarge.Image = CType(resources.GetObject("btnBrowseWDMdailydischarge.Image"), System.Drawing.Image)
        Me.btnBrowseWDMdailydischarge.Location = New System.Drawing.Point(218, 16)
        Me.btnBrowseWDMdailydischarge.Name = "btnBrowseWDMdailydischarge"
        Me.btnBrowseWDMdailydischarge.Size = New System.Drawing.Size(28, 20)
        Me.btnBrowseWDMdailydischarge.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.btnBrowseWDMdailydischarge, "Browse to choose WDM file name")
        Me.btnBrowseWDMdailydischarge.UseVisualStyleBackColor = True
        '
        'chkNWIS_GetNWISStations
        '
        Me.chkNWIS_GetNWISStations.AutoSize = True
        Me.chkNWIS_GetNWISStations.Location = New System.Drawing.Point(6, 19)
        Me.chkNWIS_GetNWISStations.Name = "chkNWIS_GetNWISStations"
        Me.chkNWIS_GetNWISStations.Size = New System.Drawing.Size(64, 17)
        Me.chkNWIS_GetNWISStations.TabIndex = 10
        Me.chkNWIS_GetNWISStations.Text = "Stations"
        Me.chkNWIS_GetNWISStations.UseVisualStyleBackColor = True
        '
        'chkNWIS_GetNWISDischarge
        '
        Me.chkNWIS_GetNWISDischarge.AutoSize = True
        Me.chkNWIS_GetNWISDischarge.Location = New System.Drawing.Point(112, 19)
        Me.chkNWIS_GetNWISDischarge.Name = "chkNWIS_GetNWISDischarge"
        Me.chkNWIS_GetNWISDischarge.Size = New System.Drawing.Size(100, 17)
        Me.chkNWIS_GetNWISDischarge.TabIndex = 9
        Me.chkNWIS_GetNWISDischarge.Text = "Daily Discharge"
        Me.chkNWIS_GetNWISDischarge.UseVisualStyleBackColor = True
        '
        'chkTerraServerWebService_Urban
        '
        Me.chkTerraServerWebService_Urban.AutoSize = True
        Me.chkTerraServerWebService_Urban.Location = New System.Drawing.Point(6, 19)
        Me.chkTerraServerWebService_Urban.Name = "chkTerraServerWebService_Urban"
        Me.chkTerraServerWebService_Urban.Size = New System.Drawing.Size(80, 17)
        Me.chkTerraServerWebService_Urban.TabIndex = 12
        Me.chkTerraServerWebService_Urban.Text = "Urban Area"
        Me.chkTerraServerWebService_Urban.UseVisualStyleBackColor = True
        '
        'grpTerraServerWebService
        '
        Me.grpTerraServerWebService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpTerraServerWebService.Controls.Add(Me.chkTerraServerWebService_DRG)
        Me.grpTerraServerWebService.Controls.Add(Me.chkTerraServerWebService_DOQ)
        Me.grpTerraServerWebService.Controls.Add(Me.chkTerraServerWebService_Urban)
        Me.grpTerraServerWebService.Location = New System.Drawing.Point(12, 359)
        Me.grpTerraServerWebService.Name = "grpTerraServerWebService"
        Me.grpTerraServerWebService.Size = New System.Drawing.Size(356, 42)
        Me.grpTerraServerWebService.TabIndex = 9
        Me.grpTerraServerWebService.TabStop = False
        Me.grpTerraServerWebService.Text = "TerraServer Images"
        '
        'chkTerraServerWebService_DRG
        '
        Me.chkTerraServerWebService_DRG.AutoSize = True
        Me.chkTerraServerWebService_DRG.Location = New System.Drawing.Point(233, 19)
        Me.chkTerraServerWebService_DRG.Name = "chkTerraServerWebService_DRG"
        Me.chkTerraServerWebService_DRG.Size = New System.Drawing.Size(50, 17)
        Me.chkTerraServerWebService_DRG.TabIndex = 14
        Me.chkTerraServerWebService_DRG.Text = "DRG"
        Me.chkTerraServerWebService_DRG.UseVisualStyleBackColor = True
        '
        'chkTerraServerWebService_DOQ
        '
        Me.chkTerraServerWebService_DOQ.AutoSize = True
        Me.chkTerraServerWebService_DOQ.Location = New System.Drawing.Point(112, 19)
        Me.chkTerraServerWebService_DOQ.Name = "chkTerraServerWebService_DOQ"
        Me.chkTerraServerWebService_DOQ.Size = New System.Drawing.Size(50, 17)
        Me.chkTerraServerWebService_DOQ.TabIndex = 13
        Me.chkTerraServerWebService_DOQ.Text = "DOQ"
        Me.chkTerraServerWebService_DOQ.UseVisualStyleBackColor = True
        '
        'grpNLCD2001
        '
        Me.grpNLCD2001.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNLCD2001.Controls.Add(Me.chkNLCD_Canopy)
        Me.grpNLCD2001.Controls.Add(Me.chkNLCD_Impervious)
        Me.grpNLCD2001.Controls.Add(Me.chkNLCD_LandCover)
        Me.grpNLCD2001.Location = New System.Drawing.Point(12, 308)
        Me.grpNLCD2001.Name = "grpNLCD2001"
        Me.grpNLCD2001.Size = New System.Drawing.Size(356, 42)
        Me.grpNLCD2001.TabIndex = 11
        Me.grpNLCD2001.TabStop = False
        Me.grpNLCD2001.Text = "NLCD 2001"
        '
        'chkNLCD_Canopy
        '
        Me.chkNLCD_Canopy.AutoSize = True
        Me.chkNLCD_Canopy.Location = New System.Drawing.Point(233, 19)
        Me.chkNLCD_Canopy.Name = "chkNLCD_Canopy"
        Me.chkNLCD_Canopy.Size = New System.Drawing.Size(62, 17)
        Me.chkNLCD_Canopy.TabIndex = 18
        Me.chkNLCD_Canopy.Text = "Canopy"
        Me.chkNLCD_Canopy.UseVisualStyleBackColor = True
        '
        'chkNLCD_Impervious
        '
        Me.chkNLCD_Impervious.AutoSize = True
        Me.chkNLCD_Impervious.Location = New System.Drawing.Point(112, 19)
        Me.chkNLCD_Impervious.Name = "chkNLCD_Impervious"
        Me.chkNLCD_Impervious.Size = New System.Drawing.Size(77, 17)
        Me.chkNLCD_Impervious.TabIndex = 17
        Me.chkNLCD_Impervious.Text = "Impervious"
        Me.chkNLCD_Impervious.UseVisualStyleBackColor = True
        '
        'chkNLCD_LandCover
        '
        Me.chkNLCD_LandCover.AutoSize = True
        Me.chkNLCD_LandCover.Location = New System.Drawing.Point(6, 19)
        Me.chkNLCD_LandCover.Name = "chkNLCD_LandCover"
        Me.chkNLCD_LandCover.Size = New System.Drawing.Size(81, 17)
        Me.chkNLCD_LandCover.TabIndex = 16
        Me.chkNLCD_LandCover.Text = "Land Cover"
        Me.chkNLCD_LandCover.UseVisualStyleBackColor = True
        '
        'grpNHDplus
        '
        Me.grpNHDplus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_streamgageevent)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_hydrologicunits)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_hydrography)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_fac)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_fdr)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_elev_cm)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_All)
        Me.grpNHDplus.Controls.Add(Me.chkNHDplus_Catchment)
        Me.grpNHDplus.Location = New System.Drawing.Point(12, 141)
        Me.grpNHDplus.Name = "grpNHDplus"
        Me.grpNHDplus.Size = New System.Drawing.Size(356, 113)
        Me.grpNHDplus.TabIndex = 12
        Me.grpNHDplus.TabStop = False
        Me.grpNHDplus.Text = "NHD Plus"
        '
        'chkNHDplus_streamgageevent
        '
        Me.chkNHDplus_streamgageevent.AutoSize = True
        Me.chkNHDplus_streamgageevent.Location = New System.Drawing.Point(233, 88)
        Me.chkNHDplus_streamgageevent.Name = "chkNHDplus_streamgageevent"
        Me.chkNHDplus_streamgageevent.Size = New System.Drawing.Size(119, 17)
        Me.chkNHDplus_streamgageevent.TabIndex = 24
        Me.chkNHDplus_streamgageevent.Text = "Streamgage Events"
        Me.chkNHDplus_streamgageevent.UseVisualStyleBackColor = True
        '
        'chkNHDplus_hydrologicunits
        '
        Me.chkNHDplus_hydrologicunits.AutoSize = True
        Me.chkNHDplus_hydrologicunits.Location = New System.Drawing.Point(233, 65)
        Me.chkNHDplus_hydrologicunits.Name = "chkNHDplus_hydrologicunits"
        Me.chkNHDplus_hydrologicunits.Size = New System.Drawing.Size(103, 17)
        Me.chkNHDplus_hydrologicunits.TabIndex = 23
        Me.chkNHDplus_hydrologicunits.Text = "Hydrologic Units"
        Me.ToolTip1.SetToolTip(Me.chkNHDplus_hydrologicunits, "Basin, Region, SubBasin, Subregion, Subwatershed, Watershed")
        Me.chkNHDplus_hydrologicunits.UseVisualStyleBackColor = True
        '
        'chkNHDplus_hydrography
        '
        Me.chkNHDplus_hydrography.AutoSize = True
        Me.chkNHDplus_hydrography.Location = New System.Drawing.Point(233, 42)
        Me.chkNHDplus_hydrography.Name = "chkNHDplus_hydrography"
        Me.chkNHDplus_hydrography.Size = New System.Drawing.Size(86, 17)
        Me.chkNHDplus_hydrography.TabIndex = 21
        Me.chkNHDplus_hydrography.Text = "Hydrography"
        Me.ToolTip1.SetToolTip(Me.chkNHDplus_hydrography, "NHDArea, NHDFlowline, NHDLine, NHDPoint, NHDWaterbody")
        Me.chkNHDplus_hydrography.UseVisualStyleBackColor = True
        '
        'chkNHDplus_fac
        '
        Me.chkNHDplus_fac.AutoSize = True
        Me.chkNHDplus_fac.Location = New System.Drawing.Point(6, 88)
        Me.chkNHDplus_fac.Name = "chkNHDplus_fac"
        Me.chkNHDplus_fac.Size = New System.Drawing.Size(137, 17)
        Me.chkNHDplus_fac.TabIndex = 20
        Me.chkNHDplus_fac.Text = "Flow Accumulation Grid"
        Me.ToolTip1.SetToolTip(Me.chkNHDplus_fac, "fac grid")
        Me.chkNHDplus_fac.UseVisualStyleBackColor = True
        '
        'chkNHDplus_fdr
        '
        Me.chkNHDplus_fdr.AutoSize = True
        Me.chkNHDplus_fdr.Location = New System.Drawing.Point(6, 65)
        Me.chkNHDplus_fdr.Name = "chkNHDplus_fdr"
        Me.chkNHDplus_fdr.Size = New System.Drawing.Size(115, 17)
        Me.chkNHDplus_fdr.TabIndex = 19
        Me.chkNHDplus_fdr.Text = "Flow Direction Grid"
        Me.ToolTip1.SetToolTip(Me.chkNHDplus_fdr, "fdr grid")
        Me.chkNHDplus_fdr.UseVisualStyleBackColor = True
        '
        'chkNHDplus_elev_cm
        '
        Me.chkNHDplus_elev_cm.AutoSize = True
        Me.chkNHDplus_elev_cm.Location = New System.Drawing.Point(6, 42)
        Me.chkNHDplus_elev_cm.Name = "chkNHDplus_elev_cm"
        Me.chkNHDplus_elev_cm.Size = New System.Drawing.Size(92, 17)
        Me.chkNHDplus_elev_cm.TabIndex = 18
        Me.chkNHDplus_elev_cm.Text = "Elevation Grid"
        Me.ToolTip1.SetToolTip(Me.chkNHDplus_elev_cm, "elev_cm grid")
        Me.chkNHDplus_elev_cm.UseVisualStyleBackColor = True
        '
        'chkNHDplus_All
        '
        Me.chkNHDplus_All.AutoSize = True
        Me.chkNHDplus_All.Location = New System.Drawing.Point(6, 19)
        Me.chkNHDplus_All.Name = "chkNHDplus_All"
        Me.chkNHDplus_All.Size = New System.Drawing.Size(37, 17)
        Me.chkNHDplus_All.TabIndex = 17
        Me.chkNHDplus_All.Text = "All"
        Me.chkNHDplus_All.UseVisualStyleBackColor = True
        '
        'chkNHDplus_Catchment
        '
        Me.chkNHDplus_Catchment.AutoSize = True
        Me.chkNHDplus_Catchment.Location = New System.Drawing.Point(233, 19)
        Me.chkNHDplus_Catchment.Name = "chkNHDplus_Catchment"
        Me.chkNHDplus_Catchment.Size = New System.Drawing.Size(82, 17)
        Me.chkNHDplus_Catchment.TabIndex = 22
        Me.chkNHDplus_Catchment.Text = "Catchments"
        Me.chkNHDplus_Catchment.UseVisualStyleBackColor = True
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Location = New System.Drawing.Point(292, 465)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 29
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'cboRegion
        '
        Me.cboRegion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Items.AddRange(New Object() {"View Rectangle", "Extent of Selected Layer"})
        Me.cboRegion.Location = New System.Drawing.Point(124, 12)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(244, 21)
        Me.cboRegion.TabIndex = 30
        '
        'lblRegion
        '
        Me.lblRegion.AutoSize = True
        Me.lblRegion.Location = New System.Drawing.Point(12, 15)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(104, 13)
        Me.lblRegion.TabIndex = 31
        Me.lblRegion.Text = "Region to Download"
        '
        'chkClip
        '
        Me.chkClip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkClip.AutoSize = True
        Me.chkClip.Location = New System.Drawing.Point(81, 469)
        Me.chkClip.Name = "chkClip"
        Me.chkClip.Size = New System.Drawing.Size(92, 17)
        Me.chkClip.TabIndex = 35
        Me.chkClip.Text = "Clip to Region"
        Me.chkClip.UseVisualStyleBackColor = True
        '
        'chkMerge
        '
        Me.chkMerge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkMerge.AutoSize = True
        Me.chkMerge.Location = New System.Drawing.Point(17, 469)
        Me.chkMerge.Name = "chkMerge"
        Me.chkMerge.Size = New System.Drawing.Size(56, 17)
        Me.chkMerge.TabIndex = 37
        Me.chkMerge.Text = "Merge"
        Me.chkMerge.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(211, 465)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'grpSTORET
        '
        Me.grpSTORET.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSTORET.Controls.Add(Me.chkSTORET_Stations)
        Me.grpSTORET.Location = New System.Drawing.Point(12, 407)
        Me.grpSTORET.Name = "grpSTORET"
        Me.grpSTORET.Size = New System.Drawing.Size(356, 44)
        Me.grpSTORET.TabIndex = 42
        Me.grpSTORET.TabStop = False
        Me.grpSTORET.Text = "STORET"
        '
        'chkSTORET_Stations
        '
        Me.chkSTORET_Stations.AutoSize = True
        Me.chkSTORET_Stations.Location = New System.Drawing.Point(6, 19)
        Me.chkSTORET_Stations.Name = "chkSTORET_Stations"
        Me.chkSTORET_Stations.Size = New System.Drawing.Size(64, 17)
        Me.chkSTORET_Stations.TabIndex = 17
        Me.chkSTORET_Stations.Text = "Stations"
        Me.chkSTORET_Stations.UseVisualStyleBackColor = True
        '
        'frmDownload
        '
        Me.AcceptButton = Me.btnDownload
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(380, 500)
        Me.Controls.Add(Me.grpNLCD2001)
        Me.Controls.Add(Me.grpSTORET)
        Me.Controls.Add(Me.grpTerraServerWebService)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkMerge)
        Me.Controls.Add(Me.chkClip)
        Me.Controls.Add(Me.lblRegion)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.grpNHDplus)
        Me.Controls.Add(Me.grpNWIS)
        Me.Controls.Add(Me.grpBASINS)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDownload"
        Me.Text = "Download Data"
        Me.grpBASINS.ResumeLayout(False)
        Me.grpBASINS.PerformLayout()
        Me.grpNWIS.ResumeLayout(False)
        Me.grpNWIS.PerformLayout()
        Me.grpTerraServerWebService.ResumeLayout(False)
        Me.grpTerraServerWebService.PerformLayout()
        Me.grpNLCD2001.ResumeLayout(False)
        Me.grpNLCD2001.PerformLayout()
        Me.grpNHDplus.ResumeLayout(False)
        Me.grpNHDplus.PerformLayout()
        Me.grpSTORET.ResumeLayout(False)
        Me.grpSTORET.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpBASINS As System.Windows.Forms.GroupBox
    Friend WithEvents chkBASINS_Census As System.Windows.Forms.CheckBox
    Friend WithEvents grpNWIS As System.Windows.Forms.GroupBox
    Friend WithEvents chkBASINS_PCS3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_NHD As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_NED As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_LSTORET As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_GIRAS As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_DEMG As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_DEM As System.Windows.Forms.CheckBox
    Friend WithEvents chkBASINS_Met As System.Windows.Forms.CheckBox
    Friend WithEvents chkNWIS_GetNWISStations As System.Windows.Forms.CheckBox
    Friend WithEvents chkNWIS_GetNWISDischarge As System.Windows.Forms.CheckBox
    Friend WithEvents chkTerraServerWebService_Urban As System.Windows.Forms.CheckBox
    Friend WithEvents grpTerraServerWebService As System.Windows.Forms.GroupBox
    Friend WithEvents chkTerraServerWebService_DRG As System.Windows.Forms.CheckBox
    Friend WithEvents chkTerraServerWebService_DOQ As System.Windows.Forms.CheckBox
    Friend WithEvents grpNLCD2001 As System.Windows.Forms.GroupBox
    Friend WithEvents chkNLCD_LandCover As System.Windows.Forms.CheckBox
    Friend WithEvents grpNHDplus As System.Windows.Forms.GroupBox
    Friend WithEvents chkNHDplus_All As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents chkClip As System.Windows.Forms.CheckBox
    Friend WithEvents chkMerge As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents grpSTORET As System.Windows.Forms.GroupBox
    Friend WithEvents chkSTORET_Stations As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowseWDMmet As System.Windows.Forms.Button
    Friend WithEvents chkNHDplus_elev_cm As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_streamgageevent As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_hydrologicunits As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_Catchment As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_hydrography As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_fac As System.Windows.Forms.CheckBox
    Friend WithEvents chkNHDplus_fdr As System.Windows.Forms.CheckBox
    Friend WithEvents chkNLCD_Impervious As System.Windows.Forms.CheckBox
    Friend WithEvents chkNLCD_Canopy As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowseWDMdailydischarge As System.Windows.Forms.Button
End Class
