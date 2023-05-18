#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : MM_StockOut
//   Form Name    : 자재 생산 출고 등록
//   Name Space   : KDTB_FORMS
//   Created Date : 2023/05
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;
using DC00_assm;
using DC00_Component;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Telerik.Reporting;
#endregion

namespace KDTB_FORMS
{
    public partial class MM_StockOut : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public MM_StockOut()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void MM_StockOut_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",       "선택",     GridColDataType_emu.CheckBox,     80,  Infragistics.Win.HAlign.Center,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",     GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",    "입고일자", GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",     GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품목명",   GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",  "LOTNO",    GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",  "재고수량", GridColDataType_emu.Double,      100,  Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",     GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",    "창고코드", GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MKAER",     "입고자",   GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);

            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
            rtnDtTemp = Common.Get_ItemCode(new string[] { "ROH" });
            Common.FillComboboxMaster(this.cboItemCode, rtnDtTemp);

            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            #endregion
        }
        #endregion


        #region < TOOL BAR AREA >
        public override void DoInquire()
        {
            DoFind();
        }
        private void DoFind()
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                base.DoInquire();
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sItemCode       = DBHelper.nvlString(this.cboItemCode.Value);
                string sLotNo          = DBHelper.nvlString(txtLotNo.Text);

                rtnDtTemp = helper.FillTable("SP00_MM_StockOut_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode)
                                    , helper.CreateParameter("ITEMCODE",    sItemCode)
                                    , helper.CreateParameter("LOTNO",       sLotNo)
                                    );
                //

                // 
                // 
                ClosePrgForm();
                grid1.DataSource = rtnDtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(),DialogForm.DialogType.OK);    
            }
            finally
            {
                helper.Close();
            }
        }
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()
        {
            
        }
        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {   
           
        }
        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
        }

        #endregion

        private void btnBarcodePrint_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count == 0) return;
            DataRow drRow = ((DataTable)grid1.DataSource).NewRow();
            drRow["ITEMCODE"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMCODE"].Value);
            drRow["ITEMNAME"] = Convert.ToString(grid1.ActiveRow.Cells["ITEMNAME"].Value);
            drRow["MATLOTNO"] = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            drRow["UNITCODE"] = Convert.ToString(grid1.ActiveRow.Cells["UNITCODE"].Value);
            drRow["STOCKQTY"] = Convert.ToString(grid1.ActiveRow.Cells["STOCKQTY"].Value);

            // 원자재 식별표 바코드 디자인 객체 (페이지)
            Report_LotBacodeROH ROH_Barcode = new Report_LotBacodeROH();

            // 페이지를 담을 레포트 북
            ReportBook reportBook= new ReportBook();

            // 바코드 디자인 에 데이터 바인딩. (페이지)
            ROH_Barcode.DataSource = drRow;

            // 레포트 북에 페이지 담기
            reportBook.Reports.Add(ROH_Barcode);

            // 레포트 뷰어 에 출력물 미리 보기 
            ReportViewer RPV = new ReportViewer(reportBook,1);
            RPV.ShowDialog();
        }

    }
}




