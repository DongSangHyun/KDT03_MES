using DC00_assm;
using DC00_Component;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*************************************************************************************
 * 화면 ID  : MM_MaterialOrderIn
 * 작성자   : 동상현
 * 작성일자 : 2023-05-17
 * 설명     : 구매 자재 발주 등록 및 입고 등록 (관리)
 * ***********************************************************************************
 * 수정 이력 : 
 * 
 * 
 **************************************************************************************/


namespace KDTB_FORMS
{

    public partial class MM_MaterialOrderIn : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil(); // 그리드 셋팅 클래스.

        public MM_MaterialOrderIn()
        {
            InitializeComponent();
        }

        private void MM_MaterialOrderIn_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅
            
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",      GridColDataType_emu.VarChar,       130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PONO",       "발주번호",  GridColDataType_emu.VarChar,       130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",   "품목",      GridColDataType_emu.VarChar,       200, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PODATE",     "발주일자",  GridColDataType_emu.YearMonthDay,  100, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "POQTY",      "발주수량",  GridColDataType_emu.Double,        100, HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",   "단위",      GridColDataType_emu.VarChar,       100, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",   "거래처",    GridColDataType_emu.VarChar,       180, HAlign.Left,   true, true);
                                                                                                               
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",        "입고등록",  GridColDataType_emu.CheckBox,       80, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INQTY",      "입고수량",  GridColDataType_emu.Double,        100, HAlign.Right,  true, true);
                                                                                                               
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",      "LOT번호",   GridColDataType_emu.VarChar,       150, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",     "입고일자",  GridColDataType_emu.VarChar,       100, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "INWORKER",   "입고자",    GridColDataType_emu.VarChar,       100, HAlign.Left,   true, false);
            
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "등록일시", GridColDataType_emu.DateTime24,     130, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "등록자",   GridColDataType_emu.VarChar,        130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",   "수정일시", GridColDataType_emu.DateTime24,     130, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",     "수정자",   GridColDataType_emu.VarChar,        130, HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid1);


            // 콤보박스 셋팅
            DataTable dtTemp = new DataTable();
            
            // 공장
            dtTemp = Common.StandardCODE("PLANTCODE");                   
            Common.FillComboboxMaster(cboPlantCode, dtTemp);             
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); 

            // 협력업체
            dtTemp = Common.GET_Cust_Code("V"); // 협력 업체만 콤보박스에 세팅.
            Common.FillComboboxMaster(cboCustCode, dtTemp);              
            UltraGridUtil.SetComboUltraGrid(grid1, "CUSTCODE", dtTemp);  
                                                                         
            //단위                                                       
            dtTemp = Common.StandardCODE("UNITCODE");                    
            UltraGridUtil.SetComboUltraGrid(grid1, "UNITCODE", dtTemp);  
                                                                         
            // 발주 품목                                                 
            dtTemp = Common.Get_ItemCode(new string[] { "ROH" });        
            Common.FillComboboxMaster(cboItemCode, dtTemp);              
            UltraGridUtil.SetComboUltraGrid(grid1, "ITEMCODE", dtTemp);

            // 입출고 일자 기본 날짜 선택
            dtpStart.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);
        }


        public override void DoInquire()
        {
            // 구매자재 발주 및 입고 내역 조회
            string sPlantCode  = Convert.ToString(cboPlantCode.Value);           // 공장
            string sCustCode   = Convert.ToString(cboCustCode.Value);            // 거래처
            string sStartDate  = string.Format("{0:yyyy-MM-dd}", dtpStart.Value); // 입출 시작일자
            string sEndDate    = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);   // 입출 종료일자
            string sPono       = Convert.ToString(txtPono.Text);                 // 발주번호
            string sItemCode   = Convert.ToString(cboItemCode.Value);            // 품목 코드
            
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid1); // 그리드 데이터 행 삭제.
                // database 에서 작업자 정보 조회
                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP00_MM_MaterialOrderIn_S1", CommandType.StoredProcedure
                                         , helper.CreateParameter("@PLANTCODE",  sPlantCode)
                                         , helper.CreateParameter("@CUSTCODE",   sCustCode)
                                         , helper.CreateParameter("@STARTDATE",  sStartDate)
                                         , helper.CreateParameter("@ENDDATE",    sEndDate)
                                         , helper.CreateParameter("@PONO",       sPono)
                                         , helper.CreateParameter("@ITEMCODE",   sItemCode)
                                         );
                grid1.DataSource = dtTemp;
                if (grid1.Rows.Count == 0)
                {
                    ClosePrgForm(); // 프로그레스 상태 창 닫기 
                    ShowDialog("조회 할 데이터가 없습니다."); 
                }

                for (int i = 0; i <grid1.Rows.Count; i++)
                {
                    // 수정 불가 컬럼 셋팅
                    grid1.Rows[i].Cells["PONO"].Activation     = Activation.NoEdit;
                    grid1.Rows[i].Cells["MAKEDATE"].Activation = Activation.NoEdit;
                    grid1.Rows[i].Cells["MAKER"].Activation    = Activation.NoEdit;
                    grid1.Rows[i].Cells["EDITDATE"].Activation = Activation.NoEdit;
                    grid1.Rows[i].Cells["EDITOR"].Activation   = Activation.NoEdit;
                }
            }
            catch (Exception ex)
            {
                ShowDialog(ex.Message);
            }
            finally
            { 
                helper.Close(); 
            }
        }

        public override void DoNew()
        {
            // 새로운 행 생성 (구매자재 발주 내역 등록을 위한 추가)
            grid1.InsertRow();

            // 기본값 셋팅.
            grid1.ActiveRow.Cells["PLANTCODE"].Value = LoginInfo.PlantCode;              // 공장
            grid1.ActiveRow.Cells["PODATE"].Value    = DateTime.Now.ToString("yyyy-MM-dd"); // 발주일자

            // 수정 불가 컬럼 셋팅
            grid1.ActiveRow.Cells["PONO"].Activation     = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["MAKER"].Activation    = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            grid1.ActiveRow.Cells["EDITOR"].Activation   = Activation.NoEdit;

        }

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoSave()
        {
            // 저장 버튼 클릭. 

            // 1. 변경된 이력이 있는 행을 데이터 테이블에 담기
            DataTable dt = grid1.chkChange();
            if (dt.Rows.Count == 0) return;

            // 저장 하시겠습니까 ? 
            if (ShowDialog("변경된 데이터를 저장 하시겠습니까?") == DialogResult.Cancel)
            {
                return;
            }

            DBHelper helper = new DBHelper(true);
            try
            {
                string sMessage = string.Empty; // 필수 입력 항목 체크
                // 변경된 이력이 담긴 테이블에 있는 행을 하나씩 추출.
                foreach(DataRow row in dt.Rows)
                {
                   switch(row.RowState)
                    {
                        case DataRowState.Deleted:
                            // 발주 내역 취소
                            row.RejectChanges();
                            helper.ExecuteNoneQuery("SP00_MM_MaterialOrderIn_D1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE", Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@PONO",     Convert.ToString(row["PONO"])));
                            break;

                        case DataRowState.Added:
                            // 신규 발주 등록 

                            // 필수 입력 항목 체크 (품목, 발주 수량, 거래처 미 입력 시 저장 안됨)
                            if (Convert.ToString(row["ITEMCODE"]) == "") sMessage += "품목 ";
                            if (Convert.ToString(row["POQTY"])    == "") sMessage += "수량 ";
                            if (Convert.ToString(row["CUSTCODE"]) == "") sMessage += "거래처 ";
                            if (sMessage != "")
                            {
                                helper.Rollback();
                                ShowDialog(sMessage + " 을(를) 입력하지 않았습니다.");
                                return;
                            }

                            helper.ExecuteNoneQuery("SP00_MM_MaterialOrderIn_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE",  Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@ITEMCODE",   Convert.ToString(row["ITEMCODE"]))
                                                     , helper.CreateParameter("@PODATE",     Convert.ToString(row["PODATE"]))
                                                     , helper.CreateParameter("@POQTY",      Convert.ToString(row["POQTY"]).Replace(",",""))
                                                     , helper.CreateParameter("@UNITCODE",   Convert.ToString(row["UNITCODE"]))
                                                     , helper.CreateParameter("@CUSTCODE",   Convert.ToString(row["CUSTCODE"]))
                                                     , helper.CreateParameter("@MAKER",      LoginInfo.UserID));

                            break;

                        case DataRowState.Modified:
                            // 입고 등록 
                            helper.ExecuteNoneQuery("SP00_MM_MaterialOrderIn_U1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE",  Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@PONO",       Convert.ToString(row["PONO"]))
                                                     , helper.CreateParameter("@INQTY",      Convert.ToString(row["INQTY"]).Replace(",",""))
                                                     , helper.CreateParameter("@INWORKER", LoginInfo.UserID));// SSS

                            break; 
                    }
                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        ShowDialog($"등록중 오류가 발생하였습니다.\r\n {helper.RSMSG}");
                        return; 
                    }
                }

                helper.Commit();
                ShowDialog("정상적으로 등록 되었습니다.");
                DoInquire(); // 등록된 데이터 재 조회.
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
    }

}

