using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demographic
{
    interface IEngine
    {
        /// <summary>
        /// Создание списка объектов класса Person.
        /// По заданным изначальным параметрам, создает Person, задавая им соответсвубщий возраст и пол.
        /// Подписывает все элементы списка на событие YearTick
        /// </summary>
        void CreateHumankind();

        /// <summary>
        /// Расчет населения в каждом новом году.
        /// Запускает событие YearTick увеличивает год на единицу.
        /// </summary>
        /// <returns>Население в очередном году (все-мужское-женское).</returns>
        List<int> ProcessStep();


        /// <summary>
        /// Создает список с данными о численности населения (все-мужчины-женщины).
        /// </summary>
        /// <returns>Список с данными о численности населения.</returns>
        List<int> CreateListPopulation();

        /// <summary>
        /// Рассчитывает возростной состав населения данного пола.
        /// </summary>
        /// <param name="genderflag">Пол, для которого ведуться расчеты.</param>
        /// <returns>Список с количеством населения каждого возраста.</returns>
        List<int> GetDividedPopulation(Gender genderflag);
    }
}
