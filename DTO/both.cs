namespace Bank.depDto{
    public class depositDto{
        public int depos {get; set;}
    }
}

namespace Bank.wtdDto{
    public class wdthDto{
        public int wdt {get; set;}
    }
}

//DTO means Data Transfer Object
//DTO is used because the input of withdrawl and deposit are not integer, they will come in JSON