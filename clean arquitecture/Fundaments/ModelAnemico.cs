using System;

namespace Fundaments;

public class ModelAnemico
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Endereco { get; set; }
}

public sealed class ModelAnemicoAlimentado
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Endereco { get; private set; }

    public ModelAnemicoAlimentado(int id, string name, string endereco)
    {
        Validar(id, name, endereco);
        Id = id;
        Name = name;
        Endereco = endereco;
    }

    public void Update(int id, string name, string endereco)
    {
        Validar(id, name, endereco);
        Id = id;
        Name = name;
        Endereco = endereco;
    }

    private static void Validar(int id, string name, string endereco)
    {
        if (id<=0) throw new InvalidOperationException("Id inválido");
        if (string.IsNullOrEmpty(name)) throw new InvalidOperationException("Nome requerido");
        if (string.IsNullOrEmpty(endereco)) throw new InvalidOperationException("Endereco requerido");
        if (name.Length < 3) throw new InvalidOperationException("Nome com menos de 3 letras");
        if (name.Length > 100) throw new InvalidOperationException("Nome com mais de 100 letras");
    }
}
