namespace QuickMon.UI
{
    partial class WSCollectorEditEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WSCollectorEditEntry));
            this.cmdGetWSDL = new System.Windows.Forms.Button();
            this.txtParameters = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServiceURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboValueFormatMacro = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboExpectedValueType = new System.Windows.Forms.ComboBox();
            this.cmdTestService = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.indexOrRowNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dataSetColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cboEndPoint = new System.Windows.Forms.ComboBox();
            this.cboMethodName = new System.Windows.Forms.ComboBox();
            this.lblParameterCount = new System.Windows.Forms.Label();
            this.sequenceGroupBox = new System.Windows.Forms.GroupBox();
            this.errorGroupBox = new System.Windows.Forms.GroupBox();
            this.cboErrorMatchType = new System.Windows.Forms.ComboBox();
            this.txtError = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.warningGroupBox = new System.Windows.Forms.GroupBox();
            this.cboWarningMatchType = new System.Windows.Forms.ComboBox();
            this.txtWarning = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.successGroupBox = new System.Windows.Forms.GroupBox();
            this.cboSuccessMatchType = new System.Windows.Forms.ComboBox();
            this.txtSuccess = new QuickMon.Controls.STDCollectorOutputValueMatchTextBox();
            this.cboReturnCheckSequence = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.indexOrRowNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetColumnNumericUpDown)).BeginInit();
            this.sequenceGroupBox.SuspendLayout();
            this.errorGroupBox.SuspendLayout();
            this.warningGroupBox.SuspendLayout();
            this.successGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdGetWSDL
            // 
            this.cmdGetWSDL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetWSDL.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdGetWSDL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdGetWSDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdGetWSDL.Location = new System.Drawing.Point(548, 12);
            this.cmdGetWSDL.Name = "cmdGetWSDL";
            this.cmdGetWSDL.Size = new System.Drawing.Size(59, 23);
            this.cmdGetWSDL.TabIndex = 2;
            this.cmdGetWSDL.Text = "WSDL";
            this.cmdGetWSDL.UseVisualStyleBackColor = true;
            this.cmdGetWSDL.Click += new System.EventHandler(this.cmdGetWSDL_Click);
            // 
            // txtParameters
            // 
            this.txtParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParameters.Location = new System.Drawing.Point(150, 92);
            this.txtParameters.Name = "txtParameters";
            this.txtParameters.Size = new System.Drawing.Size(457, 20);
            this.txtParameters.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Parameters(CSV)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Method";
            // 
            // txtServiceURL
            // 
            this.txtServiceURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServiceURL.Location = new System.Drawing.Point(150, 14);
            this.txtServiceURL.Name = "txtServiceURL";
            this.txtServiceURL.Size = new System.Drawing.Size(393, 20);
            this.txtServiceURL.TabIndex = 1;
            this.txtServiceURL.TextChanged += new System.EventHandler(this.txtServiceURL_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service URL";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Format value macro";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboValueFormatMacro
            // 
            this.cboValueFormatMacro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboValueFormatMacro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValueFormatMacro.Enabled = false;
            this.cboValueFormatMacro.Location = new System.Drawing.Point(150, 169);
            this.cboValueFormatMacro.Name = "cboValueFormatMacro";
            this.cboValueFormatMacro.Size = new System.Drawing.Size(457, 21);
            this.cboValueFormatMacro.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Expected value type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboExpectedValueType
            // 
            this.cboExpectedValueType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExpectedValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpectedValueType.Items.AddRange(new object[] {
            "Check availability only",
            "Single value",
            "Array",
            "Data set"});
            this.cboExpectedValueType.Location = new System.Drawing.Point(150, 142);
            this.cboExpectedValueType.Name = "cboExpectedValueType";
            this.cboExpectedValueType.Size = new System.Drawing.Size(457, 21);
            this.cboExpectedValueType.TabIndex = 11;
            this.cboExpectedValueType.SelectedIndexChanged += new System.EventHandler(this.cboExpectedValueType_SelectedIndexChanged);
            // 
            // cmdTestService
            // 
            this.cmdTestService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTestService.Enabled = false;
            this.cmdTestService.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdTestService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdTestService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdTestService.Location = new System.Drawing.Point(369, 431);
            this.cmdTestService.Name = "cmdTestService";
            this.cmdTestService.Size = new System.Drawing.Size(75, 23);
            this.cmdTestService.TabIndex = 20;
            this.cmdTestService.Text = "Test";
            this.cmdTestService.UseVisualStyleBackColor = true;
            this.cmdTestService.Click += new System.EventHandler(this.cmdTestService_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightSalmon;
            this.cmdCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCancel.Location = new System.Drawing.Point(531, 431);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 22;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOK.Enabled = false;
            this.cmdOK.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.cmdOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOK.Location = new System.Drawing.Point(450, 431);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 21;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Binding/Endpoint";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Array index/Data set row";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // indexOrRowNumericUpDown
            // 
            this.indexOrRowNumericUpDown.Location = new System.Drawing.Point(150, 196);
            this.indexOrRowNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.indexOrRowNumericUpDown.Name = "indexOrRowNumericUpDown";
            this.indexOrRowNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.indexOrRowNumericUpDown.TabIndex = 15;
            // 
            // dataSetColumnNumericUpDown
            // 
            this.dataSetColumnNumericUpDown.Location = new System.Drawing.Point(347, 196);
            this.dataSetColumnNumericUpDown.Name = "dataSetColumnNumericUpDown";
            this.dataSetColumnNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.dataSetColumnNumericUpDown.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(233, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 24);
            this.label10.TabIndex = 16;
            this.label10.Text = "Data set column";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboEndPoint
            // 
            this.cboEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEndPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboEndPoint.FormattingEnabled = true;
            this.cboEndPoint.Location = new System.Drawing.Point(150, 40);
            this.cboEndPoint.Name = "cboEndPoint";
            this.cboEndPoint.Size = new System.Drawing.Size(457, 21);
            this.cboEndPoint.TabIndex = 4;
            this.cboEndPoint.SelectedIndexChanged += new System.EventHandler(this.cboEndPoint_SelectedIndexChanged);
            this.cboEndPoint.TextChanged += new System.EventHandler(this.cboEndPoint_TextChanged);
            // 
            // cboMethodName
            // 
            this.cboMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMethodName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboMethodName.FormattingEnabled = true;
            this.cboMethodName.Location = new System.Drawing.Point(150, 66);
            this.cboMethodName.Name = "cboMethodName";
            this.cboMethodName.Size = new System.Drawing.Size(457, 21);
            this.cboMethodName.TabIndex = 6;
            this.cboMethodName.SelectedIndexChanged += new System.EventHandler(this.cboMethodName_SelectedIndexChanged);
            this.cboMethodName.TextChanged += new System.EventHandler(this.cboMethodName_TextChanged);
            // 
            // lblParameterCount
            // 
            this.lblParameterCount.AutoEllipsis = true;
            this.lblParameterCount.Location = new System.Drawing.Point(150, 115);
            this.lblParameterCount.Name = "lblParameterCount";
            this.lblParameterCount.Size = new System.Drawing.Size(450, 13);
            this.lblParameterCount.TabIndex = 9;
            this.lblParameterCount.Text = "Parameters info...";
            // 
            // sequenceGroupBox
            // 
            this.sequenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sequenceGroupBox.Controls.Add(this.errorGroupBox);
            this.sequenceGroupBox.Controls.Add(this.warningGroupBox);
            this.sequenceGroupBox.Controls.Add(this.successGroupBox);
            this.sequenceGroupBox.Controls.Add(this.cboReturnCheckSequence);
            this.sequenceGroupBox.Controls.Add(this.label2);
            this.sequenceGroupBox.Location = new System.Drawing.Point(15, 222);
            this.sequenceGroupBox.Name = "sequenceGroupBox";
            this.sequenceGroupBox.Size = new System.Drawing.Size(592, 200);
            this.sequenceGroupBox.TabIndex = 18;
            this.sequenceGroupBox.TabStop = false;
            this.sequenceGroupBox.Text = "Evaluate returned value/data";
            // 
            // errorGroupBox
            // 
            this.errorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorGroupBox.Controls.Add(this.cboErrorMatchType);
            this.errorGroupBox.Controls.Add(this.txtError);
            this.errorGroupBox.Location = new System.Drawing.Point(9, 147);
            this.errorGroupBox.Name = "errorGroupBox";
            this.errorGroupBox.Size = new System.Drawing.Size(577, 44);
            this.errorGroupBox.TabIndex = 4;
            this.errorGroupBox.TabStop = false;
            this.errorGroupBox.Text = "Error check";
            // 
            // cboErrorMatchType
            // 
            this.cboErrorMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboErrorMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboErrorMatchType.FormattingEnabled = true;
            this.cboErrorMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboErrorMatchType.Location = new System.Drawing.Point(457, 18);
            this.cboErrorMatchType.Name = "cboErrorMatchType";
            this.cboErrorMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboErrorMatchType.TabIndex = 1;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Location = new System.Drawing.Point(6, 18);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(445, 20);
            this.txtError.TabIndex = 0;
            this.txtError.Text = "[any]";
            // 
            // warningGroupBox
            // 
            this.warningGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningGroupBox.Controls.Add(this.cboWarningMatchType);
            this.warningGroupBox.Controls.Add(this.txtWarning);
            this.warningGroupBox.Location = new System.Drawing.Point(8, 97);
            this.warningGroupBox.Name = "warningGroupBox";
            this.warningGroupBox.Size = new System.Drawing.Size(577, 44);
            this.warningGroupBox.TabIndex = 3;
            this.warningGroupBox.TabStop = false;
            this.warningGroupBox.Text = "Warning check";
            // 
            // cboWarningMatchType
            // 
            this.cboWarningMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWarningMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarningMatchType.FormattingEnabled = true;
            this.cboWarningMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboWarningMatchType.Location = new System.Drawing.Point(458, 18);
            this.cboWarningMatchType.Name = "cboWarningMatchType";
            this.cboWarningMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboWarningMatchType.TabIndex = 1;
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarning.Location = new System.Drawing.Point(6, 18);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.Size = new System.Drawing.Size(446, 20);
            this.txtWarning.TabIndex = 0;
            this.txtWarning.Text = "[null]";
            // 
            // successGroupBox
            // 
            this.successGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successGroupBox.Controls.Add(this.cboSuccessMatchType);
            this.successGroupBox.Controls.Add(this.txtSuccess);
            this.successGroupBox.Location = new System.Drawing.Point(9, 47);
            this.successGroupBox.Name = "successGroupBox";
            this.successGroupBox.Size = new System.Drawing.Size(577, 44);
            this.successGroupBox.TabIndex = 2;
            this.successGroupBox.TabStop = false;
            this.successGroupBox.Text = "Success check";
            // 
            // cboSuccessMatchType
            // 
            this.cboSuccessMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSuccessMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSuccessMatchType.FormattingEnabled = true;
            this.cboSuccessMatchType.Items.AddRange(new object[] {
            "Match",
            "DoesNotMatch",
            "Contains",
            "DoesNotContain",
            "StartsWith",
            "DoesNotStartWith",
            "EndsWith",
            "DoesNotEndWith",
            "RegEx",
            "IsNumber",
            "IsNotANumber",
            "LargerThan",
            "SmallerThan",
            "Between",
            "NotBetween"});
            this.cboSuccessMatchType.Location = new System.Drawing.Point(457, 18);
            this.cboSuccessMatchType.Name = "cboSuccessMatchType";
            this.cboSuccessMatchType.Size = new System.Drawing.Size(110, 21);
            this.cboSuccessMatchType.TabIndex = 1;
            // 
            // txtSuccess
            // 
            this.txtSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSuccess.Location = new System.Drawing.Point(6, 18);
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.Size = new System.Drawing.Size(445, 20);
            this.txtSuccess.TabIndex = 0;
            this.txtSuccess.Text = "OK";
            // 
            // cboReturnCheckSequence
            // 
            this.cboReturnCheckSequence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReturnCheckSequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReturnCheckSequence.Items.AddRange(new object[] {
            "Good, Warning and then assume Error",
            "Error, Warning and then assume Good",
            "Good, Error and then assume Warning",
            "Error, Good and then assume Warning",
            "Warning, Good and then assume Error",
            "Warning, Error and then assume Good"});
            this.cboReturnCheckSequence.Location = new System.Drawing.Point(135, 19);
            this.cboReturnCheckSequence.Name = "cboReturnCheckSequence";
            this.cboReturnCheckSequence.Size = new System.Drawing.Size(451, 21);
            this.cboReturnCheckSequence.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Check sequence";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 436);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(225, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Tip: use [any] for any value, [null] for no value.";
            // 
            // WSCollectorEditEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(618, 466);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.sequenceGroupBox);
            this.Controls.Add(this.lblParameterCount);
            this.Controls.Add(this.cboMethodName);
            this.Controls.Add(this.cboEndPoint);
            this.Controls.Add(this.dataSetColumnNumericUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.indexOrRowNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboValueFormatMacro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboExpectedValueType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmdTestService);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdGetWSDL);
            this.Controls.Add(this.txtParameters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServiceURL);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WSCollectorEditEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Entry";
            this.Load += new System.EventHandler(this.DynamicWSCollectorEditEntry_Load);
            this.Shown += new System.EventHandler(this.DynamicWSCollectorEditEntry_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.indexOrRowNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetColumnNumericUpDown)).EndInit();
            this.sequenceGroupBox.ResumeLayout(false);
            this.errorGroupBox.ResumeLayout(false);
            this.errorGroupBox.PerformLayout();
            this.warningGroupBox.ResumeLayout(false);
            this.warningGroupBox.PerformLayout();
            this.successGroupBox.ResumeLayout(false);
            this.successGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetWSDL;
        private System.Windows.Forms.TextBox txtParameters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServiceURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboValueFormatMacro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboExpectedValueType;
        private System.Windows.Forms.Button cmdTestService;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown indexOrRowNumericUpDown;
        private System.Windows.Forms.NumericUpDown dataSetColumnNumericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboEndPoint;
        private System.Windows.Forms.ComboBox cboMethodName;
        private System.Windows.Forms.Label lblParameterCount;
        private System.Windows.Forms.GroupBox sequenceGroupBox;
        private System.Windows.Forms.ComboBox cboReturnCheckSequence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox errorGroupBox;
        private System.Windows.Forms.ComboBox cboErrorMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtError;
        private System.Windows.Forms.GroupBox warningGroupBox;
        private System.Windows.Forms.ComboBox cboWarningMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtWarning;
        private System.Windows.Forms.GroupBox successGroupBox;
        private System.Windows.Forms.ComboBox cboSuccessMatchType;
        private Controls.STDCollectorOutputValueMatchTextBox txtSuccess;
        private System.Windows.Forms.Label label11;
    }
}