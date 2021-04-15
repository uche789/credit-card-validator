namespace Validation {
    class CreditCard : Validator
    {
        public enum CreditCardBrand
        {
            Invalid,
            MasterCard,
            Visa,
            Maestro,
            AmericanExpress,
            DinersClub,
            Discover,
            JCB
        }

        private bool isMaestro(string input) {
            return input.StartsWith("5") && input.Length == 17;
        }

        private bool isJCB(string input) {
            return input.StartsWith("35");
        }

        private bool isAmericanExpress(string input) {
            return (input.StartsWith("34") || input.StartsWith("37")) && input.Length == 15;
        }

         private bool isDiners(string input) {
            return (input.StartsWith("30") || input.StartsWith("36") || input.StartsWith("38"));
        }

        private bool isVisa(string input) {
            return input.StartsWith("4");
        }

        private bool isMasterCard(string input) {
            return input.StartsWith("5") && input.Length == 16;
        }

        private bool isDiscover(string input) {
            return input.StartsWith("6") && input.Length == 16;
        }

        public CreditCardBrand GetCreditCardBrand(string input) {
            input = input.Replace(" ", "");

            if (Validator.LuhnValidator(input)) {
                if (this.isMasterCard(input)) {
                    return CreditCardBrand.MasterCard;
                } else if (this.isVisa(input)) {
                    return CreditCardBrand.Visa;
                } else if (this.isDiscover(input)) {
                    return CreditCardBrand.Discover;
                } else if (this.isMaestro(input)) {
                    return CreditCardBrand.Maestro;
                } else if (this.isDiners(input)) {
                    return CreditCardBrand.DinersClub;
                } else if (this.isAmericanExpress(input)) {
                    return CreditCardBrand.AmericanExpress;
                } else if (this.isJCB(input)) {
                    return CreditCardBrand.JCB;
                }
            }

            return CreditCardBrand.Invalid;
        }
    }
}