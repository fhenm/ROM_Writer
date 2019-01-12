using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;
using FTD2XX_NET;
using System.Threading;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {

        //コントロールを初期化する
        FTDI ftdev = new FTDI();
        private bool dirtyFlag = false;        //ダーティーフラグ 
        private bool readOnlyFlag = false;  //読み取り専用フラグ
        private string editFilePath = "";
        private string BOXC = "";//編集中のファイルのパス
        private bool handsFlag = false; //接続フラグ
        private byte[] bs_v1;
        private byte[] vbs;
        private int afd = 0;
        private int mode_sov = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void setDirty(bool flag)
        {
            dirtyFlag = flag;
            上書き保存ToolStripMenuItem.Enabled = (readOnlyFlag) ? false : flag;
        }

        private void ShowSaveDateTime()
        {
            const string STATUS_STRING = "に保存しました";

            toolStripStatusLabel1.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + STATUS_STRING;
        }
        private bool confirmDestructionText(string msgboxTitle)
        {
            const string MSG_BOX_STRING = "ファイルは保存されていません。\n\n編集中のテキストは破棄されます。\n\nよろしいですか?";
            if (!dirtyFlag) return true;
            return (MessageBox.Show(MSG_BOX_STRING, msgboxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private string GetFileNameString(string filePath, char separateChar)
        {
            try
            {
                string[] strArray = filePath.Split(separateChar);
                return strArray[strArray.Length - 1];
            }
            catch
            { return ""; }
        }
        private void 新規作成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string MSG_BOX_TITLE = "ファイルの新規作成";
            if (confirmDestructionText(MSG_BOX_TITLE))
            {
                this.Text = "新規ファイル";
                textBox1.Clear();
                editFilePath = "";
                setDirty(false);
            }
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            const string TITLE_EXTN_ReadOnly = " (読み取り専用)";
            const string MSGBOX_TITLE = "ファイル オープン";
            editFilePath = openFileDialog1.FileName;
            readOnlyFlag = openFileDialog1.ReadOnlyChecked;
            this.Text = (readOnlyFlag)
                 ? openFileDialog1.SafeFileName + TITLE_EXTN_ReadOnly : openFileDialog1.SafeFileName;

            setDirty(false);

            try
            {
                //textBox1.Text = File.ReadAllText(editFilePath, Encoding.Default);
                System.IO.FileStream fs = new System.IO.FileStream(
                openFileDialog1.FileName,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read);
                bs_v1 = new byte[fs.Length];
                fs.Read(bs_v1, 0, bs_v1.Length);
                vbs = bs_v1;
                fs.Close();
                enc_TEXTancy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            const string MSGBOX_TITLE = "名前を付けて保存";

            editFilePath = saveFileDialog1.FileName;
            try
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(vbs);
                bw.Close();
                fs.Close();
                setDirty(false);
                ShowSaveDateTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            setDirty(true);
        }

        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string NEW_FILE_NAME = "新規HEXファイル.hex";
            string fileNameString = GetFileNameString(editFilePath, '\\');

            //ファイル名が空白であった場合は　"新規HEXファイル.hex" をセット
            saveFileDialog1.FileName = (fileNameString == "")
                 ? NEW_FILE_NAME : fileNameString;
            saveFileDialog1.ShowDialog(this);
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string MSGBOX_TITLE = "ファイルの上書き保存";

            //保存先のファイルが存在するかチェック
            if (File.Exists(editFilePath))
            {
                try
                {
                    File.WriteAllText(editFilePath, textBox1.Text, Encoding.Default);

                    setDirty(false);

                    ShowSaveDateTime();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string MSG_BOX_STRING = "ファイル\"" + editFilePath
                     + "\" のパスは正しくありません。\n\nディレクトリが存在するか確認してください。";
                MessageBox.Show(MSG_BOX_STRING, MSGBOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void menuEnd_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string MSGBOX_TITLE = "アプリケーションの終了";

            if (confirmDestructionText(MSGBOX_TITLE))
            {
                // Form1の破棄
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }


        /// ////////////////////////////////////////////////////////////////

        private void button1_Click(object sender, EventArgs e)
        {
            if (handsFlag == false)
            {
                //! シリアルポートをオープンする.
                ftdev.OpenByIndex(0);
                ftdev.SetBitMode(0xFF, FTDI.FT_BIT_MODES.FT_BIT_MODE_ASYNC_BITBANG);
                ftdev.SetBaudRate(9600);
                ftdev.SetLatency(0);
                uint writtenLength = 0;
                byte[] w1 = { 0x10 + 0x20 + 0x40 + 0x00 };
                byte[] w2 = { 0x10 + 0x20 + 0x40 + 0x04 };
                byte[][] wbuf = { w1, w2 };
                foreach (byte[] buf in wbuf)
                {
                    ftdev.Write(buf, buf.Length, ref writtenLength);
                    Thread.Sleep(1);
                }

                //! ボタンの表示を[接続]から[切断]に変える.
                button1.Text = "切断";

                //! 切断処理用　フラグON
                handsFlag = true;
            }
            else
            {
                //! シリアルポートをクローズする.
                ftdev.Close();

                //! ボタンの表示を[切断]から[接続]に変える.
                button1.Text = "接続";

                //! 切断処理用　フラグOFF
                handsFlag = false;
            }
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////
        /// </summary>FT232RL書き込み
        private void reset_IC()//FT232RLリセット
        {
            uint writtenLength = 0;
            byte[] w1 = { 0x70 };
            byte[] w2 = { 0x74 };
            byte[][] wbuf = { w1, w2 };
            foreach (byte[] buf in wbuf) { ftdev.Write(buf, buf.Length, ref writtenLength); }
        }
        private void write_code(int a, int b)//a = ADDRES b = DATA
        {
            byte[] w3 = { 0x00 };
            if (a == 1)
            {
                if (b == 0) { w3[0] = 0x77; }
                else if (b == 1) { w3[0] = 0x6F; }
            }
            if (a == 0)
            {
                if (b == 0) { w3[0] = 0x76; }
                else if (b == 1) { w3[0] = 0x7E; }
            }

            uint writtenLength = 0;
            byte[] w4 = { 0x74 };
            byte[][] wbuf = { w3, w4 };
            foreach (byte[] buf in wbuf) { ftdev.Write(buf, buf.Length, ref writtenLength); }
        }

        private void SET_HEX_ECD_FF(byte _l0, byte _l1, byte _l2, byte _R1) //18bitROM書き込み関数 _l0= ADDRES0 _l1= ADDRES1 _l2= ADDRES2 _j =DATA
        {
            byte sb1 = 0x00, df = 0x02;
            int af = 0, bf = 0;
            for (int ai = 0; ai <= 1; ai++)
            {
                sb1 = (byte)(_l0 & df);
                if (sb1 == 0) { af = 0; }
                else if (sb1 >= 1) { af = 1; }
                write_code(af, 0);
                df = (byte)(df >> 1);
            }
            df = 0x80;
            for (int si = 0; si <= 7; si++)
            {
                sb1 = (byte)(_l1 & df);
                if (sb1 == 0) { af = 0; }
                else if (sb1 >= 1) { af = 1; }
                write_code(af, 0);
                df = (byte)(df >> 1);
            }
            df = 0x80;
            for (int di = 0; di <= 7; di++)
            {
                sb1 = (byte)(_l2 & df);
                if (sb1 == 0) { af = 0; }
                else if (sb1 >= 1) { af = 1; }

                sb1 = (byte)(_R1 & df);
                if (sb1 == 0) { bf = 0; }
                else if (sb1 >= 1) { bf = 1; }
                write_code(af, bf);
                df = (byte)(df >> 1);
            }
            ROM_WRITE_CMD();
        }

        private void ROM_WRITE_CMD() //ROMに書き込み信号を送る
        {
            uint writtenLength = 0;
            byte[] w1 = { 0x24 };
            byte[] w2 = { 0x74 };
            byte[][] wbuf = { w1, w2 };
            foreach (byte[] buf in wbuf) { ftdev.Write(buf, buf.Length, ref writtenLength); }
        }
        private void SET_IC_WRITE_MODE_FF() //ROMErase
        {
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0xAA);
            SET_HEX_ECD_FF(0x00, 0x0A, 0xAA, 0x55);
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0x80);
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0xAA);
            SET_HEX_ECD_FF(0x00, 0x0A, 0xAA, 0x55);
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0x10);
            Thread.Sleep(1000);
            reset_IC();
        }

        private void SET_0x00_IC()//シフトレジスタに0x00を入れる
        {
            for (int dg = 0; dg <= 10; dg++) { write_code(0, 0); }
        }

        private void SET_IC_WRITE(byte w, byte a, byte b, byte c) //ROMに書き込み w =ADD0 a =ADD1 b =ADD2 c =DATA
        {
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0xAA);
            write_code(0, 1);
            ROM_WRITE_CMD();
            SET_HEX_ECD_FF(0x00, 0x05, 0x55, 0xA0);
            SET_HEX_ECD_FF(w, a, b, c);
        }
        private void rOMへ書き込みToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = vbs.Length;
            progressBar1.Value = 0;
            WriteAsync();
        }

        public async void enc_TEXTancy()
        {
            await Task.Run(() => {
                enc_TEXT();
            });
            textBox1.Text = "";
            textBox1.Text = BOXC;
        }
        public async void WriteAsync()
        {
            textBox2.Text = "erase START";
            await Task.Run(() => {
                reset_IC();
                SET_IC_WRITE_MODE_FF();
            });
            textBox2.Text = "erase done";
            var PRO_Thread = new Progress<int>(LockPro);
            var PROa_Thread = new Progress<int>(LockProa);
            var PROb_Thread = new Progress<int>(LockProb);
            var PROc_Thread = new Progress<int>(LockProc);
            textBox2.Text = "START";
            await Task.Run(() => {
                reset_IC();
                READ_DATA_IC_write(PRO_Thread, PROa_Thread, PROb_Thread, PROc_Thread);
            });
            textBox2.Text = "done";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "START";
            await Task.Run(() => {
                reset_IC();
                SET_IC_WRITE_MODE_FF();
            });
            textBox2.Text = "done";
        }

        public String ByteToString(Byte[] bytDt)
        {
            const long LBYT1 = 1;
            System.Text.StringBuilder sb =
                new System.Text.StringBuilder("");
            for (long i = 0; i <= bytDt.Length - 1; i++)
            {
                int ival = bytDt[i];
                String sval;
                if (ival < 16)
                {
                    sval = "0" + Convert.ToString(ival, 16);
                }
                else
                {
                    sval = "" + Convert.ToString(ival, 16);
                }
                sb.Append(sval);
                if (((i + 1) % LBYT1) == 0)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        private void enc_TEXT()
        {
            String strDt = ByteToString(bs_v1);
            if (strDt.Substring(strDt.Length - 1, 1) == "\n")
            {
                strDt = strDt.Substring(0, strDt.Length - 1);
            }
            String[] strAr = strDt.Split('\n');
            BOXC = "";
            for (long i = 0; i <= strAr.Length - 1; i++)
            {
                BOXC = BOXC + strAr[i];
            }
        }

        private void READ_DATA_IC_write(IProgress<int> PR, IProgress<int> PRa, IProgress<int> PRb, IProgress<int> PRc)
        {
            byte[] buffg = vbs;
            long cntr;
            byte a = 0x00, b = 0x00, c = 0x00, data1 = 0x00, data2 = 0x00;
            if (mode_sov == 0)
            {
                for (cntr = 0; cntr <= buffg.Length - 1;)
                {
                    a = buffg[cntr];
                    cntr++;
                    b = buffg[cntr];
                    cntr++;
                    c = buffg[cntr];
                    cntr++;
                    data1 = buffg[cntr];
                    cntr++;
                    data2 = buffg[cntr];
                    cntr++;
                    PR.Report((Int32)cntr);
                    PRa.Report((Int32)a);
                    PRb.Report((Int32)b);
                    PRc.Report((Int32)c);
                    if (afd == 0)
                    {
                        SET_IC_WRITE(a, b, c, data1);
                    }
                    else if (afd == 1)
                    {
                        SET_IC_WRITE(a, b, c, data2);
                    }
                }
            }
            else if (mode_sov == 1)
            {
                for (cntr = 0; cntr <= buffg.Length - 1;)
                {
                    data1 = buffg[cntr];
                    cntr++;
                    data2 = buffg[cntr];
                    cntr++;
                    if (afd == 0)
                    {
                        SET_IC_WRITE(a, b, c, data1);
                    }
                    else if (afd == 1)
                    {
                        SET_IC_WRITE(a, b, c, data2);
                    }
                    if (c == 0xff)
                    {
                        if (b == 0xff)
                        {
                            a++;
                        }
                        b++;
                    }
                    c++;
                    PR.Report((Int32)cntr);
                    PRa.Report((Int32)a);
                    PRb.Report((Int32)b);
                    PRc.Report((Int32)c);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (afd == 1)
            {
                afd = 0;
                button3.Text = "オペコード書き込み";
            }
            else if (afd == 0)
            {
                afd = 1;
                button3.Text = "データ書き込み";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mode_sov == 1)
            {
                mode_sov = 0;
                button4.Text = "MODE 1";
            }
            else if (mode_sov == 0)
            {
                mode_sov = 1;
                button4.Text = "MODE 2";
            }
        }

        private void LockPro(int scent)
        {
            progressBar1.Value = scent;
            textBox3.Text = scent + "ブロック";
        }
        
         private void LockProa(int a)
        {
            textBox4.Text = "a = " + a;
        }

        private void LockProb(int b)
        {
            textBox5.Text = "b = " + b;
        }

        private void LockProc(int c)
        {
            textBox6.Text = "c = " + c;
        }
    }
}
