using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ffplayWrap
{
    public partial class frmMain : Form
    {
        //***************************************************************************************
        // �����o�ϐ���`
        //***************************************************************************************

        private const string prv_ffPlayExePath = @"D:\kawa@B450M-A\src2023\ffmpeg-6.0-full_build-shared\bin\ffplay.exe";
        private const string prv_VideoFolderPath = @"D:\ThaiPops(VCD)\Various Artist\GRAMMY BEST OF THE YEAR 2002";

        private Process? prv_procFFPlay = null;     // ffPlay.exe�̃v���Z�X

        //***************************************************************************************
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }
        //***************************************************************************************
        /// <summary>
        /// �Đ��J�n
        /// </summary>
        /// <param name="strVideoFilePath">�Đ����铮��t�@�C���̃p�X</param>
        private async void StartPlay(string strVideoFilePath)
        {
            try
            {
                Debug.WriteLine("StartPlay - �J�n");

                // �u�J�n�v�{�^���𖳌���
                btnStart.Enabled = false;


                // ffPlay.exe �̋N���p�����[�^��ݒ�
                ProcessStartInfo psInfo = new ProcessStartInfo();

                psInfo.FileName = prv_ffPlayExePath;    // ���s�t�@�C���p�X

#if DEBUG
#else
                psInfo.CreateNoWindow = true;   // �R���\�[���E�E�B���h�E���J���Ȃ�
                psInfo.UseShellExecute = false; // �V�F���@�\���g�p���Ȃ�
#endif

                psInfo.ArgumentList.Add("-autoexit");
                psInfo.ArgumentList.Add(strVideoFilePath);

                // ffPlay.exe �N��
                prv_procFFPlay = Process.Start(psInfo);

                // �O���A�v���̏I����񓯊��őҋ@
                if (null != prv_procFFPlay) await prv_procFFPlay.WaitForExitAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                // �u�J�n�v�{�^����L����
                btnStart.Enabled = true;

                Debug.WriteLine($"StartPlay - �I��");
            }
        }
        //***************************************************************************************
        /// <summary>
        /// �Đ���~
        /// </summary>
        public void StopPlay()
        {
            try
            {
                Debug.WriteLine("StopPlay - �J�n");

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
                Debug.WriteLine("StopPlay - �I��");
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
                Debug.WriteLine("btnStart_Click - ����");

                // Rename.txt �̓Ǎ���
                clsRenameList RenameList = new clsRenameList();

                if (true == RenameList.ReadFile(Path.Combine(prv_VideoFolderPath, "Rename.txt")))
                {
                    PlayListView.SetPlayList(RenameList);
                }



                // ����t�@�C���̍Đ��J�n
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
                Debug.WriteLine("btnStop_Click - ����");

                StopPlay();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        //***************************************************************************************
        // Win32API�̃��b�Z�[�W��`
        //***************************************************************************************

        // �C�x���g�𑗐M���邽�߂�Win32 API
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // ���M���郁�b�Z�[�W
        private const uint WM_KEYDOWN   = 0x0100;
        private const uint WM_CHAR      = 0x0102;



        private bool SendCharToFFPlay(Char c)
        {
            try
            {
                Debug.WriteLine($"�L�[���M char={c}");

                if (null != prv_procFFPlay
                 && true != prv_procFFPlay.HasExited)
                {
                    // �ΏۃE�B���h�E�ɃL�[�_�E�����b�Z�[�W�𑗐M����
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
                Debug.WriteLine($"�L�[���M key={k}");

                if (null != prv_procFFPlay
                 && true != prv_procFFPlay.HasExited)
                {
                    // �ΏۃE�B���h�E�ɃL�[�_�E�����b�Z�[�W�𑗐M����
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
        /// �u-60�b�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekMinus60_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Down);     // ���L�[ (60�b�߂�)
        }
        //***************************************************************************************
        /// <summary>
        /// �u-10�b�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekMinus10_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Left);     // ���L�[ (10�b�߂�)
        }
        //***************************************************************************************
        /// <summary>
        /// �u+10�b�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekPlus10_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Right);    // ���L�[ (10�b����)
        }
        //***************************************************************************************
        /// <summary>
        /// �u+60�b�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeekPlus60_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.Up);       // ���L�[ (60�b����)
        }
        //***************************************************************************************
        /// <summary>
        /// �u+ VOL�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolUp_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.D0);       // '0' �L�[ (���ʏグ)
                                            // SendKeyToFFPlay(Keys.Multiply);       // '*' �L�[ (���ʏグ)
        }
        //***************************************************************************************
        /// <summary>
        /// �u- VOL�v�{�^���̃n���h��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolDn_Click(object sender, EventArgs e)
        {
            SendKeyToFFPlay(Keys.D9);       // '9' �L�[ (���ʉ���)
            //SendKeyToFFPlay(Keys.Divide);       // '/' �L�[ (���ʉ���)
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            SendCharToFFPlay('m');       // 'm' �L�[ (�~���[�g�؂�ւ�)
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            SendCharToFFPlay('p');       // 's' �L�[ (�ꎞ��~)
        }
    }
}