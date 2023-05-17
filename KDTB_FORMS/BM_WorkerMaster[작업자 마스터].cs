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

namespace KDTB_FORMS
{

    public partial class BM_WorkerMaster : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil(); // 그리드 셋팅 클래스.

        public BM_WorkerMaster()
        {
            InitializeComponent();
        }

        private void BM_WorkerMaster_Load(object sender, EventArgs e)
        {
            // 1. 그리드 셋팅
            
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",  "공장",     GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERID",   "사번",     GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKERNAME", "작업자명", GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "BANCODE",    "작업반",   GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "GRPID",      "그룹",     GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPTCODE",   "부서",     GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PHONENO",    "연락처",   GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "INDATE",     "입사일자", GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "OUTDATE",    "퇴사일자", GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",    "사용여부", GridColDataType_emu.VarChar,    130, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",   "등록일시", GridColDataType_emu.DateTime24, 130, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",      "등록자",   GridColDataType_emu.VarChar,    130, HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",   "수정일시", GridColDataType_emu.DateTime24, 130, HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",     "수정자",   GridColDataType_emu.VarChar,    130, HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid1);


            // 콤보박스 셋팅
            DataTable dtTemp = new DataTable();
            
            // 공장
            dtTemp = Common.StandardCODE("PLANTCODE");                  // 공통기준정보에서 데이터 가져오기.
            Common.FillComboboxMaster(cboPlantCode, dtTemp);            // 조회부 컨트롤 의 콤보박스 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", dtTemp); // 그리드 컬럼에 콤보박스 셋팅

            // 작업반
            dtTemp = Common.StandardCODE("BANCODE");                  // 공통기준정보에서 데이터 가져오기.
            Common.FillComboboxMaster(cboBanCode, dtTemp);            // 조회부 컨트롤 의 콤보박스 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "BANCODE", dtTemp); // 그리드 컬럼에 콤보박스 셋팅

            // 사용여부
            dtTemp = Common.StandardCODE("USEFLAG");                  // 공통기준정보에서 데이터 가져오기.
            Common.FillComboboxMaster(cboUserFlag, dtTemp);            // 조회부 컨트롤 의 콤보박스 셋팅.
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", dtTemp); // 그리드 컬럼에 콤보박스 셋팅

            //그룹
            dtTemp = Common.StandardCODE("GRPID");                  // 공통기준정보에서 데이터 가져오기.
            UltraGridUtil.SetComboUltraGrid(grid1, "GRPID", dtTemp); // 그리드 컬럼에 콤보박스 셋팅

            // 부서
            dtTemp = Common.StandardCODE("DEPTCODE");                  // 공통기준정보에서 데이터 가져오기.
            UltraGridUtil.SetComboUltraGrid(grid1, "DEPTCODE", dtTemp); // 그리드 컬럼에 콤보박스 셋팅
        }


        public override void DoInquire()
        {
            // 작업자 조회 
            string sPlantCode  = Convert.ToString(cboPlantCode.Value); // 공장
            string sWorkerId   = Convert.ToString(txtWorkerId.Text);   // 사번
            string sWorkerName = Convert.ToString(txtWorkerName.Text); // 작업자명
            string sBanCode     = Convert.ToString(cboBanCode.Value);   // 작업반
            string sUseFlag    = Convert.ToString(cboUserFlag.Value);  // 사용여부

            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid1); // 그리드 데이터 행 삭제.
                // database 에서 작업자 정보 조회
                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP00_BM_WorkerMaster_S1", CommandType.StoredProcedure
                                         , helper.CreateParameter("@PLANTCODE",  sPlantCode)
                                         , helper.CreateParameter("@WORKERID",   sWorkerId)
                                         , helper.CreateParameter("@WORKERNAME", sWorkerName)
                                         , helper.CreateParameter("@BANCODE",    sBanCode)
                                         , helper.CreateParameter("@USEFLAG",    sUseFlag));
                grid1.DataSource = dtTemp;
                if (grid1.Rows.Count == 0)
                {
                    ClosePrgForm(); // 프로그레스 상태 창 닫기 
                    ShowDialog("조회 할 데이터가 없습니다."); 
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
            // 새로운 행 생성 
            grid1.InsertRow();

            // 기본값 셋팅.
            grid1.ActiveRow.Cells["PLANTCODE"].Value = LoginInfo.PlantCode;              // 공장
            grid1.ActiveRow.Cells["GRPID"].Value   = "SW";                               // 그룹
            grid1.ActiveRow.Cells["USEFLAG"].Value = "Y";                                // 사용여부
            grid1.ActiveRow.Cells["INDATE"].Value = DateTime.Now.ToString("yyyy-MM-dd"); // 입사일자

            // 수정 불가 컬럼 셋팅
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
                // 변경된 이력이 담긴 테이블에 있는 행을 하나씩 추출.
                foreach(DataRow row in dt.Rows)
                {
                   switch(row.RowState)
                    {
                        case DataRowState.Deleted:
                            row.RejectChanges();
                            helper.ExecuteNoneQuery("SP00_BM_WorkerMaster_D1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE", Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@WORKERID",  Convert.ToString(row["WORKERID"])));
                            break;

                        case DataRowState.Added:
                            helper.ExecuteNoneQuery("SP00_BM_WorkerMaster_I1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE",  Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@WORKERID",   Convert.ToString(row["WORKERID"]))
                                                     , helper.CreateParameter("@WORKERNAME", Convert.ToString(row["WORKERNAME"]))
                                                     , helper.CreateParameter("@BANCODE",    Convert.ToString(row["BANCODE"]))
                                                     , helper.CreateParameter("@GRPID",      Convert.ToString(row["GRPID"]))
                                                     , helper.CreateParameter("@DEPTCODE",   Convert.ToString(row["DEPTCODE"]))
                                                     , helper.CreateParameter("@PHONENO",    Convert.ToString(row["PHONENO"]))
                                                     , helper.CreateParameter("@INDATE",     Convert.ToString(row["INDATE"]))
                                                     , helper.CreateParameter("@OUTDATE",    Convert.ToString(row["OUTDATE"]))
                                                     , helper.CreateParameter("@USEFLAG",    Convert.ToString(row["USEFLAG"]))
                                                     , helper.CreateParameter("@MAKER",      LoginInfo.UserID));

                            break;

                        case DataRowState.Modified:
                            helper.ExecuteNoneQuery("SP00_BM_WorkerMaster_U1", CommandType.StoredProcedure
                                                     , helper.CreateParameter("@PLANTCODE",  Convert.ToString(row["PLANTCODE"]))
                                                     , helper.CreateParameter("@WORKERID",   Convert.ToString(row["WORKERID"]))
                                                     , helper.CreateParameter("@WORKERNAME", Convert.ToString(row["WORKERNAME"]))
                                                     , helper.CreateParameter("@BANCODE",    Convert.ToString(row["BANCODE"]))
                                                     , helper.CreateParameter("@GRPID",      Convert.ToString(row["GRPID"]))
                                                     , helper.CreateParameter("@DEPTCODE",   Convert.ToString(row["DEPTCODE"]))
                                                     , helper.CreateParameter("@PHONENO",    Convert.ToString(row["PHONENO"]))
                                                     , helper.CreateParameter("@INDATE",     Convert.ToString(row["INDATE"]))
                                                     , helper.CreateParameter("@OUTDATE",    Convert.ToString(row["OUTDATE"]))
                                                     , helper.CreateParameter("@USEFLAG",    Convert.ToString(row["USEFLAG"]))
                                                     , helper.CreateParameter("@EDITOR",     LoginInfo.UserID));

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

