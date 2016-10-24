using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3 {
    class Grafo {
        List<int>[] Grafos;
        int[] Fila;
        public Grafo(int quantidade) {
            Grafos = new List<int>[quantidade];
            Fila = new int[quantidade];
            for(int i = 0; i < quantidade; i++) {
                Grafos[i] = new List<int>();
                Fila[i] = -1;
            }
        }
        public void insere() {
            for(int i = 0; i < Grafos.Length; i++) {
                int valor = 0;
                while(valor != -1) {
                    Console.WriteLine("Insira a aresta do vertice " + (i+1) + ":(-1 para proximo vertice)");
                    valor = Convert.ToInt32(Console.ReadLine());
                    if(valor != -1) {
                        Grafos[i].Add(valor-1);
                    }
                }
            }
        }
        public void imprimir() {
            for(int i = 0; i < Grafos.Length; i++) {
                Console.Write((i+1) + " <-");
                foreach (int numeros in Grafos[i]) {
                    Console.Write(" " + (numeros+1));
                }
                Console.WriteLine();
            }
        }
        public void buscaEmLargura(int s) {
            int indice;
            String[] cor = new String[Grafos.Length];
            int[] d = new int[Grafos.Length];
            int[] pi = new int[Grafos.Length];
            for (indice = 0; indice < Grafos.Length; indice++) {
                cor[indice] = "Branco";
                d[indice] = -1;
                pi[indice] = -1;
            }
            cor[s] = "Cinza";
            d[s] = 0;
            CriaFila(s);
            while(Fila[0] != -1) {
                indice = Fila[0];
                foreach (int numero in Grafos[indice]) {
                    if (cor[numero].Equals("Branco")) {
                        cor[numero] = "Cinza";
                        d[numero] = d[indice] + 1;
                        pi[numero] = indice;
                        Enfila(numero);
                    }
                }
                cor[indice] = "Preto";
                Desenfila();
            }
            for (int i = 0;i < Grafos.Length; i++) {
                Console.Write((d[i]) + "      ");
            }
            Console.WriteLine();
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((pi[i]+1) + "      ");
            }
            Console.WriteLine();
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write(cor[i] + " ");
            }
        }

        void CriaFila(int s) {
            Fila[0] = s;
        }
        void Enfila(int numero) {
            int i = 0;
            while(Fila[i] != -1) {
                i++;
            }
            Fila[i] = numero;
        }
        void Desenfila() {
            for(int i = 0;Fila[i] != -1;i++) {
                Fila[i] = Fila[i + 1];
            }           
        }
    }
}
