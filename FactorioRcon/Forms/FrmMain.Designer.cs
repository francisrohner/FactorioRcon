namespace FactorioRcon.Forms
{
    partial class FrmMain
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.splConsole = new System.Windows.Forms.SplitContainer();
            this.rtbServerResp = new System.Windows.Forms.RichTextBox();
            this.btnCmdGenerator = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtClientCmd = new System.Windows.Forms.TextBox();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.gbPlayers = new System.Windows.Forms.GroupBox();
            this.lblOnline = new System.Windows.Forms.Label();
            this.lblOffline = new System.Windows.Forms.Label();
            this.lstOffline = new System.Windows.Forms.ListBox();
            this.lstOnline = new System.Windows.Forms.ListBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblChangeLog = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbChangeLog = new System.Windows.Forms.RichTextBox();
            this.llGithub = new System.Windows.Forms.LinkLabel();
            this.lblGithub = new System.Windows.Forms.Label();
            this.gbContact = new System.Windows.Forms.GroupBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.llEmail = new System.Windows.Forms.LinkLabel();
            this.gbContribution = new System.Windows.Forms.GroupBox();
            this.llDonate = new System.Windows.Forms.LinkLabel();
            this.lblDonate = new System.Windows.Forms.Label();
            this.pbCopy = new System.Windows.Forms.PictureBox();
            this.lblBTCAddress = new System.Windows.Forms.Label();
            this.lblDonateBTC = new System.Windows.Forms.Label();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbConnections = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.tmrUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.gbQuickCommand = new System.Windows.Forms.GroupBox();
            this.btnPurgeEvolution = new System.Windows.Forms.Button();
            this.btnRefillResources = new System.Windows.Forms.Button();
            this.btnResearchAll = new System.Windows.Forms.Button();
            this.btnPurgeBiters = new System.Windows.Forms.Button();
            this.btnClearPollution = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSetDay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            this.tabDiagnostic = new System.Windows.Forms.TabPage();
            this.splDiagnostic = new System.Windows.Forms.SplitContainer();
            this.gridOut = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gridIn = new System.Windows.Forms.DataGridView();
            this.tcMain.SuspendLayout();
            this.tabConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splConsole)).BeginInit();
            this.splConsole.Panel1.SuspendLayout();
            this.splConsole.Panel2.SuspendLayout();
            this.splConsole.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            this.gbPlayers.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbContact.SuspendLayout();
            this.gbContribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopy)).BeginInit();
            this.gbConnect.SuspendLayout();
            this.gbQuickCommand.SuspendLayout();
            this.tabDiagnostic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splDiagnostic)).BeginInit();
            this.splDiagnostic.Panel1.SuspendLayout();
            this.splDiagnostic.Panel2.SuspendLayout();
            this.splDiagnostic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIn)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabConsole);
            this.tcMain.Controls.Add(this.tabStatus);
            this.tcMain.Controls.Add(this.tabAbout);
            this.tcMain.Controls.Add(this.tabDiagnostic);
            this.tcMain.Enabled = false;
            this.tcMain.Location = new System.Drawing.Point(12, 142);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(909, 466);
            this.tcMain.TabIndex = 14;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.splConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 25);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(901, 437);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // splConsole
            // 
            this.splConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splConsole.Location = new System.Drawing.Point(3, 3);
            this.splConsole.Name = "splConsole";
            this.splConsole.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splConsole.Panel1
            // 
            this.splConsole.Panel1.Controls.Add(this.rtbServerResp);
            // 
            // splConsole.Panel2
            // 
            this.splConsole.Panel2.Controls.Add(this.btnCmdGenerator);
            this.splConsole.Panel2.Controls.Add(this.btnSend);
            this.splConsole.Panel2.Controls.Add(this.txtClientCmd);
            this.splConsole.Size = new System.Drawing.Size(895, 431);
            this.splConsole.SplitterDistance = 300;
            this.splConsole.TabIndex = 0;
            // 
            // rtbServerResp
            // 
            this.rtbServerResp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtbServerResp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbServerResp.Location = new System.Drawing.Point(0, 0);
            this.rtbServerResp.Name = "rtbServerResp";
            this.rtbServerResp.ReadOnly = true;
            this.rtbServerResp.Size = new System.Drawing.Size(895, 300);
            this.rtbServerResp.TabIndex = 0;
            this.rtbServerResp.TabStop = false;
            this.rtbServerResp.Text = "";
            // 
            // btnCmdGenerator
            // 
            this.btnCmdGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCmdGenerator.Location = new System.Drawing.Point(767, 3);
            this.btnCmdGenerator.Name = "btnCmdGenerator";
            this.btnCmdGenerator.Size = new System.Drawing.Size(125, 44);
            this.btnCmdGenerator.TabIndex = 16;
            this.btnCmdGenerator.Text = "Command Generator";
            this.btnCmdGenerator.UseVisualStyleBackColor = true;
            this.btnCmdGenerator.Click += new System.EventHandler(this.BtnCmdGenerator_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(767, 80);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(125, 44);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Send\r\n[Control + Enter]";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtClientCmd
            // 
            this.txtClientCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCmd.Location = new System.Drawing.Point(3, 3);
            this.txtClientCmd.Multiline = true;
            this.txtClientCmd.Name = "txtClientCmd";
            this.txtClientCmd.Size = new System.Drawing.Size(758, 121);
            this.txtClientCmd.TabIndex = 15;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.pbRefresh);
            this.tabStatus.Controls.Add(this.gbPlayers);
            this.tabStatus.Location = new System.Drawing.Point(4, 25);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(901, 437);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "Status";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // pbRefresh
            // 
            this.pbRefresh.Image = global::FactorioRcon.Properties.Resources.refresh_button;
            this.pbRefresh.Location = new System.Drawing.Point(367, 15);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(35, 34);
            this.pbRefresh.TabIndex = 1;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.PbRefresh_Click);
            // 
            // gbPlayers
            // 
            this.gbPlayers.Controls.Add(this.lblOnline);
            this.gbPlayers.Controls.Add(this.lblOffline);
            this.gbPlayers.Controls.Add(this.lstOffline);
            this.gbPlayers.Controls.Add(this.lstOnline);
            this.gbPlayers.Location = new System.Drawing.Point(6, 6);
            this.gbPlayers.Name = "gbPlayers";
            this.gbPlayers.Size = new System.Drawing.Size(355, 176);
            this.gbPlayers.TabIndex = 0;
            this.gbPlayers.TabStop = false;
            this.gbPlayers.Text = "Players";
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Location = new System.Drawing.Point(6, 19);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(49, 16);
            this.lblOnline.TabIndex = 3;
            this.lblOnline.Text = "Online";
            // 
            // lblOffline
            // 
            this.lblOffline.AutoSize = true;
            this.lblOffline.Location = new System.Drawing.Point(180, 19);
            this.lblOffline.Name = "lblOffline";
            this.lblOffline.Size = new System.Drawing.Size(49, 16);
            this.lblOffline.TabIndex = 2;
            this.lblOffline.Text = "Offline";
            // 
            // lstOffline
            // 
            this.lstOffline.FormattingEnabled = true;
            this.lstOffline.ItemHeight = 16;
            this.lstOffline.Location = new System.Drawing.Point(180, 38);
            this.lstOffline.Name = "lstOffline";
            this.lstOffline.Size = new System.Drawing.Size(168, 132);
            this.lstOffline.TabIndex = 1;
            // 
            // lstOnline
            // 
            this.lstOnline.FormattingEnabled = true;
            this.lstOnline.ItemHeight = 16;
            this.lstOnline.Location = new System.Drawing.Point(6, 38);
            this.lstOnline.Name = "lstOnline";
            this.lstOnline.Size = new System.Drawing.Size(168, 132);
            this.lstOnline.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.gbInfo);
            this.tabAbout.Controls.Add(this.gbContact);
            this.tabAbout.Controls.Add(this.gbContribution);
            this.tabAbout.Location = new System.Drawing.Point(4, 25);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(901, 437);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.lblChangeLog);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.rtbChangeLog);
            this.gbInfo.Controls.Add(this.llGithub);
            this.gbInfo.Controls.Add(this.lblGithub);
            this.gbInfo.Location = new System.Drawing.Point(6, 6);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(880, 274);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info";
            // 
            // lblChangeLog
            // 
            this.lblChangeLog.AutoSize = true;
            this.lblChangeLog.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblChangeLog.Location = new System.Drawing.Point(9, 66);
            this.lblChangeLog.Name = "lblChangeLog";
            this.lblChangeLog.Size = new System.Drawing.Size(92, 16);
            this.lblChangeLog.TabIndex = 7;
            this.lblChangeLog.Text = "ChangeLog:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "1.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Version:";
            // 
            // rtbChangeLog
            // 
            this.rtbChangeLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChangeLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rtbChangeLog.Location = new System.Drawing.Point(9, 85);
            this.rtbChangeLog.Name = "rtbChangeLog";
            this.rtbChangeLog.ReadOnly = true;
            this.rtbChangeLog.Size = new System.Drawing.Size(871, 147);
            this.rtbChangeLog.TabIndex = 1;
            this.rtbChangeLog.Text = "";
            // 
            // llGithub
            // 
            this.llGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llGithub.AutoSize = true;
            this.llGithub.Location = new System.Drawing.Point(104, 235);
            this.llGithub.Name = "llGithub";
            this.llGithub.Size = new System.Drawing.Size(316, 16);
            this.llGithub.TabIndex = 2;
            this.llGithub.TabStop = true;
            this.llGithub.Text = "https://github.com/francisrohner/FactorioRcon.git";
            this.llGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlGithub_LinkClicked);
            // 
            // lblGithub
            // 
            this.lblGithub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGithub.AutoSize = true;
            this.lblGithub.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblGithub.Location = new System.Drawing.Point(6, 235);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(59, 16);
            this.lblGithub.TabIndex = 2;
            this.lblGithub.Text = "Github:";
            // 
            // gbContact
            // 
            this.gbContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContact.Controls.Add(this.lblEmail);
            this.gbContact.Controls.Add(this.llEmail);
            this.gbContact.Location = new System.Drawing.Point(6, 286);
            this.gbContact.Name = "gbContact";
            this.gbContact.Size = new System.Drawing.Size(889, 55);
            this.gbContact.TabIndex = 1;
            this.gbContact.TabStop = false;
            this.gbContact.Text = "Contact";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(6, 19);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 16);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            // 
            // llEmail
            // 
            this.llEmail.AutoSize = true;
            this.llEmail.Location = new System.Drawing.Point(104, 19);
            this.llEmail.Name = "llEmail";
            this.llEmail.Size = new System.Drawing.Size(131, 16);
            this.llEmail.TabIndex = 3;
            this.llEmail.TabStop = true;
            this.llEmail.Text = "citricube@msn.com";
            this.llEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Email_Clicked);
            // 
            // gbContribution
            // 
            this.gbContribution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContribution.Controls.Add(this.llDonate);
            this.gbContribution.Controls.Add(this.lblDonate);
            this.gbContribution.Controls.Add(this.pbCopy);
            this.gbContribution.Controls.Add(this.lblBTCAddress);
            this.gbContribution.Controls.Add(this.lblDonateBTC);
            this.gbContribution.Location = new System.Drawing.Point(6, 347);
            this.gbContribution.Name = "gbContribution";
            this.gbContribution.Size = new System.Drawing.Size(889, 84);
            this.gbContribution.TabIndex = 0;
            this.gbContribution.TabStop = false;
            this.gbContribution.Text = "Contribution";
            // 
            // llDonate
            // 
            this.llDonate.AutoSize = true;
            this.llDonate.Location = new System.Drawing.Point(104, 58);
            this.llDonate.Name = "llDonate";
            this.llDonate.Size = new System.Drawing.Size(95, 16);
            this.llDonate.TabIndex = 4;
            this.llDonate.TabStop = true;
            this.llDonate.Text = "Donation Link";
            this.llDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLDonate_Clicked);
            // 
            // lblDonate
            // 
            this.lblDonate.AutoSize = true;
            this.lblDonate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonate.Location = new System.Drawing.Point(6, 58);
            this.lblDonate.Name = "lblDonate";
            this.lblDonate.Size = new System.Drawing.Size(62, 16);
            this.lblDonate.TabIndex = 3;
            this.lblDonate.Text = "Donate:";
            // 
            // pbCopy
            // 
            this.pbCopy.Image = global::FactorioRcon.Properties.Resources.copy_content;
            this.pbCopy.Location = new System.Drawing.Point(391, 22);
            this.pbCopy.Name = "pbCopy";
            this.pbCopy.Size = new System.Drawing.Size(26, 25);
            this.pbCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCopy.TabIndex = 2;
            this.pbCopy.TabStop = false;
            this.pbCopy.Click += new System.EventHandler(this.PbCopy_Click);
            // 
            // lblBTCAddress
            // 
            this.lblBTCAddress.AutoSize = true;
            this.lblBTCAddress.Location = new System.Drawing.Point(104, 31);
            this.lblBTCAddress.Name = "lblBTCAddress";
            this.lblBTCAddress.Size = new System.Drawing.Size(281, 16);
            this.lblBTCAddress.TabIndex = 1;
            this.lblBTCAddress.Text = "3N5t4YApY3gFkbfKBLeaKnvScsc2WsjW1C";
            // 
            // lblDonateBTC
            // 
            this.lblDonateBTC.AutoSize = true;
            this.lblDonateBTC.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblDonateBTC.Location = new System.Drawing.Point(6, 31);
            this.lblDonateBTC.Name = "lblDonateBTC";
            this.lblDonateBTC.Size = new System.Drawing.Size(94, 16);
            this.lblDonateBTC.TabIndex = 0;
            this.lblDonateBTC.Text = "Donate BTC:";
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.lblServer);
            this.gbConnect.Controls.Add(this.txtPassword);
            this.gbConnect.Controls.Add(this.lblPassword);
            this.gbConnect.Controls.Add(this.btnDelete);
            this.gbConnect.Controls.Add(this.cmbConnections);
            this.gbConnect.Controls.Add(this.btnConnect);
            this.gbConnect.Controls.Add(this.txtPort);
            this.gbConnect.Controls.Add(this.lblPort);
            this.gbConnect.Controls.Add(this.txtHost);
            this.gbConnect.Controls.Add(this.lblHost);
            this.gbConnect.Location = new System.Drawing.Point(12, 12);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(905, 62);
            this.gbConnect.TabIndex = 0;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Connection";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblServer.Location = new System.Drawing.Point(584, 24);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(60, 16);
            this.lblServer.TabIndex = 10;
            this.lblServer.Text = "Server:";
            this.lblServer.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(406, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(74, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(320, 25);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(80, 16);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(824, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // cmbConnections
            // 
            this.cmbConnections.FormattingEnabled = true;
            this.cmbConnections.Location = new System.Drawing.Point(650, 20);
            this.cmbConnections.Name = "cmbConnections";
            this.cmbConnections.Size = new System.Drawing.Size(168, 24);
            this.cmbConnections.TabIndex = 5;
            this.cmbConnections.Visible = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(486, 21);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(92, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(237, 21);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(74, 23);
            this.txtPort.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPort.Location = new System.Drawing.Point(190, 25);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 16);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(57, 22);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(127, 23);
            this.txtHost.TabIndex = 1;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblHost.Location = new System.Drawing.Point(7, 25);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(44, 16);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // tmrUpdateUI
            // 
            this.tmrUpdateUI.Enabled = true;
            this.tmrUpdateUI.Interval = 250;
            this.tmrUpdateUI.Tick += new System.EventHandler(this.tmrUpdateUI_Tick);
            // 
            // gbQuickCommand
            // 
            this.gbQuickCommand.Controls.Add(this.btnPurgeEvolution);
            this.gbQuickCommand.Controls.Add(this.btnRefillResources);
            this.gbQuickCommand.Controls.Add(this.btnResearchAll);
            this.gbQuickCommand.Controls.Add(this.btnPurgeBiters);
            this.gbQuickCommand.Controls.Add(this.btnClearPollution);
            this.gbQuickCommand.Controls.Add(this.btnHelp);
            this.gbQuickCommand.Controls.Add(this.btnSetDay);
            this.gbQuickCommand.Controls.Add(this.btnSave);
            this.gbQuickCommand.Enabled = false;
            this.gbQuickCommand.Location = new System.Drawing.Point(12, 80);
            this.gbQuickCommand.Name = "gbQuickCommand";
            this.gbQuickCommand.Size = new System.Drawing.Size(905, 56);
            this.gbQuickCommand.TabIndex = 7;
            this.gbQuickCommand.TabStop = false;
            this.gbQuickCommand.Text = "Quick Command";
            // 
            // btnPurgeEvolution
            // 
            this.btnPurgeEvolution.Location = new System.Drawing.Point(385, 27);
            this.btnPurgeEvolution.Name = "btnPurgeEvolution";
            this.btnPurgeEvolution.Size = new System.Drawing.Size(119, 23);
            this.btnPurgeEvolution.TabIndex = 13;
            this.btnPurgeEvolution.Text = "Purge Evolution";
            this.ttMain.SetToolTip(this.btnPurgeEvolution, "Set server evolution to 0 (Slow rate of biter spawns)");
            this.btnPurgeEvolution.UseVisualStyleBackColor = true;
            this.btnPurgeEvolution.Click += new System.EventHandler(this.BtnPurgeEvolution_Click);
            // 
            // btnRefillResources
            // 
            this.btnRefillResources.Location = new System.Drawing.Point(738, 27);
            this.btnRefillResources.Name = "btnRefillResources";
            this.btnRefillResources.Size = new System.Drawing.Size(121, 23);
            this.btnRefillResources.TabIndex = 12;
            this.btnRefillResources.Text = "Refill Resources";
            this.btnRefillResources.UseVisualStyleBackColor = true;
            this.btnRefillResources.Visible = false;
            this.btnRefillResources.Click += new System.EventHandler(this.BtnRefillResources_Click);
            // 
            // btnResearchAll
            // 
            this.btnResearchAll.Location = new System.Drawing.Point(624, 27);
            this.btnResearchAll.Name = "btnResearchAll";
            this.btnResearchAll.Size = new System.Drawing.Size(108, 23);
            this.btnResearchAll.TabIndex = 12;
            this.btnResearchAll.Text = "Research All";
            this.btnResearchAll.UseVisualStyleBackColor = true;
            this.btnResearchAll.Click += new System.EventHandler(this.BtnResearchAll_Click);
            // 
            // btnPurgeBiters
            // 
            this.btnPurgeBiters.Location = new System.Drawing.Point(510, 27);
            this.btnPurgeBiters.Name = "btnPurgeBiters";
            this.btnPurgeBiters.Size = new System.Drawing.Size(108, 23);
            this.btnPurgeBiters.TabIndex = 12;
            this.btnPurgeBiters.Text = "Purge Biters";
            this.btnPurgeBiters.UseVisualStyleBackColor = true;
            this.btnPurgeBiters.Click += new System.EventHandler(this.BtnPurgeBiters_Click);
            // 
            // btnClearPollution
            // 
            this.btnClearPollution.Location = new System.Drawing.Point(271, 27);
            this.btnClearPollution.Name = "btnClearPollution";
            this.btnClearPollution.Size = new System.Drawing.Size(108, 23);
            this.btnClearPollution.TabIndex = 11;
            this.btnClearPollution.Text = "Clear Pollution";
            this.ttMain.SetToolTip(this.btnClearPollution, "Clear current pollution on map.");
            this.btnClearPollution.UseVisualStyleBackColor = true;
            this.btnClearPollution.Click += new System.EventHandler(this.BtnClearPollution_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(190, 27);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "Help";
            this.ttMain.SetToolTip(this.btnHelp, "Get list of supported commands from server.");
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnSetDay
            // 
            this.btnSetDay.Location = new System.Drawing.Point(91, 27);
            this.btnSetDay.Name = "btnSetDay";
            this.btnSetDay.Size = new System.Drawing.Size(93, 23);
            this.btnSetDay.TabIndex = 9;
            this.btnSetDay.Text = "Always Day";
            this.ttMain.SetToolTip(this.btnSetDay, "Disable night time on server.");
            this.btnSetDay.UseVisualStyleBackColor = true;
            this.btnSetDay.Click += new System.EventHandler(this.BtnSetDay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(10, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.ttMain.SetToolTip(this.btnSave, "Force server to save map.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tabDiagnostic
            // 
            this.tabDiagnostic.Controls.Add(this.splDiagnostic);
            this.tabDiagnostic.Location = new System.Drawing.Point(4, 25);
            this.tabDiagnostic.Name = "tabDiagnostic";
            this.tabDiagnostic.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiagnostic.Size = new System.Drawing.Size(901, 437);
            this.tabDiagnostic.TabIndex = 3;
            this.tabDiagnostic.Text = "Diagnostic";
            this.tabDiagnostic.UseVisualStyleBackColor = true;
            // 
            // splDiagnostic
            // 
            this.splDiagnostic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splDiagnostic.Location = new System.Drawing.Point(3, 3);
            this.splDiagnostic.Name = "splDiagnostic";
            this.splDiagnostic.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splDiagnostic.Panel1
            // 
            this.splDiagnostic.Panel1.Controls.Add(this.label3);
            this.splDiagnostic.Panel1.Controls.Add(this.gridOut);
            // 
            // splDiagnostic.Panel2
            // 
            this.splDiagnostic.Panel2.Controls.Add(this.label4);
            this.splDiagnostic.Panel2.Controls.Add(this.gridIn);
            this.splDiagnostic.Size = new System.Drawing.Size(895, 431);
            this.splDiagnostic.SplitterDistance = 200;
            this.splDiagnostic.TabIndex = 0;
            // 
            // gridOut
            // 
            this.gridOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOut.Location = new System.Drawing.Point(3, 28);
            this.gridOut.Name = "gridOut";
            this.gridOut.Size = new System.Drawing.Size(889, 169);
            this.gridOut.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Outgoing:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Incoming:";
            // 
            // gridIn
            // 
            this.gridIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIn.Location = new System.Drawing.Point(3, 30);
            this.gridIn.Name = "gridIn";
            this.gridIn.Size = new System.Drawing.Size(889, 194);
            this.gridIn.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 620);
            this.Controls.Add(this.gbQuickCommand);
            this.Controls.Add(this.gbConnect);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factorio Rcon Client";
            this.tcMain.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.splConsole.Panel1.ResumeLayout(false);
            this.splConsole.Panel2.ResumeLayout(false);
            this.splConsole.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splConsole)).EndInit();
            this.splConsole.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            this.gbPlayers.ResumeLayout(false);
            this.gbPlayers.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbContact.ResumeLayout(false);
            this.gbContact.PerformLayout();
            this.gbContribution.ResumeLayout(false);
            this.gbContribution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopy)).EndInit();
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.gbQuickCommand.ResumeLayout(false);
            this.tabDiagnostic.ResumeLayout(false);
            this.splDiagnostic.Panel1.ResumeLayout(false);
            this.splDiagnostic.Panel1.PerformLayout();
            this.splDiagnostic.Panel2.ResumeLayout(false);
            this.splDiagnostic.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splDiagnostic)).EndInit();
            this.splDiagnostic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.SplitContainer splConsole;
        private System.Windows.Forms.RichTextBox rtbServerResp;
        private System.Windows.Forms.Button btnCmdGenerator;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtClientCmd;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.GroupBox gbContribution;
        private System.Windows.Forms.ComboBox cmbConnections;
        private System.Windows.Forms.GroupBox gbPlayers;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Label lblOffline;
        private System.Windows.Forms.Label lblDonateBTC;
        private System.Windows.Forms.Label lblBTCAddress;
        private System.Windows.Forms.PictureBox pbCopy;
        private System.Windows.Forms.LinkLabel llDonate;
        private System.Windows.Forms.Label lblDonate;
        private System.Windows.Forms.GroupBox gbContact;
        private System.Windows.Forms.LinkLabel llEmail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.LinkLabel llGithub;
        private System.Windows.Forms.Label lblGithub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbChangeLog;
        private System.Windows.Forms.Label lblChangeLog;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Timer tmrUpdateUI;
        private System.Windows.Forms.GroupBox gbQuickCommand;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSetDay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearPollution;
        private System.Windows.Forms.PictureBox pbRefresh;
        public System.Windows.Forms.ListBox lstOffline;
        public System.Windows.Forms.ListBox lstOnline;
        private System.Windows.Forms.Button btnPurgeEvolution;
        private System.Windows.Forms.Button btnPurgeBiters;
        private System.Windows.Forms.ToolTip ttMain;
        private System.Windows.Forms.Button btnResearchAll;
        private System.Windows.Forms.Button btnRefillResources;
        private System.Windows.Forms.TabPage tabDiagnostic;
        private System.Windows.Forms.SplitContainer splDiagnostic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView gridIn;
    }
}

