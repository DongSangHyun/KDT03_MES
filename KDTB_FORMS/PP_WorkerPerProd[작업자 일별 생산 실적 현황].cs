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
using System.Drawing;
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

               this.ClosePrgForm(); // 상태 창 닫기 
                if (rtnDtTemp.Rows.Count != 0)
                {
                    DataTable dtSubTotal = new DataTable();
                    dtSubTotal = rtnDtTemp.Clone(); // 참조형식인 DataTable 클래스를 깊은복사 기능.

                    double dGPordQty  = 0;
                    double dGBadQty   = 0;
                    double dGTotalQty = 0;

                    // 데이터의 기준 
                    string sWorkerId = Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]);
                    double dProdQty  = Convert.ToDouble(rtnDtTemp.Rows[0]["PRODQTY"]);
                    double dBadQty   = Convert.ToDouble(rtnDtTemp.Rows[0]["BADQTY"]);
                    double dTotalQty = Convert.ToDouble(rtnDtTemp.Rows[0]["TOTALQTY"]);


                    dtSubTotal.Rows.Add(new object[]
                    {
                        Convert.ToString(rtnDtTemp.Rows[0]["PLANTCODE"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["WORKER"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERCODE"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["WORKCENTERNAME"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["ITEMCODE"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["ITEMNAME"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["PRODDATE"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["PRODQTY"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["BADQTY"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["TOTALQTY"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["BADRATE"]),
                        Convert.ToString(rtnDtTemp.Rows[0]["MAKEDATE"])
                    });

                    for (int i = 1; i < rtnDtTemp.Rows.Count; i++)
                    {
                        if (sWorkerId == Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]))
                        {
                            dProdQty += Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                            dBadQty += Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                            dTotalQty += Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]);


                            dtSubTotal.Rows.Add(new object[]
                                                {
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PRODDATE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PRODQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["BADQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["TOTALQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["BADRATE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"])
                                                }); 
                        }
                        else
                        {
                            dGPordQty  += dProdQty;
                            dGBadQty   += dBadQty;
                            dGTotalQty += dTotalQty;

                            // 작업자 ID 가 다른경우
                            dtSubTotal.Rows.Add(new object[]
                            {
                                "","","","","","","합 계 : ", dProdQty,dBadQty,dTotalQty,Convert.ToString(Math.Round((dBadQty * 100 /dTotalQty),1) + " %"), null
                            });
                            dProdQty  = Convert.ToDouble(rtnDtTemp.Rows[i]["PRODQTY"]);
                            dBadQty   = Convert.ToDouble(rtnDtTemp.Rows[i]["BADQTY"]);
                            dTotalQty = Convert.ToDouble(rtnDtTemp.Rows[i]["TOTALQTY"]);

                            sWorkerId = Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]);
                            dtSubTotal.Rows.Add(new object[]
                                                {
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PLANTCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKER"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["WORKCENTERNAME"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["ITEMCODE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["ITEMNAME"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PRODDATE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["PRODQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["BADQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["TOTALQTY"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["BADRATE"]),
                                                    Convert.ToString(rtnDtTemp.Rows[i]["MAKEDATE"])
                                                });
                        }
                    }
                    dGPordQty  += dProdQty;
                    dGBadQty   += dBadQty;
                    dGTotalQty += dTotalQty;
                    // 반복문이 종료 되었을때 마지막 합계 추가
                    dtSubTotal.Rows.Add(new object[]
                     {
                          "","","","","","","합 계 : ", dProdQty,dBadQty,dTotalQty,Convert.ToString(Math.Round((dBadQty * 100 /dTotalQty),1) + " %"), null
                     });


                    dtSubTotal.Rows.Add(new object[]
                    {
                          "","","","","","","총 합계 :", dGPordQty,dGBadQty,dGTotalQty,Convert.ToString(Math.Round((dGBadQty * 100 /dGTotalQty),1) + " %"), null
                    });

                    this.grid1.DataSource = dtSubTotal;
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
                // 행에 특정 데이터 가 처리 될 경우 
                if (Convert.ToString(e.Row.Cells["PRODDATE"].Value) == "합 계 : ")
                {
                    e.Row.Appearance.BackColor = Color.Azure;
                }
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




