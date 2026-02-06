namespace ExercicioInterface;

public class Rectangle : AbstractShape
{
  public double Width { get; set; }
  public double Height { get; set; }

  public override double Area() {
    return Height * Width;
  }

  public override string ToString() {
    return "Rectangle color = "
      + color
      + ", widht = "
      + Width.ToString("F2", CultureInfo.InvariantCulture)
      + ", height = "
      + Height.ToString("F2", CultureInfo.InvariantCulture)
      + ", Area = "
      + Area().ToString("F2", CultureInfo.InvariantCulture);

  }

}
