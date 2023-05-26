using DC00_assm;
using DC00_PuMan;
using DC00_WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDTB_FORMS
{
    public partial class WM_StockWm : DC00_WinForm.BaseMDIChildForm
    {

        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        public WM_StockWm()
        {
            InitializeComponent();
        }

        private void WM_StockWm_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1); 
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",      GridColDataType_emu.VarChar,  120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMCODE",  "품목",      GridColDataType_emu.VarChar,  140, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMNAME",  "품목명",    GridColDataType_emu.VarChar,  140, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ITEMTYPE",  "품목구분",  GridColDataType_emu.VarChar,  120, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "LOTNO",     "LOTNO",     GridColDataType_emu.VarChar,  150, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOCKQTY",  "재고수량",  GridColDataType_emu.Double,   100, Infragistics.Win.HAlign.Right,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "UNITCODE",  "단위",      GridColDataType_emu.VarChar,  100, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPFLAG",  "상차여부",  GridColDataType_emu.VarChar,  100, Infragistics.Win.HAlign.Left,    true, false);
            _GridUtil.SetInitUltraGridBind(grid1);


            _GridUtil.InitializeGrid(this.grid2); 
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장",      GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO",     "LOTNO",     GridColDataType_emu.VarChar,    150, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE",  "품목",      GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME",  "품목명",    GridColDataType_emu.VarChar,    140, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "RECDATE",   "입출일자",  GridColDataType_emu.VarChar,    120, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTCODE", "입출유형",  GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTFLAG", "입출구분",  GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "INOUTQTY",  "입출수량",  GridColDataType_emu.Double,     100, Infragistics.Win.HAlign.Right,true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE",  "단위",      GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE",  "입출일시",  GridColDataType_emu.DateTime24, 160, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKER",     "일출고자",  GridColDataType_emu.VarChar,    100, Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);

            #endregion

            #region ▶ COMBOBOX ◀
            DataTable rtnDtTemp = new DataTable();
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp );
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp );


            rtnDtTemp = Common.StandardCODE("ITEMTYPE");  // 품목구분
            UltraGridUtil.SetComboUltraGrid(this.grid1, "ITEMTYPE", rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("UNITCODE");  // 단위
            UltraGridUtil.SetComboUltraGrid(this.grid1, "UNITCODE", rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("INOUTCODE");  // 입출 유형
            UltraGridUtil.SetComboUltraGrid(this.grid2, "INOUTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("INOUTFLAG");  // 입출 구분
            UltraGridUtil.SetComboUltraGrid(this.grid2, "INOUTFLAG", rtnDtTemp);


            rtnDtTemp = Common.StandardCODE("YESNO");  // 상차 여부
            UltraGridUtil.SetComboUltraGrid(this.grid1, "SHIPFLAG", rtnDtTemp);
            #endregion

            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtItemCode_H, txtItemName_H, "ITEM_MASTER");
            #endregion

            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = LoginInfo.PlantCode;
            #endregion 
        }


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
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
                string sItemCode  = DBHelper.nvlString(this.txtItemCode_H.Text);
                string sLotNo     = DBHelper.nvlString(txtLotNo.Text);

               DataTable rtnDtTemp = helper.FillTable("SP00_WM_StockWM_S1", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode)                  
                                                                   , helper.CreateParameter("@LOTNO",     sLotNo    )
                                                                   , helper.CreateParameter("@ITEMCODE",  sItemCode )
                                                                   , helper.CreateParameter("@STARTDATE", sStartDate)
                                                                   , helper.CreateParameter("@ENDDATE",   sEndDate)
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            DBHelper helper = new DBHelper(false);
            try
            {
                _GridUtil.Grid_Clear(grid2);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);
                string sLotNo     = Convert.ToString(grid1.ActiveRow.Cells["LOTNO"].Value);

                DataTable rtnDtTemp = helper.FillTable("SP00_WM_StockWM_S2", CommandType.StoredProcedure
                                                                   , helper.CreateParameter("@PLANTCODE", sPlantCode)                  
                                                                   , helper.CreateParameter("@LOTNO",     sLotNo    )
                                                                   );
                 this.grid2.DataSource = rtnDtTemp;
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
    }
}
