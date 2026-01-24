namespace Exercicios.Entities {
    public class Employee () {
        public required string Name {get; set;}
        public int Hours {get; set;}
        public double ValuePHour {get; set;}

        public Employee() {}

        public Employee (string name, int hour, double valuePHour) {
            Name = name;
            Hours = hour;
            ValuePHour = valuePHour;
        }

        public virtual double payment() {
            return Hours * ValuePHour;
        }
    }
}