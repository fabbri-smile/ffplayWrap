using Sprache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ffplayWrap
{
    //***************************************************************************************
    /// <summary>
    /// 
    /// </summary>
    internal class clsRenameItem
    {
        //***************************************************************************************
        // メンバ変数定義
        //***************************************************************************************

        private string prv_strFileName = string.Empty;  // ファイル名
        private string prv_strDispName = string.Empty;  // 表示名

        //***************************************************************************************
        /// <summary>
        /// プロパティ定義 : ファイル名
        /// </summary>
        public string FileName
        {
            get { return prv_strFileName; }
        }
        //***************************************************************************************
        /// <summary>
        /// プロパティ定義 : 表示名
        /// </summary>
        public string DispName
        {
            get { return prv_strDispName; }
        }
        //***************************************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="strFileName_init"></param>
        /// <param name="strDispName_init"></param>
        public clsRenameItem(string strFileName_init, string strDispName_init)
        {
            prv_strFileName = strFileName_init;
            prv_strDispName = strDispName_init;
        }
    }
    //***************************************************************************************
    /// <summary>
    /// 
    /// </summary>
    internal class clsRenameList
    {
        //***************************************************************************************
        // パーサーの定義
        //***************************************************************************************

        /// <summary>
        /// タブ、改行コード以外の文字が、1文字以上連続している部分の文字列を返す
        /// </summary>
#if true
        private static readonly Parser<string> strParser = from key in Parse.CharExcept(new char[] { '\t', '\r', '\n' }).AtLeastOnce().Text()
                                                           select key;
#else
        private static readonly Parser<string> strParser = from key in Parse.LetterOrDigit.Or(Parse.Chars('_', ' ', '.')).AtLeastOnce().Text()
                                                           select key;
#endif
        /// <summary>
        /// タブ区切り文字列を「ファイル名」と「表示名」のペアに分解するパーサー
        /// 
        ///     【パースする文字列の例 (タブ区切りのテキスト】
        ///         "AVSEQ15.DAT	13_การะเกด_โทษที...ไม่รู้มีแฟน"
        ///
        /// </summary>
        private static readonly Parser<clsRenameItem> RenameItemParser = from FileName in strParser.Token()     // FileName 
                                                                         from DispName in strParser.Token()     // DispName 
                                                                         select new clsRenameItem(FileName, DispName);

        /// <summary>
        /// Rename.txt の全項目のパーサー
        ///     参考 : https://www.ipentec.com/document/csharp-sprache-simple-multi-section-and-multi-key-value-parser
        /// </summary>
        public static readonly Parser<clsRenameList> LabelMapListParser = (from list in RenameItemParser.Many()
                                                                           select new clsRenameList(list)).End();

        //***************************************************************************************
        // メンバ変数定義
        //***************************************************************************************

        private List<clsRenameItem> prv_RenameList = new List<clsRenameItem>();

        //***************************************************************************************
        /// <summary>
        /// プロパティ定義 : 
        /// </summary>
        public List<clsRenameItem> RenameList
        {

            get { return prv_RenameList; }
        }
        //***************************************************************************************
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public clsRenameList()
        {
        }
        //***************************************************************************************
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="RenameList_init"></param>
        public clsRenameList(IEnumerable<clsRenameItem> RenameList_init)
        {
            prv_RenameList = RenameList_init.ToList();
        }
        //***************************************************************************************
        /// <summary>
        /// Rename.txt の読込み
        /// </summary>
        /// <param name="strFileName">Rename.txt ファイルのパス</param>
        /// <returns></returns>
        public bool ReadFile(string strFilePath)
        {
            try
            {
                Debug.WriteLine("ReadFile - 開始");

                // 念のためファイルの存在チェック
                if (true != File.Exists(strFilePath)) return false;

                // Rename.txt ファイルの内容を一括読み込み (エンコードは UTF-16LE) 
                string strFileContents = File.ReadAllText(strFilePath, Encoding.Unicode);

                // パーサーを使ってファイルの内容を解析
                clsRenameList list = LabelMapListParser.Parse(strFileContents);

                // 自分自身のメンバ変数にコピー
                this.prv_RenameList = list.prv_RenameList;

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
