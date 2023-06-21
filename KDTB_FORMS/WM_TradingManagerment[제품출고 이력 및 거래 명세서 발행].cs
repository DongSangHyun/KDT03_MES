using DC00_assm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DC00_PuMan;
using DC00_WinForm;
using DC_POPUP;
using Telerik.Reporting;

namespace KDTB_FORMS
{
    public partial class WM_TradingManagerment : DC00_WinForm.BaseMDIChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성

        
        // 생성자 멤버 , 클래스가 객체화 될때 자동으로 실행되는 특수형태의 메서드 
        public WM_TradingManagerment()
        {
            InitializeComponent();

        } 

        private void WM_TradingManagerment_Load(object sender, EventArgs e)
        {
            // 폼이 실행 될때 처리하는 로직.

            #region ▶ GRID ◀
            _GridUtil.InitializeGrid(this.grid1);
            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE",   "공장",                      GridColDataType_emu.VarChar,     120,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADINGNO",   "출하실적번호(명세서번호)",  GridColDataType_emu.VarChar,     200,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "TRADINGDATE", "출고일자",                  GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "CARNO",       "차량번호",                  GridColDataType_emu.VarChar,     140,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",    "등록일시",                  GridColDataType_emu.DateTime24,  200,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",       "등록자",                    GridColDataType_emu.VarChar,     100,  Infragistics.Win.HAlign.Left,  true, false);
            _GridUtil.SetInitUltraGridBind(grid1);
            
            
            _GridUtil.InitializeGrid(this.grid2);
            _GridUtil.InitColumnUltraGrid(grid2, "PLANTCODE",  "공장",     GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGNO",  "명세번호", GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGSEQ", "명세순번", GridColDataType_emu.VarChar,     80,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPNO",     "상차번호", GridColDataType_emu.VarChar,    160,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "SHIPSEQ",    "상차순번", GridColDataType_emu.VarChar,     80,  Infragistics.Win.HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKER",     "상차자",   GridColDataType_emu.VarChar,    160,  Infragistics.Win.HAlign.Left,  false, false);
            _GridUtil.InitColumnUltraGrid(grid2, "WORKERNAME", "상차자",   GridColDataType_emu.VarChar,     80,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTCODE",   "거래처",   GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "CUSTNAME",   "거래처명", GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "LOTNO",      "LOTNO",    GridColDataType_emu.VarChar,    150,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMCODE",   "품목코드", GridColDataType_emu.VarChar,    120,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "ITEMNAME",   "품목명",   GridColDataType_emu.VarChar,    150,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "TRADINGQTY", "출고수량", GridColDataType_emu.Double,     100,  Infragistics.Win.HAlign.Right,  true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "BASEUNIT",   "단위",     GridColDataType_emu.VarChar,    100,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid2, "MAKEDATE",   "등록일시", GridColDataType_emu.DateTime24, 200,  Infragistics.Win.HAlign.Left,   true, false);
            _GridUtil.SetInitUltraGridBind(grid2);
            #endregion

