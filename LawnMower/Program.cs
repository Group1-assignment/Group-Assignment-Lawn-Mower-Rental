namespace LawnMowerRentalAssignment {
    internal class Program {
        static void Main(string[] args) {
            Customer customer = new Customer("thord", 0765984765, CustomerType.Professional);

            customer.NewRental(new LawnMower());


        }
    }
}