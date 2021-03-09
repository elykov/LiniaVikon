Программа работает теперь с файлом, который называется new_json.json.
Все предыдущие операции проводить с ним.





(function getValueObject() {
let sa = $('form').serializeArray()
let res = {}
sa.forEach(el => res[el.name] = el.value);
return res
})().order

После необходимо залить на сайт с помощью этого скрипта
            
let data = ``; // Сюда данные из нового файла

document.cookie="PHPSESSID="; // Взять сессию возле командной строки

let jsons = data.split('\n')

setTimeout(() => {
    console.log("Program finished");
}, (jsons.length + 1) * 1000);

jsons.forEach((el, i) => { 
    setTimeout(() => {
        console.log(el);
        $.post('https://liniavikon.com.ua/admin.php?module=catalog&task=addItem', JSON.parse(el));
    }, i * 1000);
})


