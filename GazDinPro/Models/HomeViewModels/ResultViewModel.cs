using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GazDinPro.Models.HomeViewModels
{
    public class ResultViewModel
    {
        public InputDataModel Input { get; set; }
        public ResultDataModel Result { get; set; }

        public ResultViewModel(InputDataModel input)
        {
            Input = input;
            Result = CalculateResult(input);
        }

        public ResultDataModel CalculateResult(InputDataModel input)
        {
            var result = new ResultDataModel();



            //лист исходных данных (расчётные переменные)
            #region inputlist
            //Содержание элементов:[] - в чугуне, () - в шлаке ([Fe]), %
            result.C3 = 100 - input.C4 - input.C5 - input.C6 - input.C7 - input.C9 - input.C10 - input.C11;

            //Содержание "нелетучего" углерода в коксе (Снел), %
            result.C16 = 100 - input.C13 - input.C14 - input.C15;

            //Степень прямого восстановления (rd)
            result.C17 = 0.54 - 0.00214 * input.C20;

            //Степень использования CO в печи (nCO)
            result.C26 = input.C23 / (input.C23 + input.C24);

            //Степень использования водорода в печи (nH2)
            result.C27 = 0.88 * result.C26 + 0.1;


            //Удельный расход: окатышей (GОК), т/т чугуна
            result.C51 = input.C49 * input.C61;



            //Удельный расход: агломерата (GАГЛ), т/т чугуна
            result.C50 = input.C49 - result.C51;

            //Гранулометрические составы
            //содержание фракции, сумма %
            result.N40 = input.I40 + input.J40 + input.K40 + input.L40 + input.M40;  //Кокса
            result.M45 = input.I45 + input.J45 + input.K45 + input.L45;  //Агломерата
            result.M50 = input.J50 + input.K50 + input.L50;  //Окатышей

            //Порозность, м3/м3
            result.H41 = 0.3 * Math.Pow(0.1 * (100 / (input.I40 / 80 + input.J40 / 70 + input.K40 / 50 + input.L40 / 32.5 + input.M40 / 12.5)), 0.252);  //Кокса
            result.H46 = 1 - 0.00543 * input.I45 - (0.0055 * input.J45 * (0.618 + 0.18 * (input.I45 / input.J45) - 0.015 * Math.Pow((input.I45 / input.J45), 2)) + 0.0055 * input.K45 * (0.9908 + 0.18 * (input.I45 / input.K45) - 0.015 * Math.Pow((input.I45 / input.K45), 2)) + 0.00656 * 8.1 * (1.3552 + 0.18 * (input.I45 / input.L45) - 0.015 * Math.Pow((input.I45 / input.L45), 2)));  //Агломерата
            result.H51 = 0.4 - 0.29 * 0.01 * input.L50;  //Окатышей 


            //Насыпные массы: агломерата (ГНАГЛ), т/м3
            result.C53 = (1 - result.H46) * input.C67;

            //Насыпные массы: окатышей (ГНОК), т/м3
            result.C54 = (1 - result.H51) * input.C68;

            //Насыпные массы: кокса (ГНК), т/м3
            result.C55 = (1 - result.H41) * input.C69;



            #endregion inputlist


            //лист база (расчётные переменные)
            #region baselist

            //Количество углерода (С), пришедшего в печь с коксом (Сприш), кг/т
            result.B_C3 = 0.01 * input.C12 * result.C16;
            //далее без описания
            result.B_C4 = result.C3 * 10 * result.C17 * 12 / 56 + 10 * input.C4 * 12 / 55 + 10 * input.C5 * 60 / 62 + 10 * input.C6 * 24 / 28 + 10 * input.C8 * 12 / 32;
            result.B_C5 = 10 * input.C9;
            result.B_C6 = 0.008 * result.B_C3;
            result.B_C7 = result.B_C3 - (result.B_C4 + result.B_C5 + result.B_C6);
            result.B_C8 = 0.9333 / (0.01 * input.C18 + 0.00063 * input.C19);
            result.B_C9 = 0.5 / (0.01 * input.C18 + 0.00063 * input.C19);
            result.B_C10 = result.B_C8 + input.C20 / result.B_C7 * result.B_C9;
            result.B_C11 = result.B_C10 * result.B_C7;
            result.B_C12 = 1.8667 + result.B_C8 * (1 - 0.01 * input.C18 + 0.00124 * input.C19);
            result.B_C13 = 3 + result.B_C9 * (1 - 0.01 * input.C18 + 0.00124 * input.C19);
            result.B_C14 = result.B_C12 + input.C20 / result.B_C7 * result.B_C13;
            result.B_C15 = result.B_C7 * result.B_C14;
            result.B_C16 = 1.8667 + input.C20 / result.B_C7 * input.C21;
            result.B_C17 = (0.9333 + 0.5 * input.C20 / result.B_C7 * 1) / (0.01 * input.C18 + 0.00124 * input.C19) * 0.00124 * input.C19 + input.C20 / result.B_C7 * input.C22;
            result.B_C18 = (0.9333 + 0.5 * input.C20 / result.B_C7 * 1) / (0.01 * input.C18 + 0.00124 * input.C19) * (1 - 0.01 * input.C18);
            result.B_C19 = result.B_C16 / (result.B_C16 + result.B_C17 + result.B_C18);
            result.B_C20 = result.B_C17 / (result.B_C16 + result.B_C17 + result.B_C18);
            result.B_C21 = 1 - (result.B_C19 + result.B_C20);
            result.B_C22 = 10 * 22.4 * (result.C3 * result.C17 / 56 + input.C4 / 55 + 2 * input.C6 / 28 + input.C8 / 32);
            result.B_C23 = result.B_C16 * result.B_C7 + result.B_C22;
            result.B_C24 = result.B_C17 * result.B_C7 * (1 - result.C27);
            result.B_C25 = result.B_C18 * result.B_C7;
            result.B_C26 = result.B_C23 + result.B_C24 + result.B_C25;
            result.B_C27 = result.B_C23 / result.B_C26;
            result.B_C28 = result.B_C24 / result.B_C26;
            result.B_C29 = result.B_C25 / result.B_C26;
            result.B_C30 = 28 / 22.4 * result.B_C29 + 28 / 22.4 * result.B_C27 + 2 / 22.4 * result.B_C28;
            result.B_C31 = result.B_C26 * input.C28 / (24 * 60 * 60);
            result.B_C32 = (input.C29 + input.C30) / 2;

            //Среднее значение поперечного сечения нижней зоны печи (S'Н), м2
            result.C48 = 3.14 * Math.Pow(result.B_C32, 2) / 4;


            result.B_C33 = 4 * result.B_C31 / (3.14 * result.B_C32 * result.B_C32);
            result.B_C34 = 1.2897 + 0.000121 * input.C37;
            result.B_C35 = 1.456 + 0.000282 * input.C37;
            result.B_C36 = result.B_C34 * input.C37 - 0.00124 * input.C19 * (10800 - result.B_C35 * input.C37);
            result.B_C37 = input.C38 * input.C39;

            result.B_C38 = input.C20 / result.B_C7;
            result.B_C39 = (input.C40 + result.B_C8 * result.B_C36 + result.B_C37 + result.B_C38 * (input.C41 + result.B_C9 * result.B_C36)) / (result.B_C12 + result.B_C38 * result.B_C13);
            result.B_C40 = 165 + 0.6113 * result.B_C39;
            result.B_C41 = (result.B_C40 + 1000) / 2;
            result.B_C42 = result.B_C11 * input.C28 / 1440;
            result.B_C43 = ((result.B_C42 + (input.C20 * input.C28 / 1440)) * (input.C37 + 273) * 77.73) / (input.C62 * input.C63 * input.C63 * (1 + input.C42));
            result.B_C44 = -9.1 * Math.Pow(10, -5) + input.C37 * 2.65 * Math.Pow(10, -7);
            result.B_C45 = 0.001 * result.B_C43 * input.C63 / result.B_C44;
            result.B_C46 = 0.0032 + (0.221 / Math.Pow(result.B_C45, 0.237));

            result.B_E46 = result.B_C46 + result.B_C46 * 0.1;

            result.B_C47 = input.C62 * (result.B_E46 * input.C64 / (0.001 * input.C63)) * result.B_C30 * (result.B_C43 * result.B_C43 / 2) * ((input.C37 + 273) / 273) * (1 / (1 + input.C42));
            result.B_C48 = input.C58;
            result.B_C49 = result.B_C48 / (result.B_C48 + input.C59);
            result.B_C50 = input.C42 - result.B_C48;
            result.B_C51 = ((input.C42 + 1) + (result.B_C50 + 1)) / 2;
            result.B_C52 = input.C32 + input.C33 + 0.5;
            result.B_C53 = 100 / (input.I40 / 80 + input.J40 / 70 + input.K40 / 50 + input.L40 / 32.5 + input.M40 / 12.5);
            result.B_C54 = 0.3 * Math.Pow(0.1 * result.B_C53, 0.252);
            result.B_C55 = input.C44 / input.C45;
            result.B_C56 = input.C12 / result.C55;
            result.B_C57 = result.B_C56 * result.B_C54;
            result.B_C58 = result.B_C57 - result.B_C55;
            result.B_C59 = result.B_C58 / result.B_C56;
            result.B_C60 = result.B_C48 / ((Math.Pow(result.B_C33, 2) / 2) * (result.B_C30 * result.B_C52 / result.B_C53) * ((1 - result.B_C59) / Math.Pow(result.B_C59, 3)) * (result.B_C41 + 273) / 273 * (1 / result.B_C51));
            result.B_C61 = input.C47 / (result.B_C33 * result.C48);
            result.B_C62 = result.B_C60 * result.B_C52 / result.B_C53 * result.B_C30 / 2 * Math.Pow(1 / (result.C48 * result.B_C61), 2) * (1 - result.B_C59) / Math.Pow(result.B_C59, 3) * (result.B_C41 + 273) / 273 * 1 / result.B_C51;
            result.B_C63 = 0.01 * result.B_C52 * 22.4 / 44 * input.C65;
            result.B_C64 = result.B_C23 * result.C26;
            result.B_C65 = result.B_C64 + result.B_C63;
            result.B_C66 = result.B_C23 - result.B_C64;
            result.B_C67 = result.B_C6 * 22.4 / 12;
            result.B_C68 = result.B_C25;
            result.B_C69 = result.B_C24;
            result.B_C70 = result.B_C65 + result.B_C66 + result.B_C68 + result.B_C69 + result.B_C67;
            result.B_C71 = result.B_C65 / result.B_C70;
            result.B_C72 = result.B_C66 / result.B_C70;
            result.B_C73 = result.B_C69 / result.B_C70;
            result.B_C74 = result.B_C67 / result.B_C70;
            result.B_C75 = 1 - (result.B_C71 + result.B_C72 + result.B_C73 + result.B_C74);
            result.B_C76 = 44 / 22.4 * result.B_C71 + 28 / 224 * result.B_C72 + 2 / 22.4 * result.B_C73 + 16 / 22.4 * result.B_C74 + 28 / 22.4 * result.B_C75;
            result.B_C77 = result.B_C70 * input.C28 / (24 * 60 * 60);
            result.B_C78 = (input.C31 + input.C30) / 2;
            result.B_C79 = 4 * result.B_C77 / (3.14 * result.B_C78 * result.B_C78);
            result.B_C80 = 100 / (input.I45 / 25 + input.J45 / 17.5 + input.K45 / 7.5 + input.L45 / 2.5);
            result.B_C81 = result.H46;
            result.B_C82 = result.H51;
            result.B_C83 = result.C50;
            result.B_C84 = result.C51;
            result.B_C85 = 0.001 * input.C12;
            result.B_C86 = result.B_C83 + result.B_C84 + result.B_C85;
            result.B_C87 = result.B_C83 / result.C53;
            result.B_C88 = result.B_C84 / result.C54;
            result.B_C89 = result.B_C85 / result.C55;
            result.B_C90 = result.B_C87 + result.B_C88 + result.B_C89;
            result.B_C91 = result.C53;
            result.B_C92 = result.C54;
            result.B_C93 = result.C55;
            result.B_C94 = result.B_C86 / result.B_C90;
            result.B_C95 = result.B_C87 / result.B_C90;
            result.B_C96 = result.B_C88 / result.B_C90;
            result.B_C97 = result.B_C89 / result.B_C90;
            result.B_C98 = (result.B_C87 * result.B_C81 + result.B_C54 * result.B_C89 + result.B_C88 * result.B_C82) / result.B_C90;
            result.B_C99 = 1 / (result.B_C95 / result.B_C80 + result.B_C97 / result.B_C53);
            result.B_C100 = input.C34 + input.C35 - input.C36;
            result.B_C101 = input.C59;
            result.B_C102 = (input.C56 + 1000) / 2;
            result.B_C103 = ((result.B_C50 + 1) + (input.C43 + 1)) / 2;
            result.B_C104 = result.B_C101 / (Math.Pow(result.B_C79, 2) / 2 * result.B_C76 * result.B_C100 / result.B_C99 * (1 - result.B_C98) / Math.Pow(result.B_C98, 3) * (result.B_C102 + 273) / 273 * 1 / result.B_C103);
            result.B_C105 = 4 * input.C47 / (result.B_C79 * 3.14 * result.B_C78 * result.B_C78);
            result.B_C106 = result.B_C104 * result.B_C100 / result.B_C99 * result.B_C76 / 2 * Math.Pow(4 / (3.14 * result.B_C78 * result.B_C78 * result.B_C105), 2) * (1 - result.B_C98) / Math.Pow(result.B_C98, 3) * (result.B_C102 + 273) / 273 * 1 / result.B_C103;

            //Определение степени уравновешивания шихты газовым потоком и расчёт критических параметров
            result.B_C110 = input.C32 + input.C33 + input.C34 + input.C35 - input.C36 + 0.5;

            result.B_G48 = input.C58;

            result.B_C111 = 1000 * ((result.B_G48 + input.C59)) / (result.B_C110 * result.B_C94);
            result.B_C112 = input.C60 * result.B_C110 * result.B_C94 / (1000 * (1 - input.C57));
            result.B_C113 = Math.Pow(result.B_C112 / (result.B_C62 + result.B_C106), 0.5);
            result.B_C114 = 4 * result.B_C15 * input.C28 / (3.14 * Math.Pow(input.C29, 2) * 24 * 60 * 60);
            result.B_C115 = result.B_C114 * (result.B_C40 + 273) / (273 * (1 + input.C42) * result.B_C54);
            result.B_C116 = 4 * result.B_C26 * input.C28 / (24 * 60 * 60 * 3.14 * input.C30 * input.C30);
            result.B_C117 = result.B_C116 * (1000 + 273) / (273 * (1 + result.B_C50) * result.B_C59);
            result.B_C118 = 4 * result.B_C70 * input.C28 / (24 * 60 * 60 * 3.14 * input.C31 * input.C31);
            result.B_C119 = result.B_C118 * (input.C56 + 273) / (273 * (1 + input.C43) * result.B_C98);

            // доп колонки в excel
            result.B_E46 = result.B_C46 + result.B_C46 * 0.1;
            result.B_G48 = input.C58;
            #endregion baselist





            return result;
        }
    }
}
