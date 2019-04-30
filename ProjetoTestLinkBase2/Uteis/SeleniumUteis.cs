﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Uteis
{
    class SeleniumUteis : WebDriver
    {
        
        public void PreencheCampoInput(IWebElement elemento,String valor ){
            //espera elemento
            //limpa o elemento 
            //preenche o elemento 
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            elemento.Clear();
            elemento.SendKeys(valor);
          }

        public void PreencheId(IWebElement elemento)
        {
            //espera elemento
            //limpa o elemento 
            //preenche o elemento 
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            elemento.Clear();
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(999999);
            elemento.SendKeys(randomInt +"");
        }
        public void ClicaBotao(IWebElement elemento)
        {
            //espera elemento
            //limpa o elemento 
            //preenche o elemento 
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            elemento.Click();
        }
       
        public void EsperaElemento(IWebElement elemento) {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));

        }
        public static String GerarNome()
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(999999);
            return "Nome" + randomInt ;
        }
        public static String GerarPalavraChave()
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(999);
            return "PalavraChave" + randomInt;
        }
        public static String GerarEmail( string nome)
        {
            return nome + "@teste.com";
        }

        public static String GerarRotulo()
        {
            Random randomGenerator = new Random();
            int randomInt = randomGenerator.Next(999999);
            return "Rotulo" + randomInt;
        }

        public  void  VerificaNomeTabela( string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
                foreach (var tr in tabela.FindElements(By.TagName("tr")))
                {
                    var tds = tr.FindElements(By.TagName("td"));
                    for (var i = 0; i < tds.Count; i++)
                    {
                        if (tds[i].Text.Trim().Equals(nome))
                        {
                           Assert.AreEqual(nome, tds[i].Text.Trim());
                           return;   
                        }
                    }
                }
            Assert.Fail();        
        }

        public void ClicaPosicaoTabela(String nome, int val)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (tds[0].Text.Trim().Equals(nome))
                {
                    tds[val].Click();
                    return;
                }
            }
            Assert.Fail();
        }
        public int VerificarQuantidadesLinhas()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            int count=0;
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                count = count + 1;
            }
            return count;
        }

        public void VerificaNomesFiltro(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                if (nome.Trim().Contains(tds[0].Text))
                {
                    Assert.AreEqual(nome, tds[0].Text.Trim());
                }
                else Assert.Fail();
            }          
        }

        public string SelecionaRandomicoComboBox(IWebElement elemento)
        {
                WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
                espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
                Random random = new Random();
                SelectElement selector = new SelectElement(elemento);
                IList<IWebElement> options = selector.Options;
                int aux = options.Count;
                int r = 1;//random.Next(1, aux);
                new SelectElement(elemento).SelectByText(options[r].Text.Trim());
                return options[r].Text.Trim();
        }

        public string SelecionaRandomicoComboBoxTipo(IWebElement elemento, String Tipo)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementToBeClickable(elemento));
            SelectElement selector = new SelectElement(elemento);
            new SelectElement(elemento).SelectByText(Tipo);
            return Tipo;
        }

        public String ConfirmaExclusaoTabela(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("tbody")));
            var tabela = driver.FindElement(By.TagName("tbody"));
            foreach (var tr in tabela.FindElements(By.TagName("tr")))
            {
                var tds = tr.FindElements(By.TagName("td"));
                for (var i = 0; i < tds.Count; i++)
                {
                    if (tds[i].Text.Trim().Equals(nome))
                    {
                        Assert.Fail();
                        return null;
                    }
                }//fim for 1

            }//fim foreach
            return null;
        }


        public void CBClick(IWebElement iwebelement,String text)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(5));
            espera.Until(ExpectedConditions.ElementToBeClickable(iwebelement));
            iwebelement.Click();
            new SelectElement(iwebelement).SelectByText(text);
            iwebelement.Click();
        }

       
        
        public void SelecionaCheckBox(String valor, String ID)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.Id(ID)));
            var tabela = driver.FindElement(By.Id(ID));

            foreach (var tbody in tabela.FindElements(By.TagName("tbody")))
            {
                foreach (var tr in tbody.FindElements(By.TagName("tr")))
                {

                    if (tr.Text.Contains(valor) ){
                        var tds = tr.FindElements(By.TagName("td"));

                        if (tds[1].Text.Equals(valor))
                        {
                            tds[0].Click();
                            return;
                        }
                    }
                }
            }
        }


        public void VerificarElementoTabela(String valor, String ID)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.Id(ID)));
            var tabela = driver.FindElement(By.Id(ID));

            foreach (var tbody in tabela.FindElements(By.TagName("tbody")))
            {
                foreach (var tr in tbody.FindElements(By.TagName("tr")))
                {
                   if (tr.Text.Contains(valor))
                    {
                        var tds = tr.FindElements(By.TagName("td"));

                        if (tds[1].Text.Equals(valor))
                        {
                            Assert.AreEqual(valor, tds[1].Text);
                            return;
                        }
                    }
                }
            }
        }
        public void VerificarElementoTabela(String nome)
        {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(20));
            espera.Until(ExpectedConditions.ElementIsVisible(By.Id("ext-gen19")));
            var tabela = driver.FindElement(By.Id("ext-gen19"));

            foreach (var table in tabela.FindElements(By.TagName("table")))
            {

                var tds = table.FindElements(By.TagName("td"));
                if (tds[0].Text.Equals(nome))
                {
                    var td = tds[6].FindElement(By.TagName("img"));
                    Assert.Pass();
                    return;
                }
            }
        }
    }
}

