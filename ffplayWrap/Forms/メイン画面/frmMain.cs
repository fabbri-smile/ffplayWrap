using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ffplayWrap
{
    public partial class frmMain : Form
    {
        //***************************************************************************************
        // メンバ変数定義
        //***************************************************************************************

        private const string prv_ffPlayExePath = @"D:\kawa@B450M-A\src2023\ffmpeg-6.0-full_build-shared\bin\ffplay.exe";
        private const string prv_VideoFolderPath = @"D:\ThaiPops(VCD)\Various Artist\GRAMMY BEST OF THE YEAR 2002";

        private Process? prv_procFFPlay = null;     // ffPlay.exeのプロセス

        //***************************************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }
        //***************************************************************************************
        /// <summary>
        /// 再生開始
        /// </summary>
        /// <param name="strVideoFilePath">再生する動画ファイルのパス</param>
        private async void StartPlay(string strVideoFilePath)
        {
            try
            {
                Debug.WriteLine("StartPlay - 開始");

                // 「開始」ボタンを無効化
                btnStart.Enabled = false;


                // ffPlay.exe の起動パラメータを設定
                ProcessStartInfo psInfo = new ProcessStartInfo();

                psInfo.FileName = prv_ffPlayExePath;    // 実行ファイルパス

#if DEBUG
#else
                psInfo.CreateNoWindow = true;   // コンソール・ウィンドウを開かない
                psInfo.UseShellExecute = false; // シェル機能を使用しない
#endif

                psInfo.ArgumentList.Add("-autoexit");
                psInfo.ArgumentList.Add(strVideoFilePath);

                // ffPlay.exe 起動
                prv_procFFPlay = Process.Start(psInfo);

                // 外部アプリの終了を非同期で待機
                if (null != prv_procFFPlay) await prv_procFFPlay.WaitForExitAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                // 「開始」ボタンを有効化
                btnStart.Enabled = true;

                Debug.WriteLine($"StartPlay - 終了");
            }
        }
        //***************************************************************************************
        /// <summary>
        /// 再生停止
        /// </summary>
        public void StopPlay()
        {
            try
            {
                Debug.WriteLine("StopPlay - 開始");

                if (null != prv_procFFPlay
                 && true != prv_procFFPlay.HasExited)
                {
                    prv_procFFPlay.Kill();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                Debug.WriteLine("StopPlay - 終了");
            }
        }
        //***************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("btnStart_Click - 押下");

                // Rename.txt の読込み
                clsRenameList RenameList = new clsRenameList();

                if (true == RenameList.ReadFile(Path.Combine(prv_VideoFolderPath, "Rename.txt")))
                {
                    PlayListView.SetPlayList(RenameList);
                }



                // 動画ファイルの再生開始
                StartPlay(Path.Combine(prv_VideoFolderPath, "AVSEQ01.DAT"));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("btnStop_Click - 押下");

                StopPlay();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************************
        // Win32APIのメッセージ定義
        //***************************************************************************************

        // イベントを送信するためのWin32 API
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // 送信するメッセージ
        private const uint WM_KEYDOWN   = 0x0100;
        private const uint WM_CHAR      = 0x0102;



        private bool SendCharToFFPlay(Char c)
        {
            try
            {
                Debug.WriteLine($"キー送信 char={c}");

                if (null != prv_procFFPlay
                 && true != prv_procFFPlay.HasExited)
                {
                    // 対象ウィンドウにキーダウンメッセージを送信する
                    IntPtr hWnd = prv_procFFPlay.MainWindowHandle;

                    PostMessage(hWnd, WM_CHAR, (IntPtr)c, IntPtr.Zero);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }



        private bool SendKeyToFFPlay(Keys k)
        {
            try
            {
                Debug.WriteLine($"キー送信 key={k}");

                if (null != prv_procFFPlay
                 && true != prv_procFFPlay.HasExited)
                {
                    // 対象ウィンドウにキーダウンメッセージを送信する
                    IntPtr hWnd = prv_procFFPlay.MainWindowHandle;

                    PostMessage(hWnd, WM_KEYDOWN, (IntPtr)k, IntPtr.Zero);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }
        //***************************************************************************************
        /// <summary>
        /// 「-60秒」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekMinus60_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Down);     // ↓キー (60秒戻し)
        }
        //***************************************************************************************
        /// <summary>
        /// 「-10秒」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekMinus10_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Left);     // ←キー (10秒戻し)
        }
        //***************************************************************************************
        /// <summary>
        /// 「+10秒」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekPlus10_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Right);    // →キー (10秒送り)
        }
        //***************************************************************************************
        /// <summary>
        /// 「+60秒」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekPlus60_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Up);       // ↑キー (60秒送り)
        }
        //***************************************************************************************
        /// <summary>
        /// 「+ VOL」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolUp_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.D0);       // '0' キー (音量上げ)
                                            // SendKeyToFFPlay(Keys.Multiply);       // '*' キー (音量上げ)
        }
        //***************************************************************************************
        /// <summary>
        /// 「- VOL」ボタンのハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolDn_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.D9);       // '9' キー (音量下げ)
            //SendKeyToFFPlay(Keys.Divide);       // '/' キー (音量下げ)
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            SendCharToFFPlay('m');       // 'm' キー (ミュート切り替え)
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            SendCharToFFPlay('p');       // 's' キー (一時停止)
        }
    }
}