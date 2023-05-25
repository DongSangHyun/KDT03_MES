#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : PP_STockWIP
//   Form Name    : 재공 재고 조회
//   Name Space   : KDTB_FORMS
//   Created Date : 2022/08
//   Made By      : DSH
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Data;
using DC00_PuMan;

using DC00_assm;
using DC00_WinForm;

using Infragistics.Win.UltraWinGrid;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
#endregion

namespace KDTB_FORMS
{
    public partial class AP_OrderPerProduct : DC00_WinForm.BaseMDIChildForm
    {

        #region < MEMBER AREA >
        DataTable rtnDtTemp        = new DataTable(); // 
        UltraGridUtil _GridUtil    = new UltraGridUtil();  //그리드 객체 생성 
        string plantCode           = LoginInfo.PlantCode;

        #endregion


        #region < CONSTRUCTOR >
        public AP_OrderPerProduct()
        {
            InitializeComponent();
        }
        #endregion


        #region < FORM EVENTS >
        private void AP_OrderPerProduct_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",      "공장",         GridColDataType_emu.VarChar,     120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERNO",        "작업지시번호", GridColDataType_emu.VarChar,     140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",       "품목",         GridColDataType_emu.VarChar,     140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",       "품목명",       GridColDataType_emu.VarChar,     140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE", "작업장",       GridColDataType_emu.VarChar,     120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME", "작업장명",     GridColDataType_emu.VarChar,     150, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERQTY",       "지시수량",     GridColDataType_emu.Double,       80, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",       "단위",         GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERDATE",      "지시일자",     GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",        "양품수량",     GridColDataType_emu.Double,      100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "BADQTY",         "불량수량",     GridColDataType_emu.Double,      100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALPRODQTY",   "총생산수량",   GridColDataType_emu.Double,      100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ACTRATE",        "지시달성율",   GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "FIRSTSTARTDATE", "지시시작일시", GridColDataType_emu.DateTime24,  160, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ORDERCLOSEDATE", "지시종료일시", GridColDataType_emu.DateTime24,  160, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TOTALRUNTIME",   "총운영시간(분)",   GridColDataType_emu.Integer,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp );

            rtnDtTemp = Common.GET_Workcenter_Code();     //작업장
            Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp );

            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode, txtItemName, "ITEM_MASTER");
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = plantCode;

            // 현재 월 의 1일 부터
            dtpStart.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);

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
                string sPlantCode      = Convert.ToString(cboPlantCode.Value);
                string sWorkcenterCode = Convert.ToString(cboWorkcenterCode.Value);
                string sOrderrNo       = Convert.ToString(txtOrderNo.Text);
                string sItemCode       = Convert.ToString(txtItemCode.Text);
                string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);


                rtnDtTemp = helper.FillTable("SP00_AP_OrderPerProd_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE",     sPlantCode )                  
                                                                   , helper.CreateParameter("@WORKCENTERCODE",sWorkcenterCode)
                                                                   , helper.CreateParameter("@ORDERRNO",      sOrderrNo)
                                                                   , helper.CreateParameter("@ITEMCODE",      sItemCode)
                                                                   , helper.CreateParameter("@STARTDATE",     sStartDate)
                                                                   , helper.CreateParameter("@ENDDATE",       sEndDate)
                                                                   );
                this.ClosePrgForm();
                this.grid1.DataSource = rtnDtTemp;
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
        #endregion
    }
}




