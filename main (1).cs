using System;

class ContaBancaria
{
    private string titular;
    private double saldo;

    public ContaBancaria(string titular)
    {
        this.titular = titular;
        saldo = 0;
    }

    public void Depositar(double valor)
    {
        saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} realizado. Saldo atual: {saldo:C}");
    }

    public void Sacar(double valor)
    {
        if (valor <= saldo)
        {
            saldo -= valor;
            Console.WriteLine($"Saque de {valor:C} realizado. Saldo atual: {saldo:C}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para o saque.");
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual de {titular}: {saldo:C}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bem-vindo(a) ao programa de Conta Bancária!");

        // Criando uma conta bancária para o titular "João"
        ContaBancaria contaDoJoao = new ContaBancaria("João");

        // Efetuando operações na conta bancária do João
        contaDoJoao.Depositar(1000);
        contaDoJoao.Sacar(500);
        contaDoJoao.ExibirSaldo();

        // Criando outra conta bancária para o titular "Maria"
        ContaBancaria contaDaMaria = new ContaBancaria("Maria");

        // Efetuando operações na conta bancária da Maria
        contaDaMaria.Depositar(2000);
        contaDaMaria.Sacar(1000);
        contaDaMaria.ExibirSaldo();

        // Aguarda o usuário pressionar qualquer tecla para encerrar o programa
        Console.ReadKey();
    }
}
