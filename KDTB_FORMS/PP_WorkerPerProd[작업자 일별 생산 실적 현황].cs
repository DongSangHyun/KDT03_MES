#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_WorkerPerProd
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
using DC00_PuMan;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
#endregion

namespace KDTB_FORMS
{
    public partial class PP_WorkerPerProd : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성
        string plantCode           = LoginInfo.PlantCode;
        #endregion


        #region < CONSTRUCTOR >
        public PP_WorkerPerProd()
        {
            InitializeComponent();
        }
        #endregion 

        #region < FORM EVENTS >
        private void PP_WorkerPerProd_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
                                                                   
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",       GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",         "작업자",     GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",     GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",   GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품번",       GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품명",       GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODDATE",       "생산일자",   GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Center, true, false);

            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",   GridColDataType_emu.Double,     100,  Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",   GridColDataType_emu.Double,     100,  Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALQTY",       "총생산수량", GridColDataType_emu.Double,     100,  Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADRATE",        "불량률",     GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",       "생산일시",   GridColDataType_emu.DateTime24, 150,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);


            // 그리드 병합 
            grid1.DisplayLayout.Override.MergedCellContentArea                     = MergedCellContentArea.VisibleRect;
            grid1.DisplayLayout.Bands[0].Columns["PLANTCODE"].MergedCellStyle      = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["WORKER"].MergedCellStyle         = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["WORKCENTERCODE"].MergedCellStyle = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["WORKCENTERNAME"].MergedCellStyle = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["ITEMCODE"].MergedCellStyle       = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["ITEMNAME"].MergedCellStyle       = MergedCellStyle.Always;
            grid1.DisplayLayout.Bands[0].Columns["PRODDATE"].MergedCellStyle       = MergedCellStyle.Always;

            #endregion



            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);
            #endregion

            #region ▶ POP-UP ◀
            // 작업자 팝업 
            BizTextBoxManager BizManager = new BizTextBoxManager();
            BizManager.PopUpAdd(txtWorkerId, txtWorkerName, "WORKER_MASTER");
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;
            dtStart_H.Value    = string.Format("{0:yyyy-MM-01}", DateTime.Now);
            #endregion
        }
        #endregion
 

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
                
                
                string sPlantCode = DBHelper.nvlString(this.cboPlantCode.Value);
                string sWorkerID  = Convert.ToString(txtWorkerId.Text);
                string sStartDate = string.Format("{0:yyyy-MM-dd}" ,dtStart_H.Value);
                string sSendDate  = string.Format("{0:yyyy-MM-dd}", dtEnd_H.Value);

                rtnDtTemp = helper.FillTable("SP00_PP_WorkerPerProd_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("@PLANTCODE",  sPlantCode)
                                    , helper.CreateParameter("@WORKERID",   sWorkerID)
                                    , helper.CreateParameter("@RSSTARTDATE",sStartDate)
                                    , helper.CreateParameter("@RSENDDATE",  sSendDate )
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

        private void grid1_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            // 
        }

        private void grid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            CustomMergedCellEvalutor CM1 = new CustomMergedCellEvalutor("WORKER", "WORKCENTERCODE");
            e.Layout.Bands[0].Columns["WORKCENTERNAME"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["ITEMCODE"].MergedCellEvaluator = CM1;
            e.Layout.Bands[0].Columns["ITEMNAME"].MergedCellEvaluator = CM1;
            
            CustomMergedCellEvalutor CM2 = new CustomMergedCellEvalutor("WORKCENTERCODE", "PRODDATE");
            e.Layout.Bands[0].Columns["PRODDATE"].MergedCellEvaluator = CM2;

        }
    }
}




