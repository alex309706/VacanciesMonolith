using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacancyMonolith.Models.Realisations
{
    public class DBInitializer
    {
        public static void Initialize(VacancyContext context)
        {
            context.Database.EnsureCreated();
            if (context.Organizations.Any())
            {
                return;
            }
            var organizations = new Organization[]
            {
                new Organization{ID=Guid.NewGuid(),Name = "Astral", URL = "astral.ru" },
                new Organization{ID=Guid.NewGuid(),Name = "1С:Камин", URL = "kaminsoft.ru" },
                new Organization{ID=Guid.NewGuid(),Name = "2GIS", URL = "company.2gis.ru" }
            };
            context.Organizations.AddRange(organizations);
            context.SaveChanges();
            var contactPersons = new ContactPerson[]
            {
                new ContactPerson{ID=Guid.NewGuid(), FirstName = "Alex", LastName = "Test",Email = "AlexTest@mail.ru" },
                new ContactPerson{ID=Guid.NewGuid(), FirstName = "Nick", LastName = "Test",Email = "NickTest@mail.ru" },
                new ContactPerson{ID=Guid.NewGuid(), FirstName = "Scott", LastName = "Test",Email = "ScottTest@mail.ru" },
            };
            context.ContactPersons.AddRange(contactPersons);
            context.SaveChanges();
            var vacancies = new Vacancy[]
            {
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    ContactPerson = contactPersons[GetRandomIndexForCollection(contactPersons)],
                    Organization = organizations[GetRandomIndexForCollection(organizations)] ,
                    //проще пока хардкодить
                    Description = "Крупная российская нефтегазовая компания приглашает на работу Оператора-кассира! Обязанности: Работа за кассовым аппаратом; Кассовая документация; Продажа горюче-смазочных материалом; Поддержание чистоты и порядка в зале. Требования: Ответственность, доброжелательность Опыт работы желателен, но не обязателен. Условия: Официальное оформление по ТК РФ; Сменный график работы: 1/3 или 2/2 ( дневные и ночные смены); Официальная заработная плата от 35 000р; Бесплатное обучение; Медицинская книжка за счет работодателя; Место работы подбирается с учетом места жительства/учебы.",
                    TypeOfEmployment = getRandomTypeOfEmployement(),
                    Header = "Опыт работы: любой. Ответственность, доброжелательность Опыт работы желателен, но не обязателен. ",
                    Phone = GetRandomNumber("Russia"),
                    Salary = GetRandomSalary()
                },
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    ContactPerson = contactPersons[GetRandomIndexForCollection(contactPersons)],
                    Organization = organizations[GetRandomIndexForCollection(organizations)] ,
                    //проще пока хардкодить
                    Description = "Опыт работы: от 1 года. Иметь опыт в разработке схем электроавтоматики, с учетом использования современных комплектующих и материалов; Иметь опыт в сборке панелей и шкафов электроавтоматики; ... ",
                    TypeOfEmployment = getRandomTypeOfEmployement(),
                    Header = "Инженер-электроник до 44 380 руб. Калуга, полный рабочий день, опыт работы от 1 года, образование высшее",
                    Phone = GetRandomNumber("Russia"),
                    Salary = GetRandomSalary()
                },
                new Vacancy
                {
                    Id = Guid.NewGuid(),
                    ContactPerson = contactPersons[GetRandomIndexForCollection(contactPersons)],
                    Organization = organizations[GetRandomIndexForCollection(organizations)] ,
                    //проще пока хардкодить
                    Description = "Отделочник универсал Нашим мастерам мы предлагаем: Оформление по ТК; Регулярные выплаты. Качественные инструменты. Условия: возможность выбрать объект рядом с домом; Требования: Выполнять работы по поклейке, окраске и ремонту разных строительных поверхностей Штукатурить любые поверхности",
                    TypeOfEmployment = getRandomTypeOfEmployement(),
                    Header = "Отделочник-универсал по договоренности Москва, полный рабочий день, опыт работы от 1 года, образование любое ",
                    Phone = GetRandomNumber("Russia"),
                    Salary = GetRandomSalary()
                },
            };
            context.Vacancies.AddRange(vacancies);
            context.SaveChanges();
        }
        static int GetRandomIndexForCollection(IEnumerable<object> collection)
        {
            Random rnd = new Random();
            return rnd.Next(0, collection.Count());
        }
        static TypeOfEmployement getRandomTypeOfEmployement()
        {
            var rnd = new Random();
            return (TypeOfEmployement)rnd.Next(Enum.GetNames(typeof(TypeOfEmployement)).Length);
        }
        static decimal GetRandomSalary()
        {
            Random rnd = new Random();
            return (decimal)rnd.NextDouble()*100000;
        }
        static string GetRandomNumber(string CountryName)
        {

            Random rnd = new Random();
            string result = string.Empty;

            switch (CountryName)
            {
                case "Russia":
                    {
                        result += "+7";
                        for (int i = 0; i <= 9; i++)
                        {
                            result += rnd.Next(0,9);
                        }
                        break;
                    }
                default:
                    result += "+1234567890";
                    break;
            }
            return result;
        }
    }
}
