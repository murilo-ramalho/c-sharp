using System;

namespace xadrez.exceptions;

public class TabuleiroException : Exception
{
    public TabuleiroException(string msg) : base(msg) {}
}
