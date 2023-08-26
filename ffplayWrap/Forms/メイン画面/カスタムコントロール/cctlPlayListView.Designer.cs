namespace ffplayWrap
{
    partial class cctlPlayListView
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            SuspendLayout();
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "No.";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "曲名";
            columnHeader2.Width = 200;
            // 
            // cctlPlayListView
            // 
            Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            View = View.Details;
            ResumeLayout(false);
        }

        #endregion

        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}
