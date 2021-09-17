/* Прокрутка до исходных данных */
$("#runToCalculation").click(function () {
    $([document.documentElement, document.body]).animate({
        scrollTop: $("#calculation").offset().top - 60
    }, 500);
});

/* Измение шапки при прокручивании страницы */
/*var $document = $(document),
    $element = $("#header"),
    className = "scroll";

$document.scroll(function () {
    $element.toggleClass(className, $document.scrollTop() >= 20);
});*/

document.getElementById("header").classList.add("scroll");

/* Валидация данных */
window.onload = function () {
    if (document.querySelector(".form__input")) {
        let inputs = document.querySelectorAll(".form__input");
        inputs.forEach(element => replaceToCorrectValue(element));
    }
};

function replaceToCorrectValue(input) {
    let inputButton = document.getElementById("submitButton");
    input.oninput = function () {
        //this.value = this.value.replace(/[^0-9\.,]/g, '');
        var x = this.value.length - 1;
        if (this.value[x] == ",") {
            inputButton.disabled = true;
            input.parentElement.classList.add("same-error");
            inputButton.classList.add("lock"); // ref ПЛОХО БЛОКИРУЕТСЯ КНОПКА, ИСПРАВИТЬ
        } else {
            inputButton.disabled = false;
            input.parentElement.classList.remove("same-error");
            inputButton.classList.remove("lock"); // ref
        }
        console.log(input);
        if (this.value == "") {
            inputButton.disabled = true;
            inputButton.classList.add("lock"); // ref
            input.parentElement.classList.add("error");
        } else if (this.value[x] != ",") {
            inputButton.disabled = false;
            inputButton.classList.remove("lock"); // ref
            input.parentElement.classList.remove("error");
        }
    };
}

if (document.getElementById("theoreticalTemperature")) {
    let theorTemperature = document.getElementById("theoreticalTemperature");
    let theorTemperatureValue = parseFloat(document.getElementById("theoreticalTemperature").innerText);
    if (theorTemperatureValue >= 1950 && theorTemperatureValue <= 2100) {
        theorTemperature.classList.remove("incorrect");
        theorTemperature.classList.add("correct");
    } else {
        theorTemperature.classList.remove("correct");
        theorTemperature.classList.add("incorrect");
    }
}

$("input, select, textarea").attr("autocomplete", "off");
$(".form__input").numeric({ decimal: ",", negative: false, scale: 3 });

/* Кнопка экспорта */
let buttonExport = document.querySelector(".result-table-export");
if (!document.querySelector(".result-main") && !document.querySelector(".comparison-main .result-table")) {
    buttonExport.remove();
}
let link = document.querySelector(".index-main__inputs");
if (document.querySelector(".inputs-main-content")) {
    link.remove();
}

function checkTemperature() {
    let inputsTemperature = document.querySelectorAll(".temperature-calculate-data");
    let isTemperature = document.getElementById("checkbox-temperature");
    let inputs = document.querySelectorAll(".calculate-data");

    if (isTemperature.checked) {
        inputs.forEach(element => element.classList.add("hidden"));
    } else {
        inputs.forEach(element => element.classList.remove("hidden"));
    }
}

/* Реализация экспорта таблицы с результатами в Excel */
var tableToExcel = (function () {
    var uri = 'data:application/vnd.ms-excel;base64,'
        , template = '<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--><meta http-equiv="content-type" content="text/plain; charset=UTF-8"/></head><body><table>{table}</table></body></html>'
        , base64 = function (s) { return window.btoa(unescape(encodeURIComponent(s))) }
        , format = function (s, c) {
            return s.replace(/{(\w+)}/g, function (m, p) { return c[p]; })
        }
        , downloadURI = function (uri, name) {
            var link = document.createElement("a");
            link.download = name;
            link.href = uri;
            link.click();
        }

    return function (table, name, fileName) {
        if (!table.nodeType) table = document.getElementById(table)
        var ctx = { worksheet: name || 'Worksheet', table: table.innerHTML }
        var resuri = uri + base64(format(template, ctx))
        downloadURI(resuri, fileName);
    }
})();

onclick = "tableToExcel('resultTable', 'Расчет индексов', 'Расчет_индексов_верха_и_низа_доменной_плавки.xls')"

buttonExport.onclick = function () {
    if (document.title == "Result - TeploPro") {
        tableToExcel('resultTable', 'Расчет индексов доменной плавки', 'Расчет_индексов_верха_и_низа_доменной_плавки.xls')
    } else if (document.title == "ResultTemperature - TeploPro") {
        tableToExcel('resultTable', 'Расчет теоретической температуры горения', 'Расчет_теор_температуры_горения_углерода_кокса.xls')
    } else if (document.title == "Comparison - TeploPro") {
        tableToExcel('resultTable', 'Сопоставление индексов', 'Сопоставление_индексов_верха_и_низа_доменной_плавки.xls')
    } else if (document.title == "ComparisonTemperature - TeploPro") {
        tableToExcel('resultTable', 'Сопоставление теор. температуры горения', 'Сопоставление_теор_температуры_горения_углерода_кокса.xls')
    }
};
