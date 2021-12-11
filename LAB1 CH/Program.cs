using System;
using System.Collections;
using System.Collections.Generic;
namespace LAB3_CH
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam RT1 = new ResearchTeam("Armada", 5, "MATH", TimeFrame.TwoYears, new List<Paper>(), new List<Person>());
            Person participant0 = new Person("Ivan", "Ivanov", new DateTime(2001, 1, 10));
            Person participant1 = new Person("Anton", "Maryanskiy", new DateTime(2002, 5, 18));
            Person participant2 = new Person("John", "Adamson", new DateTime(1999, 3, 10));
            Person participant3 = new Person("Jason", "Statham", new DateTime(1967, 7, 26));
            RT1.AddMembers(participant0, participant1, participant2, participant3);
            RT1.AddPapers(new Paper("Integral", participant1, new DateTime(2020, 3, 1)),
                new Paper("Differential", participant2, new DateTime(2018, 7, 27)),
                new Paper("Inductio", participant2, new DateTime(2014, 7, 27)),
                new Paper("Judo", participant3, new DateTime(2000, 1, 10)));

            Console.WriteLine("Задание 1...................................................................");
                Console.WriteLine("Сортировка по дате выхода публикации................");
                RT1.SortedPublictime();
                Console.WriteLine(RT1);
                Console.WriteLine("Сортировка по названию публикации................");
                RT1.SortedName();
                Console.WriteLine(RT1);
                Console.WriteLine("Сортировка по фамилии автора................");
                RT1.SortedSurname();
                Console.WriteLine(RT1);

            Console.WriteLine("Задание 2...................................................................");
                KeySelector<String> selector = delegate (ResearchTeam resteam) { return resteam.ToString(); };
                ResearchTeamCollection<String> resteamCollection = new ResearchTeamCollection<string>(selector);
                resteamCollection.AddDefaults();
                resteamCollection.AddResearchTeams(RT1);
                Console.WriteLine(resteamCollection);

            Console.WriteLine("Задание 3...................................................................");
                Console.WriteLine("Пункт 1");
                Console.WriteLine("Дата последней публикации: " + resteamCollection.GetLastPaper.ToShortDateString()+ "\n");
                Console.WriteLine("Пункт 2");
                Console.WriteLine("ResearchTeam с продолжительностью исследований Two Years: ");
                var rGroups = resteamCollection.TimeFrameValue(TimeFrame.TwoYears);
                foreach (var key in rGroups)
                {
                    Console.WriteLine(key.Value);
                }
                Console.WriteLine("Пункт 3");
                foreach (var item in resteamCollection.TimeFrameGroup)
                {
                    foreach (var name in item)
                    {
                        Console.WriteLine(name.Value);
                    }
                }

            Console.WriteLine("Задание 4...................................................................");
                int n = -1;
                Console.Write("Введите кол-во элементов: ");
                while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    Console.Write("Пожауйста,введите число,большее 0: ");

                GenerateElement<Team, ResearchTeam> e = delegate (int j)
                {
                    var key = new Team("Team" + j, j);
                    var value = new ResearchTeam("Armada" + j, j, "MATH" + j, TimeFrame.Year, new List<Paper>(), new List<Person>());
                    return new KeyValuePair<Team, ResearchTeam>(key, value);
                };
                var searchTest = new TestCollections<Team, ResearchTeam>(n, e);
                searchTest.searchKeyList();
                searchTest.searchStringList();
                searchTest.searchDictionaryKey();
                searchTest.searchDictionaryByValue();
        }
    }                              
}                          