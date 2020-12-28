using App1.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App1.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";
       
        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(EnderecoUrl, cep);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(novoEnderecoUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null)
            {
                return null;
            }

            return end;
        }
    }
}
