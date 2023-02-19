using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinearAlgebra;

namespace Demographic
{
    public class Engine : IEngine
    { 
        List<MathVector> _startAge;
        List<Person> _humankind;
        public delegate void yearTick();
        public event yearTick OnTick;
        int _yearStart;
        int _year;
        int _population;
        const double _manProbability = 0.45;
        int _manPopulation;
        int _womanPopulation;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="deathrate">Список вероятностей смерти</param>
        /// <param name="startAge">Список стартовых параметров</param>
        /// <param name="_yearStartart">Год начала подсчета</param>
        /// <param name="start_population">Стартовая численность населения</param>
        public Engine(List<MathVector> deathRate, List<MathVector> startAge, int yearStart, int startPopulation)
        {
            _startAge = new List<MathVector>();
            for (int i = 0; i < startAge.Count; i++)
            {
                _startAge.Add(new MathVector(startAge[i]));
            }
            _yearStart = yearStart;
            _year = yearStart;
            _population = startPopulation;
            Person.DeathFill(deathRate);
            CreateHumankind();
        }

        /// <summary>
        /// Создание списка объектов класса Person.
        /// По заданным изначальным параметрам, создает Person, задавая им соответсвубщий возраст и пол.
        /// Подписывает все элементы списка на событие yearTick
        /// </summary>
        public void CreateHumankind()
        {
            _humankind = new List<Person>();
            if (_population % 2 != 0)
                _population += 1;
            for (int i = 0; i < _startAge.Count; i++)
            {
                for (int j = 0; j < _startAge[i][1] / 1000 * _population; j += 2)
                {
                    for (int q = 1; q < 3; q++)
                        PersonCreate((int)_startAge[i][0], (Gender)q, _yearStart);
                }
            }
            _manPopulation = _humankind.Count / 2;
            _womanPopulation = _humankind.Count / 2;
            _population = _humankind.Count;
        }

        /// <summary>
        /// Добавление отдельного Person в список
        /// </summary>
        /// <param name="age">Возраст человека</param>
        /// <param name="gender">Пол человека</param>
        /// <param name="year">Год рождения человека</param>
        private void PersonCreate(int age, Gender gender, int year)
        {
            _humankind.Add(new Person(age, gender, year));
            Subscribe(_humankind[_humankind.Count - 1]);
        }

        /// <summary>
        /// Подписывает Person событие yearTick
        /// Подписывает движок на событие OnBirth
        /// </summary>
        /// <param name="person"></param>
        private void Subscribe(Person person)
        {
            OnTick += person.YearNext;
            if (person.GenderGet == Gender.woman)
                person.OnBirth += BirthPerson;
            person.OnDeath += HandleDeath;
        }


        /// <summary>
        /// Расчет населения в каждом новом году.
        /// Запускает событие yearTick увеличивает год на единицу.
        /// </summary>
        /// <returns>Население в очередном году (все-мужское-женское).</returns>
        public List<int> ProcessStep()
        {
            _year += 1;
            if (_population != 0)
                OnTick();
            return CreateListPopulation();
        }

        /// <summary>
        /// Обработчик смерти человека.
        /// </summary>
        /// <param name="person">Умерший человек</param>
        private void HandleDeath(Person person)
        {
            _population -= 1;
            if (person.GenderGet == Gender.woman)
            {
                _womanPopulation -= 1;
            }
            else
                _manPopulation -= 1;
            Unscribe(person);
        }


        /// <summary>
        /// Отписка от всех событий
        /// </summary>
        /// <param name="person">Человек, которого необходимо отписать</param>
        private void Unscribe(Person person)
        {
            person.Dispose();
        }

        /// <summary>
        /// Метод, вызываемый при рожденнии нового Person.
        /// Создает нового человека, изменяет параметры человечества.
        /// </summary>
        private void BirthPerson()
        {
            int index = _humankind.Count;
            _humankind.Add(new Person(0, ChooseGender(), _year));
            Subscribe(_humankind[index]);
            _population += 1;
            if (_humankind[index].GenderGet == Gender.woman)
            {
                _womanPopulation += 1;
            }
            else _manPopulation += 1;
        }

        /// <summary>
        /// Расчет пола для родившегося человека.
        /// </summary>
        /// <returns>Пол человека.</returns>
        private Gender ChooseGender()
        {
            Gender gender = Gender.woman;
            if (ProbabilityCalculator.IsEventHappened(_manProbability))
                gender = Gender.man;
            return gender;
        }

        /// <summary>
        /// Создает список с данными о численности населения (все-мужчины-женщины).
        /// </summary>
        /// <returns>Список с данными о численности населения.</returns>
        public List<int> CreateListPopulation()
        {
            List<int> position = new List<int>();
            position.Add(_population); position.Add(_manPopulation); position.Add(_womanPopulation);
            return position;
        }

        /// <summary>
        /// Рассчитывает возростной состав населения данного пола.
        /// </summary>
        /// <param name="genderflag">Пол, для которого ведуться расчеты.</param>
        /// <returns>Список с количеством населения каждого возраста.</returns>
        public List<int> GetDividedPopulation(Gender genderflag)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < 4; i++)
                results.Add(0);
            for (int i = 0; i < _humankind.Count; i++)
            {
                if (_humankind[i].GenderGet == genderflag && _humankind[i].IsNotDead)
                {
                    if (_humankind[i].AgeGet <= 18)
                        results[0]++;
                    else if (_humankind[i].AgeGet <= 45)
                        results[1]++;
                    else if (_humankind[i].AgeGet <= 65)
                        results[2]++;
                    else
                        results[3]++;
                }
            }
            return results;
        }

        public void Dispose()
        {
            OnTick = null;
            for (int i = 0; i < _humankind.Count; i++)
            {
                _humankind[i].Dispose();
            }
        }
    }
}

