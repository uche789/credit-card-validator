using System;
using Validation;

namespace cSharpC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;

            while (!quit) {
                CreditCard card = new CreditCard();
                Console.WriteLine("Enter a credit card to validate (:q to quit):");
                string input = Console.ReadLine();
                
                if (input.Equals(":q", StringComparison.InvariantCultureIgnoreCase)) {
                    quit = true;
                    return;
                }

                CreditCard.CreditCardBrand brand = card.GetCreditCardBrand(input);
                if (!brand.Equals(CreditCard.CreditCardBrand.Invalid)){
                    Console.WriteLine("This credit card is a valid " + brand);
                } else {
                    Console.WriteLine("This credit card is invalid");
                }
            }
        }
    }
}
