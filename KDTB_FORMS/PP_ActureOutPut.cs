using DC00_assm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using System.Security.AccessControl;
using DC00_PuMan;
using System.Linq.Expressions;
using Infragistics.Win.Design;
using System.Runtime.InteropServices.WindowsRuntime;
using DC_POPUP;
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_ActureOutPut
//   Form Name    : 생산 실적 등록
//   Name Space   : KDTB_FORMS
//   Created Date : 2023/05
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
namespace KDTB_FORMS
{
    public partial class PP_ActureOutPut : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _gridUtil = new UltraGridUtil();
        public PP_ActureOutPut()
        {
            InitializeComponent();
        }

        private void PP_ActureOutPut_Load(object sender, EventArgs e)
        {
            // 생산 실적 그리드 셋팅 
            _gridUtil.InitializeGrid(grid1);                                                                        
            _gridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",          GridColDataType_emu.VarChar,    120, HAlign.Left,  false, false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",        GridColDataType_emu.VarChar,    120, HAlign.Left,  false, false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장",        GridColDataType_emu.VarChar,    120, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호",  GridColDataType_emu.VarChar,    120, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "생산품목",      GridColDataType_emu.VarChar,    130, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",          GridColDataType_emu.VarChar,    150, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",       "지시수량",      GridColDataType_emu.Double,     100, HAlign.Right, true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",      GridColDataType_emu.Double,     100, HAlign.Right, true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",      GridColDataType_emu.Double,     100, HAlign.Right, true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",          GridColDataType_emu.VarChar,    100, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKSTATUSCODE", "가동비가동코드",GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKSTATUS",     "상태",          GridColDataType_emu.VarChar,    100, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "MATLOTNO",       "투입LOT",       GridColDataType_emu.VarChar,    150, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "COMPONENTQTY",   "투입잔량",      GridColDataType_emu.Double,     100, HAlign.Right, true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자코드",    GridColDataType_emu.VarChar,    100, HAlign.Left,  false, false);
            _gridUtil.InitColumnUltraGrid(grid1, "WORKERNAME",     "작업자",        GridColDataType_emu.VarChar,    100, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ORDERSTARTDATE", "지시시작일시",  GridColDataType_emu.DateTime24, 160, HAlign.Left,  true,  false);
            _gridUtil.InitColumnUltraGrid(grid1, "ORDERENDDATE",   "지시종료일시",  GridColDataType_emu.DateTime24, 160, HAlign.Left,  true,  false);
            _gridUtil.SetInitUltraGridBind(grid1);

            // 콤보박스 셋팅
            DataTable dtTemp = new DataTable();
            dtTemp = Common.StandardCODE("PLANTCODE");  // 공장
            Common.FillComboboxMaster(cboPLantCode, dtTemp);


            dtTemp = Common.StandardCODE("UNITCODE");  // 단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", dtTemp);

            dtTemp = Common.GET_Workcenter_Code(); // 작업장.
            Common.FillComboboxMaster(cboWorkcenterCode, dtTemp); 

            // 작업자 팝업
            BizTextBoxManager biztxt= new BizTextBoxManager();
            biztxt.PopUpAdd(txtWorkerId, txtWorkerName, "WORKER_MASTER");


            // 공장 기본값 셋팅
            cboPLantCode.Value = LoginInfo.PlantCode;
        }


        public override void DoInquire()
        {
            string sWorkcentercode = string.Empty;
            if (grid1.Rows.Count != 0 && grid1.ActiveRow != null)
            {
                sWorkcentercode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            }

            // 작업장의 현재 상태 조회
            DBHelper helper = new DBHelper();
            try
            {
                string sPlantcode      = Convert.ToString(cboPLantCode.Value);      // 공장
                string sWorkcenterCode = Convert.ToString(cboWorkcenterCode.Value); // 작업장

                DataTable dtTemp = helper.FillTable("SP00_PP_ActureOutput_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE",      sPlantcode)
                                                    , helper.CreateParameter("@WORKCENTERCODE", sWorkcenterCode)
                                                    ); 
                grid1.DataSource = dtTemp;
                if (grid1.Rows.Count ==0)
                {
                    ShowDialog("조회 할 데이터 가 없습니다.");
                    return;
                }
                 
                // 그리드에 데이터 가 조회 되었을 경우 그리드 수 만큼 돌면서 먼저 선택한 행을 찾는 로직.
                for (int i = 0; i < grid1.Rows.Count; i++)
                {
                    if (Convert.ToString(grid1.Rows[i].Cells["WORKCENTERCODE"].Value) == sWorkcentercode)
                    {
                        grid1.Rows[i].Activated = true;
                        return;
                    }
                }

                // 기존에 선택한 작업장 이 그리드에 표현되지 않았을떄  
                grid1.Rows[0].Activated = true;
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



        #region < 1. 작업자 등록 로직 >
        private void btnWorkerReg_Click(object sender, EventArgs e)
        {
            if (grid1.ActiveRow == null) return;
            string sWorkerId = txtWorkerId.Text; // 작업자 ID
            if (sWorkerId.Trim() == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다.");
                return;
            }

            DBHelper helper = new DBHelper(true);
            try
            {
                string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sWOrkcentercode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
                helper.ExecuteNoneQuery("SP00_PP_ActureOutput_I1", CommandType.StoredProcedure
                                            , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                            , helper.CreateParameter("@WORKCENTERCODE", sWOrkcentercode)
                                            , helper.CreateParameter("@WORKERID",       sWorkerId)
                                            );
                if (helper.RSCODE != "S")
                {
                    helper.Rollback();
                    ShowDialog("작업자 등록을 실패 하였습니다." + helper.RSMSG);
                    return;
                }

                helper.Commit();
                ShowDialog("작업자 등록을 완료 하였습니다.");
                DoInquire();
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
        #endregion

        #region < 2. 작업지시 선택 >
        private void btnOrderSelect_Click(object sender, EventArgs e)
        {
            // 선택한 작업장이 있는지 확인 
            if (grid1.Rows.Count == 0)   return;
            if (grid1.ActiveRow == null) return;

            // 작업자 등록 된 상태인지 확인.
            string sWorkerId = Convert.ToString(grid1.ActiveRow.Cells["WORKER"].Value);
            if (sWorkerId == "")
            {
                ShowDialog("작업자를 선택하지 않았습니다.\r\n작업자 등록 후 진행하세요");
                return;
            }
            string sWorkStatus = Convert.ToString(grid1.ActiveRow.Cells["WORKSTATUSCODE"].Value);
            if (sWorkStatus == "R")  // S : Stop , R : Run
            {
                ShowDialog("현재 작업장의 상태가 가동 중입니다.\r\n비가동 등록 후 진행하세요.");
                return;
            }
            string sMatlotno = Convert.ToString(grid1.ActiveRow.Cells["MATLOTNO"].Value);
            if (sMatlotno != "")
            {
                ShowDialog("현재 작업장의 투입 LOT 가 존재 합니다.\r\nLOT 투입 취소 후 진행하세요.");
                return;
            }

            // 작업지시 선택 팝업 호출. 
            string sWorkcenterCode = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERCODE"].Value);
            string sWorkcenterName = Convert.ToString(grid1.ActiveRow.Cells["WORKCENTERNAME"].Value);
            string sPlantCode      = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);


            POP_ORDERNO popOrderNo = new POP_ORDERNO(sWorkcenterCode, sWorkcenterName);
            popOrderNo.ShowDialog();
        }
        #endregion
    }
}

