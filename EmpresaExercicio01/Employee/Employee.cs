using System;

namespace Employee {
    public class Employee () {
        public string Name {get; set;};
        public int Hours {get; set;};
        public double ValuePHour {get; set;};

        public Employee () {

        }

        public Employee (string name, int hour, double salary) {
            Name = name;
            Hours = hour;
            ValuePHour = salary;
        }

        public double payment() {
            return Hours *= ValuePHour;
        }
    }
}