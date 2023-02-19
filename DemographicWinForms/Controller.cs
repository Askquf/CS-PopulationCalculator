using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemographicFileOperations;
using TestLinearAlgebra;
using Demographic;
using System.Threading;

namespace DemographicWinForms
{
    /// <summary>
    /// Контроллер для кнопок приложения
    /// </summary>
    class Controller
    {
        FileWorker _worker;
        Engine _process;

        public Controller(){}

        /// <summary>
        /// Создает объект обработчика файла, передает в него запрос о считывании данных.
        /// Передает данные в движок.
        /// </summary>
        /// <param name="death_rate_filepath">Путь к файлу "списков смерти".</param>
        /// <param name="initial_age_filepath">Путь к файлу стартовых позиций</param>
        /// <param name="year_start">Год начала обработки</param>
        /// <param name="population">Население</param>
        public void GetLists(string death_rate_filepath, string initial_age_filepath, int year_start, int population)
        {
            _worker = new FileWorker(initial_age_filepath, 2);
            List<MathVector> tmp_initial = _worker.ReadFullFile();
            _worker = new FileWorker(death_rate_filepath, 4);
            List<MathVector> tmp_death = _worker.ReadFullFile();
            _process = new Engine(tmp_death, tmp_initial, year_start, population);
        }

        /// <summary>
        /// Отдельный шаг расчета населения.
        /// Вызывает прохождение года в движке.
        /// Добавляет данные о населении в список.
        /// </summary>
        /// <param name="people">Список с данными о населении.</param>
        public List<int> ControllerStep(/*List<List<int>>people*/)
        {
            return _process.ProcessStep();
        }

        /// <summary>
        /// Получение половозрастного соcтава от движка.
        /// </summary>
        /// <returns>Список с данными о численности населения разных полов и возрастов.</returns>
        public List<List<int>> GiveDividedPopulation()
        {
            List<List<int>> results = new List<List<int>>();
            results.Add(_process.GetDividedPopulation(Gender.man));
            results.Add(_process.GetDividedPopulation(Gender.woman));
            return results;
        }

        public void DisposeEngine()
        {
            _process.Dispose();
        }
    }
}
