using QueroUmaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueroUmaApi.Repository
{
    public class GeradorContexto
    {
        public static GeradorCpf gerador = new GeradorCpf();
        public static GeradorCnpj geradorCnpj = new GeradorCnpj();

        public static GeradorCpf GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;

            gerador.Cpf = semente;
            return gerador;
        }

        public static GeradorCnpj GeraCNPJ()
        {
            int digito1 = 0, digito2 = 0, resto = 0;
            string nDigResult;
            string numerosContatenados;
            string numeroGerado;
            Random numeroAleatorio = new Random();
            //numeros gerados
            int n1 = numeroAleatorio.Next(10);
            int n2 = numeroAleatorio.Next(10);
            int n3 = numeroAleatorio.Next(10);
            int n4 = numeroAleatorio.Next(10);
            int n5 = numeroAleatorio.Next(10);
            int n6 = numeroAleatorio.Next(10);
            int n7 = numeroAleatorio.Next(10);
            int n8 = numeroAleatorio.Next(10);
            int n9 = numeroAleatorio.Next(10);
            int n10 = numeroAleatorio.Next(10);
            int n11 = numeroAleatorio.Next(10);
            int n12 = numeroAleatorio.Next(10);
            int soma = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;
            int valor = (soma / 11) * 11;
            digito1 = soma-valor;
            //Primeiro resto da divisão por 11.
            resto = (digito1 % 11);
            if(digito1< 2){

                digito1 = 0;
            }
            else {
                digito1 = 11-resto;
            }
            numerosContatenados = n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString() + n5.ToString()
                 + n6.ToString() + n7.ToString() + n8.ToString() + n9.ToString() + n10.ToString() + n11.ToString() + n12.ToString();
            //Concatenando o primeiro resto com o segundo.
            nDigResult = digito1.ToString() + digito2.ToString();
            numeroGerado = numerosContatenados + nDigResult;

            //Conctenando os numeros
            numeroGerado = numerosContatenados+nDigResult;
            geradorCnpj.Cnpj = numeroGerado;
            return geradorCnpj;
        }

        public static bool ValidaCPF(string cpf)
        {
            int multiplicador1 = 10;
            int multiplicador2 = 11;

            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1 - i);

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador2 - i);

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }


        public static bool ValidaCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
 
            return cnpj.EndsWith(digito);
        }

    }
}