            // 콤보박스 컨트롤, 그리드에 콤보박스 셋팅.
            #region ▶ COMBOBOX ◀
            Common _Common = new Common();
            DataTable rtnDtTemp = _Common.Standard_CODE("PLANTCODE");  // 사업장
            Common.FillComboboxMaster(this.cboPlantCode, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(this.grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = _Common.Standard_CODE("UNITCODE");     //단위
            UltraGridUtil.SetComboUltraGrid(this.grid2, "BASEUNIT", rtnDtTemp);

            #endregion
             
            
            #region ▶ ENTER-MOVE ◀
            cboPlantCode.Value = "1000";
            #endregion
        }

        public override void  DoInquire()
        {
            DBHelper helper = new DBHelper(false);

            try
            {
                _GridUtil.Grid_Clear(grid1);
                _GridUtil.Grid_Clear(grid2);

                string sPlantCode = Convert.ToString(cboPlantCode.Value);
                string sTradingNo = Convert.ToString(txtTradingno.Text);
                string sCarNo     = Convert.ToString(txtCarNo.Text);
                string sStartDate = string.Format("{0:yyyy-MM-dd}", dtpStart.Value);
                string sEndDate   = string.Format("{0:yyyy-MM-dd}", dtpEnd.Value);



                DataTable rtnDtTemp = helper.FillTable("SP00_WM_TradingManager_S1", CommandType.StoredProcedure
                                                             , helper.CreateParameter("PLANTCODE", sPlantCode)
                                                             , helper.CreateParameter("TRADINGNO", sTradingNo)
                                                             , helper.CreateParameter("CARNO",     sCarNo)
                                                             , helper.CreateParameter("STARTDATE", sStartDate)
                                                             , helper.CreateParameter("ENDDATE",   sEndDate) 
                                                             );
                if (rtnDtTemp.Rows.Count > 0)
                {
                    grid1.DataSource = rtnDtTemp;
                    grid1.DataBinds(rtnDtTemp);
                }
                else
                {
                    _GridUtil.Grid_Clear(grid1);
                    this.ShowDialog("조회할 데이터가 없습니다.", DialogForm.DialogType.OK);    // 조회할 데이터가 없습니다.
                    return;
                }
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

        private void grid1_AfterRowActivate(object sender, EventArgs e)
        {
            // 제품 출고 내역 조회. 
            DBHelper helper = new DBHelper();
            try
            {
                string sTrdingno  = Convert.ToString(grid1.ActiveRow.Cells["TRADINGNO"].Value);
                string sPlantCode = Convert.ToString(grid1.ActiveRow.Cells["PLANTCODE"].Value);

                DataTable dtTemp = helper.FillTable("SP00_WM_TradingManager_S2", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", sPlantCode)
                                                    , helper.CreateParameter("TRADINGNO", sTrdingno)
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

        private void button2_Click(object sender, EventArgs e)
        {
            DoInquire();
        }

        private void btnTradingPrint_Click(object sender, EventArgs e)
        {
            // 그리드 내역이 없을 경우 return
            if (grid1.ActiveRow == null)
            {
                return;
            }

            // 1. 선택한 출하실적 번호 에 대한 정보를 조회 (거래명세서에 표기할 내역)

            // DBHelper() : DBHelper 클래스에 있는 DBHelper() 생성자 멤버를 호출 하여 
            //              관련된 로직을 수행(필드 멤버(클래스의 전역변수) 의 초기화)
            // new        : DBHelper() 가 수행하는 클래스의 멤버들 을 Heap 영역에 배치하라.
            // =  : DBHelper  클래스에 대한 그릇 이름을 helper 라는 이름으로 Stack 영역에 배치해 두었으니
            //      new 를 통해 Heap 영역에 할당된 메모리 주소의 정보를 helper 에 전달하라.
            ReceiveClass(new DBHelper());
           ;


            // 2. 데이터를 거레명세서 레포트에 전달. 
            DBHelper helper = new DBHelper();
            try
            {
                string sPlantCode  = grid1.ActiveRow.Cells["PLANTCODE"].Value.ToString();
                string sTreadingNo = grid1.ActiveRow.Cells["TRADINGNO"].Value.ToString();
                DataTable dtTemp = helper.FillTable("SP00_WM_StockTrading_S3", CommandType.StoredProcedure
                                                    , helper.CreateParameter("@PLANTCODE", sPlantCode)
                                                    , helper.CreateParameter("@TRADINGNO", sTreadingNo)
                                                    );
                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("레포트 출력 할 데이터 가 없습니다.");
                    return;
                }

                // 3. 레포트 출력. 

                // 레포트 발행 매수 (업체의 갯수 확인)
                int iCustCNT = 1;                // 업체의 갯수 
                string sCustName = dtTemp.Rows[0]["CUSTNAME"].ToString(); ; // 고객사 이름.
                for (int i = 1; i < dtTemp.Rows.Count; i++)
                {
                    if (dtTemp.Rows[i]["CUSTNAME"].ToString() == sCustName)
                    {
                        continue;
                    }
                    else
                    {
                        sCustName = dtTemp.Rows[i]["CUSTNAME"].ToString();
                        ++iCustCNT;
                    }
                }

                // 거래처의 개수 별로 데이터 테이블을 생성. 
                DataTable[] dtCustArrays = new DataTable[iCustCNT];

                // 0 번째 있는 방에 Datatable 객체를 인스턴스화 하여 주소 전달. 
                dtCustArrays[0] = new DataTable();
                dtCustArrays[0] = dtTemp.Clone(); // 컬럼 의 구조 를 복제 한다. 

                sCustName = dtTemp.Rows[0]["CUSTNAME"].ToString(); ; // 고객사 이름.
                int iCustArrayIndex  = 0; // 거래처 배열의 index 주소

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                { 
                    // 추출한 데이터가 기존 거래처와 같다면 기존 데이터테이블 배열의 방에 누적
                    if (dtTemp.Rows[i]["CUSTNAME"].ToString() == sCustName)
                    {
                        dtCustArrays[iCustArrayIndex].ImportRow(dtTemp.Rows[i]);
                    }
                    else
                    {
                        // 새로운 거래처 를 추출 하였을 경우 새로운 데이터테이블에 누적. 
                        ++iCustArrayIndex;
                        dtCustArrays[iCustArrayIndex] = new DataTable(); // 방을 초기화
                        dtCustArrays[iCustArrayIndex] = dtTemp.Clone();  // 새로운 방에 기존 컬럼의 구조를 복사. 
                        dtCustArrays[iCustArrayIndex].ImportRow(dtTemp.Rows[i]);
                        sCustName = dtTemp.Rows[i]["CUSTNAME"].ToString();
                    }
                }

                // 출력 할 레포트 의 배열
                
                // 거래처 의 수 만큼 레포트 클래스를 배열
                Report_specification_on_transaction[] TradingPrint = new Report_specification_on_transaction[iCustCNT];

                // 레포트북. (레포트가 등록되어 출력 을 할 대상)
                ReportBook rpb = new ReportBook();

                // 거래처 의 수 만큼 반복 
                //  . 명세서 레포트 에 거래처의 데이터를 담는 로직 반복
                for(int i = 0; i < iCustCNT; i++) 
                {
                    TradingPrint[i] = new Report_specification_on_transaction();
                    // 명세서 레포트 i         = 거래처의 데이터 i
                    TradingPrint[i].DataSource = dtCustArrays[i];
                    rpb.Reports.Add(TradingPrint[i]);
                }
                // 레포트 미리보기 창. 
                ReportViewer RPV = new ReportViewer(rpb);
                RPV.ShowDialog();
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
        private void ReceiveClass(DBHelper helper)
        {

        }
    }  
}
