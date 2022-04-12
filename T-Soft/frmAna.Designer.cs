namespace T_Soft
{
    partial class frmAna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAna));
            this.grdControlSip = new DevExpress.XtraGrid.GridControl();
            this.grdViewSip = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAktar = new DevExpress.XtraEditors.SimpleButton();
            this.dateBaslangic = new DevExpress.XtraEditors.DateEdit();
            this.dateBitis = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelTarih = new DevExpress.XtraEditors.PanelControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnListele = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblSipSayisi = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::T_Soft.WaitForm1), true, true);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlSip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangic.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitis.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTarih)).BeginInit();
            this.panelTarih.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdControlSip
            // 
            this.grdControlSip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdControlSip.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdControlSip.Location = new System.Drawing.Point(0, 258);
            this.grdControlSip.MainView = this.grdViewSip;
            this.grdControlSip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdControlSip.Name = "grdControlSip";
            this.grdControlSip.Size = new System.Drawing.Size(1400, 690);
            this.grdControlSip.TabIndex = 2;
            this.grdControlSip.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewSip});
            // 
            // grdViewSip
            // 
            this.grdViewSip.Appearance.Empty.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.Empty.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.Empty.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdViewSip.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdViewSip.Appearance.FocusedCell.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.FocusedCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.FocusedCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdViewSip.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdViewSip.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.Preview.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.Preview.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.Row.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.grdViewSip.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdViewSip.Appearance.TopNewRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdViewSip.DetailHeight = 431;
            this.grdViewSip.GridControl = this.grdControlSip;
            this.grdViewSip.Name = "grdViewSip";
            this.grdViewSip.OptionsBehavior.Editable = false;
            this.grdViewSip.OptionsView.ColumnAutoWidth = false;
            this.grdViewSip.OptionsView.ShowGroupPanel = false;
            // 
            // btnAktar
            // 
            this.btnAktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAktar.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnAktar.Appearance.Options.UseFont = true;
            this.btnAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAktar.ImageOptions.Image")));
            this.btnAktar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAktar.ImageOptions.ImageToTextIndent = 5;
            this.btnAktar.Location = new System.Drawing.Point(1213, 12);
            this.btnAktar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAktar.Name = "btnAktar";
            this.btnAktar.Size = new System.Drawing.Size(175, 98);
            this.btnAktar.TabIndex = 6;
            this.btnAktar.Text = "ERP\'ye Aktar";
            this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
            // 
            // dateBaslangic
            // 
            this.dateBaslangic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateBaslangic.EditValue = null;
            this.dateBaslangic.Location = new System.Drawing.Point(859, 13);
            this.dateBaslangic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateBaslangic.Name = "dateBaslangic";
            this.dateBaslangic.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateBaslangic.Properties.Appearance.Options.UseFont = true;
            this.dateBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBaslangic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBaslangic.Properties.DisplayFormat.FormatString = "g";
            this.dateBaslangic.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBaslangic.Properties.EditFormat.FormatString = "g";
            this.dateBaslangic.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBaslangic.Properties.Mask.EditMask = "g";
            this.dateBaslangic.Size = new System.Drawing.Size(292, 30);
            this.dateBaslangic.TabIndex = 3;
            // 
            // dateBitis
            // 
            this.dateBitis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateBitis.EditValue = null;
            this.dateBitis.Location = new System.Drawing.Point(859, 47);
            this.dateBitis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateBitis.Name = "dateBitis";
            this.dateBitis.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateBitis.Properties.Appearance.Options.UseFont = true;
            this.dateBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBitis.Properties.DisplayFormat.FormatString = "g";
            this.dateBitis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBitis.Properties.EditFormat.FormatString = "g";
            this.dateBitis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateBitis.Properties.Mask.EditMask = "g";
            this.dateBitis.Size = new System.Drawing.Size(292, 30);
            this.dateBitis.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(740, 49);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 24);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Bitiş Tarihi :";
            // 
            // panelTarih
            // 
            this.panelTarih.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTarih.Controls.Add(this.checkedListBoxControl1);
            this.panelTarih.Controls.Add(this.checkedComboBoxEdit1);
            this.panelTarih.Controls.Add(this.labelControl2);
            this.panelTarih.Controls.Add(this.labelControl1);
            this.panelTarih.Controls.Add(this.dateBitis);
            this.panelTarih.Controls.Add(this.dateBaslangic);
            this.panelTarih.Controls.Add(this.btnListele);
            this.panelTarih.Controls.Add(this.btnAktar);
            this.panelTarih.Location = new System.Drawing.Point(0, 0);
            this.panelTarih.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTarih.Name = "panelTarih";
            this.panelTarih.Size = new System.Drawing.Size(1400, 250);
            this.panelTarih.TabIndex = 1;
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Location = new System.Drawing.Point(337, 15);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(120, 95);
            this.checkedListBoxControl1.TabIndex = 9;
            this.checkedListBoxControl1.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxControl1_SelectedIndexChanged);
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(193, 13);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(127, 22);
            this.checkedComboBoxEdit1.TabIndex = 7;
            this.checkedComboBoxEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.checkedComboBoxEdit1_CloseUp);
            this.checkedComboBoxEdit1.EditValueChanged += new System.EventHandler(this.checkedComboBoxEdit1_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(687, 15);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(154, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Başlangıç Tarihi :";
            // 
            // btnListele
            // 
            this.btnListele.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnListele.Appearance.Options.UseFont = true;
            this.btnListele.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListele.ImageOptions.Image")));
            this.btnListele.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnListele.ImageOptions.ImageToTextIndent = 5;
            this.btnListele.Location = new System.Drawing.Point(12, 12);
            this.btnListele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(175, 98);
            this.btnListele.TabIndex = 6;
            this.btnListele.Text = "Siparişler";
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 956);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(187, 21);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Listelenen Sipariş Sayısı :";
            // 
            // lblSipSayisi
            // 
            this.lblSipSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSipSayisi.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSipSayisi.Appearance.Options.UseFont = true;
            this.lblSipSayisi.Location = new System.Drawing.Point(211, 956);
            this.lblSipSayisi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSipSayisi.Name = "lblSipSayisi";
            this.lblSipSayisi.Size = new System.Drawing.Size(0, 21);
            this.lblSipSayisi.TabIndex = 6;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmAna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 985);
            this.Controls.Add(this.lblSipSayisi);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.grdControlSip);
            this.Controls.Add(this.panelTarih);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmAna.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1202, 832);
            this.Name = "frmAna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "T-Soft - Fatura Aktarım";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAna_Load);
            this.Shown += new System.EventHandler(this.frmAna_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdControlSip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewSip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangic.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBaslangic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitis.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBitis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTarih)).EndInit();
            this.panelTarih.ResumeLayout(false);
            this.panelTarih.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl grdControlSip;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewSip;
        private DevExpress.XtraEditors.SimpleButton btnAktar;
        private DevExpress.XtraEditors.DateEdit dateBaslangic;
        private DevExpress.XtraEditors.DateEdit dateBitis;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelTarih;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnListele;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblSipSayisi;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
    }
}

