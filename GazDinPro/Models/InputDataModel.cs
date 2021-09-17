using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazDinPro.Models
{
    public class InputDataModel
    {

        public int Id { get; set; }
        public DateTime DateOfResult { get; set; }





        //Исходные данные базового периода

        //Содержание элементов в шлаке
        public double C4 { get; set; } //Mn %
        public double C5 { get; set; } //P %
        public double C6 { get; set; } //Si %
        public double C7 { get; set; } //[S] %
        public double C8 { get; set; } //(s) %
        public double C9 { get; set; } //C %
        public double C10 { get; set; } //Ti %
        public double C11 { get; set; } //Cr %

        public double C12 { get; set; } //Удельный расход кокса, кг/т чугуна (к)
        public double C13 { get; set; } //Зола кокса, %
        public double C14 { get; set; } //Сера кокса, %
        public double C15 { get; set; } //Летучие кокса, %

        public double C18 { get; set; } //Содержание кислорода в дутье (W)
        public double C19 { get; set; } //Влажность дутья (Fд)
        public double C20 { get; set; } //Удельный расход  природного газа (Vпг)
        public double C21 { get; set; } //Содержание С в природном газе (состоит из одного СН4) ((C')=CH4')
        public double C22 { get; set; } //Содержание Н2 в природном газе (состоит из одного СН4) ((H2')=2*CH4)
        public double C23 { get; set; } //Содержание CO2 в колошниковом газе, %
        public double C24 { get; set; } //Содержание CO в колошниковом газе, %
        public double C25 { get; set; } //Содержание H2 в колошниковом газе, %

        public double C28 { get; set; } //Суточная производительность печи по чугуну (Р), т/сут
        public double C29 { get; set; } //Диаметр горна (dг), м
        public double C30 { get; set; } //Диаметр распара (D), м
        public double C31 { get; set; } //Диаметр колошника (dк), м
        public double C32 { get; set; } //Высота заплечиков (hЗ), м
        public double C33 { get; set; } //Высота распара (hР), м
        public double C34 { get; set; } //Высоты шахты (hШ), м
        public double C35 { get; set; } //Высоты колошника (hК), м
        public double C36 { get; set; } //Уровень засыпи (hУЗ), м
        public double C37 { get; set; } //Температура горячего дутья (tД), °С
        public double C38 { get; set; } //Теплоёмкость кокса (СК), кДж/(кг*К)
        public double C39 { get; set; } //Температура кокса, пришедшего к фурмам (tC), °С
        public double C40 { get; set; } //Теплота неполного горения С кокса  (Wc), кДж/кг
        public double C41 { get; set; } //Теплота неполного горения природного газа (Ws), кДж/м3
        public double C42 { get; set; } //Избыточное давление горячего дутья (PД), ати
        public double C43 { get; set; } //Избыточное давление колошникового газа (PКГ), ати
        public double C44 { get; set; } //Удельный выход шлака (UШЛ), кг/т чугуна
        public double C45 { get; set; } //Плотность шлака (PШЛ), кг/м3

        public double C47 { get; set; } //Минутный расход дутья (VКИПОБ), м3/мин

        public double C49 { get; set; } //Удельный расход железорудного материала (GЖРМ), т/т чугуна
        public double C52 { get; set; } //Удельный расход: известняка, кг/т чугуна

        public double C56 { get; set; } //Температура колошникового газа (tКГ), °С
        public double C57 { get; set; } //Потери давления горячего дутья по тракту подачи (m), доли ед.
        public double C58 { get; set; } //Нижний перепад давления (ΔPНизм), атм
        public double C59 { get; set; } //Верхний перепад давления (tΔPВизм), атм
        public double C60 { get; set; } //Критическая степень уравновешивания шихты (СУКР), %
        public double C61 { get; set; } //Доля окатышей в железорудной части шихты
        public double C62 { get; set; } //Число работающих воздушных фурм (n), шт
        public double C63 { get; set; } //Диаметр воздушных фурм (dф), мм
        public double C64 { get; set; } //Длина фурмы (L), м
        public double C65 { get; set; } //Потеря массы при прокаливании  ((ппмп)и), %
        public double C67 { get; set; } //Плотность агломерата, т/м3
        public double C68 { get; set; } //Плотность окатышей, т/м3
        public double C69 { get; set; } //Плотность кокса, т/м3

        //Гранулометрический состав кокса
        //Содержание фракции, % (по размеру фракции, мм)
        public double I40 { get; set; } //>80
        public double J40 { get; set; } //80-60
        public double K40 { get; set; } //60-40
        public double L40 { get; set; } //40-25
        public double M40 { get; set; } //<25

        //Гранулометрический состав и порозность агломерата
        //Содержание фракции, % (по размеру фракции, мм)
        public double I45 { get; set; } //>25
        public double J45 { get; set; } //25-10
        public double K45 { get; set; } //10-5
        public double L45 { get; set; } //<5

        //Гранулометрический состав окатышей
        //Содержание фракции, % (по размеру фракции, мм)
        public double J50 { get; set; } //>10
        public double K50 { get; set; } //10-5
        public double L50 { get; set; } //<5

        //Сумма 100%

        // ПОЛУЧЕНИЕ ИСХОДНЫХ ЗНАЧЕНИЙ
        public static InputDataModel GetDefaultData()
        {
            return new InputDataModel
            {
                C4 = 0.294,
                C5 = 0.068,
                C6 = 0.798,
                C7 = 0.019,
                C8 = 0.7,
                C9 = 4.662,
                C10 = 0.067,
                C11 = 0.051,
                C12 = 418.4,
                C13 = 12.71,
                C14 = 0.46,
                C15 = 1.28,
                C18 = 26.9,
                C19 = 1.6,
                C20 = 96.5,
                C21 = 1,
                C22 = 2,
                C23 = 18.65,
                C24 = 24.22,
                C25 = 8.9,
                C28 = 3404.968,
                C29 = 8.4,
                C30 = 9.5,
                C31 = 6.6,
                C32 = 2.888,
                C33 = 1.976,
                C34 = 15.365,
                C35 = 1.855,
                C36 = 1.75,
                C37 = 1177,
                C38 = 1.65,
                C39 = 1500,
                C40 = 9800,
                C41 = 1590,
                C42 = 2.46,
                C43 = 1.28,
                C44 = 322.37,
                C45 = 2400,
                C47 = 2716.67,
                C49 = 1.6107,
                C52 = 0,
                C56 = 287,
                C57 = 0.1,
                C58 = 0.826,
                C59 = 0.354,
                C60 = 57,
                C61 = 0.3576,
                C62 = 17,
                C63 = 140,
                C64 = 0.45,
                C65 = 0,
                C67 = 2.9,
                C68 = 3.3,
                C69 = 0.87,
                I40 = 20.24,
                J40 = 39.18,
                K40 = 33.62,
                L40 = 5.12,
                M40 = 1.6,
                I45 = 41.59,
                J45 = 30.14,
                K45 = 22.26,
                L45 = 5.71,
                J50 = 86.87,
                K50 = 9.3,
                L50 = 3.83

            };
        }
    }
}
