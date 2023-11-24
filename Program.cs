using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Kalkulacka_v
{
    internal class Program
    {
        static void Main()
        {
            /*
            Zadání úkolu:

            Další vylepšení vaší kalkulačky! 🤯

            umožněte uživateli střídavě zadávat čísla a operátory, dokud ho to neomrzí (zadá například X, přičemž ho akceptujte jenom při zadávání operátoru).
            BONUS: pokud si troufnete tak i během zadávání čísla
            pokud zjistíte, že uživatel požádal o ukončení programu, bude se vám zde hodit klíčové slůvko return, které stojí na řádku samostatně, následuje pouze středník return;.
            po každé operaci ukažte výsledek
            Takto by to mohlo vypadat v konzoli po dokončení příkladu:
 
            Zadej číslo:
            10
            Zadej operátor (+, -, *, /, ^):
            +
            Zadej číslo:
            7
            Výsledek: 10 + 7 = 17
            Zadej operátor (+, -, *, /, ^):
            -
            Zadej číslo:
            15
            Výsledek: 17 - 15 = 2
            Zadej operátor (+, -, *, /, ^):
            ^
            Zadej číslo:
            5
            Výsledek: 2 ^ 5 = 32
            Zadej operátor (+, -, *, /, ^):
            X
            Kalkulačka končí.
            */

            while (true)
            {
                Console.WriteLine("Zadej číslo (pro ukončení zadej X): ");
                string prvniCisloOdUzivatele = Console.ReadLine();
                bool prvniCisloSpravne = int.TryParse(prvniCisloOdUzivatele, out int prvniCislo);
                
                while (!prvniCisloSpravne)//jedná se o zkrácený zápis zápisu (prvniCisloSpravne == false) - !vykřičník neguje hodnotu
                {
                    if (prvniCisloOdUzivatele == "X")
                    {
                        return;
                    }
                    Console.WriteLine("Zadal si neplatnou hodnotu, zadej číslo znovu (pro ukončení zadej X):");
                    prvniCisloOdUzivatele = Console.ReadLine();
                    prvniCisloSpravne = int.TryParse(prvniCisloOdUzivatele, out prvniCislo);
                }  

                while (true)
                {
                    Console.WriteLine("Zadej znaménko + , - , * , / , nebo ^ (pro ukončení zadej X): ");
                    string znamenko = Console.ReadLine();

                    while (znamenko != "+" && znamenko != "-" && znamenko != "*" && znamenko != "/" && znamenko != "^")
                    {
                        if (znamenko == "X")
                        {
                            return;
                        }
                        Console.WriteLine("Zadal si špatné znaménko, zadej znovu (pro ukončení zadej X):");
                        znamenko = Console.ReadLine();
                    }

                    Console.WriteLine("Zadej číslo (pro ukončení zadej X):");

                    string druheCisloOdUzivatele = Console.ReadLine();
                    bool druheCisloSpravne = int.TryParse(druheCisloOdUzivatele, out int druheCislo);
                    int vysledek = 0;
                    
                    while (!druheCisloSpravne)//jedná se o zkrácený zápis zápisu (druheCisloSpravne == false) - !vykřičník neguje hodnotu
                    {
                        if (druheCisloOdUzivatele == "X")
                        {
                            return;
                        }
                        Console.WriteLine("Zadal si neplatnou hodnotu, zadej číslo znovu (pro ukončení zadej X):");
                        druheCisloOdUzivatele = Console.ReadLine();
                        druheCisloSpravne = int.TryParse(druheCisloOdUzivatele, out druheCislo);
                    }

                    switch (znamenko)
                    {
                        case "+":
                            vysledek = prvniCislo + druheCislo;
                            break;
                        case "-":
                            vysledek = prvniCislo - druheCislo;
                            break;
                        case "*":
                            vysledek = prvniCislo * druheCislo;
                            break;
                        case "/":
                            vysledek = prvniCislo / druheCislo;
                            break;
                        case "^":
                            int mocnina = prvniCislo;
                            for (int i = druheCislo; i > 1; i--)//druhé číslo určí kolikátá je to mocnina
                            {
                                mocnina *= prvniCislo;
                            }
                            vysledek = mocnina;
                            break;
                    }

                    if (vysledek != null)
                    {
                        Console.WriteLine($"výsledek: {prvniCislo} {znamenko} {druheCislo} = {vysledek}");
                    }
                    prvniCislo = vysledek;
                }
            }
        }
    }
}
