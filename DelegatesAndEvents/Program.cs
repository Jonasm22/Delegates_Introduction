namespace DelegatesAndEvents
{
    
        public delegate int Comparation<T> (T x, T y );

        public class Person()
        {
            public int Age { get; set; }
            public string Name { get; set; }

        }

        public class PersonSorter
        {

            public void Sort(Person[] people, Comparation<Person> comparation)
            {
                for (int i = 0; i < people.Length - 1; i++)
                {
                    for(int j = i+1; j < people.Length; j++)
                    {
                        if(comparation(people[i], people[j]) > 0)
                        {
                            Person temo = people[i];
                            people[i] = people[j];  
                            people[j] = temo;
                        }
                    }


                }
            }
        }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Denis", Age= 36 },
                new Person { Name = "Charlie", Age = 34 },
            };

            PersonSorter personSorter = new PersonSorter();
            personSorter.Sort(people, CompareByAge);

            foreach (Person person in people)
            { 
                
                Console.WriteLine($"{person.Name}, {person.Age}");
            
            }

            personSorter.Sort(people, CompareByName);

            foreach (Person person in people)
            { 
                
                Console.WriteLine($"{person.Name}, {person.Age}");
            
            }



        }

        static int CompareByAge(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }


        static int CompareByName(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
