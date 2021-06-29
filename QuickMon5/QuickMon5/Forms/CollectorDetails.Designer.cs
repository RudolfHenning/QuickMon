namespace QuickMon
{
    partial class CollectorDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectorDetails));
            HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new HenIT.Windows.Controls.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.statusStripCollector = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelEnabled = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelAutoRefresh = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastUpdateTimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.collectorDetailSplitContainer = new System.Windows.Forms.SplitContainer();
            this.panelCollectorDetails = new System.Windows.Forms.Panel();
            this.panelEditing = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.agentsEditTabPage = new System.Windows.Forms.TabPage();
            this.agentsTreeListView = new HenIT.Windows.Controls.TreeListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.agentsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAgentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAgentEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.setAsDisplayValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentsImageList = new System.Windows.Forms.ImageList(this.components);
            this.collectorAgentsEditToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCollectorConfigEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addAgentEntryToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editCollectorAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteCollectorAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.disableAgentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.agentCheckSequenceToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.hostSettingsTabPage = new System.Windows.Forms.TabPage();
            this.chkExcludeFromMetrics = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAdditionalNotes = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboExpandOnStartOption = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboChildCheckBehaviour = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.operationalTabPage = new System.Windows.Forms.TabPage();
            this.serviceWindowsGroupBox = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabelServiceWindows = new System.Windows.Forms.LinkLabel();
            this.runAsGroupBox = new System.Windows.Forms.GroupBox();
            this.cmdTestRunAs = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.chkRunAsEnabled = new System.Windows.Forms.CheckBox();
            this.txtRunAs = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.remoteAgentGroupBox = new System.Windows.Forms.GroupBox();
            this.cboRemoteAgentServer = new System.Windows.Forms.ComboBox();
            this.chkRunLocalOnRemoteHostConnectionFailure = new System.Windows.Forms.CheckBox();
            this.chkBlockParentRHOverride = new System.Windows.Forms.CheckBox();
            this.chkForceRemoteExcuteOnChildCollectors = new System.Windows.Forms.CheckBox();
            this.llblRemoteAgentInstallHelp = new System.Windows.Forms.LinkLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.chkRemoteAgentEnabled = new System.Windows.Forms.CheckBox();
            this.remoteportNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmdRemoteAgentTest = new System.Windows.Forms.Button();
            this.pollingOverridesGroupBox = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.chkEnablePollingOverride = new System.Windows.Forms.CheckBox();
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.chkEnablePollingFrequencySliding = new System.Windows.Forms.CheckBox();
            this.onlyAllowUpdateOncePerXSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.alertsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmdSetNoteText = new System.Windows.Forms.Button();
            this.txtNotesText = new System.Windows.Forms.TextBox();
            this.lblNoteTextChangeIndicator = new System.Windows.Forms.Label();
            this.cboTextType = new System.Windows.Forms.ComboBox();
            this.correctiveScriptsGroupBox = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin = new System.Windows.Forms.NumericUpDown();
            this.label53 = new System.Windows.Forms.Label();
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.chkCorrectiveScriptDisabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.alertSuppressionGroupBox = new System.Windows.Forms.GroupBox();
            this.chkAlertsPaused = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownRepeatAlertInXPolls = new System.Windows.Forms.NumericUpDown();
            this.delayAlertPollsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AlertOnceInXPollsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownRepeatAlertInXMin = new System.Windows.Forms.NumericUpDown();
            this.delayAlertSecNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.AlertOnceInXMinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.configVarsTabPage = new System.Windows.Forms.TabPage();
            this.lvwConfigVars = new QuickMon.ListViewEx();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtConfigVarReplaceByValue = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtConfigVarSearchFor = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.moveDownConfigVarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwActionScriptsEdit = new QuickMon.ListViewEx();
            this.actionScriptNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adminColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.restorationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.warningColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptiomColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.actionScriptsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runActionScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runActionScriptWithPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.addActionScriptToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.editActionScriptToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteActionScriptToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.llblRawEdit = new System.Windows.Forms.LinkLabel();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panelMetrics = new System.Windows.Forms.Panel();
            this.lvwMetrics = new QuickMon.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelAgentStates = new System.Windows.Forms.Panel();
            this.agentStateSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tlvAgentStates = new HenIT.Windows.Controls.TreeListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imagesCollectorTree = new System.Windows.Forms.ImageList(this.components);
            this.collectorTimeGraph = new HenIT.Windows.Controls.Graphing.TimeGraphControl();
            this.graphContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearGraphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logarithmicGraphTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grapthColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphBackgroundColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientColor1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientColor2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapGraphGradientColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphGridColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphAxisLabelColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionBarColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedValueColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorInvertedColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphClosestClickedColorCustomColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphVisibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHeaderVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legendVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHorisonalGridLinesVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphVerticalGridLinesVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphSelectionbarVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphHighlightClickedSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaBelowSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha48ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha64ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha128ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFillAreaAlpha192ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwHistory = new QuickMon.ListViewEx();
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.collectorValueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alertCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optGraphView = new System.Windows.Forms.RadioButton();
            this.exportHistoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardExportAsCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkRAWDetails = new System.Windows.Forms.CheckBox();
            this.optHistoricStateView = new System.Windows.Forms.RadioButton();
            this.optCurrentStateView = new System.Windows.Forms.RadioButton();
            this.rtxDetails = new System.Windows.Forms.RichTextBox();
            this.rawViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rawViewCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawViewSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdActionScriptsVisible = new System.Windows.Forms.Button();
            this.optMetrics = new System.Windows.Forms.RadioButton();
            this.optAgentStates = new System.Windows.Forms.RadioButton();
            this.cmdCollectorEdit = new System.Windows.Forms.Button();
            this.lvwActionScripts = new QuickMon.ListViewEx();
            this.nameActionScriptColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdRunActionScript = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCollectorState = new System.Windows.Forms.Label();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.statusStripCollector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectorDetailSplitContainer)).BeginInit();
            this.collectorDetailSplitContainer.Panel1.SuspendLayout();
            this.collectorDetailSplitContainer.Panel2.SuspendLayout();
            this.collectorDetailSplitContainer.SuspendLayout();
            this.panelCollectorDetails.SuspendLayout();
            this.panelEditing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.agentsEditTabPage.SuspendLayout();
            this.agentsContextMenuStrip.SuspendLayout();
            this.collectorAgentsEditToolStrip.SuspendLayout();
            this.hostSettingsTabPage.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.operationalTabPage.SuspendLayout();
            this.serviceWindowsGroupBox.SuspendLayout();
            this.runAsGroupBox.SuspendLayout();
            this.remoteAgentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).BeginInit();
            this.pollingOverridesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).BeginInit();
            this.alertsTabPage.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.correctiveScriptsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestorationScriptMinimumRepeatTimeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin)).BeginInit();
            this.alertSuppressionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXPolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXPollsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertSecNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXMinNumericUpDown)).BeginInit();
            this.configVarsTabPage.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.actionScriptsContextMenuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panelMetrics.SuspendLayout();
            this.panelAgentStates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).BeginInit();
            this.agentStateSplitContainer.Panel1.SuspendLayout();
            this.agentStateSplitContainer.Panel2.SuspendLayout();
            this.agentStateSplitContainer.SuspendLayout();
            this.graphContextMenuStrip.SuspendLayout();
            this.panel3.SuspendLayout();
            this.exportHistoryContextMenuStrip.SuspendLayout();
            this.rawViewContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(100, 9);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(1067, 21);
            this.txtName.TabIndex = 5;
            this.txtName.WordWrap = false;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(42, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 18);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "&Name:";
            // 
            // statusStripCollector
            // 
            this.statusStripCollector.BackColor = System.Drawing.Color.Transparent;
            this.statusStripCollector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEnabled,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelAutoRefresh,
            this.toolStripStatusLabel2,
            this.lastUpdateTimeToolStripStatusLabel});
            this.statusStripCollector.Location = new System.Drawing.Point(0, 679);
            this.statusStripCollector.Name = "statusStripCollector";
            this.statusStripCollector.Size = new System.Drawing.Size(1199, 22);
            this.statusStripCollector.TabIndex = 7;
            this.statusStripCollector.Text = "statusStrip1";
            this.statusStripCollector.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStripCollector_ItemClicked);
            // 
            // toolStripStatusLabelEnabled
            // 
            this.toolStripStatusLabelEnabled.AutoToolTip = true;
            this.toolStripStatusLabelEnabled.DoubleClickEnabled = true;
            this.toolStripStatusLabelEnabled.Image = global::QuickMon.Properties.Resources._131;
            this.toolStripStatusLabelEnabled.Name = "toolStripStatusLabelEnabled";
            this.toolStripStatusLabelEnabled.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabelEnabled.Text = "Enabled";
            this.toolStripStatusLabelEnabled.ToolTipText = "Enabled";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabelAutoRefresh
            // 
            this.toolStripStatusLabelAutoRefresh.AutoToolTip = true;
            this.toolStripStatusLabelAutoRefresh.DoubleClickEnabled = true;
            this.toolStripStatusLabelAutoRefresh.Image = global::QuickMon.Properties.Resources._102;
            this.toolStripStatusLabelAutoRefresh.Name = "toolStripStatusLabelAutoRefresh";
            this.toolStripStatusLabelAutoRefresh.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabelAutoRefresh.Text = "Auto Refresh ON";
            this.toolStripStatusLabelAutoRefresh.ToolTipText = "Auto refresh";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // lastUpdateTimeToolStripStatusLabel
            // 
            this.lastUpdateTimeToolStripStatusLabel.Name = "lastUpdateTimeToolStripStatusLabel";
            this.lastUpdateTimeToolStripStatusLabel.Size = new System.Drawing.Size(65, 17);
            this.lastUpdateTimeToolStripStatusLabel.Text = "<No data>";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(7, 36);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.collectorDetailSplitContainer);
            this.splitContainerMain.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.lvwActionScripts);
            this.splitContainerMain.Panel2.Controls.Add(this.panel2);
            this.splitContainerMain.Panel2.Controls.Add(this.label1);
            this.splitContainerMain.Panel2MinSize = 200;
            this.splitContainerMain.Size = new System.Drawing.Size(1185, 640);
            this.splitContainerMain.SplitterDistance = 981;
            this.splitContainerMain.TabIndex = 8;
            // 
            // collectorDetailSplitContainer
            // 
            this.collectorDetailSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectorDetailSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.collectorDetailSplitContainer.Name = "collectorDetailSplitContainer";
            this.collectorDetailSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // collectorDetailSplitContainer.Panel1
            // 
            this.collectorDetailSplitContainer.Panel1.Controls.Add(this.panelCollectorDetails);
            // 
            // collectorDetailSplitContainer.Panel2
            // 
            this.collectorDetailSplitContainer.Panel2.Controls.Add(this.rtxDetails);
            this.collectorDetailSplitContainer.Size = new System.Drawing.Size(981, 615);
            this.collectorDetailSplitContainer.SplitterDistance = 418;
            this.collectorDetailSplitContainer.SplitterWidth = 6;
            this.collectorDetailSplitContainer.TabIndex = 4;
            // 
            // panelCollectorDetails
            // 
            this.panelCollectorDetails.AutoScroll = true;
            this.panelCollectorDetails.Controls.Add(this.panelEditing);
            this.panelCollectorDetails.Controls.Add(this.panelMetrics);
            this.panelCollectorDetails.Controls.Add(this.panelAgentStates);
            this.panelCollectorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCollectorDetails.Location = new System.Drawing.Point(0, 0);
            this.panelCollectorDetails.Name = "panelCollectorDetails";
            this.panelCollectorDetails.Size = new System.Drawing.Size(981, 418);
            this.panelCollectorDetails.TabIndex = 3;
            // 
            // panelEditing
            // 
            this.panelEditing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditing.Controls.Add(this.splitContainer2);
            this.panelEditing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEditing.Location = new System.Drawing.Point(0, 401);
            this.panelEditing.Name = "panelEditing";
            this.panelEditing.Size = new System.Drawing.Size(964, 465);
            this.panelEditing.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.llblRawEdit);
            this.splitContainer2.Panel2.Controls.Add(this.cmdOK);
            this.splitContainer2.Panel2.Controls.Add(this.cmdCancel);
            this.splitContainer2.Size = new System.Drawing.Size(962, 463);
            this.splitContainer2.SplitterDistance = 421;
            this.splitContainer2.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.agentsEditTabPage);
            this.tabControl1.Controls.Add(this.hostSettingsTabPage);
            this.tabControl1.Controls.Add(this.operationalTabPage);
            this.tabControl1.Controls.Add(this.alertsTabPage);
            this.tabControl1.Controls.Add(this.configVarsTabPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(962, 421);
            this.tabControl1.TabIndex = 11;
            // 
            // agentsEditTabPage
            // 
            this.agentsEditTabPage.Controls.Add(this.agentsTreeListView);
            this.agentsEditTabPage.Controls.Add(this.collectorAgentsEditToolStrip);
            this.agentsEditTabPage.Location = new System.Drawing.Point(4, 22);
            this.agentsEditTabPage.Name = "agentsEditTabPage";
            this.agentsEditTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.agentsEditTabPage.Size = new System.Drawing.Size(954, 395);
            this.agentsEditTabPage.TabIndex = 0;
            this.agentsEditTabPage.Text = "Agents";
            this.agentsEditTabPage.UseVisualStyleBackColor = true;
            // 
            // agentsTreeListView
            // 
            this.agentsTreeListView.AllowSorting = false;
            this.agentsTreeListView.AutoResizeColumnEnabled = false;
            this.agentsTreeListView.AutoResizeColumnIndex = 1;
            this.agentsTreeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.None;
            this.agentsTreeListView.Comparer = treeListViewItemCollectionComparer1;
            this.agentsTreeListView.ContextMenuStrip = this.agentsContextMenuStrip;
            this.agentsTreeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentsTreeListView.HideSelection = false;
            this.agentsTreeListView.LabelEdit = true;
            this.agentsTreeListView.Location = new System.Drawing.Point(3, 30);
            this.agentsTreeListView.Name = "agentsTreeListView";
            this.agentsTreeListView.Size = new System.Drawing.Size(948, 362);
            this.agentsTreeListView.SmallImageList = this.agentsImageList;
            this.agentsTreeListView.Sorting = System.Windows.Forms.SortOrder.None;
            this.agentsTreeListView.TabIndex = 4;
            this.agentsTreeListView.UseCompatibleStateImageBehavior = false;
            this.agentsTreeListView.AfterLabelEdit += new HenIT.Windows.Controls.TreeListViewLabelEditEventHandler(this.agentsTreeListView_AfterLabelEdit);
            this.agentsTreeListView.BeforeLabelEdit += new HenIT.Windows.Controls.TreeListViewBeforeLabelEditEventHandler(this.agentsTreeListView_BeforeLabelEdit);
            this.agentsTreeListView.SelectedIndexChanged += new System.EventHandler(this.agentsTreeListView_SelectedIndexChanged);
            this.agentsTreeListView.DoubleClick += new System.EventHandler(this.agentsTreeListView_DoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Agent/Entry";
            this.columnHeader3.Width = 316;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Summary";
            this.columnHeader4.Width = 337;
            // 
            // agentsContextMenuStrip
            // 
            this.agentsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.agentsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAgentToolStripMenuItem,
            this.addAgentEntryToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.toolStripMenuItem2,
            this.setAsDisplayValueToolStripMenuItem,
            this.enableToolStripMenuItem});
            this.agentsContextMenuStrip.Name = "agentsContextMenuStrip";
            this.agentsContextMenuStrip.Size = new System.Drawing.Size(181, 224);
            // 
            // addAgentToolStripMenuItem
            // 
            this.addAgentToolStripMenuItem.Image = global::QuickMon.Properties.Resources.add;
            this.addAgentToolStripMenuItem.Name = "addAgentToolStripMenuItem";
            this.addAgentToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addAgentToolStripMenuItem.Text = "Add Agent";
            this.addAgentToolStripMenuItem.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // addAgentEntryToolStripMenuItem
            // 
            this.addAgentEntryToolStripMenuItem.Image = global::QuickMon.Properties.Resources.addGreen24x24;
            this.addAgentEntryToolStripMenuItem.Name = "addAgentEntryToolStripMenuItem";
            this.addAgentEntryToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.addAgentEntryToolStripMenuItem.Text = "Add Agent entry";
            this.addAgentEntryToolStripMenuItem.Click += new System.EventHandler(this.addAgentEntryToolStripButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editCollectorAgentToolStripButton_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteCollectorAgentToolStripButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.moveUpToolStripMenuItem.Text = "Move up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpAgentToolStripButton_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.moveDownToolStripMenuItem.Text = "Move down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownAgentToolStripButton_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // setAsDisplayValueToolStripMenuItem
            // 
            this.setAsDisplayValueToolStripMenuItem.Name = "setAsDisplayValueToolStripMenuItem";
            this.setAsDisplayValueToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.setAsDisplayValueToolStripMenuItem.Text = "Set as Display value";
            this.setAsDisplayValueToolStripMenuItem.Click += new System.EventHandler(this.setAsDisplayValueToolStripMenuItem_Click);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Image = global::QuickMon.Properties.Resources._131;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.enableToolStripMenuItem.Text = "Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // agentsImageList
            // 
            this.agentsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("agentsImageList.ImageStream")));
            this.agentsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.agentsImageList.Images.SetKeyName(0, "NoGo.ico");
            this.agentsImageList.Images.SetKeyName(1, "Configuration.ico");
            this.agentsImageList.Images.SetKeyName(2, "127_9.ico");
            // 
            // collectorAgentsEditToolStrip
            // 
            this.collectorAgentsEditToolStrip.BackColor = System.Drawing.Color.White;
            this.collectorAgentsEditToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.collectorAgentsEditToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.collectorAgentsEditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectorConfigEntryToolStripButton,
            this.addAgentEntryToolStripButton,
            this.editCollectorAgentToolStripButton,
            this.deleteCollectorAgentToolStripButton,
            this.toolStripSeparator2,
            this.moveUpAgentToolStripButton,
            this.moveDownAgentToolStripButton,
            this.toolStripSeparator3,
            this.enableAgentToolStripButton,
            this.disableAgentToolStripButton,
            this.toolStripLabel1,
            this.agentCheckSequenceToolStripComboBox});
            this.collectorAgentsEditToolStrip.Location = new System.Drawing.Point(3, 3);
            this.collectorAgentsEditToolStrip.Name = "collectorAgentsEditToolStrip";
            this.collectorAgentsEditToolStrip.Size = new System.Drawing.Size(948, 27);
            this.collectorAgentsEditToolStrip.TabIndex = 3;
            this.collectorAgentsEditToolStrip.TabStop = true;
            this.collectorAgentsEditToolStrip.Text = "toolStrip1";
            // 
            // addCollectorConfigEntryToolStripButton
            // 
            this.addCollectorConfigEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCollectorConfigEntryToolStripButton.Image = global::QuickMon.Properties.Resources.add;
            this.addCollectorConfigEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCollectorConfigEntryToolStripButton.Name = "addCollectorConfigEntryToolStripButton";
            this.addCollectorConfigEntryToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addCollectorConfigEntryToolStripButton.Text = "Add new Agent";
            this.addCollectorConfigEntryToolStripButton.ToolTipText = "Add entry";
            this.addCollectorConfigEntryToolStripButton.Click += new System.EventHandler(this.addCollectorConfigEntryToolStripButton_Click);
            // 
            // addAgentEntryToolStripButton
            // 
            this.addAgentEntryToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addAgentEntryToolStripButton.Enabled = false;
            this.addAgentEntryToolStripButton.Image = global::QuickMon.Properties.Resources.addGreen24x24;
            this.addAgentEntryToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addAgentEntryToolStripButton.Name = "addAgentEntryToolStripButton";
            this.addAgentEntryToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addAgentEntryToolStripButton.Text = "Add new Agent entry";
            this.addAgentEntryToolStripButton.Click += new System.EventHandler(this.addAgentEntryToolStripButton_Click);
            // 
            // editCollectorAgentToolStripButton
            // 
            this.editCollectorAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editCollectorAgentToolStripButton.Enabled = false;
            this.editCollectorAgentToolStripButton.Image = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.editCollectorAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editCollectorAgentToolStripButton.Name = "editCollectorAgentToolStripButton";
            this.editCollectorAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.editCollectorAgentToolStripButton.Text = "Edit selected Agent";
            this.editCollectorAgentToolStripButton.Click += new System.EventHandler(this.editCollectorAgentToolStripButton_Click);
            // 
            // deleteCollectorAgentToolStripButton
            // 
            this.deleteCollectorAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteCollectorAgentToolStripButton.Enabled = false;
            this.deleteCollectorAgentToolStripButton.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteCollectorAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCollectorAgentToolStripButton.Name = "deleteCollectorAgentToolStripButton";
            this.deleteCollectorAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteCollectorAgentToolStripButton.Text = "Delete selected Agent(s)";
            this.deleteCollectorAgentToolStripButton.Click += new System.EventHandler(this.deleteCollectorAgentToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // moveUpAgentToolStripButton
            // 
            this.moveUpAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpAgentToolStripButton.Enabled = false;
            this.moveUpAgentToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpAgentToolStripButton.Name = "moveUpAgentToolStripButton";
            this.moveUpAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveUpAgentToolStripButton.Text = "Move selected item up";
            this.moveUpAgentToolStripButton.Click += new System.EventHandler(this.moveUpAgentToolStripButton_Click);
            // 
            // moveDownAgentToolStripButton
            // 
            this.moveDownAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownAgentToolStripButton.Enabled = false;
            this.moveDownAgentToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownAgentToolStripButton.Name = "moveDownAgentToolStripButton";
            this.moveDownAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveDownAgentToolStripButton.Text = "Move selected item down";
            this.moveDownAgentToolStripButton.Click += new System.EventHandler(this.moveDownAgentToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // enableAgentToolStripButton
            // 
            this.enableAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.enableAgentToolStripButton.Enabled = false;
            this.enableAgentToolStripButton.Image = global::QuickMon.Properties.Resources._131;
            this.enableAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enableAgentToolStripButton.Name = "enableAgentToolStripButton";
            this.enableAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.enableAgentToolStripButton.Text = "Enable";
            this.enableAgentToolStripButton.Click += new System.EventHandler(this.enableAgentToolStripButton_Click);
            // 
            // disableAgentToolStripButton
            // 
            this.disableAgentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disableAgentToolStripButton.Enabled = false;
            this.disableAgentToolStripButton.Image = global::QuickMon.Properties.Resources._141;
            this.disableAgentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disableAgentToolStripButton.Name = "disableAgentToolStripButton";
            this.disableAgentToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.disableAgentToolStripButton.Text = "Disable";
            this.disableAgentToolStripButton.Click += new System.EventHandler(this.disableAgentToolStripButton_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(126, 24);
            this.toolStripLabel1.Text = "Agent check se&quence";
            // 
            // agentCheckSequenceToolStripComboBox
            // 
            this.agentCheckSequenceToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.agentCheckSequenceToolStripComboBox.Items.AddRange(new object[] {
            "All",
            "First Success",
            "First Error"});
            this.agentCheckSequenceToolStripComboBox.Name = "agentCheckSequenceToolStripComboBox";
            this.agentCheckSequenceToolStripComboBox.Size = new System.Drawing.Size(121, 27);
            // 
            // hostSettingsTabPage
            // 
            this.hostSettingsTabPage.AutoScroll = true;
            this.hostSettingsTabPage.Controls.Add(this.chkExcludeFromMetrics);
            this.hostSettingsTabPage.Controls.Add(this.groupBox7);
            this.hostSettingsTabPage.Controls.Add(this.groupBox4);
            this.hostSettingsTabPage.Controls.Add(this.groupBox1);
            this.hostSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.hostSettingsTabPage.Name = "hostSettingsTabPage";
            this.hostSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.hostSettingsTabPage.Size = new System.Drawing.Size(954, 395);
            this.hostSettingsTabPage.TabIndex = 1;
            this.hostSettingsTabPage.Text = "Host settings";
            this.hostSettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // chkExcludeFromMetrics
            // 
            this.chkExcludeFromMetrics.AutoSize = true;
            this.chkExcludeFromMetrics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExcludeFromMetrics.Location = new System.Drawing.Point(9, 284);
            this.chkExcludeFromMetrics.Name = "chkExcludeFromMetrics";
            this.chkExcludeFromMetrics.Size = new System.Drawing.Size(172, 17);
            this.chkExcludeFromMetrics.TabIndex = 6;
            this.chkExcludeFromMetrics.Text = "Exclude From Metrics collection";
            this.chkExcludeFromMetrics.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtCategories);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.Location = new System.Drawing.Point(3, 176);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(948, 105);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            // 
            // txtCategories
            // 
            this.txtCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCategories.Location = new System.Drawing.Point(3, 16);
            this.txtCategories.Multiline = true;
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCategories.Size = new System.Drawing.Size(942, 86);
            this.txtCategories.TabIndex = 6;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.White;
            this.label46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(6, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(222, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Categories - (each line is a new entry)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAdditionalNotes);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(3, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(948, 95);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // txtAdditionalNotes
            // 
            this.txtAdditionalNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAdditionalNotes.Location = new System.Drawing.Point(3, 16);
            this.txtAdditionalNotes.Multiline = true;
            this.txtAdditionalNotes.Name = "txtAdditionalNotes";
            this.txtAdditionalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdditionalNotes.Size = new System.Drawing.Size(942, 76);
            this.txtAdditionalNotes.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(227, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Additional Notes for this Collector Host";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboExpandOnStartOption);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboChildCheckBehaviour);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 78);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cboExpandOnStartOption
            // 
            this.cboExpandOnStartOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExpandOnStartOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpandOnStartOption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboExpandOnStartOption.FormattingEnabled = true;
            this.cboExpandOnStartOption.Items.AddRange(new object[] {
            "Auto",
            "On Error/Warning",
            "On success",
            "Never",
            "Always"});
            this.cboExpandOnStartOption.Location = new System.Drawing.Point(172, 47);
            this.cboExpandOnStartOption.Name = "cboExpandOnStartOption";
            this.cboExpandOnStartOption.Size = new System.Drawing.Size(770, 21);
            this.cboExpandOnStartOption.TabIndex = 6;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(16, 50);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(158, 18);
            this.label47.TabIndex = 5;
            this.label47.Text = "Expand on (UI only)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Child Collector Host settings";
            // 
            // cboChildCheckBehaviour
            // 
            this.cboChildCheckBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChildCheckBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChildCheckBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboChildCheckBehaviour.FormattingEnabled = true;
            this.cboChildCheckBehaviour.Items.AddRange(new object[] {
            "Only Run On Success",
            "Continue On Warning",
            "Continue On Warning Or Error"});
            this.cboChildCheckBehaviour.Location = new System.Drawing.Point(172, 20);
            this.cboChildCheckBehaviour.Name = "cboChildCheckBehaviour";
            this.cboChildCheckBehaviour.Size = new System.Drawing.Size(770, 21);
            this.cboChildCheckBehaviour.TabIndex = 4;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(16, 23);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(158, 18);
            this.label39.TabIndex = 3;
            this.label39.Text = "Check sequence behaviour";
            // 
            // operationalTabPage
            // 
            this.operationalTabPage.AutoScroll = true;
            this.operationalTabPage.Controls.Add(this.serviceWindowsGroupBox);
            this.operationalTabPage.Controls.Add(this.runAsGroupBox);
            this.operationalTabPage.Controls.Add(this.remoteAgentGroupBox);
            this.operationalTabPage.Controls.Add(this.pollingOverridesGroupBox);
            this.operationalTabPage.Location = new System.Drawing.Point(4, 22);
            this.operationalTabPage.Name = "operationalTabPage";
            this.operationalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.operationalTabPage.Size = new System.Drawing.Size(954, 395);
            this.operationalTabPage.TabIndex = 2;
            this.operationalTabPage.Text = "Operational";
            this.operationalTabPage.UseVisualStyleBackColor = true;
            // 
            // serviceWindowsGroupBox
            // 
            this.serviceWindowsGroupBox.BackColor = System.Drawing.Color.White;
            this.serviceWindowsGroupBox.Controls.Add(this.label16);
            this.serviceWindowsGroupBox.Controls.Add(this.linkLabelServiceWindows);
            this.serviceWindowsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.serviceWindowsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serviceWindowsGroupBox.Location = new System.Drawing.Point(3, 235);
            this.serviceWindowsGroupBox.MinimumSize = new System.Drawing.Size(100, 50);
            this.serviceWindowsGroupBox.Name = "serviceWindowsGroupBox";
            this.serviceWindowsGroupBox.Size = new System.Drawing.Size(948, 70);
            this.serviceWindowsGroupBox.TabIndex = 12;
            this.serviceWindowsGroupBox.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Service window(s)";
            // 
            // linkLabelServiceWindows
            // 
            this.linkLabelServiceWindows.AutoEllipsis = true;
            this.linkLabelServiceWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelServiceWindows.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelServiceWindows.Location = new System.Drawing.Point(3, 16);
            this.linkLabelServiceWindows.Name = "linkLabelServiceWindows";
            this.linkLabelServiceWindows.Size = new System.Drawing.Size(942, 51);
            this.linkLabelServiceWindows.TabIndex = 1;
            this.linkLabelServiceWindows.TabStop = true;
            this.linkLabelServiceWindows.Text = "None";
            this.linkLabelServiceWindows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServiceWindows_LinkClicked);
            // 
            // runAsGroupBox
            // 
            this.runAsGroupBox.BackColor = System.Drawing.Color.White;
            this.runAsGroupBox.Controls.Add(this.cmdTestRunAs);
            this.runAsGroupBox.Controls.Add(this.label45);
            this.runAsGroupBox.Controls.Add(this.chkRunAsEnabled);
            this.runAsGroupBox.Controls.Add(this.txtRunAs);
            this.runAsGroupBox.Controls.Add(this.label43);
            this.runAsGroupBox.Controls.Add(this.label44);
            this.runAsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.runAsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runAsGroupBox.Location = new System.Drawing.Point(3, 173);
            this.runAsGroupBox.Name = "runAsGroupBox";
            this.runAsGroupBox.Size = new System.Drawing.Size(948, 62);
            this.runAsGroupBox.TabIndex = 11;
            this.runAsGroupBox.TabStop = false;
            // 
            // cmdTestRunAs
            // 
            this.cmdTestRunAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestRunAs.Enabled = false;
            this.cmdTestRunAs.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdTestRunAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTestRunAs.Location = new System.Drawing.Point(872, 17);
            this.cmdTestRunAs.Name = "cmdTestRunAs";
            this.cmdTestRunAs.Size = new System.Drawing.Size(70, 23);
            this.cmdTestRunAs.TabIndex = 4;
            this.cmdTestRunAs.Text = "Test";
            this.cmdTestRunAs.UseVisualStyleBackColor = true;
            this.cmdTestRunAs.Click += new System.EventHandler(this.cmdTestRunAs_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(105, 42);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(305, 13);
            this.label45.TabIndex = 5;
            this.label45.Text = "To set up a password use the Monitor pack configuration editor";
            // 
            // chkRunAsEnabled
            // 
            this.chkRunAsEnabled.AutoSize = true;
            this.chkRunAsEnabled.BackColor = System.Drawing.Color.White;
            this.chkRunAsEnabled.Checked = true;
            this.chkRunAsEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunAsEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRunAsEnabled.Location = new System.Drawing.Point(72, 0);
            this.chkRunAsEnabled.Name = "chkRunAsEnabled";
            this.chkRunAsEnabled.Size = new System.Drawing.Size(62, 17);
            this.chkRunAsEnabled.TabIndex = 1;
            this.chkRunAsEnabled.Text = "Enabled";
            this.chkRunAsEnabled.UseVisualStyleBackColor = false;
            this.chkRunAsEnabled.CheckedChanged += new System.EventHandler(this.chkRunAsEnabled_CheckedChanged);
            // 
            // txtRunAs
            // 
            this.txtRunAs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRunAs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRunAs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRunAs.Location = new System.Drawing.Point(108, 19);
            this.txtRunAs.Name = "txtRunAs";
            this.txtRunAs.Size = new System.Drawing.Size(758, 20);
            this.txtRunAs.TabIndex = 3;
            this.txtRunAs.TextChanged += new System.EventHandler(this.txtRunAs_TextChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(6, 1);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(47, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "Run as";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(10, 22);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 13);
            this.label44.TabIndex = 2;
            this.label44.Text = "User name";
            // 
            // remoteAgentGroupBox
            // 
            this.remoteAgentGroupBox.BackColor = System.Drawing.Color.White;
            this.remoteAgentGroupBox.Controls.Add(this.cboRemoteAgentServer);
            this.remoteAgentGroupBox.Controls.Add(this.chkRunLocalOnRemoteHostConnectionFailure);
            this.remoteAgentGroupBox.Controls.Add(this.chkBlockParentRHOverride);
            this.remoteAgentGroupBox.Controls.Add(this.chkForceRemoteExcuteOnChildCollectors);
            this.remoteAgentGroupBox.Controls.Add(this.llblRemoteAgentInstallHelp);
            this.remoteAgentGroupBox.Controls.Add(this.label17);
            this.remoteAgentGroupBox.Controls.Add(this.chkRemoteAgentEnabled);
            this.remoteAgentGroupBox.Controls.Add(this.remoteportNumericUpDown);
            this.remoteAgentGroupBox.Controls.Add(this.label13);
            this.remoteAgentGroupBox.Controls.Add(this.label14);
            this.remoteAgentGroupBox.Controls.Add(this.cmdRemoteAgentTest);
            this.remoteAgentGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.remoteAgentGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remoteAgentGroupBox.Location = new System.Drawing.Point(3, 98);
            this.remoteAgentGroupBox.Name = "remoteAgentGroupBox";
            this.remoteAgentGroupBox.Size = new System.Drawing.Size(948, 75);
            this.remoteAgentGroupBox.TabIndex = 10;
            this.remoteAgentGroupBox.TabStop = false;
            // 
            // cboRemoteAgentServer
            // 
            this.cboRemoteAgentServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRemoteAgentServer.FormattingEnabled = true;
            this.cboRemoteAgentServer.Location = new System.Drawing.Point(138, 23);
            this.cboRemoteAgentServer.Name = "cboRemoteAgentServer";
            this.cboRemoteAgentServer.Size = new System.Drawing.Size(616, 21);
            this.cboRemoteAgentServer.Sorted = true;
            this.cboRemoteAgentServer.TabIndex = 5;
            this.cboRemoteAgentServer.SelectedIndexChanged += new System.EventHandler(this.cboRemoteAgentServer_SelectedIndexChanged);
            this.cboRemoteAgentServer.TextChanged += new System.EventHandler(this.cboRemoteAgentServer_TextChanged);
            this.cboRemoteAgentServer.Leave += new System.EventHandler(this.cboRemoteAgentServer_Leave);
            // 
            // chkRunLocalOnRemoteHostConnectionFailure
            // 
            this.chkRunLocalOnRemoteHostConnectionFailure.AutoSize = true;
            this.chkRunLocalOnRemoteHostConnectionFailure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRunLocalOnRemoteHostConnectionFailure.Location = new System.Drawing.Point(256, 50);
            this.chkRunLocalOnRemoteHostConnectionFailure.Name = "chkRunLocalOnRemoteHostConnectionFailure";
            this.chkRunLocalOnRemoteHostConnectionFailure.Size = new System.Drawing.Size(218, 17);
            this.chkRunLocalOnRemoteHostConnectionFailure.TabIndex = 10;
            this.chkRunLocalOnRemoteHostConnectionFailure.Text = "Run locally if remote host connection fails";
            this.chkRunLocalOnRemoteHostConnectionFailure.UseVisualStyleBackColor = true;
            // 
            // chkBlockParentRHOverride
            // 
            this.chkBlockParentRHOverride.AutoSize = true;
            this.chkBlockParentRHOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBlockParentRHOverride.Location = new System.Drawing.Point(28, 50);
            this.chkBlockParentRHOverride.Name = "chkBlockParentRHOverride";
            this.chkBlockParentRHOverride.Size = new System.Drawing.Size(187, 17);
            this.chkBlockParentRHOverride.TabIndex = 9;
            this.chkBlockParentRHOverride.Text = "Block parent remote agent settings";
            this.chkBlockParentRHOverride.UseVisualStyleBackColor = true;
            // 
            // chkForceRemoteExcuteOnChildCollectors
            // 
            this.chkForceRemoteExcuteOnChildCollectors.AutoSize = true;
            this.chkForceRemoteExcuteOnChildCollectors.BackColor = System.Drawing.Color.White;
            this.chkForceRemoteExcuteOnChildCollectors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkForceRemoteExcuteOnChildCollectors.Location = new System.Drawing.Point(256, 0);
            this.chkForceRemoteExcuteOnChildCollectors.Name = "chkForceRemoteExcuteOnChildCollectors";
            this.chkForceRemoteExcuteOnChildCollectors.Size = new System.Drawing.Size(136, 17);
            this.chkForceRemoteExcuteOnChildCollectors.TabIndex = 2;
            this.chkForceRemoteExcuteOnChildCollectors.Text = "Override child collectors";
            this.chkForceRemoteExcuteOnChildCollectors.UseVisualStyleBackColor = false;
            this.chkForceRemoteExcuteOnChildCollectors.CheckedChanged += new System.EventHandler(this.chkForceRemoteExcuteOnChildCollectors_CheckedChanged);
            // 
            // llblRemoteAgentInstallHelp
            // 
            this.llblRemoteAgentInstallHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRemoteAgentInstallHelp.AutoSize = true;
            this.llblRemoteAgentInstallHelp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRemoteAgentInstallHelp.Location = new System.Drawing.Point(881, 1);
            this.llblRemoteAgentInstallHelp.Name = "llblRemoteAgentInstallHelp";
            this.llblRemoteAgentInstallHelp.Size = new System.Drawing.Size(57, 13);
            this.llblRemoteAgentInstallHelp.TabIndex = 3;
            this.llblRemoteAgentInstallHelp.TabStop = true;
            this.llblRemoteAgentInstallHelp.Text = "Install help";
            this.llblRemoteAgentInstallHelp.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Remote agent";
            // 
            // chkRemoteAgentEnabled
            // 
            this.chkRemoteAgentEnabled.AutoSize = true;
            this.chkRemoteAgentEnabled.BackColor = System.Drawing.Color.White;
            this.chkRemoteAgentEnabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemoteAgentEnabled.Location = new System.Drawing.Point(108, 0);
            this.chkRemoteAgentEnabled.Name = "chkRemoteAgentEnabled";
            this.chkRemoteAgentEnabled.Size = new System.Drawing.Size(139, 17);
            this.chkRemoteAgentEnabled.TabIndex = 1;
            this.chkRemoteAgentEnabled.Text = "Enabled for this collector";
            this.chkRemoteAgentEnabled.UseVisualStyleBackColor = false;
            this.chkRemoteAgentEnabled.CheckedChanged += new System.EventHandler(this.chkRemoteAgentEnabled_CheckedChanged);
            // 
            // remoteportNumericUpDown
            // 
            this.remoteportNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteportNumericUpDown.Enabled = false;
            this.remoteportNumericUpDown.Location = new System.Drawing.Point(795, 24);
            this.remoteportNumericUpDown.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.remoteportNumericUpDown.Name = "remoteportNumericUpDown";
            this.remoteportNumericUpDown.Size = new System.Drawing.Size(71, 20);
            this.remoteportNumericUpDown.TabIndex = 7;
            this.remoteportNumericUpDown.Value = new decimal(new int[] {
            48191,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Remote server name";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(763, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Port";
            // 
            // cmdRemoteAgentTest
            // 
            this.cmdRemoteAgentTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRemoteAgentTest.Enabled = false;
            this.cmdRemoteAgentTest.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdRemoteAgentTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRemoteAgentTest.Location = new System.Drawing.Point(872, 21);
            this.cmdRemoteAgentTest.Name = "cmdRemoteAgentTest";
            this.cmdRemoteAgentTest.Size = new System.Drawing.Size(70, 23);
            this.cmdRemoteAgentTest.TabIndex = 8;
            this.cmdRemoteAgentTest.Text = "Test";
            this.cmdRemoteAgentTest.UseVisualStyleBackColor = true;
            this.cmdRemoteAgentTest.Click += new System.EventHandler(this.cmdRemoteAgentTest_Click);
            // 
            // pollingOverridesGroupBox
            // 
            this.pollingOverridesGroupBox.BackColor = System.Drawing.Color.White;
            this.pollingOverridesGroupBox.Controls.Add(this.label36);
            this.pollingOverridesGroupBox.Controls.Add(this.chkEnablePollingOverride);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label34);
            this.pollingOverridesGroupBox.Controls.Add(this.label35);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label32);
            this.pollingOverridesGroupBox.Controls.Add(this.label33);
            this.pollingOverridesGroupBox.Controls.Add(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label30);
            this.pollingOverridesGroupBox.Controls.Add(this.label31);
            this.pollingOverridesGroupBox.Controls.Add(this.chkEnablePollingFrequencySliding);
            this.pollingOverridesGroupBox.Controls.Add(this.onlyAllowUpdateOncePerXSecNumericUpDown);
            this.pollingOverridesGroupBox.Controls.Add(this.label28);
            this.pollingOverridesGroupBox.Controls.Add(this.label29);
            this.pollingOverridesGroupBox.Controls.Add(this.label27);
            this.pollingOverridesGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pollingOverridesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.pollingOverridesGroupBox.Name = "pollingOverridesGroupBox";
            this.pollingOverridesGroupBox.Size = new System.Drawing.Size(948, 95);
            this.pollingOverridesGroupBox.TabIndex = 9;
            this.pollingOverridesGroupBox.TabStop = false;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(269, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(284, 22);
            this.label36.TabIndex = 5;
            this.label36.Text = "Child collectors will Inherit setting unless overridden by higher value";
            // 
            // chkEnablePollingOverride
            // 
            this.chkEnablePollingOverride.AutoSize = true;
            this.chkEnablePollingOverride.BackColor = System.Drawing.Color.White;
            this.chkEnablePollingOverride.Checked = true;
            this.chkEnablePollingOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnablePollingOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnablePollingOverride.Location = new System.Drawing.Point(117, -1);
            this.chkEnablePollingOverride.Name = "chkEnablePollingOverride";
            this.chkEnablePollingOverride.Size = new System.Drawing.Size(62, 17);
            this.chkEnablePollingOverride.TabIndex = 1;
            this.chkEnablePollingOverride.Text = "Enabled";
            this.chkEnablePollingOverride.UseVisualStyleBackColor = false;
            this.chkEnablePollingOverride.CheckedChanged += new System.EventHandler(this.chkEnablePollingOverride_CheckedChanged);
            // 
            // pollSlideFrequencyAfterThirdRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Location = new System.Drawing.Point(410, 66);
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3603,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterThirdRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.TabIndex = 14;
            this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(467, 68);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(49, 13);
            this.label34.TabIndex = 15;
            this.label34.Text = "Seconds";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(382, 68);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(22, 13);
            this.label35.TabIndex = 13;
            this.label35.Text = "3rd";
            // 
            // pollSlideFrequencyAfterSecondRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Location = new System.Drawing.Point(287, 66);
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3602,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterSecondRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.TabIndex = 11;
            this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(343, 68);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 13);
            this.label32.TabIndex = 12;
            this.label32.Text = "Sec";
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(239, 68);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(42, 13);
            this.label33.TabIndex = 10;
            this.label33.Text = "2nd";
            this.label33.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pollSlideFrequencyAfterFirstRepeatSecNumericUpDown
            // 
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Location = new System.Drawing.Point(155, 66);
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Maximum = new decimal(new int[] {
            3601,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Name = "pollSlideFrequencyAfterFirstRepeatSecNumericUpDown";
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.TabIndex = 8;
            this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(210, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(26, 13);
            this.label30.TabIndex = 9;
            this.label30.Text = "Sec";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 68);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(133, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Frequency after first repeat";
            // 
            // chkEnablePollingFrequencySliding
            // 
            this.chkEnablePollingFrequencySliding.AutoSize = true;
            this.chkEnablePollingFrequencySliding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkEnablePollingFrequencySliding.Location = new System.Drawing.Point(14, 45);
            this.chkEnablePollingFrequencySliding.Name = "chkEnablePollingFrequencySliding";
            this.chkEnablePollingFrequencySliding.Size = new System.Drawing.Size(367, 17);
            this.chkEnablePollingFrequencySliding.TabIndex = 6;
            this.chkEnablePollingFrequencySliding.Text = "Enable frequency sliding - (Frequency decrease if state does not change)";
            this.chkEnablePollingFrequencySliding.UseVisualStyleBackColor = true;
            this.chkEnablePollingFrequencySliding.CheckedChanged += new System.EventHandler(this.chkEnablePollingFrequencySliding_CheckedChanged);
            // 
            // onlyAllowUpdateOncePerXSecNumericUpDown
            // 
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Location = new System.Drawing.Point(155, 19);
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Name = "onlyAllowUpdateOncePerXSecNumericUpDown";
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.onlyAllowUpdateOncePerXSecNumericUpDown.TabIndex = 3;
            this.onlyAllowUpdateOncePerXSecNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(214, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(49, 13);
            this.label28.TabIndex = 4;
            this.label28.Text = "Seconds";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(11, 21);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Only update once every";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(6, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(101, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Polling overrides";
            // 
            // alertsTabPage
            // 
            this.alertsTabPage.AutoScroll = true;
            this.alertsTabPage.Controls.Add(this.groupBox9);
            this.alertsTabPage.Controls.Add(this.correctiveScriptsGroupBox);
            this.alertsTabPage.Controls.Add(this.alertSuppressionGroupBox);
            this.alertsTabPage.Location = new System.Drawing.Point(4, 22);
            this.alertsTabPage.Name = "alertsTabPage";
            this.alertsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.alertsTabPage.Size = new System.Drawing.Size(954, 395);
            this.alertsTabPage.TabIndex = 3;
            this.alertsTabPage.Text = "Alerts";
            this.alertsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.Color.White;
            this.groupBox9.Controls.Add(this.cmdSetNoteText);
            this.groupBox9.Controls.Add(this.txtNotesText);
            this.groupBox9.Controls.Add(this.lblNoteTextChangeIndicator);
            this.groupBox9.Controls.Add(this.cboTextType);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox9.Location = new System.Drawing.Point(3, 168);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(948, 131);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            // 
            // cmdSetNoteText
            // 
            this.cmdSetNoteText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetNoteText.Enabled = false;
            this.cmdSetNoteText.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdSetNoteText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSetNoteText.Location = new System.Drawing.Point(905, 14);
            this.cmdSetNoteText.Name = "cmdSetNoteText";
            this.cmdSetNoteText.Size = new System.Drawing.Size(39, 23);
            this.cmdSetNoteText.TabIndex = 3;
            this.cmdSetNoteText.Text = "Set";
            this.cmdSetNoteText.UseVisualStyleBackColor = true;
            this.cmdSetNoteText.Click += new System.EventHandler(this.cmdSetNoteText_Click);
            // 
            // txtNotesText
            // 
            this.txtNotesText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotesText.Location = new System.Drawing.Point(134, 12);
            this.txtNotesText.Multiline = true;
            this.txtNotesText.Name = "txtNotesText";
            this.txtNotesText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotesText.Size = new System.Drawing.Size(767, 113);
            this.txtNotesText.TabIndex = 2;
            this.txtNotesText.TextChanged += new System.EventHandler(this.txtNotesText_TextChanged);
            // 
            // lblNoteTextChangeIndicator
            // 
            this.lblNoteTextChangeIndicator.AutoSize = true;
            this.lblNoteTextChangeIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNoteTextChangeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteTextChangeIndicator.Location = new System.Drawing.Point(6, 0);
            this.lblNoteTextChangeIndicator.Name = "lblNoteTextChangeIndicator";
            this.lblNoteTextChangeIndicator.Size = new System.Drawing.Size(68, 13);
            this.lblNoteTextChangeIndicator.TabIndex = 0;
            this.lblNoteTextChangeIndicator.Text = "Alert Texts";
            // 
            // cboTextType
            // 
            this.cboTextType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboTextType.Items.AddRange(new object[] {
            "Header (All alerts)",
            "Footer (All alerts)",
            "Error Alert",
            "Warning Alert",
            "Good Alert"});
            this.cboTextType.Location = new System.Drawing.Point(6, 16);
            this.cboTextType.Name = "cboTextType";
            this.cboTextType.Size = new System.Drawing.Size(122, 21);
            this.cboTextType.TabIndex = 1;
            this.cboTextType.SelectedIndexChanged += new System.EventHandler(this.cboTextType_SelectedIndexChanged);
            // 
            // correctiveScriptsGroupBox
            // 
            this.correctiveScriptsGroupBox.BackColor = System.Drawing.Color.White;
            this.correctiveScriptsGroupBox.Controls.Add(this.label38);
            this.correctiveScriptsGroupBox.Controls.Add(this.label5);
            this.correctiveScriptsGroupBox.Controls.Add(this.numericUpDownRestorationScriptMinimumRepeatTimeMin);
            this.correctiveScriptsGroupBox.Controls.Add(this.label53);
            this.correctiveScriptsGroupBox.Controls.Add(this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin);
            this.correctiveScriptsGroupBox.Controls.Add(this.label51);
            this.correctiveScriptsGroupBox.Controls.Add(this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin);
            this.correctiveScriptsGroupBox.Controls.Add(this.label48);
            this.correctiveScriptsGroupBox.Controls.Add(this.label20);
            this.correctiveScriptsGroupBox.Controls.Add(this.label19);
            this.correctiveScriptsGroupBox.Controls.Add(this.chkCorrectiveScriptDisabled);
            this.correctiveScriptsGroupBox.Controls.Add(this.label7);
            this.correctiveScriptsGroupBox.Controls.Add(this.label12);
            this.correctiveScriptsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.correctiveScriptsGroupBox.Location = new System.Drawing.Point(3, 97);
            this.correctiveScriptsGroupBox.Name = "correctiveScriptsGroupBox";
            this.correctiveScriptsGroupBox.Size = new System.Drawing.Size(948, 71);
            this.correctiveScriptsGroupBox.TabIndex = 8;
            this.correctiveScriptsGroupBox.TabStop = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(270, 52);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(122, 12);
            this.label38.TabIndex = 22;
            this.label38.Text = "See Action scripts for details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(130, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "(0 means only on state change)";
            // 
            // numericUpDownRestorationScriptMinimumRepeatTimeMin
            // 
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin.Location = new System.Drawing.Point(545, 28);
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin.Name = "numericUpDownRestorationScriptMinimumRepeatTimeMin";
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownRestorationScriptMinimumRepeatTimeMin.TabIndex = 19;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(600, 30);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(24, 13);
            this.label53.TabIndex = 20;
            this.label53.Text = "Min";
            // 
            // numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin
            // 
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Location = new System.Drawing.Point(323, 28);
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Name = "numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin";
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.TabIndex = 13;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(378, 30);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(24, 13);
            this.label51.TabIndex = 14;
            this.label51.Text = "Min";
            // 
            // numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin
            // 
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Location = new System.Drawing.Point(130, 28);
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Name = "numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin";
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.TabIndex = 7;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(185, 30);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(24, 13);
            this.label48.TabIndex = 8;
            this.label48.Text = "Min";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(411, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Restoration - Only once in";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Corrective scripts";
            // 
            // chkCorrectiveScriptDisabled
            // 
            this.chkCorrectiveScriptDisabled.AutoSize = true;
            this.chkCorrectiveScriptDisabled.BackColor = System.Drawing.Color.White;
            this.chkCorrectiveScriptDisabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCorrectiveScriptDisabled.Location = new System.Drawing.Point(134, 2);
            this.chkCorrectiveScriptDisabled.Name = "chkCorrectiveScriptDisabled";
            this.chkCorrectiveScriptDisabled.Size = new System.Drawing.Size(141, 17);
            this.chkCorrectiveScriptDisabled.TabIndex = 1;
            this.chkCorrectiveScriptDisabled.Text = "Disable corrective scripts";
            this.chkCorrectiveScriptDisabled.UseVisualStyleBackColor = false;
            this.chkCorrectiveScriptDisabled.CheckedChanged += new System.EventHandler(this.chkCorrectiveScriptDisabled_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Warning - Only once in";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Error - Only once in";
            // 
            // alertSuppressionGroupBox
            // 
            this.alertSuppressionGroupBox.BackColor = System.Drawing.Color.White;
            this.alertSuppressionGroupBox.Controls.Add(this.chkAlertsPaused);
            this.alertSuppressionGroupBox.Controls.Add(this.label26);
            this.alertSuppressionGroupBox.Controls.Add(this.label25);
            this.alertSuppressionGroupBox.Controls.Add(this.label24);
            this.alertSuppressionGroupBox.Controls.Add(this.label23);
            this.alertSuppressionGroupBox.Controls.Add(this.numericUpDownRepeatAlertInXPolls);
            this.alertSuppressionGroupBox.Controls.Add(this.delayAlertPollsNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.AlertOnceInXPollsNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.label22);
            this.alertSuppressionGroupBox.Controls.Add(this.label21);
            this.alertSuppressionGroupBox.Controls.Add(this.label18);
            this.alertSuppressionGroupBox.Controls.Add(this.label6);
            this.alertSuppressionGroupBox.Controls.Add(this.numericUpDownRepeatAlertInXMin);
            this.alertSuppressionGroupBox.Controls.Add(this.delayAlertSecNumericUpDown);
            this.alertSuppressionGroupBox.Controls.Add(this.label8);
            this.alertSuppressionGroupBox.Controls.Add(this.label10);
            this.alertSuppressionGroupBox.Controls.Add(this.label9);
            this.alertSuppressionGroupBox.Controls.Add(this.label11);
            this.alertSuppressionGroupBox.Controls.Add(this.label37);
            this.alertSuppressionGroupBox.Controls.Add(this.AlertOnceInXMinNumericUpDown);
            this.alertSuppressionGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertSuppressionGroupBox.Location = new System.Drawing.Point(3, 3);
            this.alertSuppressionGroupBox.Name = "alertSuppressionGroupBox";
            this.alertSuppressionGroupBox.Size = new System.Drawing.Size(948, 94);
            this.alertSuppressionGroupBox.TabIndex = 7;
            this.alertSuppressionGroupBox.TabStop = false;
            // 
            // chkAlertsPaused
            // 
            this.chkAlertsPaused.AutoSize = true;
            this.chkAlertsPaused.BackColor = System.Drawing.Color.White;
            this.chkAlertsPaused.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAlertsPaused.Location = new System.Drawing.Point(125, -1);
            this.chkAlertsPaused.Name = "chkAlertsPaused";
            this.chkAlertsPaused.Size = new System.Drawing.Size(205, 17);
            this.chkAlertsPaused.TabIndex = 1;
            this.chkAlertsPaused.Text = "Pause/ignore all alerts for this collector";
            this.chkAlertsPaused.UseVisualStyleBackColor = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(313, 45);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(239, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Note that # of polls depends on polling frequency";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(269, 68);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 18;
            this.label25.Text = "Polls";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(269, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Polls";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(269, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 13);
            this.label23.TabIndex = 6;
            this.label23.Text = "Polls";
            // 
            // numericUpDownRepeatAlertInXPolls
            // 
            this.numericUpDownRepeatAlertInXPolls.Location = new System.Drawing.Point(214, 20);
            this.numericUpDownRepeatAlertInXPolls.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownRepeatAlertInXPolls.Name = "numericUpDownRepeatAlertInXPolls";
            this.numericUpDownRepeatAlertInXPolls.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownRepeatAlertInXPolls.TabIndex = 5;
            // 
            // delayAlertPollsNumericUpDown
            // 
            this.delayAlertPollsNumericUpDown.Location = new System.Drawing.Point(214, 66);
            this.delayAlertPollsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.delayAlertPollsNumericUpDown.Name = "delayAlertPollsNumericUpDown";
            this.delayAlertPollsNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.delayAlertPollsNumericUpDown.TabIndex = 17;
            // 
            // AlertOnceInXPollsNumericUpDown
            // 
            this.AlertOnceInXPollsNumericUpDown.Location = new System.Drawing.Point(214, 43);
            this.AlertOnceInXPollsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AlertOnceInXPollsNumericUpDown.Name = "AlertOnceInXPollsNumericUpDown";
            this.AlertOnceInXPollsNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.AlertOnceInXPollsNumericUpDown.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(313, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(224, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "(Only raise alert if Error/Warning state persists)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(313, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(232, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "(0 = never, Only applies to Errors and Warnings)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Alert suppresion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Repeat alert after";
            // 
            // numericUpDownRepeatAlertInXMin
            // 
            this.numericUpDownRepeatAlertInXMin.Location = new System.Drawing.Point(107, 20);
            this.numericUpDownRepeatAlertInXMin.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownRepeatAlertInXMin.Name = "numericUpDownRepeatAlertInXMin";
            this.numericUpDownRepeatAlertInXMin.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownRepeatAlertInXMin.TabIndex = 3;
            // 
            // delayAlertSecNumericUpDown
            // 
            this.delayAlertSecNumericUpDown.Location = new System.Drawing.Point(107, 66);
            this.delayAlertSecNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.delayAlertSecNumericUpDown.Name = "delayAlertSecNumericUpDown";
            this.delayAlertSecNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.delayAlertSecNumericUpDown.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Only alert once in";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Minutes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Delay alert";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(162, 45);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(44, 13);
            this.label37.TabIndex = 10;
            this.label37.Text = "Minutes";
            // 
            // AlertOnceInXMinNumericUpDown
            // 
            this.AlertOnceInXMinNumericUpDown.Location = new System.Drawing.Point(107, 43);
            this.AlertOnceInXMinNumericUpDown.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.AlertOnceInXMinNumericUpDown.Name = "AlertOnceInXMinNumericUpDown";
            this.AlertOnceInXMinNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.AlertOnceInXMinNumericUpDown.TabIndex = 9;
            // 
            // configVarsTabPage
            // 
            this.configVarsTabPage.Controls.Add(this.lvwConfigVars);
            this.configVarsTabPage.Controls.Add(this.txtConfigVarReplaceByValue);
            this.configVarsTabPage.Controls.Add(this.label41);
            this.configVarsTabPage.Controls.Add(this.txtConfigVarSearchFor);
            this.configVarsTabPage.Controls.Add(this.label40);
            this.configVarsTabPage.Controls.Add(this.label42);
            this.configVarsTabPage.Controls.Add(this.toolStrip1);
            this.configVarsTabPage.Location = new System.Drawing.Point(4, 22);
            this.configVarsTabPage.Name = "configVarsTabPage";
            this.configVarsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configVarsTabPage.Size = new System.Drawing.Size(954, 395);
            this.configVarsTabPage.TabIndex = 4;
            this.configVarsTabPage.Text = "Variables";
            this.configVarsTabPage.UseVisualStyleBackColor = true;
            // 
            // lvwConfigVars
            // 
            this.lvwConfigVars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConfigVars.AutoResizeColumnEnabled = false;
            this.lvwConfigVars.AutoResizeColumnIndex = 0;
            this.lvwConfigVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lvwConfigVars.FullRowSelect = true;
            this.lvwConfigVars.HideSelection = false;
            this.lvwConfigVars.Location = new System.Drawing.Point(2, 33);
            this.lvwConfigVars.Name = "lvwConfigVars";
            this.lvwConfigVars.Size = new System.Drawing.Size(949, 300);
            this.lvwConfigVars.TabIndex = 9;
            this.lvwConfigVars.UseCompatibleStateImageBehavior = false;
            this.lvwConfigVars.View = System.Windows.Forms.View.Details;
            this.lvwConfigVars.DeleteKeyPressed += new System.Windows.Forms.MethodInvoker(this.lvwConfigVars_DeleteKeyPressed);
            this.lvwConfigVars.SelectedIndexChanged += new System.EventHandler(this.lvwConfigVars_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Search for";
            this.columnHeader5.Width = 244;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Replace by";
            this.columnHeader6.Width = 262;
            // 
            // txtConfigVarReplaceByValue
            // 
            this.txtConfigVarReplaceByValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarReplaceByValue.Location = new System.Drawing.Point(337, 339);
            this.txtConfigVarReplaceByValue.Name = "txtConfigVarReplaceByValue";
            this.txtConfigVarReplaceByValue.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarReplaceByValue.TabIndex = 13;
            this.txtConfigVarReplaceByValue.TextChanged += new System.EventHandler(this.txtConfigVarReplaceByValue_TextChanged);
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(262, 342);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(69, 13);
            this.label41.TabIndex = 12;
            this.label41.Text = "Replace with";
            // 
            // txtConfigVarSearchFor
            // 
            this.txtConfigVarSearchFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtConfigVarSearchFor.Location = new System.Drawing.Point(83, 339);
            this.txtConfigVarSearchFor.Name = "txtConfigVarSearchFor";
            this.txtConfigVarSearchFor.Size = new System.Drawing.Size(173, 20);
            this.txtConfigVarSearchFor.TabIndex = 11;
            this.txtConfigVarSearchFor.TextChanged += new System.EventHandler(this.txtConfigVarSearchFor_TextChanged);
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 342);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(56, 13);
            this.label40.TabIndex = 10;
            this.label40.Text = "Search for";
            // 
            // label42
            // 
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(3, 364);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(948, 28);
            this.label42.TabIndex = 8;
            this.label42.Text = "Suggestions: Use \'variable\' names that are unique in the config XML. e.g. %SomeVa" +
    "lue%. Be careful when using quotes/doublequotes or any other characters that are" +
    " \'special\' in XML.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigVarToolStripButton,
            this.deleteConfigVarToolStripButton,
            this.toolStripSeparator1,
            this.moveUpConfigVarToolStripButton,
            this.moveDownConfigVarToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(948, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addConfigVarToolStripButton
            // 
            this.addConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConfigVarToolStripButton.Name = "addConfigVarToolStripButton";
            this.addConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addConfigVarToolStripButton.Text = "Create new";
            this.addConfigVarToolStripButton.ToolTipText = "Add entry";
            this.addConfigVarToolStripButton.Click += new System.EventHandler(this.addConfigVarToolStripButton_Click);
            // 
            // deleteConfigVarToolStripButton
            // 
            this.deleteConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteConfigVarToolStripButton.Enabled = false;
            this.deleteConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.stop16x16;
            this.deleteConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteConfigVarToolStripButton.Name = "deleteConfigVarToolStripButton";
            this.deleteConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteConfigVarToolStripButton.Text = "Delete selected item(s)";
            this.deleteConfigVarToolStripButton.Click += new System.EventHandler(this.deleteConfigVarToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // moveUpConfigVarToolStripButton
            // 
            this.moveUpConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveUpConfigVarToolStripButton.Enabled = false;
            this.moveUpConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Up16x16;
            this.moveUpConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveUpConfigVarToolStripButton.Name = "moveUpConfigVarToolStripButton";
            this.moveUpConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveUpConfigVarToolStripButton.Text = "Move selected item up";
            this.moveUpConfigVarToolStripButton.Click += new System.EventHandler(this.moveUpConfigVarToolStripButton_Click);
            // 
            // moveDownConfigVarToolStripButton
            // 
            this.moveDownConfigVarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveDownConfigVarToolStripButton.Enabled = false;
            this.moveDownConfigVarToolStripButton.Image = global::QuickMon.Properties.Resources.Down16x16;
            this.moveDownConfigVarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveDownConfigVarToolStripButton.Name = "moveDownConfigVarToolStripButton";
            this.moveDownConfigVarToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.moveDownConfigVarToolStripButton.Text = "Move selected item down";
            this.moveDownConfigVarToolStripButton.Click += new System.EventHandler(this.moveDownConfigVarToolStripButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwActionScriptsEdit);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(954, 395);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Action scripts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwActionScriptsEdit
            // 
            this.lvwActionScriptsEdit.AutoResizeColumnEnabled = false;
            this.lvwActionScriptsEdit.AutoResizeColumnIndex = 6;
            this.lvwActionScriptsEdit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.actionScriptNameColumnHeader,
            this.typeColumnHeader,
            this.adminColumnHeader,
            this.restorationColumnHeader,
            this.warningColumnHeader,
            this.errorColumnHeader,
            this.descriptiomColumnHeader});
            this.lvwActionScriptsEdit.ContextMenuStrip = this.actionScriptsContextMenuStrip;
            this.lvwActionScriptsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwActionScriptsEdit.FullRowSelect = true;
            this.lvwActionScriptsEdit.HideSelection = false;
            this.lvwActionScriptsEdit.Location = new System.Drawing.Point(3, 30);
            this.lvwActionScriptsEdit.Name = "lvwActionScriptsEdit";
            this.lvwActionScriptsEdit.Size = new System.Drawing.Size(948, 362);
            this.lvwActionScriptsEdit.TabIndex = 3;
            this.lvwActionScriptsEdit.UseCompatibleStateImageBehavior = false;
            this.lvwActionScriptsEdit.View = System.Windows.Forms.View.Details;
            this.lvwActionScriptsEdit.SelectedIndexChanged += new System.EventHandler(this.lvwActionScriptsEdit_SelectedIndexChanged);
            this.lvwActionScriptsEdit.DoubleClick += new System.EventHandler(this.lvwActionScriptsEdit_DoubleClick);
            // 
            // actionScriptNameColumnHeader
            // 
            this.actionScriptNameColumnHeader.Text = "Name";
            this.actionScriptNameColumnHeader.Width = 203;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 88;
            // 
            // adminColumnHeader
            // 
            this.adminColumnHeader.Text = "Admin";
            // 
            // restorationColumnHeader
            // 
            this.restorationColumnHeader.Text = "Restore";
            this.restorationColumnHeader.Width = 52;
            // 
            // warningColumnHeader
            // 
            this.warningColumnHeader.Text = "Warning";
            this.warningColumnHeader.Width = 57;
            // 
            // errorColumnHeader
            // 
            this.errorColumnHeader.Text = "Error";
            this.errorColumnHeader.Width = 49;
            // 
            // descriptiomColumnHeader
            // 
            this.descriptiomColumnHeader.Text = "Description";
            this.descriptiomColumnHeader.Width = 384;
            // 
            // actionScriptsContextMenuStrip
            // 
            this.actionScriptsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runActionScriptToolStripMenuItem,
            this.runActionScriptWithPauseToolStripMenuItem});
            this.actionScriptsContextMenuStrip.Name = "actionScriptsContextMenuStrip";
            this.actionScriptsContextMenuStrip.Size = new System.Drawing.Size(229, 48);
            this.actionScriptsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.actionScriptsContextMenuStrip_Opening);
            // 
            // runActionScriptToolStripMenuItem
            // 
            this.runActionScriptToolStripMenuItem.Image = global::QuickMon.Properties.Resources.rungreen24x24;
            this.runActionScriptToolStripMenuItem.Name = "runActionScriptToolStripMenuItem";
            this.runActionScriptToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.runActionScriptToolStripMenuItem.Text = "Run Action Script";
            this.runActionScriptToolStripMenuItem.Click += new System.EventHandler(this.runActionScriptToolStripMenuItem_Click);
            // 
            // runActionScriptWithPauseToolStripMenuItem
            // 
            this.runActionScriptWithPauseToolStripMenuItem.Image = global::QuickMon.Properties.Resources.rungreen24x24;
            this.runActionScriptWithPauseToolStripMenuItem.Name = "runActionScriptWithPauseToolStripMenuItem";
            this.runActionScriptWithPauseToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.runActionScriptWithPauseToolStripMenuItem.Text = "Run Action Script With Pause";
            this.runActionScriptWithPauseToolStripMenuItem.Click += new System.EventHandler(this.runActionScriptWithPauseToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addActionScriptToolStripButton,
            this.editActionScriptToolStripButton,
            this.deleteActionScriptToolStripButton,
            this.toolStripSeparator4,
            this.runToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(948, 27);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.TabStop = true;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // addActionScriptToolStripButton
            // 
            this.addActionScriptToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addActionScriptToolStripButton.Image = global::QuickMon.Properties.Resources.Plus16x16;
            this.addActionScriptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addActionScriptToolStripButton.Name = "addActionScriptToolStripButton";
            this.addActionScriptToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.addActionScriptToolStripButton.Text = "Create new";
            this.addActionScriptToolStripButton.ToolTipText = "Add Action Script";
            this.addActionScriptToolStripButton.Click += new System.EventHandler(this.addActionScriptToolStripButton_Click);
            // 
            // editActionScriptToolStripButton
            // 
            this.editActionScriptToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editActionScriptToolStripButton.Enabled = false;
            this.editActionScriptToolStripButton.Image = global::QuickMon.Properties.Resources.proc2;
            this.editActionScriptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editActionScriptToolStripButton.Name = "editActionScriptToolStripButton";
            this.editActionScriptToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.editActionScriptToolStripButton.Text = "toolStripButton1";
            this.editActionScriptToolStripButton.ToolTipText = "Edit Action Script";
            this.editActionScriptToolStripButton.Click += new System.EventHandler(this.editActionScriptToolStripButton_Click);
            // 
            // deleteActionScriptToolStripButton
            // 
            this.deleteActionScriptToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteActionScriptToolStripButton.Enabled = false;
            this.deleteActionScriptToolStripButton.Image = global::QuickMon.Properties.Resources.stop24x24;
            this.deleteActionScriptToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteActionScriptToolStripButton.Name = "deleteActionScriptToolStripButton";
            this.deleteActionScriptToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.deleteActionScriptToolStripButton.Text = "Delete selected item(s)";
            this.deleteActionScriptToolStripButton.Click += new System.EventHandler(this.deleteActionScriptToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // runToolStripButton
            // 
            this.runToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runToolStripButton.Enabled = false;
            this.runToolStripButton.Image = global::QuickMon.Properties.Resources.rungreen24x24;
            this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runToolStripButton.Name = "runToolStripButton";
            this.runToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.runToolStripButton.Text = "Run script";
            this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
            // 
            // llblRawEdit
            // 
            this.llblRawEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llblRawEdit.AutoSize = true;
            this.llblRawEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llblRawEdit.Location = new System.Drawing.Point(10, 12);
            this.llblRawEdit.Name = "llblRawEdit";
            this.llblRawEdit.Size = new System.Drawing.Size(86, 13);
            this.llblRawEdit.TabIndex = 7;
            this.llblRawEdit.TabStop = true;
            this.llblRawEdit.Text = "Edit RAW config";
            this.llblRawEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRawEdit_LinkClicked);
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.BackColor = System.Drawing.Color.Transparent;
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(800, 7);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "Save";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.BackColor = System.Drawing.Color.Transparent;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(881, 7);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panelMetrics
            // 
            this.panelMetrics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMetrics.Controls.Add(this.lvwMetrics);
            this.panelMetrics.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMetrics.Location = new System.Drawing.Point(0, 276);
            this.panelMetrics.Name = "panelMetrics";
            this.panelMetrics.Size = new System.Drawing.Size(964, 125);
            this.panelMetrics.TabIndex = 2;
            // 
            // lvwMetrics
            // 
            this.lvwMetrics.AutoResizeColumnEnabled = false;
            this.lvwMetrics.AutoResizeColumnIndex = 1;
            this.lvwMetrics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwMetrics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMetrics.FullRowSelect = true;
            this.lvwMetrics.HideSelection = false;
            this.lvwMetrics.Location = new System.Drawing.Point(0, 0);
            this.lvwMetrics.Name = "lvwMetrics";
            this.lvwMetrics.Size = new System.Drawing.Size(962, 123);
            this.lvwMetrics.TabIndex = 0;
            this.lvwMetrics.UseCompatibleStateImageBehavior = false;
            this.lvwMetrics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Property";
            this.columnHeader1.Width = 211;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 198;
            // 
            // panelAgentStates
            // 
            this.panelAgentStates.Controls.Add(this.agentStateSplitContainer);
            this.panelAgentStates.Controls.Add(this.panel3);
            this.panelAgentStates.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAgentStates.Location = new System.Drawing.Point(0, 0);
            this.panelAgentStates.Name = "panelAgentStates";
            this.panelAgentStates.Size = new System.Drawing.Size(964, 276);
            this.panelAgentStates.TabIndex = 1;
            // 
            // agentStateSplitContainer
            // 
            this.agentStateSplitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.agentStateSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.agentStateSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.agentStateSplitContainer.Name = "agentStateSplitContainer";
            this.agentStateSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // agentStateSplitContainer.Panel1
            // 
            this.agentStateSplitContainer.Panel1.Controls.Add(this.tlvAgentStates);
            // 
            // agentStateSplitContainer.Panel2
            // 
            this.agentStateSplitContainer.Panel2.Controls.Add(this.collectorTimeGraph);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.lvwHistory);
            this.agentStateSplitContainer.Panel2.Controls.Add(this.label3);
            this.agentStateSplitContainer.Size = new System.Drawing.Size(964, 248);
            this.agentStateSplitContainer.SplitterDistance = 96;
            this.agentStateSplitContainer.SplitterWidth = 7;
            this.agentStateSplitContainer.TabIndex = 3;
            // 
            // tlvAgentStates
            // 
            this.tlvAgentStates.AllowSorting = false;
            this.tlvAgentStates.AutoResizeColumnEnabled = false;
            this.tlvAgentStates.AutoResizeColumnIndex = 0;
            this.tlvAgentStates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlvAgentStates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this.tlvAgentStates.Comparer = treeListViewItemCollectionComparer2;
            this.tlvAgentStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlvAgentStates.HideSelection = false;
            this.tlvAgentStates.Location = new System.Drawing.Point(0, 0);
            this.tlvAgentStates.MultiSelect = false;
            this.tlvAgentStates.Name = "tlvAgentStates";
            this.tlvAgentStates.Size = new System.Drawing.Size(964, 96);
            this.tlvAgentStates.SmallImageList = this.imagesCollectorTree;
            this.tlvAgentStates.Sorting = System.Windows.Forms.SortOrder.None;
            this.tlvAgentStates.TabIndex = 1;
            this.tlvAgentStates.UseCompatibleStateImageBehavior = false;
            this.tlvAgentStates.SelectedIndexChanged += new System.EventHandler(this.tlvAgentStates_SelectedIndexChanged);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 325;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 150;
            // 
            // imagesCollectorTree
            // 
            this.imagesCollectorTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesCollectorTree.ImageStream")));
            this.imagesCollectorTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesCollectorTree.Images.SetKeyName(0, "open_folder_blue24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(1, "helpbwy24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(2, "ok.png");
            this.imagesCollectorTree.Images.SetKeyName(3, "triang_yellow.png");
            this.imagesCollectorTree.Images.SetKeyName(4, "triang_red24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(5, "ok3.png");
            this.imagesCollectorTree.Images.SetKeyName(6, "triang_yellow2.png");
            this.imagesCollectorTree.Images.SetKeyName(7, "triang_red24x24faded.png");
            this.imagesCollectorTree.Images.SetKeyName(8, "ForbiddenBW16x16.png");
            this.imagesCollectorTree.Images.SetKeyName(9, "clock1.png");
            this.imagesCollectorTree.Images.SetKeyName(10, "Error24x24.png");
            this.imagesCollectorTree.Images.SetKeyName(11, "Error2_24x24.png");
            // 
            // collectorTimeGraph
            // 
            this.collectorTimeGraph.AxisLabelColor = System.Drawing.Color.Black;
            this.collectorTimeGraph.BackColor = System.Drawing.Color.Black;
            this.collectorTimeGraph.BackgroundColor = System.Drawing.Color.White;
            this.collectorTimeGraph.BackgroundGradientColor1 = System.Drawing.Color.White;
            this.collectorTimeGraph.BackgroundGradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.collectorTimeGraph.BackgroundIsGradient = true;
            this.collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.SeriesColor;
            this.collectorTimeGraph.ClosestClickedValueCustomColor = System.Drawing.Color.White;
            this.collectorTimeGraph.ContextMenuStrip = this.graphContextMenuStrip;
            this.collectorTimeGraph.EndDateTime = new System.DateTime(((long)(0)));
            this.collectorTimeGraph.FillAreaBelowGraph = true;
            this.collectorTimeGraph.FillAreaBelowGraphAlpha = 48;
            this.collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.collectorTimeGraph.GraphHeaderFont = new System.Drawing.Font("Verdana", 12F);
            this.collectorTimeGraph.GraphHeaderText = "";
            this.collectorTimeGraph.GraphLineFormatType = HenIT.Windows.Controls.Graphing.GraphLineFormatType.Straight;
            this.collectorTimeGraph.GraphTextFont = new System.Drawing.Font("Verdana", 8F);
            this.collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            this.collectorTimeGraph.GridColor = System.Drawing.Color.Silver;
            this.collectorTimeGraph.HighlightClickedSeries = true;
            this.collectorTimeGraph.HighlightSeriesWidth = 3;
            this.collectorTimeGraph.InitialMaxGraphValue = ((long)(100));
            this.collectorTimeGraph.LastClickedLocation = null;
            this.collectorTimeGraph.LastClickedTimeSelected = false;
            this.collectorTimeGraph.LastClickedValue = -1D;
            this.collectorTimeGraph.LeftAxisMargin = 25;
            this.collectorTimeGraph.Location = new System.Drawing.Point(516, 13);
            this.collectorTimeGraph.MaxGraphValue = ((long)(1));
            this.collectorTimeGraph.Name = "collectorTimeGraph";
            this.collectorTimeGraph.NoHighlightSeriesWidth = 2;
            this.collectorTimeGraph.RightAxisMargin = 25;
            this.collectorTimeGraph.Series = null;
            this.collectorTimeGraph.ShowClickScanSearchBlock = false;
            this.collectorTimeGraph.ShowClosestClickedValue = true;
            this.collectorTimeGraph.ShowGraphHeader = false;
            this.collectorTimeGraph.ShowHorisontalGridlines = true;
            this.collectorTimeGraph.ShowLastClickedLocation = false;
            this.collectorTimeGraph.ShowLegendText = true;
            this.collectorTimeGraph.ShowSelectionBar = true;
            this.collectorTimeGraph.ShowVerticalGridLines = true;
            this.collectorTimeGraph.Size = new System.Drawing.Size(324, 85);
            this.collectorTimeGraph.StartDateTime = new System.DateTime(((long)(0)));
            this.collectorTimeGraph.TabIndex = 2;
            this.collectorTimeGraph.Text = "timeGraphControl1";
            this.collectorTimeGraph.TimeSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.collectorTimeGraph.ClosestPointSelectedChanged += new HenIT.Windows.Controls.Graphing.TimeValueDelegate(this.collectorTimeGraph_ClosestPointSelectedChanged);
            this.collectorTimeGraph.GraphClicked += new System.EventHandler(this.collectorTimeGraph_GraphClicked);
            // 
            // graphContextMenuStrip
            // 
            this.graphContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.graphTypeToolStripMenuItem,
            this.grapthColorsToolStripMenuItem,
            this.graphVisibilityToolStripMenuItem,
            this.exportGraphToolStripMenuItem});
            this.graphContextMenuStrip.Name = "graphContextMenuStrip";
            this.graphContextMenuStrip.Size = new System.Drawing.Size(144, 114);
            this.graphContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.graphContextMenuStrip_Opening);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Image = global::QuickMon.Properties.Resources.tools16x16;
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.customizeToolStripMenuItem.Text = "Customize";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // graphTypeToolStripMenuItem
            // 
            this.graphTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearGraphTypeToolStripMenuItem,
            this.logarithmicGraphTypeToolStripMenuItem});
            this.graphTypeToolStripMenuItem.Name = "graphTypeToolStripMenuItem";
            this.graphTypeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.graphTypeToolStripMenuItem.Text = "Graph Type";
            // 
            // linearGraphTypeToolStripMenuItem
            // 
            this.linearGraphTypeToolStripMenuItem.CheckOnClick = true;
            this.linearGraphTypeToolStripMenuItem.Name = "linearGraphTypeToolStripMenuItem";
            this.linearGraphTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.linearGraphTypeToolStripMenuItem.Text = "Linear Graph Type";
            this.linearGraphTypeToolStripMenuItem.Click += new System.EventHandler(this.linearGraphTypeToolStripMenuItem_Click);
            // 
            // logarithmicGraphTypeToolStripMenuItem
            // 
            this.logarithmicGraphTypeToolStripMenuItem.CheckOnClick = true;
            this.logarithmicGraphTypeToolStripMenuItem.Name = "logarithmicGraphTypeToolStripMenuItem";
            this.logarithmicGraphTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.logarithmicGraphTypeToolStripMenuItem.Text = "Logarithmic Graph Type";
            this.logarithmicGraphTypeToolStripMenuItem.Click += new System.EventHandler(this.logarithmicGraphTypeToolStripMenuItem_Click);
            // 
            // grapthColorsToolStripMenuItem
            // 
            this.grapthColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphBackgroundColorsToolStripMenuItem,
            this.graphGridColorToolStripMenuItem,
            this.graphAxisLabelColorsToolStripMenuItem,
            this.graphSelectionColorToolStripMenuItem});
            this.grapthColorsToolStripMenuItem.Name = "grapthColorsToolStripMenuItem";
            this.grapthColorsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.grapthColorsToolStripMenuItem.Text = "Graph Colors";
            // 
            // graphBackgroundColorsToolStripMenuItem
            // 
            this.graphBackgroundColorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphGradientColor1ToolStripMenuItem,
            this.graphGradientColor2ToolStripMenuItem,
            this.swapGraphGradientColorsToolStripMenuItem,
            this.graphGradientDirectionToolStripMenuItem});
            this.graphBackgroundColorsToolStripMenuItem.Name = "graphBackgroundColorsToolStripMenuItem";
            this.graphBackgroundColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphBackgroundColorsToolStripMenuItem.Text = "Background Colors";
            // 
            // graphGradientColor1ToolStripMenuItem
            // 
            this.graphGradientColor1ToolStripMenuItem.Name = "graphGradientColor1ToolStripMenuItem";
            this.graphGradientColor1ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientColor1ToolStripMenuItem.Text = "Graph Gradient Color 1";
            this.graphGradientColor1ToolStripMenuItem.Click += new System.EventHandler(this.graphGradientColor1ToolStripMenuItem_Click);
            // 
            // graphGradientColor2ToolStripMenuItem
            // 
            this.graphGradientColor2ToolStripMenuItem.Name = "graphGradientColor2ToolStripMenuItem";
            this.graphGradientColor2ToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientColor2ToolStripMenuItem.Text = "Graph Gradient Color 2";
            this.graphGradientColor2ToolStripMenuItem.Click += new System.EventHandler(this.graphGradientColor2ToolStripMenuItem_Click);
            // 
            // swapGraphGradientColorsToolStripMenuItem
            // 
            this.swapGraphGradientColorsToolStripMenuItem.Name = "swapGraphGradientColorsToolStripMenuItem";
            this.swapGraphGradientColorsToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.swapGraphGradientColorsToolStripMenuItem.Text = "Swap Graph Gradient Colors";
            this.swapGraphGradientColorsToolStripMenuItem.Click += new System.EventHandler(this.swapGraphGradientColorsToolStripMenuItem_Click);
            // 
            // graphGradientDirectionToolStripMenuItem
            // 
            this.graphGradientDirectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphGradientDirectionHorizontalToolStripMenuItem,
            this.graphGradientDirectionVerticalToolStripMenuItem,
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem,
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem});
            this.graphGradientDirectionToolStripMenuItem.Name = "graphGradientDirectionToolStripMenuItem";
            this.graphGradientDirectionToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.graphGradientDirectionToolStripMenuItem.Text = "Graph Gradient Direction";
            // 
            // graphGradientDirectionHorizontalToolStripMenuItem
            // 
            this.graphGradientDirectionHorizontalToolStripMenuItem.Name = "graphGradientDirectionHorizontalToolStripMenuItem";
            this.graphGradientDirectionHorizontalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionHorizontalToolStripMenuItem.Text = "Graph Gradient Direction Horizontal";
            this.graphGradientDirectionHorizontalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionHorizontalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionVerticalToolStripMenuItem
            // 
            this.graphGradientDirectionVerticalToolStripMenuItem.Name = "graphGradientDirectionVerticalToolStripMenuItem";
            this.graphGradientDirectionVerticalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionVerticalToolStripMenuItem.Text = "Graph Gradient Direction Vertical";
            this.graphGradientDirectionVerticalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionVerticalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionForwardDiagonalToolStripMenuItem
            // 
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Name = "graphGradientDirectionForwardDiagonalToolStripMenuItem";
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Text = "Graph Gradient Direction Forward Diagonal";
            this.graphGradientDirectionForwardDiagonalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionForwardDiagonalToolStripMenuItem_Click);
            // 
            // graphGradientDirectionBackwardDiagonalToolStripMenuItem
            // 
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Name = "graphGradientDirectionBackwardDiagonalToolStripMenuItem";
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Text = "Graph Gradient Direction Backward Diagonal";
            this.graphGradientDirectionBackwardDiagonalToolStripMenuItem.Click += new System.EventHandler(this.graphGradientDirectionBackwardDiagonalToolStripMenuItem_Click);
            // 
            // graphGridColorToolStripMenuItem
            // 
            this.graphGridColorToolStripMenuItem.Name = "graphGridColorToolStripMenuItem";
            this.graphGridColorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphGridColorToolStripMenuItem.Text = "Grid Color";
            this.graphGridColorToolStripMenuItem.Click += new System.EventHandler(this.graphGridColorToolStripMenuItem_Click);
            // 
            // graphAxisLabelColorsToolStripMenuItem
            // 
            this.graphAxisLabelColorsToolStripMenuItem.Name = "graphAxisLabelColorsToolStripMenuItem";
            this.graphAxisLabelColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphAxisLabelColorsToolStripMenuItem.Text = "Axis Label Colors";
            this.graphAxisLabelColorsToolStripMenuItem.Click += new System.EventHandler(this.graphAxisLabelColorsToolStripMenuItem_Click);
            // 
            // graphSelectionColorToolStripMenuItem
            // 
            this.graphSelectionColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphSelectionBarColorToolStripMenuItem,
            this.graphClosestClickedValueColorToolStripMenuItem});
            this.graphSelectionColorToolStripMenuItem.Name = "graphSelectionColorToolStripMenuItem";
            this.graphSelectionColorToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.graphSelectionColorToolStripMenuItem.Text = "Selection Colors";
            // 
            // graphSelectionBarColorToolStripMenuItem
            // 
            this.graphSelectionBarColorToolStripMenuItem.Name = "graphSelectionBarColorToolStripMenuItem";
            this.graphSelectionBarColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphSelectionBarColorToolStripMenuItem.Text = "Selection Bar Color";
            this.graphSelectionBarColorToolStripMenuItem.Click += new System.EventHandler(this.graphSelectionBarColorToolStripMenuItem_Click);
            // 
            // graphClosestClickedValueColorToolStripMenuItem
            // 
            this.graphClosestClickedValueColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem,
            this.graphClosestClickedColorInvertedColorToolStripMenuItem,
            this.graphClosestClickedColorCustomColorToolStripMenuItem});
            this.graphClosestClickedValueColorToolStripMenuItem.Name = "graphClosestClickedValueColorToolStripMenuItem";
            this.graphClosestClickedValueColorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphClosestClickedValueColorToolStripMenuItem.Text = "Closest Clicked Value Color";
            // 
            // graphClosestClickedColorSameAsSeriesToolStripMenuItem
            // 
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Name = "graphClosestClickedColorSameAsSeriesToolStripMenuItem";
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Text = "Same as Series";
            this.graphClosestClickedColorSameAsSeriesToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorSameAsSeriesToolStripMenuItem_Click);
            // 
            // graphClosestClickedColorInvertedColorToolStripMenuItem
            // 
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Name = "graphClosestClickedColorInvertedColorToolStripMenuItem";
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Text = "Inverted Color";
            this.graphClosestClickedColorInvertedColorToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorInvertedColorToolStripMenuItem_Click);
            // 
            // graphClosestClickedColorCustomColorToolStripMenuItem
            // 
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Name = "graphClosestClickedColorCustomColorToolStripMenuItem";
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Text = "Custom Color";
            this.graphClosestClickedColorCustomColorToolStripMenuItem.Click += new System.EventHandler(this.graphClosestClickedColorCustomColorToolStripMenuItem_Click);
            // 
            // graphVisibilityToolStripMenuItem
            // 
            this.graphVisibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphHeaderVisibleToolStripMenuItem,
            this.legendVisibleToolStripMenuItem,
            this.graphHorisonalGridLinesVisibleToolStripMenuItem,
            this.graphVerticalGridLinesVisibleToolStripMenuItem,
            this.graphSelectionbarVisibleToolStripMenuItem,
            this.graphHighlightClickedSeriesToolStripMenuItem,
            this.graphFillAreaBelowSeriesToolStripMenuItem});
            this.graphVisibilityToolStripMenuItem.Name = "graphVisibilityToolStripMenuItem";
            this.graphVisibilityToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.graphVisibilityToolStripMenuItem.Text = "Visibility";
            // 
            // graphHeaderVisibleToolStripMenuItem
            // 
            this.graphHeaderVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphHeaderVisibleToolStripMenuItem.Name = "graphHeaderVisibleToolStripMenuItem";
            this.graphHeaderVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHeaderVisibleToolStripMenuItem.Text = "Header Visible";
            this.graphHeaderVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphHeaderVisibleToolStripMenuItem_Click);
            // 
            // legendVisibleToolStripMenuItem
            // 
            this.legendVisibleToolStripMenuItem.CheckOnClick = true;
            this.legendVisibleToolStripMenuItem.Name = "legendVisibleToolStripMenuItem";
            this.legendVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.legendVisibleToolStripMenuItem.Text = "Legend Visible";
            this.legendVisibleToolStripMenuItem.Click += new System.EventHandler(this.legendVisibleToolStripMenuItem_Click);
            // 
            // graphHorisonalGridLinesVisibleToolStripMenuItem
            // 
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Name = "graphHorisonalGridLinesVisibleToolStripMenuItem";
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Text = "Horisonal Grid Lines Visible";
            this.graphHorisonalGridLinesVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphHorisonalGridLinesVisibleToolStripMenuItem_Click);
            // 
            // graphVerticalGridLinesVisibleToolStripMenuItem
            // 
            this.graphVerticalGridLinesVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Name = "graphVerticalGridLinesVisibleToolStripMenuItem";
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Text = "Vertical Grid Lines Visible";
            this.graphVerticalGridLinesVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphVerticalGridLinesVisibleToolStripMenuItem_Click);
            // 
            // graphSelectionbarVisibleToolStripMenuItem
            // 
            this.graphSelectionbarVisibleToolStripMenuItem.CheckOnClick = true;
            this.graphSelectionbarVisibleToolStripMenuItem.Name = "graphSelectionbarVisibleToolStripMenuItem";
            this.graphSelectionbarVisibleToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphSelectionbarVisibleToolStripMenuItem.Text = "Selectionbar Visible";
            this.graphSelectionbarVisibleToolStripMenuItem.Click += new System.EventHandler(this.graphSelectionbarVisibleToolStripMenuItem_Click);
            // 
            // graphHighlightClickedSeriesToolStripMenuItem
            // 
            this.graphHighlightClickedSeriesToolStripMenuItem.CheckOnClick = true;
            this.graphHighlightClickedSeriesToolStripMenuItem.Name = "graphHighlightClickedSeriesToolStripMenuItem";
            this.graphHighlightClickedSeriesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphHighlightClickedSeriesToolStripMenuItem.Text = "Highlight Clicked Series";
            this.graphHighlightClickedSeriesToolStripMenuItem.Click += new System.EventHandler(this.graphHighlightClickedSeriesToolStripMenuItem_Click);
            // 
            // graphFillAreaBelowSeriesToolStripMenuItem
            // 
            this.graphFillAreaBelowSeriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem,
            this.graphFillAreaAlpha16ToolStripMenuItem,
            this.graphFillAreaAlpha32ToolStripMenuItem,
            this.graphFillAreaAlpha48ToolStripMenuItem,
            this.graphFillAreaAlpha64ToolStripMenuItem,
            this.graphFillAreaAlpha128ToolStripMenuItem,
            this.graphFillAreaAlpha192ToolStripMenuItem});
            this.graphFillAreaBelowSeriesToolStripMenuItem.Name = "graphFillAreaBelowSeriesToolStripMenuItem";
            this.graphFillAreaBelowSeriesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.graphFillAreaBelowSeriesToolStripMenuItem.Text = "Fill Area Below Series";
            // 
            // graphFillAreaBelowSeriesEnabledToolStripMenuItem
            // 
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.CheckOnClick = true;
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Name = "graphFillAreaBelowSeriesEnabledToolStripMenuItem";
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Text = "Graph Fill Area Below Series Enabled";
            this.graphFillAreaBelowSeriesEnabledToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaBelowSeriesEnabledToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha16ToolStripMenuItem
            // 
            this.graphFillAreaAlpha16ToolStripMenuItem.Name = "graphFillAreaAlpha16ToolStripMenuItem";
            this.graphFillAreaAlpha16ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha16ToolStripMenuItem.Text = "Graph Fill Area Alpha 16";
            this.graphFillAreaAlpha16ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha16ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha32ToolStripMenuItem
            // 
            this.graphFillAreaAlpha32ToolStripMenuItem.Name = "graphFillAreaAlpha32ToolStripMenuItem";
            this.graphFillAreaAlpha32ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha32ToolStripMenuItem.Text = "Graph Fill Area Alpha 32";
            this.graphFillAreaAlpha32ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha32ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha48ToolStripMenuItem
            // 
            this.graphFillAreaAlpha48ToolStripMenuItem.Name = "graphFillAreaAlpha48ToolStripMenuItem";
            this.graphFillAreaAlpha48ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha48ToolStripMenuItem.Text = "Graph Fill Area Alpha 48";
            this.graphFillAreaAlpha48ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha48ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha64ToolStripMenuItem
            // 
            this.graphFillAreaAlpha64ToolStripMenuItem.Name = "graphFillAreaAlpha64ToolStripMenuItem";
            this.graphFillAreaAlpha64ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha64ToolStripMenuItem.Text = "Graph Fill Area Alpha 64";
            this.graphFillAreaAlpha64ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha64ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha128ToolStripMenuItem
            // 
            this.graphFillAreaAlpha128ToolStripMenuItem.Name = "graphFillAreaAlpha128ToolStripMenuItem";
            this.graphFillAreaAlpha128ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha128ToolStripMenuItem.Text = "Graph Fill Area Alpha 128";
            this.graphFillAreaAlpha128ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha128ToolStripMenuItem_Click);
            // 
            // graphFillAreaAlpha192ToolStripMenuItem
            // 
            this.graphFillAreaAlpha192ToolStripMenuItem.Name = "graphFillAreaAlpha192ToolStripMenuItem";
            this.graphFillAreaAlpha192ToolStripMenuItem.Size = new System.Drawing.Size(264, 22);
            this.graphFillAreaAlpha192ToolStripMenuItem.Text = "Graph Fill Area Alpha 192";
            this.graphFillAreaAlpha192ToolStripMenuItem.Click += new System.EventHandler(this.graphFillAreaAlpha192ToolStripMenuItem_Click);
            // 
            // exportGraphToolStripMenuItem
            // 
            this.exportGraphToolStripMenuItem.Image = global::QuickMon.Properties.Resources.doc_export;
            this.exportGraphToolStripMenuItem.Name = "exportGraphToolStripMenuItem";
            this.exportGraphToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportGraphToolStripMenuItem.Text = "Export Graph";
            this.exportGraphToolStripMenuItem.Click += new System.EventHandler(this.exportGraphToolStripMenuItem_Click);
            // 
            // lvwHistory
            // 
            this.lvwHistory.AutoResizeColumnEnabled = false;
            this.lvwHistory.AutoResizeColumnIndex = 1;
            this.lvwHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.timeColumnHeader,
            this.collectorValueColumnHeader,
            this.durationColumnHeader,
            this.alertCountColumnHeader});
            this.lvwHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwHistory.FullRowSelect = true;
            this.lvwHistory.HideSelection = false;
            this.lvwHistory.Location = new System.Drawing.Point(0, 1);
            this.lvwHistory.Name = "lvwHistory";
            this.lvwHistory.Size = new System.Drawing.Size(964, 144);
            this.lvwHistory.SmallImageList = this.imagesCollectorTree;
            this.lvwHistory.TabIndex = 0;
            this.lvwHistory.UseCompatibleStateImageBehavior = false;
            this.lvwHistory.View = System.Windows.Forms.View.Details;
            this.lvwHistory.SelectedIndexChanged += new System.EventHandler(this.lvwHistory_SelectedIndexChanged);
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 153;
            // 
            // collectorValueColumnHeader
            // 
            this.collectorValueColumnHeader.Text = "Value";
            this.collectorValueColumnHeader.Width = 150;
            // 
            // durationColumnHeader
            // 
            this.durationColumnHeader.Text = "Duration (ms)";
            this.durationColumnHeader.Width = 87;
            // 
            // alertCountColumnHeader
            // 
            this.alertCountColumnHeader.Text = "Alerts";
            this.alertCountColumnHeader.Width = 48;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(964, 1);
            this.label3.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.optGraphView);
            this.panel3.Controls.Add(this.chkRAWDetails);
            this.panel3.Controls.Add(this.optHistoricStateView);
            this.panel3.Controls.Add(this.optCurrentStateView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 28);
            this.panel3.TabIndex = 2;
            // 
            // optGraphView
            // 
            this.optGraphView.AutoSize = true;
            this.optGraphView.ContextMenuStrip = this.exportHistoryContextMenuStrip;
            this.optGraphView.Dock = System.Windows.Forms.DockStyle.Left;
            this.optGraphView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optGraphView.Location = new System.Drawing.Point(114, 0);
            this.optGraphView.Name = "optGraphView";
            this.optGraphView.Size = new System.Drawing.Size(53, 28);
            this.optGraphView.TabIndex = 4;
            this.optGraphView.Text = "Graph";
            this.optGraphView.UseVisualStyleBackColor = true;
            this.optGraphView.CheckedChanged += new System.EventHandler(this.optGraphView_CheckedChanged);
            // 
            // exportHistoryContextMenuStrip
            // 
            this.exportHistoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToClipboardToolStripMenuItem});
            this.exportHistoryContextMenuStrip.Name = "exportHistoryContextMenuStrip";
            this.exportHistoryContextMenuStrip.Size = new System.Drawing.Size(176, 26);
            // 
            // exportToClipboardToolStripMenuItem
            // 
            this.exportToClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipboardExportAsCSVToolStripMenuItem,
            this.asXMLToolStripMenuItem});
            this.exportToClipboardToolStripMenuItem.Name = "exportToClipboardToolStripMenuItem";
            this.exportToClipboardToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exportToClipboardToolStripMenuItem.Text = "Export to clipboard";
            // 
            // clipboardExportAsCSVToolStripMenuItem
            // 
            this.clipboardExportAsCSVToolStripMenuItem.Name = "clipboardExportAsCSVToolStripMenuItem";
            this.clipboardExportAsCSVToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.clipboardExportAsCSVToolStripMenuItem.Text = "As CSV";
            this.clipboardExportAsCSVToolStripMenuItem.Click += new System.EventHandler(this.clipboardExportAsCSVToolStripMenuItem_Click);
            // 
            // asXMLToolStripMenuItem
            // 
            this.asXMLToolStripMenuItem.Name = "asXMLToolStripMenuItem";
            this.asXMLToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.asXMLToolStripMenuItem.Text = "As XML";
            this.asXMLToolStripMenuItem.Click += new System.EventHandler(this.asXMLToolStripMenuItem_Click);
            // 
            // chkRAWDetails
            // 
            this.chkRAWDetails.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRAWDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkRAWDetails.FlatAppearance.BorderSize = 0;
            this.chkRAWDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRAWDetails.Image = global::QuickMon.Properties.Resources._131;
            this.chkRAWDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkRAWDetails.Location = new System.Drawing.Point(869, 0);
            this.chkRAWDetails.Name = "chkRAWDetails";
            this.chkRAWDetails.Size = new System.Drawing.Size(95, 28);
            this.chkRAWDetails.TabIndex = 3;
            this.chkRAWDetails.Text = "More details";
            this.chkRAWDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkRAWDetails.UseVisualStyleBackColor = true;
            this.chkRAWDetails.CheckedChanged += new System.EventHandler(this.chkRAWDetails_CheckedChanged);
            // 
            // optHistoricStateView
            // 
            this.optHistoricStateView.AutoSize = true;
            this.optHistoricStateView.ContextMenuStrip = this.exportHistoryContextMenuStrip;
            this.optHistoricStateView.Dock = System.Windows.Forms.DockStyle.Left;
            this.optHistoricStateView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optHistoricStateView.Location = new System.Drawing.Point(58, 0);
            this.optHistoricStateView.Name = "optHistoricStateView";
            this.optHistoricStateView.Size = new System.Drawing.Size(56, 28);
            this.optHistoricStateView.TabIndex = 2;
            this.optHistoricStateView.Text = "History";
            this.optHistoricStateView.UseVisualStyleBackColor = true;
            this.optHistoricStateView.CheckedChanged += new System.EventHandler(this.optHistoricStateView_CheckedChanged);
            // 
            // optCurrentStateView
            // 
            this.optCurrentStateView.AutoSize = true;
            this.optCurrentStateView.Checked = true;
            this.optCurrentStateView.Dock = System.Windows.Forms.DockStyle.Left;
            this.optCurrentStateView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optCurrentStateView.Location = new System.Drawing.Point(0, 0);
            this.optCurrentStateView.Name = "optCurrentStateView";
            this.optCurrentStateView.Size = new System.Drawing.Size(58, 28);
            this.optCurrentStateView.TabIndex = 1;
            this.optCurrentStateView.TabStop = true;
            this.optCurrentStateView.Text = "Current";
            this.optCurrentStateView.UseVisualStyleBackColor = true;
            this.optCurrentStateView.CheckedChanged += new System.EventHandler(this.optCurrentStateView_CheckedChanged);
            // 
            // rtxDetails
            // 
            this.rtxDetails.ContextMenuStrip = this.rawViewContextMenuStrip;
            this.rtxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxDetails.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxDetails.HideSelection = false;
            this.rtxDetails.Location = new System.Drawing.Point(0, 0);
            this.rtxDetails.Name = "rtxDetails";
            this.rtxDetails.ReadOnly = true;
            this.rtxDetails.Size = new System.Drawing.Size(981, 191);
            this.rtxDetails.TabIndex = 2;
            this.rtxDetails.Text = "";
            // 
            // rawViewContextMenuStrip
            // 
            this.rawViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawViewCopyToolStripMenuItem,
            this.rawViewSelectAllToolStripMenuItem});
            this.rawViewContextMenuStrip.Name = "rawViewContextMenuStrip";
            this.rawViewContextMenuStrip.Size = new System.Drawing.Size(123, 48);
            // 
            // rawViewCopyToolStripMenuItem
            // 
            this.rawViewCopyToolStripMenuItem.Name = "rawViewCopyToolStripMenuItem";
            this.rawViewCopyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewCopyToolStripMenuItem.Text = "C&opy";
            this.rawViewCopyToolStripMenuItem.Click += new System.EventHandler(this.rawViewCopyToolStripMenuItem_Click);
            // 
            // rawViewSelectAllToolStripMenuItem
            // 
            this.rawViewSelectAllToolStripMenuItem.Name = "rawViewSelectAllToolStripMenuItem";
            this.rawViewSelectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rawViewSelectAllToolStripMenuItem.Text = "Select &All";
            this.rawViewSelectAllToolStripMenuItem.Click += new System.EventHandler(this.rawViewSelectAllToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdActionScriptsVisible);
            this.panel1.Controls.Add(this.optMetrics);
            this.panel1.Controls.Add(this.optAgentStates);
            this.panel1.Controls.Add(this.cmdCollectorEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 25);
            this.panel1.TabIndex = 1;
            // 
            // cmdActionScriptsVisible
            // 
            this.cmdActionScriptsVisible.BackColor = System.Drawing.Color.Transparent;
            this.cmdActionScriptsVisible.BackgroundImage = global::QuickMon.Properties.Resources.scroll24x24;
            this.cmdActionScriptsVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdActionScriptsVisible.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdActionScriptsVisible.FlatAppearance.BorderSize = 0;
            this.cmdActionScriptsVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdActionScriptsVisible.Location = new System.Drawing.Point(954, 0);
            this.cmdActionScriptsVisible.Name = "cmdActionScriptsVisible";
            this.cmdActionScriptsVisible.Size = new System.Drawing.Size(27, 25);
            this.cmdActionScriptsVisible.TabIndex = 4;
            this.cmdActionScriptsVisible.UseVisualStyleBackColor = false;
            this.cmdActionScriptsVisible.Click += new System.EventHandler(this.cmdActionScriptsVisible_Click);
            // 
            // optMetrics
            // 
            this.optMetrics.AutoSize = true;
            this.optMetrics.Dock = System.Windows.Forms.DockStyle.Left;
            this.optMetrics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optMetrics.Location = new System.Drawing.Point(120, 0);
            this.optMetrics.Name = "optMetrics";
            this.optMetrics.Size = new System.Drawing.Size(101, 25);
            this.optMetrics.TabIndex = 1;
            this.optMetrics.Text = "Collector metrics";
            this.optMetrics.UseVisualStyleBackColor = true;
            this.optMetrics.CheckedChanged += new System.EventHandler(this.optMetrics_CheckedChanged);
            // 
            // optAgentStates
            // 
            this.optAgentStates.AutoSize = true;
            this.optAgentStates.Checked = true;
            this.optAgentStates.Dock = System.Windows.Forms.DockStyle.Left;
            this.optAgentStates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.optAgentStates.Location = new System.Drawing.Point(27, 0);
            this.optAgentStates.Name = "optAgentStates";
            this.optAgentStates.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.optAgentStates.Size = new System.Drawing.Size(93, 25);
            this.optAgentStates.TabIndex = 0;
            this.optAgentStates.TabStop = true;
            this.optAgentStates.Text = "Agent states";
            this.optAgentStates.UseVisualStyleBackColor = true;
            this.optAgentStates.CheckedChanged += new System.EventHandler(this.optAgentStates_CheckedChanged);
            // 
            // cmdCollectorEdit
            // 
            this.cmdCollectorEdit.BackColor = System.Drawing.Color.Transparent;
            this.cmdCollectorEdit.BackgroundImage = global::QuickMon.Properties.Resources.doc_edit24x24;
            this.cmdCollectorEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdCollectorEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmdCollectorEdit.FlatAppearance.BorderSize = 0;
            this.cmdCollectorEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCollectorEdit.Location = new System.Drawing.Point(0, 0);
            this.cmdCollectorEdit.Name = "cmdCollectorEdit";
            this.cmdCollectorEdit.Size = new System.Drawing.Size(27, 25);
            this.cmdCollectorEdit.TabIndex = 5;
            this.cmdCollectorEdit.UseVisualStyleBackColor = false;
            this.cmdCollectorEdit.Click += new System.EventHandler(this.cmdCollectorEdit_Click);
            // 
            // lvwActionScripts
            // 
            this.lvwActionScripts.AutoResizeColumnEnabled = false;
            this.lvwActionScripts.AutoResizeColumnIndex = 0;
            this.lvwActionScripts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwActionScripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameActionScriptColumnHeader});
            this.lvwActionScripts.ContextMenuStrip = this.actionScriptsContextMenuStrip;
            this.lvwActionScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwActionScripts.FullRowSelect = true;
            this.lvwActionScripts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwActionScripts.HideSelection = false;
            this.lvwActionScripts.Location = new System.Drawing.Point(2, 25);
            this.lvwActionScripts.Name = "lvwActionScripts";
            this.lvwActionScripts.Size = new System.Drawing.Size(198, 615);
            this.lvwActionScripts.TabIndex = 5;
            this.lvwActionScripts.UseCompatibleStateImageBehavior = false;
            this.lvwActionScripts.View = System.Windows.Forms.View.Details;
            this.lvwActionScripts.SelectedIndexChanged += new System.EventHandler(this.lvwActionScripts_SelectedIndexChanged);
            this.lvwActionScripts.DoubleClick += new System.EventHandler(this.lvwActionScripts_DoubleClick);
            // 
            // nameActionScriptColumnHeader
            // 
            this.nameActionScriptColumnHeader.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdRunActionScript);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 25);
            this.panel2.TabIndex = 3;
            // 
            // cmdRunActionScript
            // 
            this.cmdRunActionScript.BackColor = System.Drawing.Color.Transparent;
            this.cmdRunActionScript.BackgroundImage = global::QuickMon.Properties.Resources.rungreen24x24;
            this.cmdRunActionScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRunActionScript.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRunActionScript.Enabled = false;
            this.cmdRunActionScript.FlatAppearance.BorderSize = 0;
            this.cmdRunActionScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRunActionScript.Location = new System.Drawing.Point(171, 0);
            this.cmdRunActionScript.Name = "cmdRunActionScript";
            this.cmdRunActionScript.Size = new System.Drawing.Size(27, 25);
            this.cmdRunActionScript.TabIndex = 8;
            this.cmdRunActionScript.UseVisualStyleBackColor = false;
            this.cmdRunActionScript.Click += new System.EventHandler(this.cmdRunActionScript_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Action scripts";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 640);
            this.label1.TabIndex = 4;
            // 
            // lblCollectorState
            // 
            this.lblCollectorState.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCollectorState.Image = global::QuickMon.Properties.Resources.helpbwy24x24;
            this.lblCollectorState.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCollectorState.Location = new System.Drawing.Point(0, 0);
            this.lblCollectorState.Name = "lblCollectorState";
            this.lblCollectorState.Size = new System.Drawing.Size(34, 33);
            this.lblCollectorState.TabIndex = 6;
            this.lblCollectorState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.Transparent;
            this.cmdRefresh.BackgroundImage = global::QuickMon.Properties.Resources.refresh24x24;
            this.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmdRefresh.FlatAppearance.BorderSize = 0;
            this.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRefresh.Location = new System.Drawing.Point(1169, 0);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(30, 33);
            this.cmdRefresh.TabIndex = 9;
            this.cmdRefresh.UseVisualStyleBackColor = false;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblCollectorState);
            this.panelTop.Controls.Add(this.lblName);
            this.panelTop.Controls.Add(this.cmdRefresh);
            this.panelTop.Controls.Add(this.txtName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1199, 33);
            this.panelTop.TabIndex = 10;
            // 
            // CollectorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 701);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.statusStripCollector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "CollectorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collector Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CollectorDetails_FormClosing);
            this.Load += new System.EventHandler(this.CollectorDetails_Load);
            this.Shown += new System.EventHandler(this.CollectorDetails_Shown);
            this.statusStripCollector.ResumeLayout(false);
            this.statusStripCollector.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.collectorDetailSplitContainer.Panel1.ResumeLayout(false);
            this.collectorDetailSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collectorDetailSplitContainer)).EndInit();
            this.collectorDetailSplitContainer.ResumeLayout(false);
            this.panelCollectorDetails.ResumeLayout(false);
            this.panelEditing.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.agentsEditTabPage.ResumeLayout(false);
            this.agentsEditTabPage.PerformLayout();
            this.agentsContextMenuStrip.ResumeLayout(false);
            this.collectorAgentsEditToolStrip.ResumeLayout(false);
            this.collectorAgentsEditToolStrip.PerformLayout();
            this.hostSettingsTabPage.ResumeLayout(false);
            this.hostSettingsTabPage.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.operationalTabPage.ResumeLayout(false);
            this.serviceWindowsGroupBox.ResumeLayout(false);
            this.serviceWindowsGroupBox.PerformLayout();
            this.runAsGroupBox.ResumeLayout(false);
            this.runAsGroupBox.PerformLayout();
            this.remoteAgentGroupBox.ResumeLayout(false);
            this.remoteAgentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remoteportNumericUpDown)).EndInit();
            this.pollingOverridesGroupBox.ResumeLayout(false);
            this.pollingOverridesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterThirdRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterSecondRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pollSlideFrequencyAfterFirstRepeatSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlyAllowUpdateOncePerXSecNumericUpDown)).EndInit();
            this.alertsTabPage.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.correctiveScriptsGroupBox.ResumeLayout(false);
            this.correctiveScriptsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRestorationScriptMinimumRepeatTimeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin)).EndInit();
            this.alertSuppressionGroupBox.ResumeLayout(false);
            this.alertSuppressionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXPolls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertPollsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXPollsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeatAlertInXMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayAlertSecNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertOnceInXMinNumericUpDown)).EndInit();
            this.configVarsTabPage.ResumeLayout(false);
            this.configVarsTabPage.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.actionScriptsContextMenuStrip.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelMetrics.ResumeLayout(false);
            this.panelAgentStates.ResumeLayout(false);
            this.agentStateSplitContainer.Panel1.ResumeLayout(false);
            this.agentStateSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.agentStateSplitContainer)).EndInit();
            this.agentStateSplitContainer.ResumeLayout(false);
            this.graphContextMenuStrip.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.exportHistoryContextMenuStrip.ResumeLayout(false);
            this.rawViewContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.StatusStrip statusStripCollector;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEnabled;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelAutoRefresh;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton optMetrics;
        private System.Windows.Forms.RadioButton optAgentStates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdActionScriptsVisible;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdCollectorEdit;
        private System.Windows.Forms.Button cmdRunActionScript;
        private System.Windows.Forms.Panel panelAgentStates;
        private System.Windows.Forms.Panel panelMetrics;
        private ListViewEx lvwMetrics;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panelEditing;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Panel panelCollectorDetails;
        private System.Windows.Forms.Label lblCollectorState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ImageList imagesCollectorTree;
        private HenIT.Windows.Controls.TreeListView tlvAgentStates;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.SplitContainer agentStateSplitContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton optHistoricStateView;
        private System.Windows.Forms.RadioButton optCurrentStateView;
        private ListViewEx lvwHistory;
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        private System.Windows.Forms.ColumnHeader durationColumnHeader;
        private System.Windows.Forms.ColumnHeader alertCountColumnHeader;
        private System.Windows.Forms.ColumnHeader collectorValueColumnHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer collectorDetailSplitContainer;
        private System.Windows.Forms.RichTextBox rtxDetails;
        private System.Windows.Forms.CheckBox chkRAWDetails;
        private System.Windows.Forms.ImageList agentsImageList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage agentsEditTabPage;
        private HenIT.Windows.Controls.TreeListView agentsTreeListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip collectorAgentsEditToolStrip;
        private System.Windows.Forms.ToolStripButton addCollectorConfigEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton addAgentEntryToolStripButton;
        private System.Windows.Forms.ToolStripButton editCollectorAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteCollectorAgentToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton moveUpAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownAgentToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton enableAgentToolStripButton;
        private System.Windows.Forms.ToolStripButton disableAgentToolStripButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox agentCheckSequenceToolStripComboBox;
        private System.Windows.Forms.TabPage hostSettingsTabPage;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtCategories;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtAdditionalNotes;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboChildCheckBehaviour;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TabPage operationalTabPage;
        private System.Windows.Forms.GroupBox serviceWindowsGroupBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabelServiceWindows;
        private System.Windows.Forms.GroupBox runAsGroupBox;
        private System.Windows.Forms.Button cmdTestRunAs;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox chkRunAsEnabled;
        private System.Windows.Forms.TextBox txtRunAs;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.GroupBox remoteAgentGroupBox;
        private System.Windows.Forms.ComboBox cboRemoteAgentServer;
        private System.Windows.Forms.CheckBox chkRunLocalOnRemoteHostConnectionFailure;
        private System.Windows.Forms.CheckBox chkBlockParentRHOverride;
        private System.Windows.Forms.CheckBox chkForceRemoteExcuteOnChildCollectors;
        private System.Windows.Forms.LinkLabel llblRemoteAgentInstallHelp;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkRemoteAgentEnabled;
        private System.Windows.Forms.NumericUpDown remoteportNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdRemoteAgentTest;
        private System.Windows.Forms.GroupBox pollingOverridesGroupBox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox chkEnablePollingOverride;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterThirdRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterSecondRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.NumericUpDown pollSlideFrequencyAfterFirstRepeatSecNumericUpDown;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkEnablePollingFrequencySliding;
        private System.Windows.Forms.NumericUpDown onlyAllowUpdateOncePerXSecNumericUpDown;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage alertsTabPage;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button cmdSetNoteText;
        private System.Windows.Forms.TextBox txtNotesText;
        private System.Windows.Forms.Label lblNoteTextChangeIndicator;
        private System.Windows.Forms.ComboBox cboTextType;
        private System.Windows.Forms.GroupBox correctiveScriptsGroupBox;
        private System.Windows.Forms.NumericUpDown numericUpDownRestorationScriptMinimumRepeatTimeMin;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.NumericUpDown numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.NumericUpDown numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkCorrectiveScriptDisabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox alertSuppressionGroupBox;
        private System.Windows.Forms.CheckBox chkAlertsPaused;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatAlertInXPolls;
        private System.Windows.Forms.NumericUpDown delayAlertPollsNumericUpDown;
        private System.Windows.Forms.NumericUpDown AlertOnceInXPollsNumericUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeatAlertInXMin;
        private System.Windows.Forms.NumericUpDown delayAlertSecNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.NumericUpDown AlertOnceInXMinNumericUpDown;
        private System.Windows.Forms.TabPage configVarsTabPage;
        private ListViewEx lvwConfigVars;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtConfigVarReplaceByValue;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtConfigVarSearchFor;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveUpConfigVarToolStripButton;
        private System.Windows.Forms.ToolStripButton moveDownConfigVarToolStripButton;
        private System.Windows.Forms.ContextMenuStrip agentsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addAgentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAgentEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llblRawEdit;
        private System.Windows.Forms.ToolStripStatusLabel lastUpdateTimeToolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TabPage tabPage1;
        private ListViewEx lvwActionScripts;
        private ListViewEx lvwActionScriptsEdit;
        private System.Windows.Forms.ColumnHeader actionScriptNameColumnHeader;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.ColumnHeader restorationColumnHeader;
        private System.Windows.Forms.ColumnHeader warningColumnHeader;
        private System.Windows.Forms.ColumnHeader errorColumnHeader;
        private System.Windows.Forms.ColumnHeader descriptiomColumnHeader;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton addActionScriptToolStripButton;
        private System.Windows.Forms.ToolStripButton editActionScriptToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteActionScriptToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ColumnHeader adminColumnHeader;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ColumnHeader nameActionScriptColumnHeader;
        private System.Windows.Forms.ContextMenuStrip actionScriptsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem runActionScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runActionScriptWithPauseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rawViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rawViewCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawViewSelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAsDisplayValueToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboExpandOnStartOption;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.ContextMenuStrip exportHistoryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardExportAsCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asXMLToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkExcludeFromMetrics;
        private System.Windows.Forms.RadioButton optGraphView;
        private HenIT.Windows.Controls.Graphing.TimeGraphControl collectorTimeGraph;
        private System.Windows.Forms.ContextMenuStrip graphContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem graphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearGraphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logarithmicGraphTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grapthColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphBackgroundColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientColor1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientColor2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapGraphGradientColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionForwardDiagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGradientDirectionBackwardDiagonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphGridColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphAxisLabelColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionBarColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedValueColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorSameAsSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorInvertedColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphClosestClickedColorCustomColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphVisibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHeaderVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHorisonalGridLinesVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphVerticalGridLinesVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphSelectionbarVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphHighlightClickedSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaBelowSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaBelowSeriesEnabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha48ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha64ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha128ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFillAreaAlpha192ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendVisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
    }
}