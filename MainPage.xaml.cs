using App1.Servico;
using App1.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {

            string cep = CEP.Text.Trim();
            if (eValido(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end == null)
                    {
                        DisplayAlert("CEP Inválido", "Você digitou um cep invalido: ", "OK");
                        return;
                    }
                    RESULTADO.Text = "Cep: " + end.cep + "\nRua: " + end.logradouro + "\nComplemento: "
                        + end.complemento + "\nBairro: " + end.bairro + "\nLocalidade: " + end.localidade;
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "OK");
                }
                
            }
        }

        private bool eValido(string cep)
        {
            int novoCep = 0;
            if (int.TryParse(cep, out novoCep) && cep.Length == 8)
            {
                return true;
            }
            DisplayAlert("ERRO", "Você digitou um cep invalido", "Corrigir");
            RESULTADO.Text = "CEP INVALIDO"; 
            return false;
        }

    }

}
