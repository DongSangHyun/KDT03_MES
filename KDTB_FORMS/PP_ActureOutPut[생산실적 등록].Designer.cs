namespace KDTB_FORMS
{
    partial class PP_ActureOutPut
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            this.cboPLantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel1 = new DC00_Component.SLabel();
            this.sLabel2 = new DC00_Component.SLabel();
            this.cboWorkcenterCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.txtWorkerId = new DC00_Component.SBtnTextEditor();
            this.sLabel3 = new DC00_Component.SLabel();
            this.txtWorkerName = new DC00_Component.STextBox(this.components);
            this.btnWorkerReg = new System.Windows.Forms.Button();
            this.btnOrderSelect = new System.Windows.Forms.Button();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnLotInOut = new System.Windows.Forms.Button();
            this.txtInLotNo = new DC00_Component.STextBox(this.components);
            this.sLabel4 = new DC00_Component.SLabel();
            this.btnRunStop = new System.Windows.Forms.Button();
            this.sLabel5 = new DC00_Component.SLabel();
            this.txtProdQty = new DC00_Component.STextBox(this.components);
            this.txtBadQty = new DC00_Component.STextBox(this.components);
            this.sLabel6 = new DC00_Component.SLabel();
            this.btnProdReg = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.grid1 = new DC00_Component.Grid(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPLantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInLotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBadQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.button3);
            this.gbxHeader.Controls.Add(this.btnProdReg);
            this.gbxHeader.Controls.Add(this.txtBadQty);
            this.gbxHeader.Controls.Add(this.sLabel6);
            this.gbxHeader.Controls.Add(this.txtProdQty);
            this.gbxHeader.Controls.Add(this.sLabel5);
            this.gbxHeader.Controls.Add(this.btnRunStop);
            this.gbxHeader.Controls.Add(this.ultraGroupBox1);
            this.gbxHeader.Controls.Add(this.btnOrderSelect);
            this.gbxHeader.Controls.Add(this.btnWorkerReg);
            this.gbxHeader.Controls.Add(this.txtWorkerName);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.txtWorkerId);
            this.gbxHeader.Controls.Add(this.cboWorkcenterCode);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.cboPLantCode);
            this.gbxHeader.Size = new System.Drawing.Size(1022, 161);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.grid1);
            this.gbxBody.Location = new System.Drawing.Point(0, 161);
            this.gbxBody.Size = new System.Drawing.Size(1022, 322);
            // 
            // cboPLantCode
            // 
            this.cboPLantCode.Location = new System.Drawing.Point(71, 12);
            this.cboPLantCode.Name = "cboPLantCode";
            this.cboPLantCode.Size = new System.Drawing.Size(144, 29);
            this.cboPLantCode.TabIndex = 0;
            // 
            // sLabel1
            // 
            appearance19.FontData.BoldAsString = "False";
            appearance19.FontData.UnderlineAsString = "False";
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance19;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(7, 18);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(58, 23);
            this.sLabel1.TabIndex = 1;
            this.sLabel1.Text = "공장";
            // 
            // sLabel2
            // 
            appearance18.FontData.BoldAsString = "False";
            appearance18.FontData.UnderlineAsString = "False";
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance18;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(221, 18);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(74, 23);
            this.sLabel2.TabIndex = 2;
            this.sLabel2.Text = "(1) 작업장";
            // 
            // cboWorkcenterCode
            // 
            this.cboWorkcenterCode.Location = new System.Drawing.Point(301, 12);
            this.cboWorkcenterCode.Name = "cboWorkcenterCode";
            this.cboWorkcenterCode.Size = new System.Drawing.Size(168, 29);
            this.cboWorkcenterCode.TabIndex = 3;
            // 
            // txtWorkerId
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerId.Appearance = appearance2;
            this.txtWorkerId.btnImgType = DC00_Component.SBtnTextEditor.ButtonImgTypeEnum.Type1;
            this.txtWorkerId.btnWidth = 26;
            this.txtWorkerId.Location = new System.Drawing.Point(555, 12);
            this.txtWorkerId.Name = "txtWorkerId";
            this.txtWorkerId.RequireFlag = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.RequirePop = DC00_Component.SBtnTextEditor.RequireFlagEnum.NO;
            this.txtWorkerId.Size = new System.Drawing.Size(146, 29);
            this.txtWorkerId.TabIndex = 4;
            // 
            // sLabel3
            // 
            appearance17.FontData.BoldAsString = "False";
            appearance17.FontData.UnderlineAsString = "False";
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance17;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(475, 18);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(74, 23);
            this.sLabel3.TabIndex = 5;
            this.sLabel3.Text = "(2) 작업자";
            // 
            // txtWorkerName
            // 
            appearance23.FontData.BoldAsString = "False";
            appearance23.FontData.UnderlineAsString = "False";
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.txtWorkerName.Appearance = appearance23;
            this.txtWorkerName.Location = new System.Drawing.Point(707, 12);
            this.txtWorkerName.Name = "txtWorkerName";
            this.txtWorkerName.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtWorkerName.Size = new System.Drawing.Size(138, 29);
            this.txtWorkerName.TabIndex = 6;
            // 
            // btnWorkerReg
            // 
            this.btnWorkerReg.Location = new System.Drawing.Point(861, 14);
            this.btnWorkerReg.Name = "btnWorkerReg";
            this.btnWorkerReg.Size = new System.Drawing.Size(128, 26);
            this.btnWorkerReg.TabIndex = 7;
            this.btnWorkerReg.Text = "작업자 등록";
            this.btnWorkerReg.UseVisualStyleBackColor = true;
            this.btnWorkerReg.Click += new System.EventHandler(this.btnWorkerReg_Click);
            // 
            // btnOrderSelect
            // 
            this.btnOrderSelect.Location = new System.Drawing.Point(33, 56);
            this.btnOrderSelect.Name = "btnOrderSelect";
            this.btnOrderSelect.Size = new System.Drawing.Size(135, 84);
            this.btnOrderSelect.TabIndex = 8;
            this.btnOrderSelect.Text = "(3) 작업지시 선택";
            this.btnOrderSelect.UseVisualStyleBackColor = true;
            this.btnOrderSelect.Click += new System.EventHandler(this.btnOrderSelect_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnLotInOut);
            this.ultraGroupBox1.Controls.Add(this.txtInLotNo);
            this.ultraGroupBox1.Controls.Add(this.sLabel4);
            this.ultraGroupBox1.Location = new System.Drawing.Point(188, 56);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(361, 98);
            this.ultraGroupBox1.TabIndex = 9;
            this.ultraGroupBox1.Text = "LOT 투입/취소";
            // 
            // btnLotInOut
            // 
            this.btnLotInOut.Location = new System.Drawing.Point(113, 58);
            this.btnLotInOut.Name = "btnLotInOut";
            this.btnLotInOut.Size = new System.Drawing.Size(242, 26);
            this.btnLotInOut.TabIndex = 11;
            this.btnLotInOut.Text = "(4) LOT 투입";
            this.btnLotInOut.UseVisualStyleBackColor = true;
            this.btnLotInOut.Click += new System.EventHandler(this.btnLotInOut_Click);
            // 
            // txtInLotNo
            // 
            appearance22.FontData.BoldAsString = "False";
            appearance22.FontData.UnderlineAsString = "False";
            appearance22.ForeColor = System.Drawing.Color.Black;
            this.txtInLotNo.Appearance = appearance22;
            this.txtInLotNo.Location = new System.Drawing.Point(113, 21);
            this.txtInLotNo.Name = "txtInLotNo";
            this.txtInLotNo.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtInLotNo.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtInLotNo.Size = new System.Drawing.Size(242, 29);
            this.txtInLotNo.TabIndex = 10;
            // 
            // sLabel4
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel4.Appearance = appearance1;
            this.sLabel4.DbField = null;
            this.sLabel4.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel4.Location = new System.Drawing.Point(6, 27);
            this.sLabel4.Name = "sLabel4";
            this.sLabel4.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel4.Size = new System.Drawing.Size(101, 23);
            this.sLabel4.TabIndex = 6;
            this.sLabel4.Text = "투입 LOT 번호";
            // 
            // btnRunStop
            // 
            this.btnRunStop.Location = new System.Drawing.Point(553, 69);
            this.btnRunStop.Name = "btnRunStop";
            this.btnRunStop.Size = new System.Drawing.Size(88, 73);
            this.btnRunStop.TabIndex = 12;
            this.btnRunStop.Text = "(5) 가동";
            this.btnRunStop.UseVisualStyleBackColor = true;
            this.btnRunStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // sLabel5
            // 
            appearance16.FontData.BoldAsString = "False";
            appearance16.FontData.UnderlineAsString = "False";
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.sLabel5.Appearance = appearance16;
            this.sLabel5.DbField = null;
            this.sLabel5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel5.Location = new System.Drawing.Point(647, 62);
            this.sLabel5.Name = "sLabel5";
            this.sLabel5.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel5.Size = new System.Drawing.Size(74, 23);
            this.sLabel5.TabIndex = 13;
            this.sLabel5.Text = "양품 수량";
            // 
            // txtProdQty
            // 
            appearance21.FontData.BoldAsString = "False";
            appearance21.FontData.UnderlineAsString = "False";
            appearance21.ForeColor = System.Drawing.Color.Black;
            this.txtProdQty.Appearance = appearance21;
            this.txtProdQty.Location = new System.Drawing.Point(727, 56);
            this.txtProdQty.Name = "txtProdQty";
            this.txtProdQty.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtProdQty.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtProdQty.Size = new System.Drawing.Size(138, 29);
            this.txtProdQty.TabIndex = 14;
            // 
            // txtBadQty
            // 
            appearance20.FontData.BoldAsString = "False";
            appearance20.FontData.UnderlineAsString = "False";
            appearance20.ForeColor = System.Drawing.Color.Black;
            this.txtBadQty.Appearance = appearance20;
            this.txtBadQty.Location = new System.Drawing.Point(727, 91);
            this.txtBadQty.Name = "txtBadQty";
            this.txtBadQty.RequireFlag = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtBadQty.RequirePop = DC00_Component.STextBox.RequireFlagEnum.NO;
            this.txtBadQty.Size = new System.Drawing.Size(138, 29);
            this.txtBadQty.TabIndex = 16;
            // 
            // sLabel6
            // 
            appearance3.FontData.BoldAsString = "False";
            appearance3.FontData.UnderlineAsString = "False";
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.sLabel6.Appearance = appearance3;
            this.sLabel6.DbField = null;
            this.sLabel6.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel6.Location = new System.Drawing.Point(647, 97);
            this.sLabel6.Name = "sLabel6";
            this.sLabel6.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel6.Size = new System.Drawing.Size(74, 23);
            this.sLabel6.TabIndex = 15;
            this.sLabel6.Text = "불량 수량";
            // 
            // btnProdReg
            // 
            this.btnProdReg.Location = new System.Drawing.Point(661, 125);
            this.btnProdReg.Name = "btnProdReg";
            this.btnProdReg.Size = new System.Drawing.Size(204, 26);
            this.btnProdReg.TabIndex = 17;
            this.btnProdReg.Text = "(6) 생산 실적 등록";
            this.btnProdReg.UseVisualStyleBackColor = true;
            this.btnProdReg.Click += new System.EventHandler(this.btnProdReg_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(871, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 101);
            this.button3.TabIndex = 18;
            this.button3.Text = "(7) 작업지시 종료";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // grid1
            // 
            this.grid1.AutoResizeColumn = true;
            this.grid1.AutoUserColumn = true;
            this.grid1.ContextMenuCopyEnabled = true;
            this.grid1.ContextMenuDeleteEnabled = true;
            this.grid1.ContextMenuExcelEnabled = true;
            this.grid1.ContextMenuInsertEnabled = true;
            this.grid1.ContextMenuPasteEnabled = true;
            this.grid1.DeleteButtonEnable = true;
            appearance4.BackColor = System.Drawing.SystemColors.Window;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance4;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance14;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)(((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance15;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance9.TextHAlignAsString = "Left";
            this.grid1.DisplayLayout.Override.HeaderAppearance = appearance9;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance12;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance10;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(6, 6);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1010, 310);
            this.grid1.TabIndex = 0;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.AfterRowActivate += new System.EventHandler(this.grid1_AfterRowActivate);
            // 
            // PP_ActureOutPut
            // 
            this.ClientSize = new System.Drawing.Size(1022, 483);
            this.Name = "PP_ActureOutPut";
            this.Text = "생산 실적 등록";
            this.Load += new System.EventHandler(this.PP_ActureOutPut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPLantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInLotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBadQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnProdReg;
        private DC00_Component.STextBox txtBadQty;
        private DC00_Component.SLabel sLabel6;
        private DC00_Component.STextBox txtProdQty;
        private DC00_Component.SLabel sLabel5;
        private System.Windows.Forms.Button btnRunStop;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.Button btnLotInOut;
        private DC00_Component.STextBox txtInLotNo;
        private DC00_Component.SLabel sLabel4;
        private System.Windows.Forms.Button btnOrderSelect;
        private System.Windows.Forms.Button btnWorkerReg;
        private DC00_Component.STextBox txtWorkerName;
        private DC00_Component.SLabel sLabel3;
        private DC00_Component.SBtnTextEditor txtWorkerId;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWorkcenterCode;
        private DC00_Component.SLabel sLabel2;
        private DC00_Component.SLabel sLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPLantCode;
        private DC00_Component.Grid grid1;
    }
}
