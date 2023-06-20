using DC00_assm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_PuMan;

namespace KDTB_FORMS
{
    public partial class WM_StockOut : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        public WM_StockOut()
        {
            InitializeComponent();

        }

        private void WM_StockOut_Load(object sender, EventArgs e)
        {
            // 폼이 실행 될때 처리하는 로직.

            // 1 번 그드 셋팅
            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "CHK",         "출고 등록",   GridColDataType_emu.CheckBox,    120, Infragistics.Win.HAlign.Left,  true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장",        GridColDataType_emu.VarChar,     120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPNO",      "상차번호",    GridColDataType_emu.VarChar,     160, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "SHIPDATE",    "상차일자",    GridColDataType_emu.VarChar,     140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARNO",       "차량번호",    GridColDataType_emu.VarChar,     140, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTCODE",    "거래처",      GridColDataType_emu.VarChar,     120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CUSTNAME",    "거래처명",    GridColDataType_emu.VarChar,     120, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "WORKER",      "상차자",      GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",    "등록일시",    GridColDataType_emu.DateTime24,  150, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",       "등록자",      GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",    "수정일시",    GridColDataType_emu.DateTime24,  150, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",      "수정자",      GridColDataType_emu.VarChar,     100, Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            
            // 2그리드 셋팅
            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE", "공장",         GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO",    "상차번호",     GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPSEQ",   "상차순번",     GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Center,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO",     "LOTNO",        GridColDataType_emu.VarChar,     160,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE",  "품목",         GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME",  "품목명",       GridColDataType_emu.VarChar,     150,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPQTY",   "상차수량",     GridColDataType_emu.Double,      100,  Infragistics.Win.HAlign.Right, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "UNITCODE",  "단위",         GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left, true, false);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            // 콤보박스 컨트롤, 그리드에 콤보박스 셋팅.
            #region ▶ COMBOBOX ◀
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid2, "UNITCODE", rtnDtTemp);

            #endregion

            // 거래처 팝업. 
            #region ▶ POP-UP ◀
            BizTextBoxManager btbManager = new BizTextBoxManager();
            btbManager.PopUpAdd(txtCustCode, txtCustName, "CUST_MASTER");
            #endregion

            
            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = "1000";
            #endregion
        }

        public override void  DoInquire()
        {
            // 제품 출고 내역 조회. 
            DBHelper helper = new DBHelper();
            try
            {
                _GridUtil.Grid_Clear(grid1); // 1번 그리드 삭제 
                _GridUtil.Grid_Clear(grid2); // 2번 그리드 삭제.

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sStartDate = string.Format("{0:yyyy-MM-dd}",dtpStart.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);
                string sCustCode  = txtCustCode.Text;
                string sShipNo    = txtShipNo.Text;
                string sCarNo     = txtCarNo.Text;

                DataTable dtTemp = helper.FillTable("SP00_WM_StockOutWM_S1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                                    , helper.CreateParameter("STARTDATE", sStartDate)
                                                    , helper.CreateParameter("ENDDATE",  sEndDate)
                                                    , helper.CreateParameter("CUSTCODE", sCustCode)
                                                    , helper.CreateParameter("SHIPNO",   sShipNo)
                                                    , helper.CreateParameter("CARNO",    sCarNo)
                                                   );

                grid1.DataSource = dtTemp; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            // 제품 출고 내역 조회. 
            DBHelper helper = new DBHelper();
            try
            {
                string sShipNo = Convert.ToString(grid1.ActiveRow.Cells["SHIPNO"].Value);

                DataTable dtTemp = helper.FillTable("SP00_WM_StockOutWM_S2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("SHIPNO", sShipNo)
                                                   );

                grid2.DataSource = dtTemp; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        public override void DoSave()
        {
            // 출고 등록을 위한 벨리데이션 체크 

            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                return;
            }

            // 거래처 가 같은 상차 실적 만 선택하였는지 확인.
            string sCustCode = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // 체크가 되어있는 첫 행의 거래처 코드 가져오기
                if (dt.Rows[i]["CHK"].ToString() == "1" && sCustCode == string.Empty)
                {
                    sCustCode = dt.Rows[i]["CARNO"].ToString();
                    continue;
                }
                else if (dt.Rows[i]["CHK"].ToString() == "1" && dt.Rows[i]["CARNO"].ToString() != sCustCode)
                {
                    MessageBox.Show("다른 차량 선택하였습니다.");
                    return;
                }
            } 

            // 출고 실적 데이터 등록 
            DBHelper helper = new DBHelper(true); // 트랜잭션 사용 DB Open
            try
            {
                string sTradingno = string.Empty; // 출하 실적 번호.
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // 선택 하지 않은 행 일 경우 continue
                    if (dt.Rows[i]["CHK"].ToString() == "0") continue;

                    helper.ExecuteNoneQuery("SP00_WM_StockOut_I1", CommandType.StoredProcedure
                                           , helper.CreateParameter("PLANTCODE", dt.Rows[i]["PLANTCODE"].ToString())
                                           , helper.CreateParameter("SHIPNO",    dt.Rows[i]["SHIPNO"].ToString())
                                           , helper.CreateParameter("TRADINGNO", sTradingno)
                                           , helper.CreateParameter("MAKER",     LoginInfo.UserID)
                                            );

                    if (helper.RSCODE != "S")
                    {
                        helper.Rollback();
                        MessageBox.Show(helper.RSMSG);
                        return;
                    }
                    sTradingno = helper.RSMSG; // 데이터베이스에서 채번한 출하실적 번호 할당.
                }
                helper.Rollback();
                MessageBox.Show("정상적으로 데이터를 등록 하였습니다.");
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

        }
    }  
}
