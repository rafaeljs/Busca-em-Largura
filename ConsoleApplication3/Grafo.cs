using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busca_em_Lagura {
    class Grafo {
        List<int>[] Grafos;
        int[] Fila;
        String s;
        int valor;
        String[] cor;
        int[] d;
        int[] pi;
        public Grafo(int quantidade) {
            cor = new String[quantidade];
            d = new int[quantidade];
            pi = new int[quantidade];
            Grafos = new List<int>[quantidade];
            Fila = new int[quantidade];
            for (int i = 0; i < quantidade; i++) {
                Grafos[i] = new List<int>();
                Fila[i] = -1;
            }
        }
        public void insere() {
            for (int i = 0; i < Grafos.Length; i++) {
                Console.WriteLine((i + 1) + ": ");
                s = Console.ReadLine();
                int y = 0;
                while (y < s.Length) {
                    valor = Convert.ToInt32(s.Substring(y, 1));
                    if (valor == 1) {
                        Grafos[i].Add(y / 2);
                    }

                    y = y + 2;
                }

            }
        }
        public void imprimir() { // imprime os vertices e suas respectivas ligaçoes 
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((i + 1) + " <-");
                foreach (int numeros in Grafos[i]) {
                    Console.Write(" " + (numeros + 1));
                }
                Console.WriteLine();
            }
        }
        public void buscaEmLargura(int s) {
            int indice;
            for (indice = 0; indice < Grafos.Length; indice++) {
                cor[indice] = "Branco";
                d[indice] = -1;
                pi[indice] = -1;
            }
            cor[s] = "Cinza";
            d[s] = 0;
            CriaFila(s);
            while (Fila[0] != -1) {
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
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((d[i]) + "      ");
            }
            Console.WriteLine();
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((pi[i] + 1) + "      ");
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
            while (Fila[i] != -1) {
                i++;
            }
            Fila[i] = numero;
        }
        void Desenfila() {
            for (int i = 0; Fila[i] != -1; i++) {
                Fila[i] = Fila[i + 1];
            }
        }

        public void BuscaEmProfundidade() {
            int time = 0;
            for (int i = 0; i < Grafos.Length; i++) {
                cor[i] = "Branco";
                d[i] = -1;
                pi[i] = -1;
            }
            for (int i = 0; i < Grafos.Length; i++) {
                if (cor[i].Equals("Branco")) {
                    DFS_Visit(time, i);
                }
            }
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((d[i]) + "      ");
            }
            Console.WriteLine();
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write((pi[i] + 1) + "      ");
            }
            Console.WriteLine();
            for (int i = 0; i < Grafos.Length; i++) {
                Console.Write(cor[i] + " ");
            }
        }


        void DFS_Visit(int time, int u) {
            cor[u] = "Cinza";
            time++;
            d[u] = time;
            foreach (int numero in Grafos[u]) {
                if (cor[numero].Equals("Branco")) {
                    pi[numero] = u;
                    DFS_Visit(time, numero);
                }
            }
            cor[u] = "Preto";
        }
    }
}
