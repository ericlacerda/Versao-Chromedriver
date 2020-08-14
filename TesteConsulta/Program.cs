using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersaoChromedriver;

namespace TesteConsulta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Este projeto foi criado a fim de demostração de utilização da dll

            versionador versao = new versionador();

            Console.WriteLine($"O chrome driver correto para sua versão do chrome é {versao.versaoChromeDriver()}");


            Console.ReadLine();
                
                


        }
    }
}
