namespace ExercicioInterface;

abstract class AbstractShape : IShape
{
  public Color color { get; set; }
  public abstract double Area();
}
