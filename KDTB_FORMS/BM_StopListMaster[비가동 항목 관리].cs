#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   Form ID      : BM_StopListMaster
//   Form Name    : 비가동관리
//   Name Space   : DC_BM
//   Created Date : 2012-6-12 
//   Made By      :  
//   Description  : 
// *---------------------------------------------------------------------------------------------*
#endregion

#region < USING AREA >
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using DC00_assm;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System.Configuration; 
using Infragistics.Win;
#endregion

namespace KDTB_FORMS
{
    public partial class BM_StopListMaster : DC00_WinForm.BaseMDIChildForm
    {
        #region < MEMBER AREA >
        DataTable rtnDtTemp = new DataTable();  // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil(); 

        private string plantCode = LoginInfo.PlantCode; //plantcode default 설정
        private bool inquire = false;
        #endregion

        #region < CONSTRUCTOR >
        public BM_StopListMaster()
        {
            InitializeComponent(); 
        }
        #endregion

        #region < FORM LOAD >
        private void BM_StopListMaster_Load(object sender, EventArgs e)
        {
            #region [ Grid1 셋팅 ] 
            _GridUtil.InitializeGrid(grid1);

            _GridUtil.InitColumnUltraGrid(grid1, "PLANTCODE", "공장",        GridColDataType_emu.VarChar, 140,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPCODE",  "비가동코드",  GridColDataType_emu.VarChar, 120,  HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "STOPNAME",  "비가동명",    GridColDataType_emu.VarChar, 200,  HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "REMARK",    "비고",        GridColDataType_emu.VarChar, 200,  HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USEFLAG",   "사용여부",    GridColDataType_emu.VarChar, 90,   HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKER",     "등록자",      GridColDataType_emu.VarChar, 100,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE",  "등록일자",    GridColDataType_emu.VarChar, 140,  HAlign.Center, true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR",    "수정자",      GridColDataType_emu.VarChar, 100,  HAlign.Left,   true, false);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITDATE",  "수정일자",    GridColDataType_emu.VarChar, 140,  HAlign.Center, true, false);

            _GridUtil.SetInitUltraGridBind(grid1);
             
            #endregion



            #region [ 콤보박스 ] 
            rtnDtTemp = Common.StandardCODE("PLANTCODE");     // PLANTCODE
            Common.FillComboboxMaster(cboPlantCode_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "PLANTCODE", rtnDtTemp);

            rtnDtTemp = Common.StandardCODE("USEFLAG");     //사용여부
            Common.FillComboboxMaster(cboUseFlag_H, rtnDtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "USEFLAG", rtnDtTemp);

            #endregion

            cboPlantCode_H.Value = plantCode;

            // 그리드 팝업 버튼 설정.
            grid1.PopUpColumnListAdd("ITEMCODE");

        }
        #endregion

        #region < TOOL BAR AREA >

        /// <summary>
        /// ToolBar의 출력 버튼 클릭
        /// </summary>
        //public override void DoReport()
        //{
        //    base.DoReport();

        //    System.Drawing.Rectangle bounds = this.Parent.Bounds;
        //    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(bounds.Width, bounds.Height);
        //    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
        //    {
        //        g.CopyFromScreen(new Point(this.Parent.Location.X + 2, this.Parent.Location.Y + 23), System.Drawing.Point.Empty, new Size(bounds.Size.Width - 4, bounds.Height - 33));
        //    }

