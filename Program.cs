using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;
using System.Threading.Tasks;


namespace Selenium{
    class Program{

        public static void Consulta(IWebDriver driver){
            /* Funcionalidade: O objetivo dessa função é realizar uma consulta ao google.

                Cenário: O usuário quer fazer uma pesquisa no Google
                O usuário irá acessar o google chrome com o objetivo de pesquisar informações de uma empresa que fará entrevista.
                O usuário digita o nome dessa empresa na caixa de texto do Google.
                Ao apertar o botão "Enter" ou pressionar o botão "Pesquisa Google", o Google fornecerá os resultados dessa pesquisa.
                O Google irá abrir a página com o resultado dessa pesquisa.

                Esquema do Cenário: Pesquisa
                Dado que eu pesquiso por "Concert Technologies"
                Quando eu clicar no botão de pesquisa
                Então terei o resultado dessa pesquisa        
            */

            driver.Navigate().GoToUrl(@"https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Concert Technologies"+ Keys.Return);
        }

        public static void ScreenShot(string screenshotsPath, IWebDriver driver){

            /* Funcionalidade: O objetivo dessa função é tirar um ScreenShot da tela.

                Cenário: Verificação da Funcionalidade
                O desenvolvedor precisa verificar se o site está funcionando.
                Para isso, ele irá simular as ações de um usuário.
                Ao acessar a página que deseja, irá realizar um screenshot dessa página.
                Desse modo, ao visualizar a página, poderá ter certeza do funcionamento dela através do resultado dessa imagem.

                Esquema do Cenário: ScreenShot
                Dado que eu pesquiso por "Concert Technologies" no Google
                Quando tiver o resultado dessa pesquisa
                Então terei um screenshot dessa página em funcionamento.        
            */

            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPath, ScreenshotImageFormat.Png);
        }

