### Контакт: https://twitter.com/SanSYS

_Все вопросы относительно donet/C# из разряда не самых стандартных, для самого непростого собеса, или для теста, в рамках какого-либо конкурса по фану_

_А совсем собесные вопросы сюда кидать смысла нет, имхо (типа - поколения памяти, классы/страктуры и пр.)_

- Чем отличается абстрактный класс от интерфейса в условиях C#8? (http://bit.ly/2LNs9cG)
- Может ли быть приватным конструктор абстрактного класса? Аргументируй
- Вопрос конкретно на засыпку: что будет в консоли? ) (http://bit.ly/2OmRKuQ)
```csharp
int? superTax = null;
int? init = null;

var t = (
  (superTax ??= init --??+- 12) is var nil, 
    nil --> 0
) switch {
    (true, Item2: false == true) => 0 <= nil,
    (_,_) => true
};

Console.WriteLine(t);
```
- Что такое HttpClientFactory? (см. тест по WebClient/HttpClient/HttpClientFactory http://bit.ly/3388NFa)
- Будет ли объект `new byte[84990]` размещён в LOH?
- Сколько раз можно вызвать конструктор объекта? (http://bit.ly/31Vbwl2)
- Можно ли создать объект без вызова конструктора? (http://bit.ly/31Vbwl2)
- Может ли `new Class()` вернуть null? (http://bit.ly/334A7nF)
- Будет ли этот код работать быстрее, если массив data будет отсортирован? (http://bit.ly/2OpvAs0)
```csharp
int sum = 0;

foreach (var item in data)
{
  if (item > 128)
    sum += item;
}

return sum;
```
- Когда это точно не работает? )
- Вы знаете, что приложению на старте требуется много потоков, ваши действия? (http://bit.ly/2pPR9aR)
- Как на C# определить класс, запускающий приложение, где имя приложения будет именем метода, без создания такого метода? (http://bit.ly/2OnSLmr)
```csharp
run.calc();
run.notepad();
```
- Что нужно сделать, чтобы вывод в консоль не приводил в локу треда? (http://bit.ly/35ctIZB)
- Как ограничить размер управляемой кучи? (http://bit.ly/2OknvEV)
- Что будет в консоли? (http://bit.ly/2MlE5S0)
```csharp
for (byte i = byte.MaxValue; i >= 0; i--)
    Console.WriteLine(i);
```
- Что не так с этим методом контроллера?
```csharp
[HttpGet("test")]
public async Task<string> Test()
{
    using (var wc = new HttpClient())
    {
        return await wc.GetStringAsync("https://github.com/dotnetmore/job-interview-competition");
    }
}
```
- Сделай на async/await deadlock (https://twitter.com/SanSYS/status/1134445700689932288). Можно просто словами, на примере http-запроса )