        //    System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
        //    pd.PrintPage += (sender, args) =>
        //    {
        //        Image i = bitmap;
        //        Rectangle m = args.MarginBounds;
        //        if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
        //        {
        //            m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
        //        }
        //        else
        //        {
        //            m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
        //        }
        //        args.Graphics.DrawImage(i, m);
        //    };
        //    pd.Print();
        //}
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper();
            try
            { 
                string sPlantcode = Convert.ToString(cboPlantCode_H.Value);
                string sUseflag  = Convert.ToString(cboUseFlag_H.Value);
                string sStopcode = Convert.ToString(txtStopCode.Text);
                string sStopName = Convert.ToString(txtStopName.Text);


                DataTable dtTemp = new DataTable();
                dtTemp = helper.FillTable("SP00_BM_StopListMaster_S1", CommandType.StoredProcedure
                                           , helper.CreateParameter("PLANTCODE", sPlantcode)
                                           , helper.CreateParameter("STOPCODE", sStopcode)
                                           , helper.CreateParameter("STOPNAME", sStopName)
                                           , helper.CreateParameter("USEFLAG", sUseflag));
                grid1.DataSource = dtTemp; 
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
        /// <summary>
        /// ToolBar의 신규 버튼 클릭
        /// </summary>
        public override void DoNew()  
        {
            try
            {
                //if (inquire == false) return;
                base.DoNew();
                this.grid1.InsertRow();

                grid1.SetDefaultValue("PLANTCODE", LoginInfo.PlantCode);
                grid1.SetDefaultValue("USEFLAG", "Y");

                grid1.ActiveRow.Cells["MAKER"].Activation    = Activation.NoEdit;
                grid1.ActiveRow.Cells["MAKEDATE"].Activation = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITOR"].Activation   = Activation.NoEdit;
                grid1.ActiveRow.Cells["EDITDATE"].Activation = Activation.NoEdit;
            }
            catch (Exception ex)
            {
                ShowDialog(ex.ToString());
            }
        }

        /// <summary>
        /// ToolBar의 삭제 버튼 Click
        /// </summary>
        public override void DoDelete()
        {
            base.DoDelete();
            grid1.DeleteRow();
        }

        /// <summary>
        /// ToolBar의 저장 버튼 Click
        /// </summary>

        #endregion

        #region < EVENT AREA >

        public override void DoSave()
        {
            DataTable dt = grid1.chkChange();
            if (dt == null)
                return;
            DBHelper helper = new DBHelper(true);


            try
            {
                if (ShowDialog("C:Q00009") == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                foreach (DataRow drRow in dt.Rows)
                {
                    switch (drRow.RowState)
                    {
                        case DataRowState.Deleted:
                            #region 삭제
                            drRow.RejectChanges();

                            helper.ExecuteNoneQuery("SP00_BM_StopListMaster_D1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("STOPCODE",  Convert.ToString(drRow["STOPCODE"])));
                            #endregion
                            break;
                        case DataRowState.Added:
                            #region 추가
                            if (Convert.ToString(drRow["STOPCODE"]) == string.Empty) throw new Exception("비가동 코드 를 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("SP00_BM_StopListMaster_I1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]))
                                                    , helper.CreateParameter("STOPCODE",  Convert.ToString(drRow["STOPCODE"]) )
                                                    , helper.CreateParameter("STOPNAME",  Convert.ToString(drRow["STOPNAME"]) )
                                                    , helper.CreateParameter("USEFLAG",   Convert.ToString(drRow["USEFLAG"]) )
                                                    , helper.CreateParameter("REMARK",    Convert.ToString(drRow["REMARK"]) )
                                                    , helper.CreateParameter("MAKER",     LoginInfo.UserID ));
                            #endregion
                            break;
                        case DataRowState.Modified:
                            #region 수정
                            if (Convert.ToString(drRow["STOPCODE"]) == string.Empty) throw new Exception("비가동 코드 를 입력하지 않았습니다.");

                            helper.ExecuteNoneQuery("SP00_BM_StopListMaster_U1", CommandType.StoredProcedure
                                                    , helper.CreateParameter("PLANTCODE", Convert.ToString(drRow["PLANTCODE"]) )
                                                    , helper.CreateParameter("STOPCODE",  Convert.ToString(drRow["STOPCODE"]) )
                                                    , helper.CreateParameter("STOPNAME",  Convert.ToString(drRow["STOPNAME"]) )
                                                    , helper.CreateParameter("USEFLAG",   Convert.ToString(drRow["USEFLAG"]) )
                                                    , helper.CreateParameter("REMARK",    Convert.ToString(drRow["REMARK"]) )
                                                    , helper.CreateParameter("EDITOR",    LoginInfo.UserID ));
                            #endregion
                            break;
                    }
                    
                }
                ClosePrgForm();
                helper.Commit();
                ShowDialog("데이터 저장에 성공 하였습니다.");
            }
            catch (Exception ex)
            {
                ClosePrgForm();
                helper.Rollback();
                ShowDialog(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
        #endregion

        private void grid1_CellListSelect(object sender, CellEventArgs e)
        {
            if (this.grid1.ActiveCell.Column.Key == "USEFLAG")
            {
                grid1.UpdateGridData();
                string sUsefFLagCode = string.Empty;
                sUsefFLagCode = Convert.ToString(e.Cell.Value);
            }
        }
 
 
    }

}
