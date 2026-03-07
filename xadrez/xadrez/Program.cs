using xadrez;
using xadrez.tabuleiro;
using xadrez.xadrez;
using xadrez.exceptions;

PosicaoXadrez pos = new PosicaoXadrez('a', 1);
PosicaoXadrez po2 = new PosicaoXadrez('c', 7);

System.Console.WriteLine(pos);
System.Console.WriteLine(po2.toPosicao());


