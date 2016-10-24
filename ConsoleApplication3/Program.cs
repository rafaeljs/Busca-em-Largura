using Busca_em_Lagura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busca_em_Largura{
    class Program{
        static void Main(string[] args){
            int quantidade;
            Console.Write("Informe quantos vertices tera: ");
            quantidade = Convert.ToInt32(Console.ReadLine());
            Grafo grafo = new Grafo(quantidade);
            grafo.insere();
            grafo.imprimir();
           
            Console.Write("Insira o indice inicial: ");
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;
            grafo.buscaEmLargura(indice);
            Console.ReadKey();
        }
    }
}
