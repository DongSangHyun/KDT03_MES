namespace KDTB_FORMS
{
    partial class PP_PrdErrorChart
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.UltraChart.Resources.Appearance.GradientEffect gradientEffect1 = new Infragistics.UltraChart.Resources.Appearance.GradientEffect();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            this.dtpEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.sLabel3 = new DC00_Component.SLabel();
            this.sLabel2 = new DC00_Component.SLabel();
            this.dtpStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.cboWorkcenterCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.sLabel1 = new DC00_Component.SLabel();
            this.cboPlantCode = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPlantCode = new DC00_Component.SLabel();
            this.chtProd = new Infragistics.Win.UltraWinChart.UltraChart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid1 = new DC00_Component.Grid(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ultraSplitter1 = new Infragistics.Win.Misc.UltraSplitter();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            this.gbxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.gbxBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtProd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Controls.Add(this.button1);
            this.gbxHeader.Controls.Add(this.dtpEnd);
            this.gbxHeader.Controls.Add(this.sLabel3);
            this.gbxHeader.Controls.Add(this.sLabel2);
            this.gbxHeader.Controls.Add(this.dtpStart);
            this.gbxHeader.Controls.Add(this.cboWorkcenterCode);
            this.gbxHeader.Controls.Add(this.sLabel1);
            this.gbxHeader.Controls.Add(this.cboPlantCode);
            this.gbxHeader.Controls.Add(this.lblPlantCode);
            this.gbxHeader.Size = new System.Drawing.Size(850, 69);
            // 
            // gbxBody
            // 
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Controls.Add(this.groupBox2);
            this.gbxBody.Controls.Add(this.ultraSplitter1);
            this.gbxBody.Controls.Add(this.groupBox1);
            this.gbxBody.Size = new System.Drawing.Size(850, 636);
            // 
            // dtpEnd
            // 
            this.dtpEnd.DateButtons.Add(dateButton1);
            this.dtpEnd.Location = new System.Drawing.Point(761, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.NonAutoSizeHeight = 26;
            this.dtpEnd.Size = new System.Drawing.Size(121, 26);
            this.dtpEnd.TabIndex = 205;
            // 
            // sLabel3
            // 
            appearance85.FontData.BoldAsString = "False";
            appearance85.FontData.UnderlineAsString = "False";
            appearance85.ForeColor = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            appearance85.TextVAlignAsString = "Middle";
            this.sLabel3.Appearance = appearance85;
            this.sLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel3.DbField = null;
            this.sLabel3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel3.Location = new System.Drawing.Point(743, 11);
            this.sLabel3.Name = "sLabel3";
            this.sLabel3.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel3.Size = new System.Drawing.Size(12, 23);
            this.sLabel3.TabIndex = 204;
            this.sLabel3.Text = "~";
            // 
            // sLabel2
            // 
            appearance5.FontData.BoldAsString = "False";
            appearance5.FontData.UnderlineAsString = "False";
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.sLabel2.Appearance = appearance5;
            this.sLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel2.DbField = null;
            this.sLabel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel2.Location = new System.Drawing.Point(527, 15);
            this.sLabel2.Name = "sLabel2";
            this.sLabel2.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel2.Size = new System.Drawing.Size(83, 23);
            this.sLabel2.TabIndex = 203;
            this.sLabel2.Text = "생산 일자";
            // 
            // dtpStart
            // 
            this.dtpStart.DateButtons.Add(dateButton2);
            this.dtpStart.Location = new System.Drawing.Point(616, 11);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.NonAutoSizeHeight = 26;
            this.dtpStart.Size = new System.Drawing.Size(121, 26);
            this.dtpStart.TabIndex = 202;
            // 
            // cboWorkcenterCode
            // 
            this.cboWorkcenterCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboWorkcenterCode.Location = new System.Drawing.Point(370, 13);
            this.cboWorkcenterCode.Name = "cboWorkcenterCode";
            this.cboWorkcenterCode.Size = new System.Drawing.Size(145, 27);
            this.cboWorkcenterCode.TabIndex = 200;
            // 
            // sLabel1
            // 
            appearance6.FontData.BoldAsString = "False";
            appearance6.FontData.UnderlineAsString = "False";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance6;
            this.sLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(281, 14);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(83, 23);
            this.sLabel1.TabIndex = 201;
            this.sLabel1.Text = "작업장";
            // 
            // cboPlantCode
            // 
            this.cboPlantCode.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cboPlantCode.Location = new System.Drawing.Point(119, 12);
            this.cboPlantCode.Name = "cboPlantCode";
            this.cboPlantCode.Size = new System.Drawing.Size(145, 27);
            this.cboPlantCode.TabIndex = 198;
            // 
            // lblPlantCode
            // 
            appearance2.FontData.BoldAsString = "False";
            appearance2.FontData.UnderlineAsString = "False";
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPlantCode.Appearance = appearance2;
            this.lblPlantCode.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.lblPlantCode.DbField = null;
            this.lblPlantCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPlantCode.Location = new System.Drawing.Point(30, 13);
            this.lblPlantCode.Name = "lblPlantCode";
            this.lblPlantCode.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.lblPlantCode.Size = new System.Drawing.Size(83, 23);
            this.lblPlantCode.TabIndex = 199;
            this.lblPlantCode.Text = "공장";
            // 
            // chtProd
            // 
            this.chtProd.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.chtProd.Axis.PE = paintElement1;
            this.chtProd.Axis.X.Extent = 33;
            this.chtProd.Axis.X.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.X.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtProd.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chtProd.Axis.X.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.X.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.X.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X.LineThickness = 1;
            this.chtProd.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.X.MajorGridLines.Visible = true;
            this.chtProd.Axis.X.Margin.Far.Value = 2D;
            this.chtProd.Axis.X.Margin.Near.Value = 2D;
            this.chtProd.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.X.MinorGridLines.Visible = false;
            this.chtProd.Axis.X.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.X.Visible = true;
            this.chtProd.Axis.X2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.X2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtProd.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chtProd.Axis.X2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtProd.Axis.X2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.X2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.X2.Labels.Visible = false;
            this.chtProd.Axis.X2.LineThickness = 1;
            this.chtProd.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.X2.MajorGridLines.Visible = true;
            this.chtProd.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.X2.MinorGridLines.Visible = false;
            this.chtProd.Axis.X2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.X2.Visible = false;
            this.chtProd.Axis.Y.Extent = 10;
            this.chtProd.Axis.Y.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Y.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtProd.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chtProd.Axis.Y.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Y.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Y.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtProd.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y.LineThickness = 1;
            this.chtProd.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Y.MajorGridLines.Visible = true;
            this.chtProd.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Y.MinorGridLines.Visible = false;
            this.chtProd.Axis.Y.TickmarkInterval = 40D;
            this.chtProd.Axis.Y.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.Y.Visible = true;
            this.chtProd.Axis.Y2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Y2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtProd.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chtProd.Axis.Y2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Y2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Y2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtProd.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Y2.Labels.Visible = false;
            this.chtProd.Axis.Y2.LineThickness = 1;
            this.chtProd.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Y2.MajorGridLines.Visible = true;
            this.chtProd.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Y2.MinorGridLines.Visible = false;
            this.chtProd.Axis.Y2.TickmarkInterval = 40D;
            this.chtProd.Axis.Y2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.Y2.Visible = false;
            this.chtProd.Axis.Z.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Z.Labels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtProd.Axis.Z.Labels.ItemFormatString = "";
            this.chtProd.Axis.Z.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Z.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Z.Labels.SeriesLabels.FontColor = System.Drawing.Color.DimGray;
            this.chtProd.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z.LineThickness = 1;
            this.chtProd.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Z.MajorGridLines.Visible = true;
            this.chtProd.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Z.MinorGridLines.Visible = false;
            this.chtProd.Axis.Z.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.Z.Visible = false;
            this.chtProd.Axis.Z2.Labels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Z2.Labels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtProd.Axis.Z2.Labels.ItemFormatString = "";
            this.chtProd.Axis.Z2.Labels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Z2.Labels.SeriesLabels.Font = new System.Drawing.Font("Verdana", 7F);
            this.chtProd.Axis.Z2.Labels.SeriesLabels.FontColor = System.Drawing.Color.Gray;
            this.chtProd.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z2.Labels.SeriesLabels.Layout.Behavior = Infragistics.UltraChart.Shared.Styles.AxisLabelLayoutBehaviors.Auto;
            this.chtProd.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtProd.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtProd.Axis.Z2.Labels.Visible = false;
            this.chtProd.Axis.Z2.LineThickness = 1;
            this.chtProd.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtProd.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Z2.MajorGridLines.Visible = true;
            this.chtProd.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtProd.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtProd.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtProd.Axis.Z2.MinorGridLines.Visible = false;
            this.chtProd.Axis.Z2.TickmarkStyle = Infragistics.UltraChart.Shared.Styles.AxisTickStyle.Smart;
            this.chtProd.Axis.Z2.Visible = false;
            this.chtProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chtProd.Border.Color = System.Drawing.Color.Gold;
            this.chtProd.Border.CornerRadius = 10;
            this.chtProd.Border.Raised = true;
            this.chtProd.Border.Thickness = 4;
            this.chtProd.ColorModel.AlphaLevel = ((byte)(150));
            this.chtProd.ColorModel.ColorBegin = System.Drawing.Color.Pink;
            this.chtProd.ColorModel.ColorEnd = System.Drawing.Color.DarkRed;
            this.chtProd.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.chtProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtProd.Effects.Effects.Add(gradientEffect1);
            this.chtProd.Location = new System.Drawing.Point(3, 23);
            this.chtProd.Name = "chtProd";
            this.chtProd.Size = new System.Drawing.Size(832, 287);
            this.chtProd.TabIndex = 0;
            this.chtProd.Tooltips.HighlightFillColor = System.Drawing.Color.DimGray;
            this.chtProd.Tooltips.HighlightOutlineColor = System.Drawing.Color.DarkGray;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chtProd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 313);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "작업장 기간별 생산/불량 현황";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(6, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(838, 294);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "기간별 생산 / 불량 현황";
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
            appearance29.BackColor = System.Drawing.SystemColors.Window;
            appearance29.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grid1.DisplayLayout.Appearance = appearance29;
            this.grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid1.DisplayLayout.DefaultSelectedBackColor = System.Drawing.Color.Empty;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grid1.DisplayLayout.GroupByBox.Hidden = true;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.grid1.DisplayLayout.MaxColScrollRegions = 1;
            this.grid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance36.BackColor = System.Drawing.SystemColors.Window;
            appearance36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grid1.DisplayLayout.Override.ActiveCellAppearance = appearance36;
            appearance43.BackColor = System.Drawing.SystemColors.Highlight;
            appearance43.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grid1.DisplayLayout.Override.ActiveRowAppearance = appearance43;
            this.grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.DisplayLayout.Override.AllowMultiCellOperations = ((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation)((((((((Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Copy | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.CopyWithHeaders) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Cut) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Delete) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Paste) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Undo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Redo) 
            | Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.Reserved)));
            this.grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance44.BackColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.CardAreaAppearance = appearance44;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            appearance57.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grid1.DisplayLayout.Override.CellAppearance = appearance57;
            this.grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grid1.DisplayLayout.Override.CellPadding = 0;
            appearance58.BackColor = System.Drawing.SystemColors.Control;
            appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance58.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance58.BorderColor = System.Drawing.SystemColors.Window;
            this.grid1.DisplayLayout.Override.GroupByRowAppearance = appearance58;
            this.grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance59.BackColor = System.Drawing.SystemColors.Window;
            appearance59.BorderColor = System.Drawing.Color.Silver;
            this.grid1.DisplayLayout.Override.RowAppearance = appearance59;
            this.grid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance61.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance61;
            this.grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grid1.DisplayLayout.SelectionOverlayBorderThickness = 2;
            this.grid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnterNextRowEnable = true;
            this.grid1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(3, 23);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(832, 268);
            this.grid1.TabIndex = 7;
            this.grid1.TabStop = false;
            this.grid1.Text = "grid1";
            this.grid1.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.grid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange;
            this.grid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 29);
            this.button1.TabIndex = 206;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ultraSplitter1
            // 
            this.ultraSplitter1.BackColor = System.Drawing.Color.White;
            this.ultraSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraSplitter1.Location = new System.Drawing.Point(6, 319);
            this.ultraSplitter1.Name = "ultraSplitter1";
            this.ultraSplitter1.RestoreExtent = 313;
            this.ultraSplitter1.Size = new System.Drawing.Size(838, 17);
            this.ultraSplitter1.TabIndex = 3;
            // 
            // PP_PrdErrorChart
            // 
            this.ClientSize = new System.Drawing.Size(850, 705);
            this.Name = "PP_PrdErrorChart";
            this.Load += new System.EventHandler(this.PP_PrdErrorChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            this.gbxHeader.ResumeLayout(false);
            this.gbxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.gbxBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWorkcenterCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPlantCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtProd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpEnd;
        private DC00_Component.SLabel sLabel3;
        private DC00_Component.SLabel sLabel2;
        private Infragistics.Win.UltraWinSchedule.UltraCalendarCombo dtpStart;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboWorkcenterCode;
        private DC00_Component.SLabel sLabel1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cboPlantCode;
        private DC00_Component.SLabel lblPlantCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Infragistics.Win.UltraWinChart.UltraChart chtProd;
        private DC00_Component.Grid grid1;
        private System.Windows.Forms.Button button1;
        private Infragistics.Win.Misc.UltraSplitter ultraSplitter1;
    }
}
