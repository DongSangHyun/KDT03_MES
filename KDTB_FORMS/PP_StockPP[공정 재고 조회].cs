#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_StockPP
//   Form Name    : 공정 재고 조회 및 원자재 출고 취소.
//   Name Space   : KDTB_FORMS
//   Created Date : 2023/05
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using System.Linq.Expressions;
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
    public partial class PP_StockPP : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public PP_StockPP()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void PP_StockPP_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",       "선택",        GridColDataType_emu.CheckBox,     80,  Infragistics.Win.HAlign.Center,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",        GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",        GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품목명",      GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",  "품목구분",    GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",     "LOTNO",       GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",  "재고수량",    GridColDataType_emu.Double,      100,  Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",        GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WHCODE",    "창고코드",    GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",     "입고자",      GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("ITEMTYPE");  // 품목구분
            Common.FillComboboxMaster(this.cboItemType, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp);


            // 품목코드 
            //FP  : 완제품
            //OM  : 외주가공품
            //R/M : 원자재
            //S/M : 부자재(H / W)
            //SFP : 반제품
            rtnDtTemp = Common.Get_ItemCode(new string[] { "ROH","FERT" });
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
                string sPlantCode  = DBHelper.nvlString(this.cboPlantCode.Value);
                string sItemCode   = DBHelper.nvlString(this.cboItemCode.Value);
                string sLotNo      = DBHelper.nvlString(txtLotNo.Text);
                string sItemType   = Convert.ToString(cboItemType.Value);

                rtnDtTemp = helper.FillTable("SP00_PP_StockPP_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",   sPlantCode)
                                    , helper.CreateParameter("ITEMCODE",    sItemCode)
                                    , helper.CreateParameter("LOTNO",       sLotNo)
                                    , helper.CreateParameter("ITEMTYPE",    sItemType)
                                    ); 

                ClosePrgForm();
                grid1.DataSource = rtnDtTemp;
                if (grid1.Rows.Count == 0)
                    ShowDialog("조회할 데이터 가 없습니다.");
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

        public override void DoSave()
        {
            _doSave();
        }


        private void _doSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt.Rows.Count == 0) return;

            if (ShowDialog("선택 한 원자재 를 생산 출고 등록 하시겠습니까?")
                == System.Windows.Forms.DialogResult.Cancel) return;

            // 출고 등록을 시작. 
            DBHelper helper = new DBHelper(true);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {


                    helper.ExecuteNoneQuery("SP00_PP_StockPP_U1", CommandType.StoredProcedure
                                            , helper.CreateParameter("@MATLOTNO", dr["MATLOTNO"])
                                            , helper.CreateParameter("@MAKER",    LoginInfo.UserID)
                                            );

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        ShowDialog(helper.RSMSG);
                        return;
                    }
                }
                helper.Commit();
                ShowDialog("정상적으로 출고 등록을 완료 하였습니다.");
                DoInquire();
            }
            catch(Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally 
            { 
                helper.Close();
            }

        }

        #endregion 
    }
}




