using System.IO.Compression;
using System.Reflection.Metadata;
//    2 задание
//Есть класс боец и противники их 3 класса.
//Есть классы : нож = мечь = ружье= пистолет.Чтобы выстрелить в оружие должно быть заряжено.
//Сделать программу в которой боец будет пользоватся разным оружием смотря какой перед ним бует противник.
namespace Warrior
{
    public class Programm
    {
        static void Main(string[] args)
        {
            Warrior war = new Warrior();

            
            Fighter1 fighter1 = new Fighter1();
            Fighter2 fighter2 = new Fighter2();
            Fighter3 fighter3 = new Fighter3();

            Knife knife = new Knife();
            Sword sword = new Sword();
            Pistol pistol = new Pistol();
            Gun gun = new Gun();

            CreateCharacteristicOurPerson person = new CreateCharacteristicOurPerson();
            
            war.name = person.GetNameOutPerson();            
            war.weapon = person.GetWeaponForOurPerson();
            
            string fighterFromUser = person.GetNameFighterOutPerson(/*war.name, war.weapon, war.powerWeapon,*/war, fighter1, fighter2, fighter3, knife, sword, pistol, gun);                      
        }
    }    
    public class Warrior
    {      
        public string weapon;
        public string name;
        public bool powerWeapon;
        
        public string Weapon { get; set; }
        public string Name { get; set; }        
        public bool PowerWeapon { get; set; }

        public Warrior()
        {
            powerWeapon = false;
            weapon = Weapon;
            name = Name;
        }       
        public void Fire(Weapon weapon)
        {
            weapon.Fire();
        }
        public void PowerWeaponFunc(Weapon weapon)
        {
            if(weapon.nameWeapon != "нож" && weapon.nameWeapon != "меч")
            {
                PowerWeapon = true;
            }
        }
    }
    public abstract class Fighter
    {
        public string nameFighter;
        public string nameWeapon;

        public abstract string NameFighter { get; }
        public abstract string NameWeapon { get; }                
    }
    public class Fighter1 : Fighter
    {  
        public override string NameFighter => "Чак Норис";
        public override string NameWeapon => "Ружье";       
    }
    public class Fighter2 : Fighter
    {
        public override string NameFighter => "Стивен Сигал";
        public override string NameWeapon => "Пистолет";      
    }
    public class Fighter3 : Fighter
    {
        public override string NameFighter =>"Rembo";
        public override string NameWeapon => "Нож";
    }
    public abstract class Weapon
    {
        public string nameWeapon;
        public abstract int DamagWeapon { get; }
        public abstract string WeaponName { get;}
        public Weapon()
        {
            nameWeapon = WeaponName;
        }
        public abstract void Fire();
        public void InfoAboutDamag()
        {
            Console.WriteLine($"Наносит:{DamagWeapon}");
        }
    }
    public class Knife : Weapon
    {        
        public override int DamagWeapon => 3;

        public override string WeaponName { get => "Нож"; }

        public override void Fire()
        {
            Console.WriteLine("Тык-Тык");
        }
    }
    public class Gun : Weapon
    {        
        public override int DamagWeapon => 20;
        public override string WeaponName { get => "Ружье"; }

        public override void Fire()
        {
            Console.WriteLine("ТЫК-ТЫК-ПЫЩ");
        }
    }
    public class Pistol : Weapon
    {
        public override int DamagWeapon => 10;

        public override string WeaponName => "Пистолет";

        public override void Fire()
        {
            Console.WriteLine("Пиф-Паф");
        }
    }
    public class Sword : Weapon
    {
        public override int DamagWeapon => 6;

        public override string WeaponName => "Меч";

        public override void Fire()
        {
            Console.WriteLine("Жиньк-Жиньк");
        }
    }
    public class CreateCharacteristicOurPerson
    {
        public string namePerson;
        public string NamePerson { get; set; }
        public CreateCharacteristicOurPerson()
        {
            namePerson = NamePerson;
        }
        public string GetNameOutPerson()
        {
            Console.WriteLine("Дайте имя своему персонажу:");
            string namePerson = Console.ReadLine();
            return namePerson;
        }
        public string GetWeaponForOurPerson()
        {
            Console.WriteLine("Введите оружие которое вы ходите взять своему герою?\n\n Меч, Нож, Ружье, Пистолет");
            string weaponOfUser = Console.ReadLine();
            return weaponOfUser;
        }
        public string GetNameFighterOutPerson(/*string nameUser, string nameWeapon*/  Warrior war, Fighter1 fighter1, Fighter2 fighter2, Fighter3 fighter3, Knife knife, Sword sword, Pistol pistol, Gun gun)
        {
            string fighterFromUser;        
            fighterFromUser =  FinderFighters(war, fighter1, fighter2, fighter3);            
            if(fighterFromUser != "ххх")
            {
                Console.WriteLine($"Хорошо {war.name}, вы выбрали оружие: {war.weapon}, значит ваш противник:{fighterFromUser}\n");
            }
            return fighterFromUser;
        }
        public string FinderFighters(Warrior war, Fighter1 fighter1, Fighter2 fighter2, Fighter3 fighter3)
        {
            if (war.weapon == fighter1.NameWeapon)
            {
                return fighter1.NameFighter;
            }
            else if (war.weapon == fighter2.NameWeapon)
            {
                return fighter2.NameFighter;
            }
            else if (war.weapon == fighter3.NameWeapon)
            {
                return fighter3.NameFighter;
            }
            else if(war.weapon == "меч" || war.weapon == "Меч")
            {
                Console.WriteLine("Вы взяли меч, с вами никто не хочет сражаться. Удалите игру!");
                return "ххх";
            }
            return "Ошибка!";
        }
    }    
}