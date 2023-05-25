#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WCTRunStopList_T
//   Form Name    : 작업장 비가동 현황 및 사유관리
//   Name Space   : KDTB_FORMS
//   Created Date : 2020/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC_POPUP;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDTB_FORMS
{
    public partial class PP_WCTRunStopList_T : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        string plantCode           = LoginInfo.PlantCode;
        #endregion


        #region < CONSTRUCTOR >
        public PP_WCTRunStopList_T()
        {
            InitializeComponent();
        }
        #endregion 

        #region < FORM EVENTS >
        private void PP_WCTRunStopList_T_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",                 GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSEQ",          "작업장지시별 순번",    GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left, false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",               GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",             GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호",         GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목코드",             GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",                 GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자",               GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUS",         "가동/비가동",          GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,   false, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STATUSNAME",     "가동/비가동",          GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSSTARTDATE",    "시작일시",             GridColDataType_emu.VarChar,    150,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "RSENDDATE",      "종료일시",             GridColDataType_emu.VarChar,    150,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TIMEDIFF",       "소요시간(분)",         GridColDataType_emu.Double,      90,  Infragistics.Win.HAlign.Right,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",             GridColDataType_emu.Double,      80,  Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",             GridColDataType_emu.Double,      80,  Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",         "사유",                 GridColDataType_emu.VarChar,    250,  Infragistics.Win.HAlign.Left,    true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",          "등록자",               GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "등록일시",             GridColDataType_emu.DateTime24, 150,  Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",         "수정자",               GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",       "수정일시",             GridColDataType_emu.DateTime24, 150,  Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1); 

            #endregion



            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.GET_Workcenter_Code();  //작업장
            Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp);


            rtnDtTemp = Common.GET_StopList();
            UltraGridUtil.SetComboUltraGrid(this.grid1, "REMARK", rtnDtTemp);
            #endregion

            #region ▶ POP-UP ◀
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            dtStart_H.Value    = string.Format("{0:yyyy-MM-01}", DateTime.Now);
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
                string sWorkcenterCode = DBHelper.nvlString(this.cboWorkcenterCode.Value);
                string sStartDate      = string.Format("{0:yyyy-MM-dd}" ,dtStart_H.Value);
                string sSendDate       = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);

                rtnDtTemp = helper.FillTable("PP_WCTRunStopList_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("PLANTCODE",      sPlantCode        )
                                    , helper.CreateParameter("WORKCENTERCODE", sWorkcenterCode   )
                                    , helper.CreateParameter("RSSTARTDATE",    sStartDate        )
                                    , helper.CreateParameter("RSENDDATE",      sSendDate         )
                                    );

               this.ClosePrgForm();
                if (rtnDtTemp.Rows.Count != 0)
                {
                    this.grid1.DataSource = rtnDtTemp;
                }
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
        /// ToolBar의 저장 버튼 Click
        /// </summary>
        public override void DoSave()
        {
            this.grid1.UpdateData();
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return; 
            DBHelper helper = new DBHelper(true);
            try
            {  
                if (this.ShowDialog("비가동 사유를 등록 하시겠습니까 ?") == System.Windows.Forms.DialogResult.Cancel)
                {
                    CancelProcess = true;
                    return;
                }

                base.DoSave();

                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제 
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                             
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정 
                            helper.ExecuteNoneQuery("PP_WCTRunStopList_T_U1", CommandType.StoredProcedure
                                                  , helper.CreateParameter("PLANTCODE",      Convert.ToString(drRow["PLANTCODE"])       )
                                                  , helper.CreateParameter("WORKCENTERCODE", Convert.ToString(drRow["WORKCENTERCODE"])  )
                                                  , helper.CreateParameter("ORDERNO",        Convert.ToString(drRow["ORDERNO"])         )
                                                  , helper.CreateParameter("RSSEQ",          Convert.ToInt32(drRow["RSSEQ"])            )
                                                  , helper.CreateParameter("REMARK",         Convert.ToString(drRow["REMARK"])          )
                                                  , helper.CreateParameter("EDITOR",         LoginInfo.UserID                           )
                                                  );


                            #endregion
                            break;
                    }
                }
                if (helper.RSCODE != "S")
                {
                    this.ClosePrgForm();
                    helper.Rollback();
                    this.ShowDialog(helper.RSMSG, DialogForm.DialogType.OK);
                    return;
                }
                helper.Commit();
                this.ClosePrgForm();
                this.ShowDialog("데이터가 저장 되었습니다.", DialogForm.DialogType.OK);    
                DoInquire();
            }
            catch (Exception ex)
            {
                CancelProcess = true;
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




