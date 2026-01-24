namespace Exercicios.Entities {
    public class OutsourcedEmployee : Employee {
        private double AdditionalCharge {get; set;}

        public OutsourcedEmployee () {}

        public OutsourcedEmployee (string name, int hour, double valuePHour, double additionalCharge) : base(name, hour, valuePHour)
        {
            AdditionalCharge = additionalCharge;
        }

        public override double payment() {
            return base.payment() + 1.1 * AdditionalCharge;
        }
    }
}