using DC00_assm;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace KDTB_FORMS
{
    public partial class AP_ProdPlan : DC00_WinForm.BaseMDIChildForm
    {
        private UltraGridUtil _GridUtil = new UltraGridUtil();
        public AP_ProdPlan()
        {
            InitializeComponent();
        }

        private void AP_ProdPlan_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",     GridColDataType_emu.VarChar, 120, HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANNO",    "계획번호", GridColDataType_emu.VarChar, 120, HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",     GridColDataType_emu.VarChar, 200, HAlign.Left,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANQTY",   "계획수량", GridColDataType_emu.Integer, 100, HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",     GridColDataType_emu.VarChar,  80,  HAlign.Left, true, true);


            _GridUtil.InitColumnUltraGrid(grid1, "CHK",            "확정",          GridColDataType_emu.CheckBox,    80, HAlign.Left,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",        GridColDataType_emu.VarChar,    120, HAlign.Left, true,  true);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시 번호", GridColDataType_emu.VarChar,    150, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERTEMP",      "확정일시",      GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false); 
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERWORKER",    "확정자",        GridColDataType_emu.VarChar,     80, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEFLAG", "지시종료여부",  GridColDataType_emu.VarChar,    120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEDATE", "지시종료일시",  GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",          "등록자",        GridColDataType_emu.VarChar,    120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "등록일시",      GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false); 
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",         "수정자",        GridColDataType_emu.VarChar,    120, HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",       "수정일시",      GridColDataType_emu.DateTime24, 150, HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);

            // 2. 콤보박스 셋팅. 

            // 공장 콤보박스 셋팅.
            DataTable dtTemp = Common.StandardCODE("PLANTCODE");         // 공통기준정보 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             // 콤보박스 에 선택 데이터 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드 컬럼에 콤보박스 셋팅.

            // 종료 여부 콤보박스 셋팅
            dtTemp = Common.StandardCODE("YESNO");                            // 공통기준정보 데이터 가져오기.
            Common.FillComboboxMaster(cboCloseFlag, dtTemp);                  // 콤보박스 에 선택 데이터 셋팅
            UltraGridUtil.SetComboUltraGrid(grid1, "ORDERCLOSEFLAG", dtTemp); // 그리드 컬럼에 콤보박스 셋팅.

            // 품목 정보 콤보 박스에 셋팅
            // FERT : 완제품 , ROH : 원자재 ,   HALB : 반제품. 
            dtTemp = Common.Get_ItemCode(new string[] { "FERT"});
            Common.FillComboboxMaster(cboItemCode, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp);

            // 작업장 정보 콤보박스 셋팅
            dtTemp = Common.GET_Workcenter_Code();    // 작업장 : workcentercode
            Common.FillComboboxMaster(cboWorkceter, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "WORKCENTERCODE", dtTemp);

            // 그리드 콤보박스에 단위 셋팅
            dtTemp = Common.StandardCODE("UNITCODE");  // 단위 : UNITCODE
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);
        }

        public override void DoInquire()
        {
            // 조회 버튼 클릭 
            DBHelper helper = new DBHelper();
            try
            {
                string sPlantCode      = Convert.ToString(cboPlantCode.Value); // 공장
                string sWorkcenterCode = Convert.ToString(cboWorkceter.Value); // 작업장
                string sOrderNo        = Convert.ToString(txtOrderNo.Text);    // 작업지시번호
                string sOrderCloseFlag = Convert.ToString(cboCloseFlag.Value); // 종료여부
                string sItemCode       = Convert.ToString(cboItemCode.Value);  // 품목코드

                // 그리드 행 삭제 후 조회
                _GridUtil.Grid_Clear(grid1);


                DataTable dtTemp = helper.FillTable("SP00_AP_ProdPlan_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                                    , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                                    , helper.CreateParameter("@ORDERNO",        sOrderNo)
                                                    , helper.CreateParameter("@ORDERCLOSEFLAG", sOrderCloseFlag)
                                                    , helper.CreateParameter("@ITEMCODE",       sItemCode));
                if (dtTemp.Rows.Count == 0) 
                {
                    ShowDialog("조회할 데이터가 없습니다.");
                    return;
                }
                grid1.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
            finally
            { 
                helper.Close(); 
            }
        }
        public override void DoNew()
        {
            grid1.InsertRow();

            // 공장의 기본값을 로그인한 사용자의 공장으로 셋팅.
            grid1.ActiveRow.Cells["PLANTCODE"].Value     = LoginInfo.PlantCode;
            
            grid1.ActiveRow.Cells["PLANNO"].Activation   = Activation.NoEdit;

            grid1.ActiveRow.Cells["MAKER"].Activation    = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation   = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;

        }

        public override void DoDelete()
        {
            // 삭제 버튼을 클릭 하였을때 
            
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            // 초기화 이후 변경된 내역이 있는 행을 추출 
            DataTable dt = grid1.chkChange();
            if (dt.Rows.Count == 0) return;

            if (ShowDialog("데이터를 저장 하시겠습니까?") == DialogResult.Cancel) return;

            // 필수 입력 값을 찾는 변수.
            string sMessage = string.Empty;
            DBHelper helper = new DBHelper(true);
            try
            {
                foreach(DataRow row in dt.Rows)
                {
                    switch (row.RowState)
                    {
                        case DataRowState.Added:
                            // 생산 계획을 편성 하는 SQL  
                            // 먼저 체크 해야하는 항목 ?  품목, 수량.
                            // 둘중 하나라도 입력을하지 않았을경우 : rollback , return 
                            if (Convert.ToString(row["ITEMCODE"]) == "") sMessage += "품목 ";
                            if (Convert.ToString(row["PLANQTY"]) == "") sMessage += "수량 ";
                            if (sMessage != "")
                            {
                                helper.Rollback();
                                ShowDialog(sMessage + "(을)를 입력하지 않았습니다.");
                                return;
                            }
                            helper.ExecuteNoneQuery("SP00_AP_ProdPlan_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", row["PLANTCODE"])
                                                    , helper.CreateParameter("@ITEMCODE", row["ITEMCODE"])
                                                    , helper.CreateParameter("@PLANQTY", Convert.ToString(row["PLANQTY"]).Replace(",", ""))
                                                    , helper.CreateParameter("@UNITCODE", row["UNITCODE"])
                                                    , helper.CreateParameter("@MAKER", LoginInfo.UserID));

                            break;
                        case DataRowState.Modified:
                            // 확정 체크박스 체크 상태 확인
                            string sCheckFlag = "N";
                            if (Convert.ToString(row["CHK"]) == "1") sCheckFlag = "Y";

                            if (Convert.ToString(row["WORKCENTERCODE"]) == "")
                            {
                                helper.Rollback();
                                ShowDialog("작업장 을 입력하지 않았습니다.");
                                return;
                            }

                            // 작업지시 확정 또는 취소 로직. sCheckFlag = 'Y' 인경우 : 확정 , sCheckFlag = 'N' : 확정 취소 
                            helper.ExecuteNoneQuery("SP00_AP_ProdPlan_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE",      row["PLANTCODE"])
                                                    , helper.CreateParameter("@PLANNO",         row["PLANNO"])
                                                    , helper.CreateParameter("@WORKCENTERCODE", row["WORKCENTERCODE"])
                                                    , helper.CreateParameter("@CHECKFLAG",      sCheckFlag)
                                                    , helper.CreateParameter("@EDITOR",         LoginInfo.UserID)
                                                    );

                            break;
                        case DataRowState.Deleted:
                            row.RejectChanges(); // 삭제 된 내역을 원상복구 
                            // 생산 계획 편성 내역을 취소 하고자 할때
                            if (Convert.ToString(row["ORDERNO"]) != "")
                            {
                                helper.Rollback();
                                ShowDialog("작업지시 가 확정된 데이터 는 취소 할 수 없습니다.\r\n재조회후 진행하세요.");
                                return;
                            }
                            helper.ExecuteNoneQuery("SP00_AP_ProdPlan_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE" , row["PLANTCODE"])
                                                    , helper.CreateParameter("@PLANNO",     row["PLANNO"])
                                                    );
                            break;
                    }

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        ShowDialog("데이터 저장 중 오류 가 발생하였습니다.\r\n" + helper.RSMSG);
                        return;
                    }
                }

                helper.Commit();
                ShowDialog("정상적으로 등록을 완료하였습니다.");
                DoInquire(); //재조회
            }
            catch (Exception ex)
            {
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally 
            {
                helper.Close(); 
            }
        }
    }
}
