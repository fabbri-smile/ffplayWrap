using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ffplayWrap
{
    internal partial class cctlPlayListView : ListView
    {
        //***************************************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public cctlPlayListView()
        {
            InitializeComponent();
        }
        //***************************************************************************************
        /// <summary>
        /// カスタムことロールの描画
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        //***************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RenameList"></param>
        /// <returns></returns>
        public bool SetPlayList(clsRenameList RenameList)
        {
            try
            {
                int iNo = 1;

                foreach (clsRenameItem RenameItem in RenameList.RenameList)
                {
                    ListViewItem lvItem = Items.Add($"{iNo++}");

                    lvItem.SubItems.Add(RenameItem.DispName);

                    lvItem.Tag = RenameItem;
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
