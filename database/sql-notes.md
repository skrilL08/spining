# SQL notes

> Учебная база: `PracticeDB`. Схема и тестовые данные создаются скриптом [`init.sql`](init.sql).
> Проверка выполнена локально на Microsoft SQL Server через `sqlcmd`.

## Task 01–20 — базовый и средний уровни

В переданном ТЗ для заданий 1–20 перечислены темы, но нет отдельных формулировок заданий. Чтобы не приписывать запросам неподтверждённые условия, эти разделы пока оставлены для заполнения по точным формулировкам.

## Task 21 — Хранимые процедуры

### Запрос

```sql
CREATE OR ALTER PROCEDURE dbo.sp_GetEmployeesByDepartment @DeptId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT EmployeeName, Salary
    FROM dbo.Employees
    WHERE DepartmentId = @DeptId
    ORDER BY EmployeeName;
END;
GO

CREATE OR ALTER PROCEDURE dbo.sp_GetAverageSalaryByDepartment
    @DeptId INT,
    @AverageSalary DECIMAL(10, 2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @AverageSalary = AVG(Salary)
    FROM dbo.Employees
    WHERE DepartmentId = @DeptId;
END;
GO

EXEC dbo.sp_GetEmployeesByDepartment @DeptId = 1;
DECLARE @AverageSalary DECIMAL(10, 2);
EXEC dbo.sp_GetAverageSalaryByDepartment @DeptId = 1, @AverageSalary = @AverageSalary OUTPUT;
SELECT @AverageSalary AS AverageSalary;
```

### Результат

Обе процедуры созданы. Для отдела 1 возвращены четыре сотрудника; средняя зарплата — 60000.00.

### Вывод

Процедура с `OUTPUT` позволяет вернуть скалярное значение вызывающему коду.

## Task 22 — Функции

### Запрос

```sql
CREATE OR ALTER FUNCTION dbo.fn_GetAnnualSalary(@MonthlySalary DECIMAL(10, 2))
RETURNS DECIMAL(12, 2)
AS
BEGIN
    RETURN @MonthlySalary * 12;
END;
GO

CREATE OR ALTER FUNCTION dbo.fn_GetEmployeesBySalaryRange
    (@Min DECIMAL(10, 2), @Max DECIMAL(10, 2))
RETURNS TABLE
AS
RETURN
(
    SELECT EmployeeId, EmployeeName, Salary
    FROM dbo.Employees
    WHERE Salary BETWEEN @Min AND @Max
);
GO

SELECT dbo.fn_GetAnnualSalary(50000) AS AnnualSalary;
SELECT * FROM dbo.fn_GetEmployeesBySalaryRange(50000, 65000) ORDER BY Salary;
```

### Результат

Годовая зарплата для 50000 равна 600000. В диапазон 50000–65000 включены Елена Волкова, Мария Кузнецова, Дмитрий Орлов, Ольга Смирнова и Анна Иванова.

### Вывод

Скалярная функция возвращает одно значение, табличная функция используется как источник строк в `FROM`.

## Task 23 — Оконные ранги

### Запрос

```sql
SELECT EmployeeName, DepartmentId, Salary,
       ROW_NUMBER() OVER (ORDER BY Salary DESC, EmployeeId) AS RowNumber,
       RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS SalaryRank,
       DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS DenseSalaryRank
FROM dbo.Employees
ORDER BY DepartmentId, Salary DESC;
```

### Результат

Возвращено 10 сотрудников с тремя видами ранга. В исходных данных нет одинаковых зарплат внутри отделов, поэтому `RANK` и `DENSE_RANK` пока совпадают.

### Вывод

При совпадающих значениях `RANK` пропускает следующий номер, а `DENSE_RANK` продолжает нумерацию подряд.

## Task 24 — Оконные агрегаты

### Запрос

```sql
SELECT EmployeeName, DepartmentId, Salary,
       SUM(Salary) OVER (PARTITION BY DepartmentId) AS DepartmentSalaryTotal,
       AVG(Salary) OVER (PARTITION BY DepartmentId) AS DepartmentSalaryAverage,
       Salary - AVG(Salary) OVER (PARTITION BY DepartmentId) AS DifferenceFromAverage
FROM dbo.Employees
ORDER BY DepartmentId, EmployeeId;
```

### Результат

Для каждого сотрудника показаны сумма и среднее по его отделу, а также отклонение его зарплаты от среднего.

### Вывод

Оконные агрегаты сохраняют строки сотрудников и добавляют рядом сводные значения отдела.

## Task 25 — CTE

### Запрос

```sql
WITH AvgSalary AS
(
    SELECT AVG(Salary) AS Value
    FROM dbo.Employees
)
SELECT EmployeeName, Salary
FROM dbo.Employees
WHERE Salary > (SELECT Value FROM AvgSalary)
ORDER BY Salary DESC;
GO

WITH DepartmentAverages AS
(
    SELECT DepartmentId, AVG(Salary) AS AverageSalary
    FROM dbo.Employees
    GROUP BY DepartmentId
)
SELECT TOP (3) DepartmentId, AverageSalary
FROM DepartmentAverages
ORDER BY AverageSalary DESC;
```

### Результат

Первая выборка содержит сотрудников с зарплатой выше средней по компании. Во второй показаны три отдела с самой высокой средней зарплатой.

### Вывод

CTE даёт имя промежуточному запросу и упрощает чтение выражений с несколькими шагами.

## Task 26 — CASE

### Запрос

```sql
SELECT EmployeeName, Salary,
       CASE WHEN Salary > 60000 THEN 'High'
            WHEN Salary >= 40000 THEN 'Medium'
            ELSE 'Low' END AS SalaryLevel,
       HireDate,
       CASE WHEN HireDate < '2020-01-01' THEN 'Senior'
            WHEN HireDate < '2023-01-01' THEN 'Mid'
            ELSE 'Junior' END AS Tenure
FROM dbo.Employees
ORDER BY EmployeeId;
```

### Результат

Для всех 10 сотрудников рассчитаны категории зарплаты и стажа.

### Вывод

Ветви `CASE` проверяются сверху вниз, поэтому границы диапазонов заданы без пересечений.

## Task 27 — Даты

### Запрос

```sql
SELECT EmployeeName,
       DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsSinceHire,
       DATEDIFF(MONTH, HireDate, GETDATE()) AS MonthsSinceHire,
       DATEADD(YEAR, 1, HireDate) AS FirstWorkAnniversary,
       FORMAT(HireDate, 'dd.MM.yyyy') AS FormattedHireDate
FROM dbo.Employees
ORDER BY EmployeeId;
```

### Результат

Возвращено 10 строк. Годы и месяцы рассчитаны относительно даты запуска запроса; дата найма отформатирована как `дд.ММ.гггг`.

### Вывод

`DATEDIFF` считает пересечения границ календарных периодов, поэтому для точного возраста в полных годах нужна дополнительная проверка дня и месяца.

## Task 28–30 — интеграция с C#

Эти задания выполняются из C#-приложения. Строка подключения должна читаться только из переменной окружения `PRACTICE_DB_CONNECTION`; результаты и вывод программы добавляются после настройки подключения.
