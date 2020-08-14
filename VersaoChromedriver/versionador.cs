using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace VersaoChromedriver
{
    public class versionador
    {

        public string versaoChromeDriver()
        {

            string exeFolder = Path.GetDirectoryName(Application.ExecutablePath);




            string chrome = consultaultimaversao();

            string ChromeDriverDirectory = exeFolder + $@"\{chrome}\";


            while (!consultaarquivo(ChromeDriverDirectory))
            { }


            return ChromeDriverDirectory;

        }

        private string consultaultimaversao()
        {
            var versao = Consultaversao().Split('.');
            string chrome;
            using (var client = new WebClient())
            {

                var URL = $"https://chromedriver.storage.googleapis.com/LATEST_RELEASE_{versao[0]}.{versao[1]}.{versao[2]}";



                chrome = client.DownloadString(URL);




            }

            return chrome;
        }

        private string Consultaversao()
        {
            object path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            if (path != null)
                return FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion;
            return string.Empty;
        }



        private bool consultaarquivo(string arquivo)
        {
            FileInfo file = new FileInfo(arquivo + @"\chromedriver.exe");
            if (file.Exists)
            {
                return true;
            }
            else
            {
                using (var client = new WebClient())
                {
                    var versao = consultaultimaversao();

                    var URL = $"https://chromedriver.storage.googleapis.com/{versao}/chromedriver_win32.zip";

                    string caminho = Path.GetDirectoryName(Application.ExecutablePath);

                    client.DownloadFile(URL, $@"{caminho}\{versao}.zip");
                    FileInfo novo = new FileInfo($@"{caminho}\{versao}.zip");

                    while (!novo.Exists)
                    {

                    }

                    ZipFile.ExtractToDirectory($@"{caminho}\{versao}.zip", $@"{caminho}\{versao}\");

                    novo = new FileInfo($@"{caminho}\{versao}\chromedriver.exe");
                    while (!novo.Exists)
                    {

                    }

                    File.Delete($@"{caminho}\{versao}.zip");


                }
                return false;


            }








        }



    }

}
