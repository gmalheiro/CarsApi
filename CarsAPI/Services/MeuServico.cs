﻿namespace CarsAPI.Services
{
    public class MeuServico : IMeuServico
    {
        public string? saudacao(string nome)
        {
            return $"Bem vindo,{nome} \n\n {DateTime.Now}";
        }
    }
}
