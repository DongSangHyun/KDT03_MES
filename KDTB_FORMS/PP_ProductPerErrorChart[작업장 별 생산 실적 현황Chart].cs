using DC00_assm;
using DC00_PuMan;
using DC00_WinForm;
using Infragistics.UltraChart.Resources.Appearance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KDTB_FORMS
{
    public partial class PP_PrdErrorChart : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성 
        public PP_PrdErrorChart()
        {
            InitializeComponent();
        }

        private void PP_PrdErrorChart_Load(object sender, EventArgs e)
        {
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",        "공장",        GridColDataType_emu.VarChar, 120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERCODE",   "작업장 코드", GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKCENTERNAME",   "작업장 명",   GridColDataType_emu.VarChar, 140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "PRODQTY",          "생산수량",    GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORQTY",         "불량수량",    GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "ERRORRATE",        "불량률",      GridColDataType_emu.VarChar, 100, Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            #endregion

            DataTable rtnDtTemp = new DataTable();
            #region ▶ COMBOBOX ◀
            rtnDtTemp = Common.StandardCODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.GET_Workcenter_Code();     //작업장
            Common.FillComboboxMaster(this.cboWorkcenterCode, rtnDtTemp);

            #endregion 

            // 현재 월 의 1일 부터
            dtpStart.Value = string.Format("{0:yyyy-MM-01}", DateTime.Now);

            // 차트 초기화
            _DoSetChartInit();
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
                _GridUtil.Grid_Clear(grid1);
                string sPlantCode      = DBHelper.nvlString(this.cboPlantCode.Value);
                string sWOrkcenterCode = DBHelper.nvlString(this.cboWorkcenterCode.Value);
                string sStartDate      = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate        = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value); 

                DataTable rtnDtTemp = helper.FillTable("SP00_PP_ProductPerErrorChar_S2", CommandType.StoredProcedure
                                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                    , helper.CreateParameter("@WORKCENTERCODE", sWOrkcenterCode)
                                    , helper.CreateParameter("@STARTDATE",      sStartDate)
                                    , helper.CreateParameter("@ENDDATE",        sEndDate)
                                    );

                ClosePrgForm();
                grid1.DataSource = rtnDtTemp;
                if (grid1.Rows.Count == 0)
                {
                    ShowDialog("조회할 데이터 가 없습니다.");
                    return;
                }

              

                rtnDtTemp = helper.FillTable("SP00_PP_ProductPerErrorChar_S1", CommandType.StoredProcedure
                                    , helper.CreateParameter("@PLANTCODE",      sPlantCode)
                                    , helper.CreateParameter("@WORKCENTERCODE", sWOrkcenterCode)
                                    , helper.CreateParameter("@STARTDATE",      sStartDate)
                                    , helper.CreateParameter("@ENDDATE",        sEndDate)
                                    );
                chtProd.DataSource = rtnDtTemp;

                for (int i = 0; i < rtnDtTemp.Rows.Count; i++)
                {
                    chtProd.ColumnChart.ChartText.Add(new ChartTextAppearance());
                    chtProd.ColumnChart.ChartText[i].ItemFormatString = "<DATA_VALUE:0>";
                    chtProd.ColumnChart.ChartText[i].Row    = -2;
                    chtProd.ColumnChart.ChartText[i].Column = -2;
                    chtProd.ColumnChart.ChartText[i].VerticalAlign = StringAlignment.Far;
                    chtProd.ColumnChart.ChartText[i].Visible = true;
                    chtProd.ColumnChart.ChartText[i].ChartTextFont = new Font("맑은 고딕", 10F);
                }


            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString(), DialogForm.DialogType.OK);
            }
            finally
            {
                helper.Close();
            }
        }


        #region < METHOD >
        /// <summary>
        /// 조회 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DoInquire();
        }

        /// <summary>
        /// 차트의 기본 데이터 셋팅 ( 초기화 )
        /// </summary>
        private void _DoSetChartInit()
        {
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("WORNCENTERNAME", typeof(string));
            dtTemp.Columns.Add("양품", typeof(int));
            dtTemp.Columns.Add("불량", typeof(int));
            dtTemp.Rows.Add(new object[] {"작업장",0,0});
            chtProd.DataSource= dtTemp;
        } 
        #endregion
    }
}
