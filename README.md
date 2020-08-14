# versao-chromedriver
Este projeto verificar e faz download da versão correta para utilização do Selenium.
Programa simple e direto.<br>
Caso esteja usando como dll basta adicionar referência a dll.<br>
using VersaoChromedriver;<br>
Instânciar<br>
versionador versao = new versionador();<br>
versao.versaoChromeDriver()<br>
Ex de uso com o selenium:<br>

<b>versionador versao = new versionador();</b><br>
ChromeOptions options = new ChromeOptions();<br>
var chromeDriverService = ChromeDriverService.CreateDefaultService(<b>versao.versaoChromeDriver()</b>)<br>

using (ChromeDriver driver = new ChromeDriver(chromeDriverService, options: options))<br>
{<br>
}<br>

<h1> Considere doar para o programa sim eu sou do meio! Que cuida de crianças pobres em cituações de riscos!</h1>
[Doações para o programa sim ] (http://vaka.me/1039138)
