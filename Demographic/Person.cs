using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLinearAlgebra;

namespace Demographic
{

    public enum Gender
    {
        man = 1,
        woman
    }
    public class Person
    {
        int _age;
        Gender _personGender;
        int _birth;
        int _death;
        const double _birthProb = 0.1;
        public delegate void ChildBirth();
        public event ChildBirth OnBirth;
        public delegate void Die(Person person);
        public event Die OnDeath;
        static int _timeToDie = 100;
        double _deathProb;

        static List<MathVector> deathProbability;

        /// <summary>
        /// Получение возраста.
        /// </summary>
        public int AgeGet
        {
            get { return _age; }
        }

        /// <summary>
        /// Получение пола.
        /// </summary>
        public Gender GenderGet
        {
            get { return _personGender; }
        }

        /// <summary>
        /// Проверка, жив ли данный человек.
        /// </summary>
        /// <returns>Статус человека жив-мертв.</returns>
        public bool IsNotDead
        {
            get { return _death == 0; }
        }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="age">Возраст создаваемого человека</param>
        /// <param name="gender">Пол человека</param>
        /// <param name="year">Текущий год</param>
        public Person(int age, Gender gender, int year)
        {
            _age = age;
            _personGender = gender;
            _birth = year - age;
            _death = 0;
        }

        static public void DeathFill(List<MathVector> deathRules)
        {
            deathProbability = new List<MathVector>();
            for (int i = 0; i < deathRules.Count; i++)
            {
                deathProbability.Add(new MathVector(deathRules[i]));
            }
        }

        /// <summary>
        /// Метод, срабатывающий при событий движка YearTick.
        /// Увеличивает возраст человека на 1, проверяет шансы смерти.
        /// Проверяет шансы рождения ребенка у женщин.
        /// </summary>
        public void YearNext()
        {
            if (IsNotDead)
            {
                _age += 1;
                if (RandomCheck(_deathProb) || _age == _timeToDie)
                {
                    _death = _birth + _age;
                    OnDeath(this);
                }
                else 
                {
                    for (int i = 0; i < deathProbability.Count(); i++)
                    {
                        if (_age == deathProbability[i][0])
                            ChangeDeath(this, i);
                    }
                    if (GenderGet == Gender.woman && RandomCheck(_birthProb) && _age >= 18 && _age <= 45)
                        OnBirth();
                }

            }
        }

        /// <summary>
        /// Проверка случаных величин (вызывает метод статического класса калькулятора)
        /// </summary>
        /// <param name="prob">Вероятно проверяемого события.</param>
        private bool RandomCheck(double prob)
        {
            return ProbabilityCalculator.IsEventHappened(prob);
        }

        /// <summary>
        /// Изменяет вероятность смерти Person в зависимости от пола
        /// </summary>
        /// <param name="person">Person, вероятность смерти которого нужно изменить</param>
        /// <param name="str">Место его возраста в "списках смерти".</param>
        private void ChangeDeath(Person person, int str)
        {
            if (person.GenderGet == Gender.woman)
                person.ProbablitySet(deathProbability[str][3]);
            else
                person.ProbablitySet(deathProbability[str][2]);
        }

        /// <summary>
        /// Установка новой вероятности смерти.
        /// </summary>
        /// <param name="prob">Новая вероятность смерти.</param>
        public void ProbablitySet(double prob)
        {
            _deathProb = prob;
        }

        public void Dispose()
        {
            OnBirth = null;
            OnDeath = null;   
        }
    }

}