        public static void Stress(IWebDriver driver){

            /* Funcionalidade: O objetivo dessa função é testar a quantidade de estresse suportada pela página.

                Cenário: Verificação do Estresse da Página
                Vários usuários querem realizar uma pesquisa na página do Google simultaneamente.
                Todos eles acessam a página do Google.
                Todos eles realizam uma pesquisa ao mesmo tempo.
                A página irá aguentar essa quantidade de submissão e ficar disponível integralmente.

                Esquema do Cenário: Estresse
                Dado que vários usuários pesquisam por "Concert Technologies" no Google.
                Quando todos os usuários realizarem a consulta.
                Então todos terão uma página de resultados disponível.        
            */

            int i;

            for(i=0; i<50; i++){
                driver.Navigate().GoToUrl(@"https://www.google.com");
                driver.FindElement(By.Name("q")).SendKeys("Concert Technologies"+ Keys.Return);
                
                //Verificação de Funcionamento da Página
                try{
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    using StreamWriter file = File.AppendText(@"C:\Users\Larissa\Documents\Entrevista\Stress\Stress.txt");
                    file.WriteLine("Teste " + i + ": Sucesso.");
                }
                catch{
                    using StreamWriter file = File.AppendText(@"C:\Users\Larissa\Documents\Entrevista\Stress\Stress.txt");
                    file.WriteLine("Teste " + i + ": Erro.");
                }
            }
        }
        public static void Abas(IWebDriver driver){

            /* Funcionalidade: O objetivo dessa função é testar o acesso de todas as abas do Google.

                Cenário: Acesso de abas do menu
                O usuário realiza uma pesquisa sobre a "Concert Technologies".
                Após receber o resultado de sites sobre sua pesquisa, ele decide que quer ver as opções de "Notícias" sobre essa empresa.
                O usuário clica na aba "Notícias".
                O usuário receberá o resultado dessa página.
                Em seguida, ele decide verificar as opções de vídeos sobre essa empresa.
                O usuário clica na aba "Vídeos".
                O usuário receberá o resultado dessa página.

                Esquema do Cenário: Funcionamento das Abas
                Dado uma pesquisa do usuário.
                Quando acessar as diversas abas do Google.
                Então ele deverá receber o resultado correto para cada página..        
            */

            driver.Navigate().GoToUrl(@"https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Concert Technologies"+ Keys.Return);
            System.Threading.Thread.Sleep(1000);

            //Notícias
            //driver.FindElement(By.XPath("//*[@id='hdtb-msb']/div[1]/div/div[2]/a")).Click();
            driver.FindElement(By.LinkText("Notícias")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Noticias.png", driver);
            System.Threading.Thread.Sleep(1000);

            //Maps
            //driver.FindElement(By.XPath("//*[@id='hdtb-msb']/div[1]/div/div[3]/a")).Click();
             driver.FindElement(By.LinkText("Maps")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Maps.png", driver);
            System.Threading.Thread.Sleep(1000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            //Imagens
            //driver.FindElement(By.XPath("//*[@id='hdtb-msb']/div[1]/div/div[4]/a")).Click();
            driver.FindElement(By.LinkText("Imagens")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Imagens.png", driver);
            System.Threading.Thread.Sleep(1000);

            //Vídeos
            //driver.FindElement(By.XPath("//*[@id='yDmH0d']/div[2]/c-wiz/div[1]/div/div[1]/div[1]/div/div/a[4]/span")).Click();
            driver.FindElement(By.LinkText("Vídeos")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Videos.png", driver);
            System.Threading.Thread.Sleep(1000);

            //Shopping
            //driver.FindElement(By.XPath("//*[@id='l1p7YOXOBsfV1sQPiYegyAE17']/g-menu/g-menu-item[1]/div/a")).Click();
            driver.FindElement(By.ClassName("GOE98c")).Click();
            driver.FindElement(By.LinkText("Shopping")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Shopping.png", driver);
            System.Threading.Thread.Sleep(1000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            //Livros
            //driver.FindElement(By.XPath("//*[@id='_5Fp7YJKRF-ra1sQPld60wAE7']/g-menu/g-menu-item[3]/div/a")).Click();
            driver.FindElement(By.ClassName("GOE98c")).Click();
            driver.FindElement(By.LinkText("Livros")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Livros.png", driver);
            System.Threading.Thread.Sleep(1000);

            //Voos
            //driver.FindElement(By.XPath("//*[@id='_BFt7YISTIOHc1sQP2bS_6AE27']/g-menu/g-menu-item[3]/div/a")).Click();
            driver.FindElement(By.ClassName("GOE98c")).Click();
            driver.FindElement(By.LinkText("Voos")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Voos.png", driver);
            System.Threading.Thread.Sleep(1000);
            driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);

            //Finanças
            //driver.FindElement(By.XPath("//*[@id='ow11']/div[1]/div/span")).Click();
            driver.FindElement(By.ClassName("GOE98c")).Click();
            driver.FindElement(By.LinkText("Finanças")).Click();
            ScreenShot(@"C:\Users\Larissa\Documents\Entrevista\Fotos\Financas.png", driver);
            System.Threading.Thread.Sleep(1000);
        }
        
        public static void Main(string[] args){
            
            /*  Funcionalidade: O objetivo da função principal é facilitar o acesso ao desenvolvedor de testes, fornecendo possibilidades de escolhas de 
                tipos de testes disponíveis, com um texto claro e objetivo. Essa função também será responsável por chamar as funções de testes.

                Cenário: Auxílio ao desenvolvedor de testes
                O desenvolvedor de testes irá realizar testes de usabilidade da página do Google.
                Ele acessa esse software e receberá uma mensagem disponibilizando as opções de testes para esse website.
                O desenvolvedor pressiona o número 1 para testar a consulta no Google.
                Após esse teste, ele vai até a pasta onde a foto ficará salva e checa se a consulta obteve sucesso.
                Em seguida, ele pressiona o número 2 para testar o estresse do site.
                Ao finalizar, ele irá até a pasta com o documento de texto com o resultado dessa análise.
                Nesse documento, ele irá verificar se os acessos ao site obtiveram sucesso.
                Por fim, ele vai pressionar o número 3 para testar as abas do website.
                Ao finalizar esse teste, ele vai até a pasta com esses screenshots e verificará pelas imagens se todas as abas funcionaram.

                Esquema do Cenário: Teste Completo
                Dado a criação/modificação de um website, será necessário o teste de usabilidade.
                Quando o desenvolvedor testar a página por esse software.
                Então ele saberá os defeitos e qualidades do site nos quesitos que foram testados.        
            */


            //Variaveis
            string path = @"C:\Users\Larissa\Documents\chromedriver_win32\";
            
            int number;
            Console.WriteLine("Software para teste da página: Google");

            //Escolha de Teste
            while(true){
                Console.WriteLine("Digite o número do teste deseja realizar:");
                Console.WriteLine("1. Teste de Consulta com ScreenShot");
                Console.WriteLine("2. Teste de Estresse");
                Console.WriteLine("3. Teste de Todas as Abas do Menu com ScreenShot");
                number = Console.Read();

                if(number-48 == 1){
                    string screenshotsPath = @"C:\Users\Larissa\Documents\Entrevista\Fotos\TesteConsulta.png";
                    IWebDriver driver = new ChromeDriver(path);
                    //Teste de Consulta
                    Consulta(driver);
                    //ScreenShot
                    ScreenShot(screenshotsPath, driver);
                    driver.Quit();
                }
                else if(number-48 == 2){
                    IWebDriver driver = new ChromeDriver(path);
                    //Teste de Estresse
                    Stress(driver);
                    driver.Quit();
                }
                else if(number-48 == 3){
                    IWebDriver driver = new ChromeDriver(path);
                    //Teste de Funcionamento das Abas do Menu
                    Abas(driver);
                    driver.Quit();
                }
                else{
                    Console.WriteLine("Insira um número válido.");
                }
            }
        }        
    }
}
