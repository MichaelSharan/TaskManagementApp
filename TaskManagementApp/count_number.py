import sys

def calculate_largest_odd_number(s):
    print(f"Функция вызвана с аргументом: {s}")  # Лог в консоль
    with open("log.txt", "a") as f:  # Лог в файл
        f.write(f"Полученные данные: {s}\n")

    # Сортируем цифры в порядке убывания
    digits = sorted(s, reverse=True)

    # Ищем первую нечётную цифру
    odd_digit = None
    for i in range(len(digits) - 1, -1, -1):
        if int(digits[i]) % 2 == 1:
            odd_digit = digits.pop(i)  # Убираем её из списка
            break

    # Если нечётной цифры нет, возвращаем "NO"
    if odd_digit is None:
        return "NO"

    # Собираем наибольшее число с нечётной цифрой в конце
    result = "".join(digits) + odd_digit

    # Убираем ведущие нули
    result = result.lstrip('0')

    # Если строка стала пустой (например, при вводе "0"), возвращаем "NO"
    return result if result else "NO"

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("NO")  # На случай, если аргумент не передан
    else:
        input_value = sys.argv[1]
        print(calculate_largest_odd_number(input_value))  # Вывод результата
